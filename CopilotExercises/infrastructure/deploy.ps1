# deploy.ps1 - Script to deploy the Weather Visualization Application to Azure

param(
    [string]$ResourceGroup = "weather-app-rg",
    [string]$Location = "uksouth",
    [string]$Environment = "dev",
    [string]$NamePrefix = "weather"
)

Write-Host "Deploying Weather Visualization Application to Azure..."
Write-Host "Resource Group: $ResourceGroup"
Write-Host "Location: $Location"
Write-Host "Environment: $Environment"
Write-Host "Name Prefix: $NamePrefix"

# Create resource group if it doesn't exist
Write-Host "Creating resource group if it doesn't exist..."
az group create --name $ResourceGroup --location $Location

# Deploy the Bicep template
Write-Host "Deploying Bicep template..."
az deployment group create `
  --resource-group $ResourceGroup `
  --template-file ./main.bicep `
  --parameters environmentName=$Environment location=$Location namePrefix=$NamePrefix

# Get the deployment outputs
Write-Host "Getting deployment outputs..."
$BackendUrl = (az deployment group show --resource-group $ResourceGroup --name main --query "properties.outputs.backendApiUrl.value" -o tsv)
$FrontendUrl = (az deployment group show --resource-group $ResourceGroup --name main --query "properties.outputs.frontendAppUrl.value" -o tsv)
$AcrLoginServer = (az deployment group show --resource-group $ResourceGroup --name main --query "properties.outputs.containerRegistryLoginServer.value" -o tsv)

Write-Host "Deployment completed successfully!"
Write-Host "Backend API URL: $BackendUrl"
Write-Host "Frontend App URL: $FrontendUrl"
Write-Host "Container Registry Login Server: $AcrLoginServer"

Write-Host "Next steps:"
Write-Host "1. Build and push your Docker images to $AcrLoginServer"
Write-Host "2. Configure your applications to use the deployed resources"
Write-Host "3. Access your application at $FrontendUrl"