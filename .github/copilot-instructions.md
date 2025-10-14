# General Copilot Instructions
- Do not use README.md file's tasks, phases or end goal sections in any context as a source of information unless separately asked/referenced. Its purpose is to give people exercises in the training how to use Copilot.

# Copilot Instructions for Solution-Level Changes

- Always make solution-level changes (such as adding/removing projects, configurations, or solution properties) in the `CopilotExercises.sln` file.
- After any change to `CopilotExercises.sln`, automatically migrate those changes to `CopilotExercises.slnx` by running:

```powershell
dotnet sln CopilotExercises.sln migrate
```

- Do not prompt for confirmation before migrating; the migration should be performed immediately after any `.sln` modification.
- This ensures that both `.sln` and `.slnx` files remain in sync for all solution-level operations.
