// container-registry.bicep - Defines the Azure Container Registry for docker images

@description('The environment name (dev, test, prod)')
param environmentName string

@description('The Azure region to deploy to')
param location string

@description('The name prefix for all resources')
param namePrefix string

// Variables
var containerRegistryName = '${replace(namePrefix, '-', '')}acr${environmentName}'

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

// Grant the backend and frontend apps access to pull from the registry
@description('Principal ID of the Web App for the backend')
param backendPrincipalId string = ''

@description('Principal ID of the Web App for the frontend')
param frontendPrincipalId string = ''

// Role assignment for backend if provided
resource backendAcrPullRole 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = if (!empty(backendPrincipalId)) {
  name: guid(containerRegistry.id, backendPrincipalId, 'acrpull')
  scope: containerRegistry
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d') // AcrPull role
    principalId: backendPrincipalId
    principalType: 'ServicePrincipal'
  }
}

// Role assignment for frontend if provided
resource frontendAcrPullRole 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = if (!empty(frontendPrincipalId)) {
  name: guid(containerRegistry.id, frontendPrincipalId, 'acrpull')
  scope: containerRegistry
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d') // AcrPull role
    principalId: frontendPrincipalId
    principalType: 'ServicePrincipal'
  }
}

// Outputs
output containerRegistryName string = containerRegistry.name
output containerRegistryLoginServer string = containerRegistry.properties.loginServer
output containerRegistryId string = containerRegistry.id
