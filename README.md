# CSharp Copilot Exercises - Solution Overview

This repository contains a comprehensive .NET 8 solution demonstrating a modern web application architecture with Blazor Server UI, ASP.NET Core Web API backend, and comprehensive testing. The solution showcases best practices for building scalable, containerised web applications.

## Solution Structure

The solution is organised into the following projects:

### 1. **Backend** (ASP.NET Core Web API)
- **Purpose**: RESTful API providing weather forecast data and counter functionality
- **Framework**: ASP.NET Core 8.0 with Web API template
- **Architecture**: Clean API design with controllers, services, and Entity Framework integration
- **Key Components**:
  - Controllers: `WeatherForecastController`, `CounterController`
  - Services: `CounterService` for business logic
  - Data: `WeatherForecastDbContext` with Entity Framework Core
  - Models: `WeatherForecast`, `Points` entities

### 2. **BlazorUI** (Blazor Server Application)
- **Purpose**: Interactive web frontend consuming the Backend API
- **Framework**: Blazor Server with .NET 8.0
- **Architecture**: Component-based UI with server-side rendering
- **Key Components**:
  - Pages: `Home.razor`, `Counter.razor`, `Weather.razor`
  - Layout: `MainLayout.razor`, `NavMenu.razor`
  - Project Reference: Depends on Backend project

### 3. **Tests** (Unit and Integration Testing)
- **Purpose**: Comprehensive testing suite for both Backend and BlazorUI
- **Framework**: xUnit with .NET 8.0
- **Testing Types**: Unit tests, integration tests, component tests
- **Key Test Files**:
  - `CounterControllerTests.cs` - API endpoint testing
  - `WeatherForecastControllerTests.cs` - Weather API testing
  - `WeatherPageTests.cs` - Blazor component testing
  - `DockerIntegrationTests.cs` - Container integration testing

### 4. **Infrastructure** (Azure Deployment)
- **Purpose**: Azure deployment configuration using Bicep templates
- **Components**: Container registry setup, infrastructure as code
- **Deployment Scripts**: PowerShell and Bash scripts for deployment automation

## Key Frameworks and Libraries

### Core Frameworks
- **.NET 8.0**: Latest LTS version providing performance improvements and new features
- **ASP.NET Core 8.0**: Web framework for building APIs and web applications
- **Blazor Server**: Interactive web UI framework using C# instead of JavaScript
- **Entity Framework Core 9.0.5**: Object-relational mapping (ORM) for data access

### Backend Dependencies
- **Microsoft.EntityFrameworkCore** (9.0.5): ORM for database operations
- **Microsoft.EntityFrameworkCore.InMemory** (9.0.5): In-memory database provider for development and testing
- **Swashbuckle.AspNetCore** (8.1.4): Swagger/OpenAPI documentation generation

### Frontend Dependencies
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson** (8.0.16): JSON serialisation support
- **Radzen.Blazor** (7.0.8): Rich component library for Blazor applications
- **Bootstrap**: CSS framework for responsive design (included via wwwroot)

### Testing Dependencies
- **xUnit** (2.9.3): Primary testing framework
- **xunit.runner.visualstudio** (3.1.1): Visual Studio test runner integration
- **Microsoft.NET.Test.Sdk** (17.14.1): .NET testing SDK
- **Moq** (4.20.72): Mocking framework for unit tests
- **bUnit** (1.39.5): Testing library for Blazor components
- **Testcontainers** (4.5.0): Integration testing with Docker containers
- **coverlet.collector** (6.0.4): Code coverage collection

## Architecture Highlights

### Database Strategy
- **In-Memory Database**: Uses Entity Framework Core InMemory provider for development and testing
- **Context**: `WeatherForecastDbContext` manages weather forecast and points data
- **Models**: Clean entity design with proper relationships

### Containerisation
- **Docker Support**: Both Backend and BlazorUI have Dockerfile configurations
- **Docker Compose**: Multi-container setup for local development
- **Production Ready**: Separate Dockerfiles for development and production scenarios

### Development Features
- **Hot Reload**: Blazor Server supports real-time UI updates during development
- **API Documentation**: Swagger UI for interactive API exploration
- **Cross-Origin Requests**: CORS configured for frontend-backend communication
- **SignalR**: Real-time communication capabilities (configured in BlazorUI)

### Build and Deployment
- **Solution File**: `CopilotExercises.sln` manages all projects
- **CI/CD Ready**: Infrastructure scripts for automated deployment
- **Azure Deployment**: Bicep templates for cloud infrastructure
- **Multi-Environment**: Development and production configurations

This solution demonstrates modern .NET development practices including clean architecture, comprehensive testing, containerisation, and cloud-ready deployment strategies.


# Excercise overview
This exercise aims to get you familiar with GitHub Copilot by using it to refactor and enhance a Blazor application that
visualizes weather data. While all tasks can be done without assistive tooling, you are strongly encouraged to use 
Copilot for everything first, and only then explore the "manual" way.  By the end of this exercise, you should have a 
better understanding of Copilot's strengths, limitations, and current best uses.

Experiment with all Copilot modes: inline suggestions, chat, and edits. If you have access to Copilot Agents 
(currently in Visual Studio Insider), feel free to experiment with that as well.

## Phase 1: Explore and document the solution

Use Copilot to explore and document the project. Specifically, use Copilot to:

* Identify the major components of the solution
* Determine the programming languages, frameworks, and libraries used, and how they relate to each other
* Generate instructions on how to run and test the application
* (If using Agent mode) Attempt to use Copilot to build and run the application

Example prompts:
* "List the programming languages used in this project"
* "Describe used frameworks and major libraries and their purpose"
* "Describe the purpose of the [Project name] project"

## Phase 2: Planning

Read the "End goal" section first. Then, use Copilot to break down the end goal into smaller, actionable steps. 
Document these steps in the end of this readme file.

Example prompts:
"List all frontend logic that could be refactored to the backend"
"Suggest a plan to refactor a frontend functionality for [feature/functionality name] to move business logic to the
backend and visualize data"

## End Goal: Refactor and Implement New Features

The objective is to refactor and add features to the existing application. Use Copilot to assist with each of the 
following:

1.  **Implement TDD for Backend:** Write tests for all backend code *before* implementing the actual code
    * Follow Test-Driven Development (TDD) principles
    * Generate test data with Copilot, if required
    * *Optional:* Test the frontend using a testing framework like bUnit

2.  **Move Business Logic:** Move all existing business logic from the frontend project to the backend.

3.  **Implement Persistent Storage:** If any functionality (outside of tests) uses random data or doesn't store data, 
move it to a persistent storage solution
    * Examples: in-memory database, a file, or a proper database
    * Generate initial data and import it into the storage

4.  **Visualize Weather Data:** Create visualizations (e.g., graphs) for the weather page data

5.  **Dockerize the Application:** Create Dockerfiles for both the frontend and backend projects, and document them in 
the readme
    * If you have Docker installed, build and run the application using Docker

6.  **Infrastructure as Code:** Create infrastructure-as-code definitions to run the application on a cloud provider or 
other infrastructure
    * Examples:  Use e.g. Terraform, Bicep, or AWS CloudFormation

7.  **Implement CI/CD:** Create CI/CD definition files for your preferred platform (e.g., GitHub Actions, Azure DevOps 
Pipelines, Jenkins)
    * The CI/CD pipeline should automate the build and test process
    * *Optional:* Configure the pipeline to automate deployment

## Task List

### Backend
1. **Write Tests for Weather Data Retrieval**
   - Create unit tests for the `WeatherForecastController` to validate the `Get` method.
   - Mock dependencies (e.g., `ILogger`) to isolate the controller logic.

2. **Implement Weather Data Retrieval**
   - Implement the `Get` method in `WeatherForecastController` to return weather data.

3. **Write Tests for Persistent Storage**
   - Write tests to validate saving and retrieving weather data from a persistent storage solution.
   - Mock the storage layer to ensure isolation.

4. **Implement Persistent Storage**
   - Add a persistent storage solution (e.g., in-memory database or file-based storage).
   - Implement logic to save and retrieve weather data.

5. **Write Tests for Business Logic**
   - Write unit tests for any business logic that needs to be moved from the frontend to the backend.
   - Ensure edge cases are covered.

### Frontend (BlazorUI)
7. **Write Tests for Frontend API Integration**
   - Use a testing framework like `bUnit` to validate that the frontend correctly calls backend APIs and displays data.

8. **Refactor Frontend to Use Backend Logic**
   - Update the BlazorUI project to fetch data and rely on backend APIs for business logic. Run tests afterwards.

9. **Write Tests for Weather Data Visualization**
   - Write tests to validate the rendering of weather data visualizations (e.g., graphs).

10. **Implement Weather Data Visualization**
    - Add visualizations (e.g., graphs) to the weather page using a library like Chart.js or similar.

### Dockerization
11. **Write Tests for Dockerized Environment**
    - Validate that the application runs correctly in a Dockerized environment (e.g., using integration tests).

12. **Create Dockerfiles**
    - Write Dockerfiles for both the backend and frontend projects.
    - Ensure the application can be built and run using Docker.

### Infrastructure as Code
13. **Write Tests for Infrastructure Deployment**
    - Validate infrastructure definitions using tools like `terraform validate` or `bicep build`.

14. **Create Infrastructure Definitions**
    - Write infrastructure-as-code definitions (e.g., Terraform, Bicep) to deploy the application to a cloud provider.

### CI/CD
15. **Implement CI/CD Pipeline**
    - Create CI/CD workflows using GitHub Actions or another platform.
    - Automate the build, test, and deployment process.

## CI/CD Pipeline Implementation

The project includes a comprehensive CI/CD pipeline implemented using GitHub Actions, which automates the build, test, and deployment process of the Weather Visualization application to Azure.

### Pipeline Overview

The CI/CD pipeline consists of three main stages:

1. **Build and Test**
   - Builds the .NET 8 solution
   - Runs all unit tests
   - Publishes the backend and frontend applications
   - Creates build artifacts

2. **Build and Push Docker Images**
   - Deploys Azure infrastructure using Bicep templates
   - Builds Docker images for both backend and frontend
   - Pushes images to Azure Container Registry (ACR)

3. **Deploy to Azure**
   - Updates the container apps to use the latest images
   - Outputs the deployment URLs

### Workflow Triggers

The pipeline is triggered by:
- Pushes to main/master branches
- Pull requests to main/master branches
- Manual workflow dispatch (with environment selection)

### Required Secrets

To use this CI/CD pipeline, the following secrets need to be configured in your GitHub repository:

- `AZURE_CREDENTIALS`: Azure service principal credentials for authentication
- `ACR_USERNAME`: Username for Azure Container Registry
- `ACR_PASSWORD`: Password for Azure Container Registry

### How to Set Up Azure Credentials

1. Create an Azure service principal:
   ```bash
   az ad sp create-for-rbac --name "GitHubActions" --role contributor --scopes /subscriptions/<subscription-id> --sdk-auth
   ```

2. Copy the JSON output and add it as a repository secret named `AZURE_CREDENTIALS`.

3. After deploying the infrastructure, retrieve and set the ACR credentials:
   ```bash
   az acr credential show --name <acr-name> --resource-group weather-app-rg
   ```

4. Add the username and password as secrets named `ACR_USERNAME` and `ACR_PASSWORD`.

### Environment Variables

The pipeline uses the following environment variables:
- `DOTNET_VERSION`: Set to '8.0.x' for .NET 8 LTS
- `RESOURCE_GROUP`: Azure resource group (default: weather-app-rg)
- `LOCATION`: Azure region (default: uksouth)
- `NAME_PREFIX`: Resource name prefix (default: weather)

These can be modified directly in the workflow file if needed.


