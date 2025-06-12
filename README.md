# Summary
This exercise is designed to help you become familiar with GitHub Copilot by guiding you through the process of refactoring and enhancing a Blazor application that displays weather data. The application will be restructured into separate front-end and back-end projects, integrated with persistent data storage, and extended to include weather data visualizations. It will also be containerized using Docker. Finally, Infrastructure as Code (IaC) and CI/CD pipelines will be implemented to support deployment and automation.

Although all tasks can be completed without assistive tools, you are strongly encouraged to rely on Copilot as much as possible before resorting to a manual approach. By the end of this exercise, you should have a clearer understanding of Copilot’s capabilities, limitations, and most effective use cases.

Experiment with all Copilot modes to understand their differences:
* Ask mode
* Edits mode
* Agent mode (currently in preview mode in Visual Studio)

Remember to utilzie all features available in Visual Studio:
* Custom instructions (.github/copilot-instructions.md)
* Inline suggestions
* Chat participants
* References
* Slash commands
* Next edit suggestions
* Vision (if applicable)

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


