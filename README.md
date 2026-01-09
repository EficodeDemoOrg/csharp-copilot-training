# Blazor Weather Application - GitHub Copilot Training Exercise

## What is This Project?

This is a training exercise repository designed to help developers learn GitHub Copilot through hands-on practice. The project consists of a simple weather forecasting application built with:

- **Backend**: ASP.NET Core 8 Web API
  - Located in the `Backend/` directory
  - Provides RESTful endpoints for weather data
  - Uses the WeatherForecast model to serve data

- **Frontend**: Blazor Server Application
  - Located in the `BlazorUI/` directory
  - Interactive server-side Blazor components
  - Displays weather forecasts in a table format

- **Tests**: xUnit Test Project
  - Located in the `Tests/` directory
  - Ready for unit and integration test implementation

### Project Structure

```
csharp-copilot-training/
├── Backend/                    # ASP.NET Core Web API
│   ├── Controllers/
│   │   └── WeatherForecastController.cs
│   ├── WeatherForecast.cs     # Data model
│   └── Program.cs             # Application entry point
├── BlazorUI/                  # Blazor Server UI
│   ├── Components/
│   │   ├── Layout/
│   │   └── Pages/
│   │       ├── Counter.razor
│   │       ├── Home.razor
│   │       └── Weather.razor
│   └── Program.cs
├── Tests/                     # Test project
│   └── Tests.csproj
├── .github/
│   └── copilot-instructions.md  # Custom Copilot instructions
└── CopilotExercises.sln      # Visual Studio solution
```

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 8 SDK** or later
  - Download from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
  - Verify installation: `dotnet --version`

- **Visual Studio 2022** (17.8 or later) or **Visual Studio Code**
  - Visual Studio: [https://visualstudio.microsoft.com/](https://visualstudio.microsoft.com/)
  - VS Code: [https://code.visualstudio.com/](https://code.visualstudio.com/)
    - Install C# Dev Kit extension for VS Code

- **GitHub Copilot**
  - Active GitHub Copilot subscription
  - Copilot extension installed in your IDE

- **Git**
  - For version control and repository management

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/EficodeDemoOrg/csharp-copilot-training.git
cd csharp-copilot-training
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Build the Solution

```bash
dotnet build
```

### 4. Run the Backend API

```bash
cd Backend
dotnet run
```

The API will start on `http://localhost:5000` (or the port displayed in the console).

### 5. Run the Blazor UI (in a separate terminal)

```bash
cd BlazorUI
dotnet run
```

The Blazor application will start on `http://localhost:5001` (or the port displayed in the console).

### 6. Access the Application

- Open your browser and navigate to the Blazor UI URL (typically `https://localhost:7XXX`)
- Navigate to the "Weather" page to see the weather forecast data

### 7. Run Tests

```bash
dotnet test
```

## Verification Steps

To verify your setup is correct:

1. **Check Backend API**:
   - Navigate to `http://localhost:5000/swagger` (if Swagger is enabled)
   - Or test the endpoint: `http://localhost:5000/weatherforecast`

2. **Check Blazor UI**:
   - Open the application in your browser
   - Navigate to Counter page - should increment when clicked
   - Navigate to Weather page - should display weather forecast data

3. **Check GitHub Copilot**:
   - Open any `.cs` file in your IDE
   - Start typing a comment and verify Copilot suggestions appear
   - Open Copilot Chat and ask: `@workspace Explain this project`

## Troubleshooting

### Port Already in Use

If you encounter port conflicts:

```bash
# Backend: Edit Backend/Properties/launchSettings.json
# BlazorUI: Edit BlazorUI/Properties/launchSettings.json
# Change the "applicationUrl" to different ports
```

### Build Errors

```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

### Copilot Not Working

- Verify your GitHub Copilot subscription is active
- Check that the Copilot extension is enabled in your IDE
- Restart your IDE
- Check the `.github/copilot-instructions.md` file is present

## Learning Path

This repository includes comprehensive training exercises:

1. **For VS Code Users**: Follow [`github_copilot_exercises.md`](github_copilot_exercises.md)
2. **For Visual Studio Users**: Follow [`VS_github_copilot_exercises.md`](VS_github_copilot_exercises.md)
3. **Advanced Agent Workflows**: Follow [`github_copilot_exercises_2.md`](github_copilot_exercises_2.md) or [`VS_github_copilot_exercises_2.md`](VS_github_copilot_exercises_2.md)

## Training Approach

This exercise is designed to help you become familiar with GitHub Copilot by guiding you through the process of refactoring and enhancing the Blazor weather application. The application will be restructured into separate front-end and back-end projects, integrated with persistent data storage, and extended to include weather data visualizations. It will also be containerized using Docker. Finally, Infrastructure as Code (IaC) and CI/CD pipelines will be implemented to support deployment and automation.

Although all tasks can be completed without assistive tools, you are strongly encouraged to rely on Copilot as much as possible before resorting to a manual approach. By the end of this exercise, you should have a clearer understanding of Copilot's capabilities, limitations, and most effective use cases.

### Experiment with all Copilot modes to understand their differences:
* Ask mode
* Edits mode
* Agent mode

### Remember to utilize all features available in Visual Studio and VS Code:
* Custom instructions (`.github/copilot-instructions.md`)
* Inline suggestions
* Chat participants (`@workspace`, `@editor`)
* References and code navigation
* Slash commands (`/explain`, `/fix`, `/tests`, etc.)
* Next edit suggestions
* Vision (if applicable)
* Multi-model support (if enabled)

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
* "List all frontend logic that could be refactored to the backend"
* "Suggest a plan to refactor a frontend functionality for [feature/functionality name] to move business logic to the backend and visualize data"

## End Goal: Refactor and Implement New Features

The objective is to refactor and add features to the existing application. Use Copilot to assist with each of the 
following requirements:

1. **All code is written using TDD**
    * Write tests for all backend code *before* implementing the actual code
    * Follow Test-Driven Development (TDD) principles
    * Generate test data with Copilot, if required
    * *Optional:* Test the frontend using a testing framework like bUnit

2. **Keep Front-end Code and Business Logic separate**
    * Move all existing business logic from the frontend project to the backend project

3. **The application must use a persistent storage**
    * The initial solution contains random data and data that is not stored anywhere
    * Create a persistent data storage solution for all data displayed and manipulated in the application
    * Examples: in-memory database, a file, or a proper database
      * Note: Entity Framework Core in-memory database is included in the whitelisted packages
    * Use Copilot to generate seed data for your datasource, e.g. an SQL script
    * Import the seed data into your data store

4. **Weather Data must be visualized**
    *  Using [Radzen Blazor components](https://blazor.radzen.com), visualize the weather data
    *  Create a line chart that plots the numeric data of the table

5.  **The application is Dockerized**
    * Create Dockerfiles for both the frontend and backend projects, and document them in the readme
    * If you have Docker installed, build and run the application using Docker

6.  **The application is deployed using Infrastructure as Code**
    * Create infrastructure-as-code definitions to run the application on a cloud provider or other infrastructure
    * Examples: Use e.g. Terraform, Bicep, or AWS CloudFormation

7. **The application must have CI/CD pipelines**
    * Create CI/CD definition files for your preferred platform (e.g., GitHub Actions, Azure DevOps Pipelines, Jenkins)
    * The CI/CD pipeline should automate the build and test process
    * *Optional:* Configure the pipeline to automate deployment

## Additional Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [GitHub Copilot Documentation](https://docs.github.com/copilot)
- [.NET CLI Reference](https://learn.microsoft.com/dotnet/core/tools/)

## Support

If you encounter issues:
1. Check the Troubleshooting section above
2. Review the training exercise documentation
3. Use GitHub Copilot to help diagnose issues: `@workspace Why am I getting this error: [paste error]`

## License

This project is for educational purposes as part of GitHub Copilot training.


