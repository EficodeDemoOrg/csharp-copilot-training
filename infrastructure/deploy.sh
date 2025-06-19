#!/bin/bash
# deploy.sh - Script to deploy the Weather Visualization Application to Azure

# Set default values
RESOURCE_GROUP="weather-app-rg"
LOCATION="uksouth"
ENVIRONMENT="dev"
NAME_PREFIX="weather"

# Parse command line arguments
while [[ $# -gt 0 ]]; do
  case $1 in
    --resource-group|-g)
      RESOURCE_GROUP="$2"
      shift 2
      ;;
    --location|-l)
      LOCATION="$2"
      shift 2
      ;;
    --environment|-e)
      ENVIRONMENT="$2"
      shift 2
      ;;
    --name-prefix|-p)
      NAME_PREFIX="$2"
      shift 2
      ;;
    --help|-h)
      echo "Usage: $0 [options]"
      echo "Options:"
      echo "  --resource-group, -g   Resource group name (default: weather-app-rg)"
      echo "  --location, -l         Azure region (default: uksouth)"
      echo "  --environment, -e      Environment name (dev, test, prod) (default: dev)"
      echo "  --name-prefix, -p      Resource name prefix (default: weather)"
      echo "  --help, -h             Show this help message"
      exit 0
      ;;
    *)
      echo "Unknown option: $1"
      exit 1
      ;;
  esac
done

echo "Deploying Weather Visualization Application to Azure..."
echo "Resource Group: $RESOURCE_GROUP"
echo "Location: $LOCATION"
echo "Environment: $ENVIRONMENT"
echo "Name Prefix: $NAME_PREFIX"

# Create resource group if it doesn't exist
echo "Creating resource group if it doesn't exist..."
az group create --name "$RESOURCE_GROUP" --location "$LOCATION"

# Deploy the Bicep template
echo "Deploying Bicep template..."
az deployment group create \
  --resource-group "$RESOURCE_GROUP" \
  --template-file ./main.bicep \
  --parameters environmentName="$ENVIRONMENT" location="$LOCATION" namePrefix="$NAME_PREFIX"

# Get the deployment outputs
echo "Getting deployment outputs..."
BACKEND_URL=$(az deployment group show --resource-group "$RESOURCE_GROUP" --name main --query "properties.outputs.backendApiUrl.value" -o tsv)
FRONTEND_URL=$(az deployment group show --resource-group "$RESOURCE_GROUP" --name main --query "properties.outputs.frontendAppUrl.value" -o tsv)
ACR_LOGIN_SERVER=$(az deployment group show --resource-group "$RESOURCE_GROUP" --name main --query "properties.outputs.containerRegistryLoginServer.value" -o tsv)

echo "Deployment completed successfully!"
echo "Backend API URL: $BACKEND_URL"
echo "Frontend App URL: $FRONTEND_URL"
echo "Container Registry Login Server: $ACR_LOGIN_SERVER"

echo "Next steps:"
echo "1. Build and push your Docker images to $ACR_LOGIN_SERVER"
echo "2. Configure your applications to use the deployed resources"
echo "3. Access your application at $FRONTEND_URL"