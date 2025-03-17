# Solution summary

This solution is a Blazor project targeting .NET 8, consisting of a Blazor UI, a backend API, and a test project. Below are the major components, frameworks used, and main functionalities of the project:

## Major components

1. **BlazorUI**
   - **MainLayout.razor**: Defines the main layout of the application, including a sidebar with a navigation menu and a main content area
   - **NavMenu.razor**: Provides navigation links for the application
   - **App.razor**: Sets up the main application structure and includes necessary styles and scripts
   - **_Imports.razor**: Includes common namespaces and components used throughout the Blazor UI project
   - **Program.cs**: Configures services and the HTTP request pipeline for the Blazor application

2. **Backend**
   - **WeatherForecastController.cs**: Provides an API endpoint to retrieve weather forecast data
   - **Program.cs**: Configures services and the HTTP request pipeline for the backend API

3. **Tests**
   - **WeatherForecastControllerTests.cs**: Contains unit tests for the `WeatherForecastController` using xUnit and Moq
   - **Tests.csproj**: Configures the test project, including references to necessary packages and the backend project

## Frameworks used

- **Blazor**: For building interactive web UIs using C# instead of JavaScript
- **ASP.NET Core**: For building the backend API
- **Swagger**: For API documentation and testing
- **xUnit**: For unit testing
- **Moq**: For mocking dependencies in tests

## Main functionality

- **BlazorUI**:
  - Provides a user interface with a navigation menu and main content area
  - Uses Razor components to build interactive web pages
  - Configures services for Razor components and interactive server components

- **Backend**:
  - Provides a RESTful API for retrieving weather forecast data
  - Uses controllers to handle HTTP requests and return JSON responses
  - Configures Swagger for API documentation and testing

- **Tests**:
  - Contains unit tests to ensure the functionality of the backend API
  - Uses xUnit for writing and running tests
  - Uses Moq for creating mock objects in tests

This solution demonstrates the integration of a Blazor front-end with an ASP.NET Core backend, providing a seamless and interactive user experience, along with a robust testing setup.


# Exercises

Backlog Items (2 Hours, Group of 4-5)

## Phase 1: Foundations & UI Enhancement (Easy-Medium)

### Task 1: Implement Local Storage for Click Counter (Easy, 15-20 min)
**Description**: Modify the click counter component to persist the count using browser local storage. When the user revisits the page, the count should be restored.  
**Goal**: Introduction to client-side storage, basic Blazor component modification.  
**AI Leverage**: Copilot can help with local storage access in JavaScript interop, and with Blazor component state management.  
**Testing**: Unit tests are not mandatory for this task, but manual testing of the click counter is required.

### Task 2: Improve Weather Forecast UI (Medium, 20-25 min)
**Description**: Enhance the weather forecast page to display the data in a more user-friendly table format. Add visual cues (e.g., icons) to represent weather conditions.  
**Goal**: Improve UI/UX, work with data display in Blazor.  
**AI Leverage**: Copilot can generate table markup, CSS styling, and potentially suggest icons based on weather descriptions.  
**Testing**: Manual testing of the UI is sufficient.

### Task 3: Add a "Clear Counter" Button (Easy, 10-15 min)
**Description**: Add a button to the click counter page that resets the counter to zero and clears the local storage.  
**Goal**: Further manipulation of client side storage, and event handling.  
**AI Leverage**: Copilot can generate the button markup and the corresponding event handler code.  
**Testing**: Manual testing of the button functionality.

## Phase 2: Data Persistence & API Expansion (Medium-Hard)

### Task 4: Implement Weather Forecast Persistence (Medium-Hard, 30 min)
**Description**: Modify the backend API to store generated weather forecast data in an in-memory database (e.g., a List<WeatherForecast>). Update the API to retrieve the stored data instead of generating new random data on each request.  
**Goal**: Introduce basic data persistence, modify API endpoints.  
**AI Leverage**: Copilot can assist with creating the in-memory data store, modifying the API controller, and generating basic CRUD operations.  
**Testing**: Write xUnit tests for the updated WeatherForecastController to verify data storage and retrieval.

### Task 5: Add a "Historical Weather" Page (Medium-Hard, 25 min)
**Description**: Create a new Blazor page that displays the historical weather forecast data retrieved from the backend API.  
**Goal**: Consume data from the API in Blazor, display historical data.  
**AI Leverage**: Copilot can help with creating the Blazor page, fetching data from the API, and displaying it in a table.  
**Testing**: Manual testing of the new page and API endpoint.

## Phase 3: Data Analysis & Advanced Testing (Hard)

### Task 6: Analyze Weather Data (Hard, 30 min)
**Description**: Add an API endpoint that performs basic data analysis on the stored weather forecast data. For example, calculate the average temperature, find the hottest/coldest days, or count the number of sunny days. Create a Blazor page that displays the results of the analysis.  
**Goal**: Introduce data analysis, more complex API development.  
**AI Leverage**: Copilot can assist with writing LINQ queries for data analysis, creating the new API endpoint, and displaying the results in Blazor.  
**Testing**: Write xUnit tests for the new API endpoint, including tests for different data scenarios. Copilot can generate test data and assertions.

### Task 7: Generate Mock Weather Data for Testing (Hard, 10 min)
**Description**: Utilize Github copilot to generate a large set of mock weather data, that will be used for testing the data analysis endpoint.  
**Goal**: Use AI to generate test data.  
**AI Leverage**: Copilot can generate large amount of data based on the existing weather forecast class.  
**Testing**: Verify the generated data.

## Tips for the Group Exercise

- **Divide and Conquer**: Split the tasks among the group members based on their strengths and interests.
- **Communication**: Encourage regular communication and collaboration.
- **Version Control**: Emphasize the importance of using Git and GitHub for version control.
- **AI as a Tool**: Remind participants that Copilot is a tool to assist, not replace, their coding skills.
- **Time Management**: Keep track of time and adjust the pace as needed.
- **Testing**: Emphasize the importance of testing throughout the development process.
- **Data analysis**: Encourage the participants to try out different data analysis methods.