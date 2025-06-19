#!/bin/bash
# setup-github-secrets.sh - Script to set up GitHub secrets for CI/CD pipeline

# Check for required tools
if ! command -v az &> /dev/null; then
    echo "Azure CLI is not installed. Please install it first."
    exit 1
fi

if ! command -v gh &> /dev/null; then
    echo "GitHub CLI is not installed. Please install it first."
    exit 1
fi

# Default parameters
REPO_NAME=""
RESOURCE_GROUP="weather-app-rg"
ACR_NAME=""
SUBSCRIPTION_ID=""
SP_NAME="GitHubActionsServicePrincipal"

# Parse command line arguments
while [[ $# -gt 0 ]]; do
  case $1 in
    --repo|-r)
      REPO_NAME="$2"
      shift 2
      ;;
    --resource-group|-g)
      RESOURCE_GROUP="$2"
      shift 2
      ;;
    --acr-name|-a)
      ACR_NAME="$2"
      shift 2
      ;;
    --subscription|-s)
      SUBSCRIPTION_ID="$2"
      shift 2
      ;;
    --sp-name|-p)
      SP_NAME="$2"
      shift 2
      ;;
    --help|-h)
      echo "Usage: $0 [options]"
      echo "Options:"
      echo "  --repo, -r               GitHub repository name in format 'owner/repo'"
      echo "  --resource-group, -g     Azure resource group name (default: weather-app-rg)"
      echo "  --acr-name, -a           Azure Container Registry name"
      echo "  --subscription, -s       Azure Subscription ID"
      echo "  --sp-name, -p            Service Principal name (default: GitHubActionsServicePrincipal)"
      echo "  --help, -h               Show this help message"
      exit 0
      ;;
    *)
      echo "Unknown option: $1"
      exit 1
      ;;
  esac
done

# Validate required parameters
if [ -z "$REPO_NAME" ]; then
    echo "GitHub repository name is required. Use --repo or -r option."
    exit 1
fi

if [ -z "$SUBSCRIPTION_ID" ]; then
    echo "Azure Subscription ID is required. Use --subscription or -s option."
    exit 1
fi

# Check if user is logged in to GitHub
gh auth status || (echo "Please log in to GitHub using 'gh auth login'" && exit 1)

# Check if user is logged in to Azure
az account show > /dev/null 2>&1 || (echo "Please log in to Azure using 'az login'" && exit 1)

echo "Setting up GitHub secrets for CI/CD pipeline..."
echo "GitHub Repository: $REPO_NAME"
echo "Azure Resource Group: $RESOURCE_GROUP"
echo "Azure Subscription ID: $SUBSCRIPTION_ID"

# Create service principal and get credentials
echo "Creating Azure service principal for GitHub Actions..."
AZURE_CREDENTIALS=$(az ad sp create-for-rbac \
    --name "$SP_NAME" \
    --role contributor \
    --scopes /subscriptions/$SUBSCRIPTION_ID \
    --sdk-auth)

# Add Azure credentials as a GitHub secret
echo "Adding AZURE_CREDENTIALS to GitHub secrets..."
echo "$AZURE_CREDENTIALS" | gh secret set AZURE_CREDENTIALS --repo "$REPO_NAME"

# If ACR name is provided, set up ACR credentials
if [ -n "$ACR_NAME" ]; then
    echo "Getting credentials for Azure Container Registry $ACR_NAME..."
    
    # Ensure ACR exists
    if ! az acr show --name "$ACR_NAME" --resource-group "$RESOURCE_GROUP" &> /dev/null; then
        echo "ACR $ACR_NAME does not exist in resource group $RESOURCE_GROUP."
        echo "You may need to deploy the infrastructure first using the Bicep templates."
        echo "Skipping ACR credential setup."
    else
        # Get ACR credentials
        ACR_USERNAME=$(az acr credential show --name "$ACR_NAME" --resource-group "$RESOURCE_GROUP" --query "username" -o tsv)
        ACR_PASSWORD=$(az acr credential show --name "$ACR_NAME" --resource-group "$RESOURCE_GROUP" --query "passwords[0].value" -o tsv)

        # Add ACR credentials as GitHub secrets
        echo "Adding ACR_USERNAME to GitHub secrets..."
        echo "$ACR_USERNAME" | gh secret set ACR_USERNAME --repo "$REPO_NAME"
        
        echo "Adding ACR_PASSWORD to GitHub secrets..."
        echo "$ACR_PASSWORD" | gh secret set ACR_PASSWORD --repo "$REPO_NAME"
    fi
else
    echo "ACR name not provided. Skipping ACR credential setup."
    echo "To set up ACR credentials later, use the --acr-name option after deploying the infrastructure."
fi

echo "GitHub secrets setup completed successfully!"
echo "Your CI/CD pipeline is now configured with the necessary secrets."