// main.bicep - Central deployment file for Weather Visualization Application

// Parameters
@description('The environment name (dev, test, prod)')
param environmentName string = 'dev'

@description('The Azure region to deploy to')
param location string = resourceGroup().location

@description('The name prefix for all resources')
param namePrefix string = 'weather'

// Variables
var appServicePlanName = '${namePrefix}-asp-${environmentName}'
var backendApiName = '${namePrefix}-api-${environmentName}'
var frontendAppName = '${namePrefix}-web-${environmentName}'
var containerRegistryName = '${namePrefix}acr${environmentName}'
var applicationInsightsName = '${namePrefix}-ai-${environmentName}'
var logAnalyticsWorkspaceName = '${namePrefix}-law-${environmentName}'
var storageAccountName = '${replace(namePrefix, '-', '')}sa${environmentName}'

// Resources
resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: logAnalyticsWorkspaceName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
  }
}

resource applicationInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: applicationInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: logAnalyticsWorkspace.id
  }
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
  }
  properties: {
    accessTier: 'Hot'
    supportsHttpsTrafficOnly: true
    minimumTlsVersion: 'TLS1_2'
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: environmentName == 'prod' ? 'P1v2' : 'B1'
    tier: environmentName == 'prod' ? 'PremiumV2' : 'Basic'
  }
  properties: {
    reserved: true // Required for Linux
  }
}

resource backendApi 'Microsoft.Web/sites@2022-03-01' = {
  name: backendApiName
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|8.0'
      appSettings: [
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: applicationInsights.properties.ConnectionString
        }
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: environmentName == 'prod' ? 'Production' : 'Development'
        }
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(storageAccount.id, storageAccount.apiVersion).keys[0].value}'
        }
      ]
    }
  }
}

resource frontendApp 'Microsoft.Web/sites@2022-03-01' = {
  name: frontendAppName
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|8.0'
      appSettings: [
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: applicationInsights.properties.ConnectionString
        }
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: environmentName == 'prod' ? 'Production' : 'Development'
        }
        {
          name: 'BackendApi__BaseUrl'
          value: 'https://${backendApi.properties.defaultHostName}'
        }
      ]
    }
  }
}

// Container Registry for storing Docker images
resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-12-01-preview' = {
  name: containerRegistryName
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

// Outputs
output backendApiUrl string = 'https://${backendApi.properties.defaultHostName}'
output frontendAppUrl string = 'https://${frontendApp.properties.defaultHostName}'
output containerRegistryLoginServer string = containerRegistry.properties.loginServer

