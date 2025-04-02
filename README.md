# Summary

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


