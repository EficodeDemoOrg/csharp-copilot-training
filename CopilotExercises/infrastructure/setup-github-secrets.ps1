# setup-github-secrets.ps1 - Script to set up GitHub secrets for CI/CD pipeline

# Default parameters
param(
    [Parameter(Mandatory=$true)]
    [string]$RepoName,
    
    [Parameter(Mandatory=$true)]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$false)]
    [string]$ResourceGroup = "weather-app-rg",
    
    [Parameter(Mandatory=$false)]
    [string]$AcrName = "",
    
    [Parameter(Mandatory=$false)]
    [string]$ServicePrincipalName = "GitHubActionsServicePrincipal"
)

# Check for required tools
$azExists = Get-Command az -ErrorAction SilentlyContinue
if (-not $azExists) {
    Write-Error "Azure CLI is not installed. Please install it first."
    exit 1
}

$ghExists = Get-Command gh -ErrorAction SilentlyContinue
if (-not $ghExists) {
    Write-Error "GitHub CLI is not installed. Please install it first."
    exit 1
}

# Check if user is logged in to GitHub
try {
    gh auth status
}
catch {
    Write-Error "Please log in to GitHub using 'gh auth login'"
    exit 1
}

# Check if user is logged in to Azure
try {
    az account show | Out-Null
}
catch {
    Write-Error "Please log in to Azure using 'az login'"
    exit 1
}

Write-Host "Setting up GitHub secrets for CI/CD pipeline..."
Write-Host "GitHub Repository: $RepoName"
Write-Host "Azure Resource Group: $ResourceGroup"
Write-Host "Azure Subscription ID: $SubscriptionId"

# Create service principal and get credentials
Write-Host "Creating Azure service principal for GitHub Actions..."
$azureCredentials = az ad sp create-for-rbac `
    --name "$ServicePrincipalName" `
    --role contributor `
    --scopes /subscriptions/$SubscriptionId `
    --sdk-auth

# Add Azure credentials as a GitHub secret
Write-Host "Adding AZURE_CREDENTIALS to GitHub secrets..."
$azureCredentials | gh secret set AZURE_CREDENTIALS --repo "$RepoName"

# If ACR name is provided, set up ACR credentials
if ($AcrName) {
    Write-Host "Getting credentials for Azure Container Registry $AcrName..."
    
    # Ensure ACR exists
    try {
        az acr show --name "$AcrName" --resource-group "$ResourceGroup" | Out-Null
    }
    catch {
        Write-Warning "ACR $AcrName does not exist in resource group $ResourceGroup."
        Write-Warning "You may need to deploy the infrastructure first using the Bicep templates."
        Write-Warning "Skipping ACR credential setup."
        exit 0
    }
    
    # Get ACR credentials
    $acrUsername = az acr credential show --name "$AcrName" --resource-group "$ResourceGroup" --query "username" -o tsv
    $acrPassword = az acr credential show --name "$AcrName" --resource-group "$ResourceGroup" --query "passwords[0].value" -o tsv

    # Add ACR credentials as GitHub secrets
    Write-Host "Adding ACR_USERNAME to GitHub secrets..."
    $acrUsername | gh secret set ACR_USERNAME --repo "$RepoName"
    
    Write-Host "Adding ACR_PASSWORD to GitHub secrets..."
    $acrPassword | gh secret set ACR_PASSWORD --repo "$RepoName"
}
else {
    Write-Host "ACR name not provided. Skipping ACR credential setup."
    Write-Host "To set up ACR credentials later, run this script again with the -AcrName parameter after deploying the infrastructure."
}

Write-Host "GitHub secrets setup completed successfully!" -ForegroundColor Green
Write-Host "Your CI/CD pipeline is now configured with the necessary secrets." -ForegroundColor Green

# Usage examples
Write-Host "`nUsage Examples:" -ForegroundColor Cyan
Write-Host ".\setup-github-secrets.ps1 -RepoName 'username/repo' -SubscriptionId '00000000-0000-0000-0000-000000000000'" -ForegroundColor Cyan
Write-Host ".\setup-github-secrets.ps1 -RepoName 'username/repo' -SubscriptionId '00000000-0000-0000-0000-000000000000' -ResourceGroup 'custom-rg' -AcrName 'myacr'" -ForegroundColor Cyan