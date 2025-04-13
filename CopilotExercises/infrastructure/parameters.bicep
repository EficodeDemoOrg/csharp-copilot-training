// parameters.bicep - Configurable parameters for the Weather Visualization Application deployment

@description('The environment name (dev, test, prod)')
param environmentName string = 'dev'

@description('The Azure region to deploy to')
param location string = 'UK South'

@description('The name prefix for all resources')
param namePrefix string = 'weather'

// Export parameters for use in main.bicep
output environmentName string = environmentName
output location string = location
output namePrefix string = namePrefix
