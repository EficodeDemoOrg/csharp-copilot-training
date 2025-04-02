# Summary
This repository contains a Blazor-based weather visualization application. It is structured into three main projects, each serving a distinct purpose:

1. **Backend**: Handles server-side logic, including API endpoints and business logic for weather data.
2. **BlazorUI**: A Blazor-based frontend for visualizing weather data and interacting with the backend.
3. **Tests**: Contains unit tests to validate the functionality of the backend and potentially the frontend.

### Technologies and Tools
- **Languages**: C#, CSS, HTML
- **Frameworks**: ASP.NET Core (Backend), Blazor (Frontend)
- **Libraries**: xUnit (Testing), Moq (Mocking), Swagger (API Documentation), Bootstrap (Styling)

### Key Features
- Backend provides weather data through APIs.
- BlazorUI visualizes weather data and interacts with the backend.
- Tests ensure the correctness of backend logic and APIs.


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

6. **Move Business Logic to Backend**
   - Refactor the application to move all business logic from the frontend to the backend.

### Frontend (BlazorUI)
7. **Write Tests for Frontend API Integration**
   - Use a testing framework like `bUnit` to validate that the frontend correctly calls backend APIs and displays data.

8. **Refactor Frontend to Use Backend Logic**
   - Update the BlazorUI project to fetch data and rely on backend APIs for business logic.

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
15. **Write Tests for CI/CD Pipeline**
    - Validate that the CI/CD pipeline builds, tests, and deploys the application correctly.

16. **Implement CI/CD Pipeline**
    - Create CI/CD workflows using GitHub Actions or another platform.
    - Automate the build, test, and deployment process.

---

This task list ensures that each step is actionable and follows TDD principles. You can now add this to the end of your `README.md` file.


