# GitHub Copilot Comprehensive Training Exercises

Welcome to your comprehensive GitHub Copilot training journey! These exercises are designed to progressively learn GitHub Copilot's features starting with foundational concepts and building up to advanced techniques through hands-on practice with our C# .NET project.

## Phase 1: Getting Started with Copilot Basics

### Exercise 1.1: Understanding Your Project with Chat Participants

**Welcome to the project!** Before diving into code generation, let's use GitHub Copilot to understand the project you'll be working with.

> **💡 IDE-Specific Participants:** 
> Note that `@vscode` and `@terminal` participants are exclusive to VS Code. Users of other IDEs should utilize `@workspace` and `@editor`. In JetBrains, `@workspace` is replaced by `@project`.


1. **@workspace Participant - Project Overview**
   - Press `Ctrl+Alt+I` (or `Cmd+Alt+I`) to open Copilot Chat and select "Ask" mode
   - Ask: `@workspace Tell me about this project?`
   - Try: `@workspace /explain Give me a comprehensive overview of this application`
   - Request: `@workspace What are the main features and components I should know about?`

2. **@workspace Participant - Code Structure**
   - Ask: `@workspace How are the files and folders organized in this project?`
   - Try: `@workspace Show me all the validation patterns used`
   - Request: `@workspace How are dependencies managed across the codebase?`

3. **@vscode Participant - Development Setup**
   - Ask: `@vscode What extensions would help with development in this project?`
   - Try: `@vscode How do I configure debugging for this project?`
   - Request: `@vscode How to set up tasks for this project?`

4. **@terminal Participant - Running the Project**
   - Ask: `@terminal What's the best way to start a development server for this project?`
   - Try: `@terminal Show me common dependency management commands for this project`
   - Request: `@terminal How do I run tests from command line?`

**Learning Goal:** Use different chat participants to get familiar with the project structure, setup, and workflow before starting development.

### Exercise 1.2: First Steps with Code Suggestions and Inline Chat

1. **Explore Auto-Suggestions**
   - Open `Backend/WeatherForecast.cs`
   - Position your cursor after the existing properties and press Enter
   - Type `// Method to check if forecast is from today` and press Enter
   - Watch Copilot suggest a method implementation
   - Try accepting the suggestion with `Tab`

2. **Practice with Comments**
   - Add this comment: `// Calculate the age of this forecast in days`
   - Let Copilot suggest the implementation
   - Notice how descriptive comments lead to better suggestions

3. **Experiment with Method Names**
   - Start typing `public string FormatTemperature` and see what Copilot suggests
   - Try `public bool IsHot` and observe the different suggestion

4. **Quick Edits with Inline Chat**
   - With `Backend/WeatherForecast.cs` still open, select any method
   - Open inline chat directly in the editor
   - Try: "Add a docblock comment to this method"
   - Notice how inline chat allows quick edits without leaving your code

**Learning Goal:** Understand how Copilot uses context and comments to generate relevant code suggestions.

### Exercise 1.3: Exploring the Suggestion Interface

1. **Navigation Practice**
   - Open `Backend/Controllers/WeatherForecastController.cs`
   - Add a comment: `// Get weather forecast for a specific date`
   - Hover mouse over the suggestion to see alternative suggestions

2. **Partial Acceptance**
   - Start typing a function and accept only part of a suggestion using `Ctrl+→`
   - Try modifying the suggestion before accepting it

**Learning Goal:** Master the Copilot interface and keyboard shortcuts.

### Exercise 1.4: Introduction to Copilot Chat

1. **Opening Chat**
   - Press `Ctrl+Alt+I` (or `Cmd+Alt+I`) to open Copilot Chat
   - Select "Ask" mode from the dropdown
   - Open `Backend/Program.cs` in VS Code
   - Ask: "Explain what this file does"

2. **Basic Chat Questions**
   - Ask: "What are the main components of this application?"
   - Try: "How is data persistence handled in this project?"
   - Notice how Copilot provides explanations and guidance

**Learning Goal:** Get comfortable with basic Copilot Chat interactions.

### Exercise 1.5: Understanding Built-in Agents

VS Code provides **four built-in agents** that you can switch between using the **agent picker** in the Chat view. Each agent is optimized for different tasks.

1. **Ask Agent - Questions & Explanations**

   - Select **Ask** from the agent picker in the Chat view
   - Ask questions about code without making changes
   - Try: "What design patterns are used in this codebase?"
   - Notice how Ask provides explanations, guidance, and learning resources

2. **Edit Agent - Direct Code Changes**

   - Select **Edit** from the agent picker
   - Add files as context using the **Add Context** button or by opening them in the editor
   - Request: "Add input validation to this method"
   - Observe how Edit focuses on making targeted code changes to specific files

   > **For other IDE users:** If #selection is not supported, open the file, provide it as context, and specify: "Add input validation to the Temperature property in WeatherForecast.cs"

3. **Agent - Autonomous Coding**

   - Select **Agent** from the agent picker (this is the most powerful mode)
   - Request: "Add weather alert functionality to this application"
   - Watch as Agent analyzes the codebase, creates files, and makes multi-file changes
   - Notice how Agent determines what needs to be done and makes changes across your workspace

4. **Plan Agent - Strategic Planning**
   - Select **Plan** from the agent picker
   - Ask: "Create an implementation plan for adding user authentication to this ASP.NET Core application"
   - Review the structured plan before implementation begins
   - Plan helps you think through implementation before coding

**Learning Goal:** Understand when and how to use each of the four built-in agents for different development tasks.

### Exercise 1.6: Setting Up Project Context with Copilot Instructions

**Why This Matters:** Creating a `copilot-instructions.md` file helps Copilot understand your project's specific patterns, conventions, and architecture, leading to more accurate and relevant suggestions throughout your development session.

1. **Generate Instructions Using VS Code**
   - Look for the **gear icon (⚙️)** in the VS Code interface (usually in the status bar or activity bar)
   - Click on the gear icon and select **"Generate Instructions for Copilot"**
   - VS Code will analyze your codebase and create a `.github/copilot-instructions.md` file
   - Wait for the generation process to complete

> **💡 For Other IDEs (JetBrains, etc.):** If you're not using VS Code, you can create the instructions manually:
>
> **Generate Instructions Using Copilot**
>    - Create the `.github` folder if it doesn't exist
>    - Open Copilot Chat in Agent mode
>    - Add your project's README.md and main configuration files as context
>    - Request: `@project Based on the project structure and README, create a comprehensive copilot-instructions.md file that defines our coding standards, architectural patterns, and development practices`


2. **Review the Generated Instructions**
   - Open the newly created `.github/copilot-instructions.md` file
   - Read through the generated content to understand what Copilot discovered about your project
   - Notice how it identifies:
     - Project architecture and patterns
     - Key conventions and coding styles
     - Important file structures and relationships
     - Development workflows and commands

3. **Test the Instructions with Copilot**
   - Open Copilot Chat
   - Ask: "Based on the project instructions, explain the main architecture of this application"
   - Try: "Following this project's patterns, how would I add a new field to the Task model?"
   - Request: "What are the key conventions I should follow when adding a new controller?"
   - Compare the responses to earlier interactions - they should be more specific and aligned with your project

4. **Explore Additional Instruction Types (Optional)**
   You can create these files manually or generate them via the gear icon menu. Each type serves a different purpose in guiding Copilot's behavior.
   - `.github/copilot-instructions.md` - Project-specific patterns and conventions
   - `.agent.instructions.md` - Custom agent behavior and constraints
   
   You can create these files manually or generate them via the gear icon menu. Each type serves a different purpose in guiding Copilot's behavior.
   
   > **For JetBrains users:** Check your IDE's documentation for instruction file support and location conventions.

5. **Refine the Instructions (Optional)**
   - If you notice any missing patterns or inaccurate information in the generated instructions
   - Edit the `.github/copilot-instructions.md` file to add project-specific details
   - Consider adding information about:
     - Specific coding conventions you follow
     - Common debugging approaches
     - Testing strategies used in the project

**Learning Goal:** Understand how to leverage VS Code's instruction generation feature to provide Copilot with better project context, resulting in more accurate and relevant code suggestions.

---

## Phase 2: Mastering Chat Commands

### Exercise 2.1: Basic Slash Commands

> **For other IDE users:** The `#selection` command is not supported. Instead, open the file, select `getWeatherData()`, open inline chat and use `/explain`.


1. **Understanding Code with `/explain`**
   - Select the WeatherForecastController class in `Backend/Controllers/WeatherForecastController.cs`
   - Type: `/explain #selection`
   - Try: `/explain How do models interact with controllers in ASP.NET Core?`
   - Compare explanations with different context levels

2. **Code Documentation with `/doc`**
   - Select the `WeatherForecast` class
   - Type: `/doc #selection`
   - Try: `/doc Generate comprehensive XML documentation for this class`

3. **Quick Fixes with `/fix`**
   - Create intentional issues (missing semicolon, wrong variable name)
   - Use: `/fix` to address the issues
   - Try: `/fix Address all C# coding standard issues in this file`

**Learning Goal:** Master basic slash commands for common development tasks.

### Exercise 2.2: Code and Structure Generation with `/new`

#### For VSCode Users:

1. **Simple Utility Creation**

   - Try: `/new Create a logging service class for this ASP.NET Core project`
   - Experiment: `/new Generate a configuration manager that fits this .NET architecture`
   - Advanced: `/new Create a custom middleware for request logging`

2. **Folder and File Structure Creation**

   - Try: `/new Create a new folder structure for API endpoints with controllers and DTOs`
   - Experiment: `/new Generate a services directory with dependency injection setup`
   - Advanced: `/new Create a complete testing structure with unit and integration test projects`

3. **Multi-file Component Generation**
   - Request: `/new Create a user management module with model, controller, service, and repository classes`
   - Try: `/new Generate a reporting system with data processors and response formatters`

#### For Other IDE Users:

1. **Simple Utility Creation**
   - In Agent mode, request: `Create a logging service class for this ASP.NET Core project`
   - Advanced: `Create a middleware system for request handling`

2. **Component Generation**
   - Try: `Generate a configuration class with validation`
   - Experiment: `Create a factory pattern implementation for Task objects`

**Learning Goal:** Learn to use Copilot for generating code components, folder structures, and multi-file modules.

### Exercise 2.3: Generating Tests with `/tests`

1. **Unit Test Generation**
   - Open `Backend/WeatherForecast.cs`
   - Select a property or method
   - In chat: `/tests #selection`
   - Examine the generated test structure

2. **Controller Testing**
   - Select a method from `Backend/Controllers/WeatherForecastController.cs`
   - Use `/tests` and observe how Copilot handles more complex scenarios
   - Ask follow-up questions like "How would I mock the dependencies in ASP.NET Core?"

3. **Custom Test Scenarios**
   - Ask: "Generate edge case tests for the WeatherForecast model validation"
   - Request: "Create integration tests for the WeatherForecast API endpoints"

**Learning Goal:** Understand how to generate comprehensive tests and testing strategies.

---

## Phase 3: Chat Variables and Context Control

> **💡 Context Setup Guide for VS Code**  
> 
> **Using #file**: Start typing `#` and begin typing the filename you want to add as context. VS Code will show you a dropdown of available files to choose from. Select the file you want and it will appear as `#file` in your prompt.
> 
> **Using #selection**: Select code in the editor, then reference it in chat with `#selection` to work with that specific code.
> 
> **Using #terminalSelection**: Select text in the terminal, then reference it in chat with `#terminalSelection` to debug errors or analyze command output.
> 
> **Using #fetch**: Use `#fetch <url>` to fetch and include web content in your prompt (e.g., `#fetch https://example.com/api-docs`).
> 

> **💡 Context Setup Guide for JetBrains**  
> 
> **Using #file**: Start typing `#file:` and begin typing the filename you want to add as context. JetBrains will show you a dropdown of available files to choose from. Select the file you want and it will appear as `#file:filename` in your prompt.
> 
> **Using #get_errors**: Type `#get_errors` to identify any compile or lint errors in the current file.
> 
> **Using #get_terminal_output**: Type `#get_terminal_output` to include the visible output from your terminal window (similar to `#terminalSelection` in VS Code).
> 
> **Using #get_terminal_output**: Type `#get_terminal_output` to include the visible output from your terminal window.
> 
> **Drag and Drop**: You can also drag files directly from the Project view into the chat window to add them as context.
> 
> **Using + Add Files/Context**: In Edits or Agent mode, click the `+ Add Files` or `+ Add Context` button to select files or folders.
> 
> **For Code Selections**: Select code in the editor, then either drag it into chat or use inline chat (`Alt+\` or `Option+\`) to work with the selection directly.
### Exercise 3.1: Chat Variables Deep Dive  

1. **File Context Variables**
   - Select `Backend/Controllers/WeatherForecastController.cs` in Explorer
   - Ask: `Analyze the code structure in #file`
   - Try with different files: `What security issues exist in #file?`

2. **Selection and Editor Variables**
   - Select a method in any C# file
   - Ask: `Optimize this code #selection for better performance`
   - With cursor in editor: `What's the context around #editor position?`

3. **Codebase Structure Analysis**
   - Ask: `What design patterns are used in #codebase?`
   - Try: `How is error handling implemented across #codebase?`
   - Request: `Show me the data flow in #codebase`

4. **Terminal Context Variables**
   - Run a command that produces an error (e.g., `dotnet build` with compilation errors)
   - Select the error output in your terminal
   - Ask: `What does this error mean #terminalSelection?`
   - Try: `Debug the issue shown in #terminalSelection`
   
   > **For JetBrains users:** Use `#get_terminal_output` instead of `#terminalSelection` to capture terminal output.

5. **Web Content and External Repositories**
   - Fetch content from a URL: `Summarize the main points #fetch https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection`
   - Use for documentation reference: `Compare our approach to #fetch https://docs.microsoft.com/dotnet/architecture/microservices/`
   
   > **For JetBrains users:** Check your IDE's documentation for web content fetching capabilities.

6. **Advanced Variable Combinations**
   - Try: `@workspace #codebase What would be the impact of adding caching?`
   - Experiment: `#file #selection How does this relate to the overall architecture?`
   - Combine multiple contexts: `Compare #selection with similar code in #file and #codebase patterns`

**Learning Goal:** Master chat variables for precise context control and analysis.

---

## Phase 4: Advanced Context and File Analysis

### Exercise 4.1: Working with File Context

1. **File-Based Questions**
   - Open `Backend/Controllers/WeatherForecastController.cs`
   - Ask: "What design patterns are used in #file?"
   - Try: "How can I improve error handling in #file?"
   - Request: "Explain the dependency injection pattern in ASP.NET Core controllers"

2. **Cross-File Analysis**
   - Ask: "How does WeatherForecastController.cs interact with WeatherForecast.cs?"
   - Request: "Show me the data flow from WeatherForecastController to WeatherForecast model"

**Learning Goal:** Learn to leverage file context for deeper code understanding.

---

## Phase 5: Practical Development Scenarios

### Exercise 5.1: Feature Development Guidance

1. **Planning New Features**
   - "I want to add weather alerts. How should I implement this feature?"
   - "Walk me through adding user authentication to this ASP.NET Core application"
   - "How would I add weather location tracking without breaking existing functionality?"

2. **Implementation Guidance**
   - Ask: "Show me step-by-step how to add weather history tracking"
   - Request code examples for each step
   - Ask for Entity Framework migration strategies for existing data

**Learning Goal:** Learn to use Copilot for feature planning and implementation guidance.

### Exercise 5.2: Debugging and Problem Solving

1. **Common Issues**
   - Ask: "What could cause the weather API to fail silently?"
   - Request: "How should I debug serialization issues in ASP.NET Core?"

2. **Error Handling Improvements**
   - Ask: "How can I improve error handling throughout this ASP.NET Core application?"
   - Request: "Show me best practices for logging in .NET applications using ILogger"

**Learning Goal:** Develop debugging skills with Copilot assistance.

---

## Phase 6: Specialized Agent Interactions

### Exercise 6.1: Security-Focused Reviews

1. **Security Agent Role**
   - "Act as a security expert and review the input validation in Backend/Controllers/WeatherForecastController.cs"
   - "As a security specialist, what vulnerabilities do you see in the WeatherForecastController?"
   - "From a security perspective, how should I improve this ASP.NET Core API?"

2. **Security Best Practices**
   - "What OWASP top 10 issues should I check for in this .NET application?"
   - "Provide specific security improvements for API input handling in ASP.NET Core"

**Learning Goal:** Learn to use Copilot for security-focused code reviews.

### Exercise 6.2: Performance and Code Quality

1. **Performance Expert Role**
   - "As a performance expert, analyze the efficiency of WeatherForecastController.cs"
   - "How can I optimize the data loading in ASP.NET Core Controllers?"

2. **Code Quality Reviewer**
   - "Act as a senior .NET developer and review the code quality in the Backend project"
   - "What C# coding standards and best practices should I implement in this codebase?"

**Learning Goal:** Understand how different expert perspectives can improve your code.

### Exercise 6.3: Code Review Workflow

GitHub Copilot provides built-in code review capabilities directly in VS Code, allowing you to get instant feedback on your code without leaving the editor.

> **💡 For JetBrains users:** Code review features may vary. The most direct way is to ask in the prompt to review. Or Right-click in the editor and select **GitHub Copilot → Generate Code Review**

1.  **Context Menu Code Review (VS Code)**

    - Open `Backend/Controllers/WeatherForecastController.cs`
    - Right-click in the editor and select **Copilot → Review and Comment**
    - Review the suggestions provided by Copilot about code quality, potential bugs, and improvements
    - Navigate through the suggestions using the review panel

2.  **Targeted Code Reviews with Selection**

    - Select a specific method or code block in `Backend/WeatherForecast.cs`
    - Right-click and choose **Copilot → Review and Comment** (or use chat with `/review #selection`)
    - Request specific reviews: `/review #selection for security vulnerabilities`
    - Try: `/review #selection for performance optimizations`

3.  **Custom Review Requests in Chat**

    - Open Copilot Chat and add a file as context
    - Request comprehensive reviews: "Review #file for potential bugs and edge cases"
    - Ask for specific aspects: "Review #file for C# best practices and SOLID principles"
    - Request architecture feedback: "Are there any design pattern violations or anti-patterns here?"

4.  **Implementing Review Feedback**
    - Switch to the **Edit** agent in Copilot Chat
    - Add the reviewed file as context
    - Request: "Apply the suggested improvements from the code review to #file"
    - Review and accept the changes into your workflow

**Learning Goal:** Master code review workflows to catch issues and improve code quality before committing.

---

## Phase 7: Advanced Context Optimization

### Exercise 7.1: Strategic Context Building

1. **Minimal vs. Maximum Context**
   - Ask the same question with different context levels:
     - Minimal: "How do I add validation?"
     - Medium: "How do I add validation to #file?"  
     - Maximum: "@workspace #codebase How do I add consistent validation across all controllers following the existing patterns?"
   - Compare response quality and relevance

2. **Context Layering Technique**
   - Start broad: "@workspace What's the validation strategy?"
   - Layer specific: "#file How does this controller handle validation?"
   - Drill down: "#selection Improve this validation logic"
   - Notice how each layer builds understanding

3. **Cross-Reference Optimization**
   - Use multiple file references: "Compare API patterns in WeatherForecastController.cs vs Program.cs"
   - Combine selection with file context: "How does #selection relate to patterns in #file?"
   - Mix variables effectively: "#codebase #selection Where else is this pattern used?"

### Exercise 7.2: Context Quality Assessment  
1. **Response Quality Testing**
   - Ask the same question 3 different ways with varying context
   - Rate responses on: accuracy, completeness, actionability
   - Document which context combinations work best for different question types

2. **Context Efficiency**
   - Time how long different context levels take to process
   - Find the sweet spot between comprehensive context and response speed
   - Learn when minimal context is sufficient vs. when maximum context is necessary

**Learning Goal:** Master the art of providing optimal context for different scenarios.

### Exercise 7.3: Leveraging Multiple Models for Specialized Tasks

Copilot allows you to switch between different AI models using the **model picker** in the chat input field. Different models are optimized for different tasks - some excel at complex reasoning, others at fast code generation.

1. **Scenario: Adding Weather Alert Feature - A Multi-Model Workflow**
   
   **Step 1: Analysis with a Reasoning Model**
   - Use the model picker to select a reasoning-focused model (e.g., o1, o3, or similar)
   - Ask: "Looking at the current weather forecast structure in this ASP.NET Core project, what would be the architectural implications of adding weather alerts? What potential issues should I consider?"
   - Follow up with: "Based on the existing WeatherForecastController and WeatherForecast model, what's the most logical way to integrate alerts without breaking current functionality?"
   
   **Step 2: Implementation with a Fast Coding Model**
   - Switch to a code-generation optimized model (e.g., Claude Sonnet, GPT-4, or similar)
   - Say: "Based on the analysis above, generate the code changes needed to add alert functionality to the WeatherForecast model. Include validation and proper C# properties."
   - Then: "Now generate the corresponding controller changes to handle alerts in weather forecast endpoints."
   
   **Step 3: Documentation and Git Summary**
   - Switch to a lightweight model for quick tasks (e.g., GPT-4o-mini or similar)
   - Request: "Get the current git status and create a summary of what files would be changed for this weather alert feature."
   - Follow with: "Generate a concise commit message and brief documentation for these alert changes."
   
   **Step 4: Validation Back to Reasoning Model**
   - Return to the reasoning model and ask: "Review the generated code changes. Are there any logical flaws or edge cases I should address before implementing?"

2. **Exploring Available Models**

   - Click the **model picker** in the chat input field to see available models
   - Note the different model types and their characteristics:
     - **Reasoning models**: Deep analysis, complex problem-solving
     - **Coding models**: Fast code generation, refactoring
     - **Lightweight models**: Quick responses, documentation, summaries
   - Experiment with different models for the same task and compare results
   
   > **Note:** Available models vary based on your Copilot subscription and may change over time.

3. **Reflect on the Multi-Model Experience**
   - Compare how each model approached their specialized task
   - Note the differences in reasoning depth, code quality, and task execution efficiency
   - Consider how this workflow could be applied to other feature development scenarios

**Learning Goal:** Master a practical multi-model workflow that leverages each LLM's strengths for analysis, implementation, and project management tasks.

---

## Phase 8: Advanced Prompt Engineering with Custom Agents

### Exercise 8.1: Understanding Custom Agents

Copilot allows you to create **custom agents** (`.agent.md` files) that define specialized personas with specific tools, instructions, and behaviors. This repository includes two custom agents in `.github/agents/`.


1. **Explore the Custom Agents in This Repository**

   - Open `.github/agents/Implementer.agent.md` and review its structure
   - Notice how it defines:
     - A specific **role** (focused implementer)
     - **Strict boundaries** (refuses to do planning or research)
     - **Execution phases** (understand → implement → validate)
     - **Output format requirements** (code-first, minimal explanation)
   - Open `.github/agents/Lead Developer.agent.md` and compare the differences

2. **Using Custom Agents**

   - Open Copilot Chat
   - Click the **agent picker** (usually shows the current agent like "Ask" or "Agent")
   - Select **Implementer** to activate that persona
   - Notice how the agent's behavior changes based on its defined role

3. **Practice with the Implementer Agent**

   - With Implementer selected, request: "Add temperature unit conversion to WeatherForecast.cs"
   - Observe how it focuses purely on implementation without architectural discussions
   - Try asking it to "research best practices for temperature conversion" - it should refuse and redirect
   - Notice how it follows its defined execution phases

4. **Practice with the Lead Developer Agent**

   - Switch to the **Lead Developer** agent
   - Request: "How should we add weather alert functionality?"
   - Notice how it provides architectural guidance and planning
   - Try asking it to "write the code" - it should refuse and create a plan instead

5. **Creating Your Own Custom Agent (Optional)**
   - In VS Code, click **Configure Chat (gear icon) → Custom Agents → New agent**
   - For other IDE users, create a new file in `.github/agents/` named `YourRole.agent.md`
   - Define a specialized role (e.g., "Security Reviewer", "Test Specialist", "Documentation Writer")
   - Consider creating agents for: code review, documentation, testing, or security analysis

**Learning Goal:** Understand how custom agents extend Copilot's capabilities with specialized personas and workflows.

### Exercise 8.2: Role-Based Collaboration with Custom Agents

1. **Simulate a Lead Developer / Implementer Workflow**

   **Thread 1: Planning with Lead Developer Agent**
   - Open a new Copilot chat
   - Select the **Lead Developer** agent
   - Request: "I need to add user authentication to this ASP.NET Core weather application. Create an implementation plan."
   - Review the architectural plan provided
   - Ask follow-up questions about security considerations or Entity Framework schema changes
   
   **Thread 2: Implementation with Implementer Agent**
   - Open a second Copilot chat (separate thread)
   - Select the **Implementer** agent
   - Copy the key points from the Lead Developer's plan
   - Request: "Based on this plan, implement the User model and JWT authentication in ASP.NET Core."
   - Watch as Implementer creates the code without architectural discussion
   
   **Thread 3: Code Review Back to Lead Developer**
   - Return to the Lead Developer thread
   - Share the implemented code
   - Request: "Review this authentication implementation for security and best practices."
   - Receive architectural feedback and improvement suggestions
   
   **Thread 4: Refinement with Implementer**
   - Return to the Implementer thread
   - Apply the Lead Developer's feedback
   - Request: "Apply these security improvements to the authentication code."
   - Continue until the feature is complete

2. **Understanding Agent Boundaries**
   - Notice how Lead Developer refuses to write production code
   - Observe how Implementer refuses to do planning or research
   - This separation prevents scope creep and maintains quality

**Learning Goal:** Master role-based collaboration using custom agents that mirror real team dynamics.

### Exercise 8.3: Reusable Prompt Files

Copilot supports **prompt files** (`.prompt.md`) that define reusable prompt templates you can invoke with `/` commands. This repository includes several prompts in `.github/prompts/`.

1. **Explore the Available Prompt Files**

   - Navigate to `.github/prompts/` in your workspace
   - Review available prompt templates:
     - Implementation prompts for code changes
     - Planning prompts for feature design
     - Review prompts for code quality checks
   - Open a few to understand their structure and purpose

2. **Using Prompt Files**

   - In Copilot Chat, type `/` to see available custom prompts
   - Select a prompt to insert its template into the chat

3. **Practice with Implementation Prompts**

   - Use a `/implement` prompt (if available) to request a feature
   - Observe how the structured prompt guides the implementation
   - Notice how prompts and agents work together for structured workflows

4. **Creating Your Own Prompt Files (Optional)**
   - In VS Code, click **Configure Chat (gear icon) → Prompt Files → New prompt file**
   - For other IDE users, create a new file in `.github/prompts/` named `YourPrompt.prompt.md`
   - Define reusable templates for common tasks (code reviews, documentation, testing)
   - Consider creating prompts for: code reviews, documentation, testing scenarios

**Learning Goal:** Leverage reusable prompt files to standardize common workflows and ensure consistency across your team.

### Exercise 8.4: Effective Context Management

1. **Context Window Awareness**

   - Each chat thread has a token limit for context
   - When a conversation gets long, create a summary before starting a new thread

2. **Creating Handoff Documents**

   - When switching between agents or threads, create a brief summary:
     - What was accomplished
     - Current state of the implementation
     - Next steps needed
   - Save these summaries in your project docs

3. **Thread Hygiene**
   - Name your threads descriptively (e.g., "Auth Implementation", "Security Review")
   - Keep each thread focused on a single concern
   - Don't mix different concerns in the same thread

**Learning Goal:** Master the art of managing multiple focused agent threads effectively.

---

## Phase 9: Creative and Exploratory Exercises

### Exercise 9.1: Code Refactoring Challenges

1. **Refactoring Scenarios**
   - "How would you refactor the WeatherForecastController to use dependency injection properly?"
   - "Show me how to implement the Repository pattern for weather data access"

2. **Design Pattern Implementation**
   - "How could I implement the Observer pattern for weather condition changes?"
   - "Show me how to add a Factory pattern for creating different weather forecast types"

**Learning Goal:** Explore advanced programming concepts with Copilot's guidance.

### Exercise 9.2: Alternative Implementations

1. **Different Approaches**
   - "Show me 3 different ways to implement weather data filtering in C#"
   - "What are alternative approaches to in-memory weather data storage?"

2. **Technology Comparisons**
   - "How would this application look if built with .NET Minimal APIs?"
   - "Compare this implementation with an Entity Framework-driven approach"

**Learning Goal:** Understand different implementation strategies and trade-offs.

### Exercise 9.3: Multi-Thread Task Management with Custom Agents

This exercise demonstrates how to use multiple chat views with different custom agents to organize complex development workflows. Each chat maintains its own context and agent selection, allowing you to separate concerns like planning, implementation, and review.

> **💡 For other IDE users:** While you can't view threads side-by-side like in VS Code, you can effectively switch between threads and share context through files.

1. **Opening Multiple Chat Views**

   - In VS Code, open multiple Copilot chat panels (you can split the chat view)
   - Each thread maintains its own conversation history and context

   For other IDE users:
   - Open the Copilot Chat tool window from the right sidebar
   - Click the **"+"** button to create a new chat thread
   - Each thread maintains its own conversation history and agent selection
   - You can switch between threads using the thread selector/tabs

2. **Scenario: Implementing User Authentication - Organized Workflow**

   **Thread 1: Planning Phase with Lead Developer Agent**
   - Select the **Lead Developer** agent (or establish role: "Act as a Lead .NET Developer")
   - Request: "I need to add user authentication to this ASP.NET Core weather application. Create an implementation plan with:
     - Entity Framework schema changes
     - Security considerations
     - JWT token implementation approach"
   - Review and refine the architectural plan
   
   **Thread 2: Implementation Phase with Implementer Agent**
   - Select the **Implementer** agent (or establish role: "Act as a .NET Code Implementer")
   - Add relevant files as context (e.g., `Program.cs`, existing models)
   - Request: "Based on the plan, implement:
     - User model with Entity Framework
     - JWT authentication service
     - Authentication controller endpoints"
   - Review the generated code
   
   **Thread 3: Testing Phase**
   - Use the **Ask** agent or establish role: "Act as a Testing Specialist"
   - Add the implemented authentication code as context
   - Request: "Generate comprehensive xUnit tests for the authentication system:
     - User model validation tests
     - JWT token generation tests
     - Authentication endpoint tests"
   
   **Thread 4: Security Review Phase**
   - Use a custom Security Reviewer agent or establish role: "Act as a Security Expert"
   - Add the authentication implementation as context
   - Request: "Review the authentication implementation for:
     - OWASP vulnerabilities
     - JWT security best practices
     - Input validation gaps
     - Potential attack vectors"
   - Request: "Generate comprehensive unit tests for the authentication system."

3. **Cross-Thread Collaboration Workflow**

   **Iteration 1: Initial Review**
   - Copy code from Implementation thread (Thread 2)
   - Paste into Security Review thread (Thread 4)
   - Get security feedback
   
   **Iteration 2: Apply Feedback**
   - Return to Implementation thread (Thread 2)
   - Request: "Apply these security improvements: [paste security feedback]"
   - Get updated implementation
   
   **Iteration 3: Final Validation**
   - Return to Planning thread (Thread 1) with Lead Developer
   - Request: "Review this final implementation against the original plan"
   - Get architectural validation
   
   **Iteration 4: Documentation**
   - Open a new thread with a Documentation focus
   - Request: "Create API documentation for the authentication endpoints"
   - Continue iterating between threads until both agents approve

4. **Tips for Multi-Chat Workflows**
   - **Use bookmarks**: Pin important responses in each thread for quick reference
   - **Clear thread naming**: Name each chat window by its purpose (Planning, Implementation, Review)
   - **Context handoffs**: When switching threads, provide brief summaries of what was accomplished
   - **Document decisions**: Keep a running note of key decisions from each thread

**Learning Goal:** Master multi-chat organization techniques using custom agents to separate planning, implementation, and review concerns, creating a structured development workflow that mirrors professional team collaboration.

---

Happy coding with GitHub Copilot!
