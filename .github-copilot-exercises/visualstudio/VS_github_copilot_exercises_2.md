# GitHub Copilot Comprehensive Training Exercises - Session 2: Agent-Based Development Workflow (Visual Studio Version)

Welcome to Session 2! You'll now dive into advanced agent-based development workflows. These exercises implement a structured approach focusing on **multi-agent collaboration** and **complex feature implementation**.

> **💡 About Custom Chatmodes in Visual Studio**
>
> Visual Studio will eventually support custom chatmodes similar to VS Code, allowing you to save and reuse agent configurations. For now, we'll manually prime agents with specific roles and instructions using reusable prompt files. This approach teaches you valuable prompt engineering skills and gives you full control over agent behavior.
>
> **What this means for you:**
> - You'll use **agent priming prompts** to define roles (Lead Developer, Implementer, QA Agent)
> - You'll store reusable prompts in `.github/prompts/` as `.prompt.md` files
> - You'll reference them using `#prompt:VS_prompt_name` in Copilot Chat
> - Each new chat session requires manual role definition

## Model Recommendations

Different agents work best with different AI models:

- **Lead Developer**: Claude Sonnet 4/4.5 or GPT-4 (better at detailed planning and research)
- **Implementer**: Claude Sonnet 4/4.5 (superior code generation and precision)
- **Deep reasoning and debugging**: Gemini 2.5 Pro or o1

**Always verify before running a prompt:**
1. Check the model selector shows your preferred model for that task
2. Manually switch models if needed
3. Keep track of which role you're using in each chat session

## Exercise 1: Complete User Management System Implementation

### Scenario: Multi-Agent Epic Development

You've been tasked with adding a complete user management system to the Weather Forecast application. This comprehensive exercise demonstrates the full agent-based development workflow from requirements analysis through implementation and completion. This will require user registration, authentication, user profiles, and user-specific weather preferences and history.

### Phase 1: Multi-Agent Feature Planning

#### Part 1.1: Requirements Analysis with Ask Agent

1. **Create Context Understanding**
   - Open a new Copilot Chat and set the context: "I am analyzing requirements for a user management system"
   - Ask: `@workspace Analyze the current architecture. How would adding user management impact the existing weather forecast system?`
   - Follow up: `What are the main challenges and considerations for adding users to this weather forecast application?`
   - Request: `Identify all files that would need modification and new files that need creation for user management`

2. **Security and Data Flow Analysis**
   - Ask: `From a security perspective, what authentication and authorization patterns should I implement using ASP.NET Core Identity?`
   - Request: `How should user data flow between the Backend API and BlazorUI components?`
   - Analyze: `What Entity Framework Core schema changes would be required for user management and personalized weather data?`

3. **Integration Impact Assessment**
   - Ask: `How will user management affect the existing WeatherForecastController and related services in the Backend project?`
   - Request: `What backwards compatibility considerations do I need for existing WeatherForecast functionality?`
   - Evaluate: `What ASP.NET Core Identity features and NuGet packages would be recommended for authentication in this Blazor + API architecture?`

**Deliverable:** Create a `REQUIREMENT-ANALYSIS.md` file documenting all findings, challenges, and recommendations.

#### Part 1.2: Lead Developer Planning Agent

**Understanding Agent Priming:**
Since Visual Studio doesn't yet have custom chatmodes, you'll manually prime the agent with a specific role. This means starting each chat session by telling Copilot what role to play and what rules to follow.

1. **Create the Lead Developer Prompt File**
   - Create `.github/prompts/VS_lead-plan.prompt.md` with the following content:

```markdown
You are a Lead .NET Developer responsible for architectural decisions, code reviews, and ensuring best practices.

Your task is to create a detailed implementation plan based on the provided requirements analysis.

Follow this process:
1. Read and understand the requirements analysis document
2. Break down the work into small, sequential, numbered tasks
3. Each task should be completable in one development session
4. Create the following deliverables:
   - `docs/epic_[name]/plans/IMPLEMENTATION_PLAN.md` - Overall strategy and approach
   - `docs/epic_[name]/plans/DECISION_LOG.md` - Key architectural decisions
   - `docs/epic_[name]/tasks/01_[task_name].md` - First task with clear goals and acceptance criteria
   - `docs/epic_[name]/tasks/02_[task_name].md` - Second task, and so on
   - `docs/epic_[name]/MANIFEST.md` - List of all generated files

Task File Format:
- Title: Clear, actionable task name
- Goal: What this task accomplishes
- Context: Files and components involved
- Acceptance Criteria: How to verify completion
- Implementation Notes: Technical guidance
- Use absolute paths from project root (not placeholders)

Plan Requirements:
- Focus on .NET 8, ASP.NET Core, Entity Framework Core, and C# best practices
- Each task must be independent (no blocking dependencies)
- Number tasks sequentially (01, 02, 03...)
- Keep tasks small and focused

Epic name will be provided. Generate all files with proper structure.
```

2. **Use the Lead Developer Prompt**
   - Start a **new Copilot Chat session**
   - Reference the prompt file: `#prompt:VS_lead-plan`
   - Add your requirements file: `#file:REQUIREMENT-ANALYSIS.md`
   - Provide the epic name: "The epic name is 'user_management'. Create the implementation plan."

3. **Review the Generated Plan**
   - The agent will create a new epic in `docs/epic_user_management/` containing:
     - `plans/IMPLEMENTATION_PLAN.md`: The overall strategy
     - `plans/DECISION_LOG.md`: Key decisions and rationale
     - `tasks/01_[name].md`, `tasks/02_[name].md`, etc.: Sequenced tasks
     - `MANIFEST.md`: A manifest of all generated files

   **Your responsibility:**
   - Read each task file to ensure it makes sense
   - Verify tasks are small enough (each should be completable in one session)
   - Check that file paths use project root (`/`) not placeholders
   - Ensure tasks follow C# and .NET conventions

**Deliverable:**
   - Output files in `docs/epic_user_management/`:
     - `plans/IMPLEMENTATION_PLAN.md`
     - `plans/DECISION_LOG.md`
     - `tasks/01_[name].md`, `tasks/02_[name].md`, etc.
     - `MANIFEST.md`

#### Part 1.3: Experimenting with Custom Planning Prompts

Instead of using the structured prompt file, you can experiment with generating the plan using your own custom prompts. This is a great way to practice prompt engineering and compare outputs.

1. **Start a new chat session** with your preferred model (e.g., Claude Sonnet 4, GPT-4)
2. **Provide Context**: Add `#file:REQUIREMENT-ANALYSIS.md`
3. **Craft Your Own Prompt**: Try variations like:
   > "Based on the attached requirements analysis, create a detailed implementation plan for adding user management to this ASP.NET Core application. Break it into 5-7 numbered, sequential task files. Each task should focus on a specific component (models, controllers, services, UI, etc.). Use .NET 8 and Entity Framework Core best practices. Generate a MANIFEST.md listing all files you create."

4. **Compare Results**: 
   - How does your custom prompt compare to the structured prompt?
   - Which produces clearer task definitions?
   - What prompt patterns work best for planning?

### Phase 2: Collaborative Implementation Workflow

#### Part 2.1: Create the Implementer Prompt File

1. **Create `.github/prompts/VS_implement.prompt.md`:**

```markdown
You are a .NET Implementer responsible for executing tasks with precision and quality.

Your role:
- Read and understand the task specification
- Implement code following .NET 8, C#, and ASP.NET Core best practices
- Write clean, maintainable, well-documented code
- Use proper error handling and validation patterns
- Follow Entity Framework Core conventions

Process:
1. Read the task file and summarize what you will do
2. List all files you will create or modify (use absolute paths from project root)
3. Ask for approval before proceeding
4. After approval, implement the task step by step
5. Run `dotnet build` on affected projects to verify compilation
6. Run tests if applicable with `dotnet test`
7. Report completion status

Code Standards:
- PascalCase for public members (classes, methods, properties)
- camelCase for private fields and local variables
- Use async/await for I/O operations
- Add XML documentation comments for public APIs
- Use dependency injection for services
- Follow REST conventions for API endpoints
- Use proper HTTP status codes

If verification fails:
- Explain what went wrong
- Propose a solution
- Ask for guidance if blocked

Always think through the task before implementing. Quality over speed.
```

#### Part 2.2: Implement the First Task

1. **Start a new Copilot Chat session**
2. **Prime the agent**: Reference `#prompt:VS_implement`
3. **Add task context**: Add `#file:docs/epic_user_management/tasks/01_[task_name].md`
4. **Request implementation**: "Implement this task following the process defined in the prompt."

**The Implementer will:**
- Read and summarize what it plans to do
- List all files it will create/modify
- Ask for your approval to proceed

**Your responsibility:**
- Review the implementation plan
- Confirm it matches the task specification
- Check that it follows C# and .NET conventions
- Approve with "yes" or request clarification

**Once approved, the Implementer will:**
- Execute the task step by step
- Run `dotnet build` on modified projects
- Execute tests if applicable
- Report completion status

#### Part 2.3: Handle Implementation Issues

**If the task succeeds:**
- Review the code changes
- Test manually if needed
- Move to the next task (repeat Part 2.2 with `02_[task_name].md`)

**If verification fails:**
- Read the Implementer's explanation
- Minor issues: Let it proceed if non-critical items failed
- Major issues: Ask the agent to propose solutions

**If the Implementer gets blocked:**
The agent will present what went wrong and propose solutions.

You can:
- Approve a proposed solution
- Provide an alternative approach
- Modify the task specification
- Go back to Lead Developer for task revision

#### Part 2.4: Complete Remaining Tasks

Repeat Part 2.2 for each task file in sequence (02, 03, etc.) until all tasks in the epic are complete.

**Important:** Each task should be run in a fresh chat session with the Implementer role primed using `#prompt:VS_implement`.

#### Part 2.5: Experimenting with Custom Implementation Prompts

Want to try a different implementation approach? Create your own prompt!

1. **Start a new chat session**
2. **Add task context**: `#file:docs/epic_user_management/tasks/01_[task_name].md`
3. **Craft your prompt**: Try variations like:
   > "Act as a senior .NET developer. Implement the attached task using .NET 8 and Entity Framework Core. List all files you'll modify, explain your approach, and then implement it step by step. Run dotnet build to verify. Use PascalCase for public members and follow async/await patterns."

4. **Apply changes**: Copy code blocks and apply them to your workspace

This hands-on approach helps you understand how to guide an agent through complex tasks.

#### Part 2.6: Complete the Epic

After the last task succeeds:

1. **Create `.github/prompts/VS_report-to-lead.prompt.md`:**

```markdown
You are a .NET Implementer reporting completion of an epic to the Lead Developer.

Your task:
- Review the implementation plan and manifest
- Summarize all work completed
- Note any deviations from the original plan
- Highlight challenges encountered and how they were resolved
- Provide recommendations for future epics
- List all files created or modified

Generate a completion report in markdown format with:
- Epic name and summary
- Completion status
- Implementation summary
- Deviations and rationale
- Lessons learned
- Recommendations

Be concise but thorough. Focus on architectural decisions and quality.
```

2. **Generate the Completion Report**
   - Start a **new chat session** or continue in Implementer mode
   - Reference: `#prompt:VS_report-to-lead`
   - Add context: `#file:docs/epic_user_management/plans/IMPLEMENTATION_PLAN.md` and `#file:docs/epic_user_management/MANIFEST.md`
   - Request: "Generate the completion report."

The agent generates a completion report with:
- Summary of work completed
- Any deviations from plan
- Recommendations for future epics

## Exercise 2: Comprehensive Testing and QA

### Scenario: Agent-Driven Quality Assurance

The user management system from Exercise 1 is feature-complete, but it hasn't been tested! Your task is to use a QA-focused agent workflow to create and implement a comprehensive test suite, ensuring the new features are robust, secure, and bug-free.

### Phase 1: Test Strategy and Planning

#### Part 1.1: Test Analysis with a QA Agent

1. **Create `.github/prompts/VS_qa-analysis.prompt.md`:**

```markdown
You are a QA Engineer specializing in .NET testing and quality assurance.

Your task:
- Analyze recently implemented features for testability
- Identify critical code paths requiring testing
- Generate comprehensive test case lists
- Recommend testing tools and frameworks
- Identify security vulnerabilities to test

Focus areas:
- Unit tests for business logic
- Integration tests for API endpoints
- Security tests for authentication/authorization
- Edge cases and error handling
- Entity Framework data access tests

Deliverables:
- List of test cases (unit, integration, end-to-end)
- Security vulnerability checklist (SQL injection, XSS, session issues)
- Testing framework recommendations
- Setup and configuration guidance

Use xUnit, Moq, Microsoft.AspNetCore.Mvc.Testing, and Entity Framework InMemory provider for .NET 8.
```

2. **Analyze the Feature Implementation**
   - Open a new Copilot Chat session
   - Reference: `#prompt:VS_qa-analysis`
   - Ask: `@workspace Based on the recently added user management system, analyze what needs testing.`
   - Follow up: `Generate a comprehensive list of test cases covering unit, integration, and security scenarios.`
   - Request: `What testing frameworks and setup do we need for this .NET 8 project?`

**Deliverable:** Create a `TEST-ANALYSIS.md` file documenting the test cases, security concerns, and setup plan.

#### Part 1.2: Test Plan Generation with Lead Developer

1. **Generate Test Implementation Plan**
   - Start a **new Copilot Chat session**
   - Reference: `#prompt:VS_lead-plan`
   - Add context: `#file:TEST-ANALYSIS.md`
   - Request: "Create a detailed test implementation plan. The epic name is 'user_auth_testing'. Focus on .NET 8, xUnit, and ASP.NET Core testing best practices."

2. **Review the Generated Plan**
   - The agent creates `docs/epic_user_auth_testing/` containing:
     - `plans/IMPLEMENTATION_PLAN.md`: Testing strategy
     - `tasks/01_[name].md`, `tasks/02_[name].md`, etc.: Sequential test implementation tasks
     - `MANIFEST.md`: Manifest of generated files
   - Verify tasks are logical, sequential, and appropriately sized

#### Part 1.3: Experimenting with Custom Test Planning

Try creating the test plan with your own prompt:

1. **Start a new chat session**
2. **Add context**: `#file:TEST-ANALYSIS.md`
3. **Custom prompt example**:
   > "Based on the attached test analysis, create a step-by-step test implementation plan for the 'user_auth_testing' epic. Break into numbered task files: setup test infrastructure, unit tests for models, integration tests for controllers, security tests, etc. Use xUnit, Moq, and .NET 8 patterns. Generate MANIFEST.md."

4. **Create files manually** based on the output
5. **Compare** with the structured prompt approach

### Phase 2: Test Implementation and Debugging

#### Part 2.1: Implement Test Tasks

1. **Execute Tasks with the Implementer**
   - For each task file (starting with `01_...`), start a **new chat session**
   - Reference: `#prompt:VS_implement`
   - Add task: `#file:docs/epic_user_auth_testing/tasks/01_[task_name].md`
   - Request: "Implement this task."
   - Review the plan and approve with "yes"
   - The agent will write test files, configuration, and helper code

#### Part 2.2: Experimenting with Custom Test Implementation

Try implementing tests with custom prompts:

1. **Start a new chat session**
2. **Add task**: `#file:docs/epic_user_auth_testing/tasks/01_[task_name].md`
3. **Custom prompt**:
   > "Based on the attached task, generate the necessary xUnit test code for .NET 8. Use Moq for mocking, follow AAA pattern (Arrange-Act-Assert), and include proper test naming conventions. List all files you'll create or modify before implementing."

4. **Apply changes manually** from the agent's response

#### Part 2.3: Running Tests and Fixing Bugs

This is the core of the QA workflow.

1. **Run the Newly Created Tests**
   - After creating test files, run them from the terminal:
     - Single test file: `dotnet test Tests/UserManagementTests.cs`
     - Entire test suite: `dotnet test`
     - Specific categories: `dotnet test --filter Category=Unit`

2. **If Tests Pass:**
   - Excellent! Move to the next task in sequence
   - Commit your changes: `git add . && git commit -m "Complete task: [task_name]"`

3. **If Tests Fail (Bug Found):**
   - Start a **new chat session**
   - Paste the full error output into the chat
   - Ask: `@workspace This .NET test is failing with the error below. Analyze the code and test to identify the bug. Propose a fix using ASP.NET Core and Entity Framework best practices.`
   - Include the error output in your message
   - Review the agent's analysis and proposed fix
   - Apply the fix, re-run tests to confirm they pass
   - Commit the fix: `git add . && git commit -m "Fix: [description]"`

4. **Create `.github/prompts/VS_debug-test.prompt.md` for Systematic Debugging:**

```markdown
You are a .NET Debugging Specialist focused on test failures and quality issues.

Your task:
- Analyze test failure output and stack traces
- Identify root causes (logic errors, configuration issues, test setup problems)
- Propose targeted fixes following .NET best practices
- Consider Entity Framework, async/await, and dependency injection patterns

Process:
1. Read the test failure output carefully
2. Identify the failing test and what it was testing
3. Analyze the relevant production code
4. Determine the root cause
5. Propose a specific fix with code examples
6. Explain why the fix resolves the issue

Common .NET test issues:
- Async/await misuse (missing await, deadlocks)
- Entity Framework context issues (disposed contexts, tracking problems)
- Dependency injection configuration errors
- Mock setup problems (incorrect return values, unmet expectations)
- Null reference exceptions (missing null checks)
- Configuration or appsettings issues

Provide clear, actionable fixes with proper error handling.
```

5. **Use the Debug Prompt for Systematic Fixing:**
   - Start a new chat session
   - Reference: `#prompt:VS_debug-test`
   - Add failing test file: `#file:Tests/UserManagementTests.cs`
   - Paste error output and request: "Analyze this test failure and propose a fix."

#### Part 2.4: Complete the Test Suite

- Repeat the implement-run-fix cycle for all tasks in `docs/epic_user_auth_testing/tasks/`
- Ensure all tests pass before marking the epic complete
- Run the full suite: `dotnet test` to verify everything works together

#### Part 2.5: Generate Test Completion Report

1. **Complete the Testing Epic**
   - Start a **new chat session**
   - Reference: `#prompt:VS_report-to-lead`
   - Add context: `#file:docs/epic_user_auth_testing/plans/IMPLEMENTATION_PLAN.md` and `#file:docs/epic_user_auth_testing/MANIFEST.md`
   - Request: "Generate the completion report for the testing epic."

## Exercise 3: Advanced Performance Optimization with Copilot Profiler Agent

> **⚠️ Visual Studio 2026 Insiders Only**
>
> The Copilot Profiler Agent is currently available only in **Visual Studio 2026 Insiders**. This is a cutting-edge AI-powered performance assistant built directly into Visual Studio.
>
> **Requirements:**
> - Visual Studio 2026 Insiders ([Download here](https://visualstudio.microsoft.com/insiders/))
> - GitHub Copilot subscription
> - Profiler Agent enabled in Copilot Chat tool menu
>
> **Capabilities:**
> - Analyzes CPU usage, memory allocations, and runtime behavior
> - Surfaces the most expensive bottlenecks in your code
> - Generates and optimizes BenchmarkDotNet benchmarks
> - Suggests actionable performance improvements
> - Validates fixes with before/after metrics in a guided loop
>
> **How to use:**
> - Tag it directly: `@profiler Why is my app slow?`
> - Or use plain language in Agent mode: "Why is my frame rate dropping?"
> - Make sure Profiler Agent is enabled in the Copilot Chat tool menu

### Scenario: Production-Ready Performance Optimization

The Weather Forecast application is feature-complete with user management and comprehensive tests. Now it's time to optimize it for production workloads. Use the Profiler Agent in combination with your multi-agent workflow to systematically improve performance.

### Phase 1: Performance Analysis and Planning

#### Part 1.1: Comprehensive Performance Audit

1. **Enable the Profiler Agent**
   - Open Visual Studio 2026 Insiders
   - Navigate to Copilot Chat
   - Click the tool menu and ensure **Profiler Agent** is enabled

2. **Initial Performance Assessment**
   - Run your application (F5 or Ctrl+F5)
   - In Copilot Chat, ask: `@profiler Analyze the overall performance of this ASP.NET Core application`
   - Follow up: `@profiler What are the top 5 performance bottlenecks in the Backend project?`
   - Request: `@profiler Show me CPU hotspots and memory allocation patterns`

3. **Endpoint-Specific Analysis**
   - Ask: `@profiler Analyze the performance of all WeatherForecast API endpoints`
   - Follow up: `@profiler What happens under high load in the user authentication endpoints?`
   - Request: `@profiler Compare the performance characteristics of GET vs POST endpoints`

4. **Database and Data Access**
   - If you implemented Entity Framework in Exercise 1:
     - Ask: `@profiler Analyze Entity Framework query performance`
     - Look for: `@profiler Are there any N+1 query problems or missing indexes?`
     - Check: `@profiler What are the most expensive database operations?`

**Deliverable:** Create a `PERFORMANCE-ANALYSIS.md` file documenting:
- Top performance bottlenecks identified
- CPU and memory hotspots
- Database query issues
- Recommendations from Profiler Agent

#### Part 1.2: Create Performance Optimization Epic with Profiler Insights

1. **Generate Performance Plan with Lead Developer**
   - Start a **new Copilot Chat session**
   - Reference: `#prompt:VS_lead-plan`
   - Add context: `#file:PERFORMANCE-ANALYSIS.md`
   - Request: "Create a detailed performance optimization plan. The epic name is 'production_performance_optimization'. Focus on .NET 8 high-performance patterns and BenchmarkDotNet validation."

2. **Review and Enhance the Plan**
   - The agent creates `docs/epic_production_performance_optimization/` with tasks like:
     - `01_setup_benchmarking_infrastructure.md`
     - `02_optimize_weather_endpoints.md`
     - `03_implement_response_caching.md`
     - `04_optimize_entity_framework_queries.md`
     - `05_implement_memory_pooling.md`
     - `06_add_performance_monitoring.md`
   - Ensure each task includes acceptance criteria based on benchmark results

### Phase 2: Benchmark-Driven Optimization

#### Part 2.1: Setup Benchmarking Infrastructure

1. **Create the Profiler-Assisted Implementation Prompt**
   - Create `.github/prompts/VS_implement-with-profiler.prompt.md`:

```markdown
You are a .NET Performance Engineer combining implementation skills with Profiler Agent insights.

Your role:
- Read and understand the performance optimization task
- Use `@profiler` to analyze current performance
- Implement optimizations following .NET 8 high-performance patterns
- Generate BenchmarkDotNet benchmarks to measure improvements
- Validate changes with before/after metrics

Process:
1. Use `@profiler` to establish baseline performance
2. Summarize what you will optimize and why
3. List all files you will create or modify
4. Ask for approval before proceeding
5. Implement the optimization step by step
6. Generate or update BenchmarkDotNet benchmarks
7. Run benchmarks and report performance improvements
8. Run `dotnet build` and `dotnet test` to ensure correctness

High-Performance Patterns:
- Use `Span<T>` and `Memory<T>` for efficient array operations
- Leverage `ArrayPool<T>` for temporary buffer allocation
- Use `ValueTask<T>` for hot paths that often complete synchronously
- Prefer `StringBuilder` over string concatenation
- Use `[MethodImpl(MethodImplOptions.AggressiveInlining)]` for small, hot methods
- Apply `async`/`await` judiciously (avoid for CPU-bound work)
- Use `stackalloc` for small, short-lived allocations
- Leverage `System.Runtime.CompilerServices.Unsafe` when safe

Benchmarking:
- Use `[MemoryDiagnoser]` to track allocations
- Add `[Benchmark(Baseline = true)]` for the original implementation
- Include multiple scenarios (small, medium, large datasets)
- Report: throughput (ops/sec), mean time, allocated memory

Always validate that optimizations improve performance without breaking functionality.
```

2. **Implement Benchmarking Infrastructure**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/01_setup_benchmarking_infrastructure.md`
   - Request: "Implement this task using Profiler Agent for guidance."

#### Part 2.2: Optimize Critical Endpoints

1. **Endpoint Optimization with Profiler Validation**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/02_optimize_weather_endpoints.md`
   - Request: "Implement this task. Use `@profiler` to identify bottlenecks first."

2. **Profiler-Guided Optimization Loop**
   - The agent will:
     - Use `@profiler` to analyze current endpoint performance
     - Identify specific bottlenecks (LINQ, string operations, allocations)
     - Generate a benchmark for the current implementation
     - Implement optimizations (e.g., use `Span<T>`, reduce allocations)
     - Generate updated benchmark
     - Compare before/after metrics
   - Review the performance improvements (aim for 20-50% improvement)

#### Part 2.3: Implement Caching Strategies

1. **Response Caching Analysis**
   - Start a **new chat session** with Profiler Agent
   - Ask: `@profiler Which endpoints would benefit most from response caching?`
   - Follow up: `@profiler What's the cache hit ratio we should target for weather data?`

2. **Implement Caching with Validation**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/03_implement_response_caching.md`
   - Request: "Implement caching and validate throughput improvements."

3. **Benchmark Caching Effectiveness**
   - Use `@profiler`: "Generate a benchmark comparing cached vs non-cached endpoint performance"
   - Run the benchmark and verify improvements (aim for 5-10x improvement on cache hits)

#### Part 2.4: Database Query Optimization

If you implemented Entity Framework in Exercise 1:

1. **Query Performance Analysis**
   - Ask: `@profiler Analyze all Entity Framework queries for performance issues`
   - Request: `@profiler Show me queries with the highest execution time`
   - Check: `@profiler Are there any cartesian product or missing Include() issues?`

2. **Optimize Data Access**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/04_optimize_entity_framework_queries.md`
   - Implement optimizations:
     - Add `.AsNoTracking()` for read-only queries
     - Use `.Include()` for proper eager loading
     - Implement compiled queries for repeated operations
     - Add pagination for large result sets
   - Validate with `@profiler`: "Compare query performance before and after optimization"

### Phase 3: Advanced Performance Techniques

#### Part 3.1: Memory Optimization with ArrayPool

1. **Identify Allocation Hotspots**
   - Ask: `@profiler What are the biggest memory allocation sources in the application?`
   - Focus on: `@profiler Show me temporary array allocations that could use ArrayPool`

2. **Implement Memory Pooling**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/05_implement_memory_pooling.md`
   - Request: "Implement ArrayPool<T> for temporary buffers and validate memory reduction."

3. **Validate Memory Improvements**
   - Use `@profiler`: "Generate a memory allocation benchmark comparing before and after ArrayPool implementation"
   - Look for 50-90% reduction in allocations

#### Part 3.2: Span<T> and Modern .NET Patterns

1. **Identify Span<T> Opportunities**
   - Ask: `@profiler Where can I use Span<T> or ReadOnlySpan<T> to avoid allocations?`
   - Look for: String parsing, array slicing, temporary buffers

2. **Implement Zero-Allocation Patterns**
   - Convert string operations to use `ReadOnlySpan<char>`
   - Use `stackalloc` for small, short-lived buffers
   - Implement `ValueTask<T>` for hot async paths
   - Ask `@profiler`: "Validate that these changes reduce allocations"

#### Part 3.3: Load Testing and Concurrency

1. **Simulate Production Load**
   - Ask: `@profiler What happens under high concurrent load (100+ requests/second)?`
   - Identify: Thread contention, lock contention, async bottlenecks

2. **Optimize for Throughput**
   - Implement: Async all the way, minimize lock duration, use concurrent collections
   - Use `@profiler`: "Compare throughput before and after concurrency optimizations"
   - Target: Linear scalability up to CPU core count

### Phase 4: Performance Monitoring and Reporting

#### Part 4.1: Implement Performance Monitoring

1. **Add Production Performance Tracking**
   - Start a **new chat session**
   - Reference: `#prompt:VS_implement-with-profiler`
   - Add task: `#file:docs/epic_production_performance_optimization/tasks/06_add_performance_monitoring.md`
   - Implement: Application Insights, custom performance counters, endpoint timing middleware

#### Part 4.2: Generate Comprehensive Performance Report

1. **Collect All Benchmark Results**
   - Gather all BenchmarkDotNet results from the epic
   - Use `@profiler`: "Summarize all performance improvements made across the application"

2. **Create Performance Summary**
   - Start a **new chat session**
   - Reference: `#prompt:VS_report-to-lead`
   - Add context: All benchmark results and `#file:docs/epic_production_performance_optimization/MANIFEST.md`
   - Request: "Generate a comprehensive performance optimization report with before/after metrics."

**Performance Report Should Include:**
- Overall application throughput improvement (%)
- Per-endpoint latency reduction (ms)
- Memory allocation reduction (bytes/request)
- CPU usage reduction (%)
- Database query time improvement (ms)
- Specific optimizations applied and their impact
- Recommendations for future performance work

### Phase 5: Real-World Performance Case Study (Optional)

#### Part 5.1: Contributing to Open Source

Inspired by the Profiler Agent's success with CSVHelper, NLog, and Serilog:

1. **Find a Performance Opportunity**
   - Choose an open-source .NET library you use
   - Ask: `@profiler Analyze performance of [library] and suggest improvements`

2. **Create a PR with Profiler Insights**
   - Use the Profiler Agent to identify bottlenecks
   - Generate benchmarks showing the issue
   - Implement optimizations
   - Validate improvements with `@profiler`
   - Create a pull request with before/after benchmarks

**Learning Goal:** Apply enterprise-level performance engineering skills to real-world projects using AI-powered profiling.

## Agent Priming Templates Reference

For quick reference, here are the key prompt files you'll create:

| Prompt File | Purpose | When to Use |
|-------------|---------|-------------|
| `VS_lead-plan.prompt.md` | Generate implementation plans and task breakdowns | At the start of each epic for planning |
| `VS_implement.prompt.md` | Execute individual tasks with precision | For each task implementation |
| `VS_implement-with-profiler.prompt.md` | Execute performance tasks with Profiler Agent | For performance optimization tasks (Exercise 3) |
| `VS_report-to-lead.prompt.md` | Generate completion reports | After completing all tasks in an epic |
| `VS_qa-analysis.prompt.md` | Analyze features for testing needs | Before creating test implementation plans |
| `VS_debug-test.prompt.md` | Debug test failures systematically | When tests fail and you need root cause analysis |

**Usage Pattern:**
1. Create the prompt file in `.github/prompts/`
2. Start a new chat session
3. Reference it: `#prompt:VS_prompt_name`
4. Add additional context as needed (`#file`, `@workspace`)
5. Make your request

## Tips for Success with Visual Studio

### Agent Priming Best Practices

1. **One role, one session** - Don't mix agent roles in the same chat
2. **Always prime first** - Start each session by referencing the appropriate prompt file
3. **Verify your model** - Check you're using the right model for the task
4. **Keep context focused** - Add only relevant files with `#file` references
5. **New task = new session** - Don't reuse chat sessions across tasks

### Visual Studio-Specific Tips

1. **Use Solution Explorer** - Easy file navigation and context
2. **Test Explorer** - View and run tests efficiently
3. **Reference prompts** - Type `#prompt:` to see available prompt files
4. **Terminal integration** - Run `dotnet` commands directly in VS terminal
5. **File references** - Use `#file:path/to/file` for precise context

### Development Workflow

1. **Commit frequently** - After each successful task: `git add . && git commit -m "Complete task: [task_name]"`
2. **Build often** - Use `dotnet build` to catch errors early
3. **Test continuously** - Run `dotnet test` after changes
4. **Review everything** - Always review generated code before accepting
5. **Trust but verify** - Agents are powerful but can make mistakes

### .NET and C# Conventions

1. **Naming conventions**:
   - PascalCase for classes, methods, properties: `UserController`, `GetUserById`
   - camelCase for private fields, parameters: `_userService`, `userId`
   - Prefix interfaces with `I`: `IUserService`

2. **Async patterns**:
   - Use `async`/`await` for I/O operations
   - Suffix async methods with `Async`: `GetUserAsync`
   - Return `Task` or `Task<T>` from async methods

3. **Dependency Injection**:
   - Register services in `Program.cs`
   - Inject via constructor
   - Use interfaces for abstraction

4. **Entity Framework**:
   - Use `DbContext` for data access
   - Prefer async methods: `ToListAsync`, `FirstOrDefaultAsync`
   - Use migrations for schema changes

5. **API conventions**:
   - Use proper HTTP verbs: GET, POST, PUT, DELETE
   - Return appropriate status codes: 200, 201, 400, 404, 500
   - Use DTOs for request/response models

### When Things Go Wrong

1. **Agent confused or off-track:**
   - Start a fresh session
   - Re-prime with the prompt file
   - Provide clearer context

2. **Generated code doesn't compile:**
   - Check for missing `using` statements
   - Verify NuGet packages are installed
   - Review namespaces and type names

3. **Tests fail unexpectedly:**
   - Use `#prompt:VS_debug-test` for systematic debugging
   - Check async/await usage
   - Verify Entity Framework context configuration
   - Review mock setups

4. **Task specification unclear:**
   - Go back to Lead Developer
   - Ask for clarification or task revision
   - Break down further if needed

5. **Blocked on dependencies:**
   - Check if earlier tasks were completed properly
   - Review IMPLEMENTATION_PLAN.md for context
   - Consider if task order needs adjustment

## Looking Ahead: Future Visual Studio Features

Visual Studio is continuously evolving its Copilot integration. Features coming in the future may include:

- **Custom Chatmodes**: Save and reuse agent configurations (similar to VS Code)
- **Workflow Templates**: Pre-built agent workflows for common scenarios
- **Enhanced Context**: More sophisticated code understanding and project analysis
- **Team Collaboration**: Share agent configurations and prompts across teams

**For now**, the manual agent priming approach you're learning gives you:
- **Full control** over agent behavior
- **Deeper understanding** of effective prompting
- **Transferable skills** that work across AI tools
- **Flexibility** to customize agents for your specific needs

This experimental system will continue to evolve. When you find better patterns or improvements, document them and share with your team!

---

Happy coding with GitHub Copilot in Visual Studio!
