# Educator Guide: GitHub Copilot Training (2 Sessions)

## Overview

This guide provides clear instructions for educators to teach GitHub Copilot using this C# training repository across **2 comprehensive sessions**. The training is designed to take students from Copilot basics to advanced multi-agent workflows.

## Repository Structure

- **Session 1 Materials**:
  - `github_copilot_exercises.md` - For VS Code users
  - `VS_github_copilot_exercises.md` - For Visual Studio users
  
- **Session 2 Materials**:
  - `github_copilot_exercises_2.md` - Advanced agent workflows (VS Code)
  - `VS_github_copilot_exercises_2.md` - Advanced agent workflows (Visual Studio)

- **Supporting Materials**:
  - `README.md` - Project overview and end goals (for context only)
  - `.github/copilot-instructions.md` - Custom instructions for better context
  - `.github/chatmodes/` - Custom agent modes (VS Code only)
  - `.github/prompts/` - Reusable prompt templates

## Pre-Session Preparation

### For Educators

1. **Familiarize Yourself with the Materials**
   - Read through both session exercise files for your IDE
   - Test key exercises yourself before teaching
   - Identify potential challenging areas for your audience

2. **Technical Setup**
   - Clone this repository: `git clone https://github.com/EficodeDemoOrg/csharp-copilot-training.git`
   - Ensure .NET 8 SDK is installed
   - Test the project builds: `dotnet build`
   - Verify all students have GitHub Copilot access

3. **Environment Check**
   - Teaching space has projector/screen sharing capability
   - Internet connectivity is stable
   - IDE (VS Code or Visual Studio) is properly configured

### For Students (Send Before Session 1)

**Prerequisites Checklist:**
- [ ] GitHub account with Copilot access enabled
- [ ] IDE installed:
  - **VS Code**: Latest version with GitHub Copilot extension
  - **Visual Studio**: 2022 or later with GitHub Copilot
- [ ] .NET 8 SDK installed
- [ ] Git installed and configured
- [ ] Repository cloned: `git clone https://github.com/EficodeDemoOrg/csharp-copilot-training.git`
- [ ] Project builds successfully: `dotnet build`

**Verify Copilot is Working:**
1. Open any `.cs` file in the project
2. Type `// Method to` and press Enter
3. You should see a gray suggestion appear (this is Copilot!)
4. Press Tab to accept it

---

## Session 1: GitHub Copilot Fundamentals (3-4 hours)

### Learning Objectives
By the end of Session 1, students will be able to:
- Use inline code suggestions effectively
- Navigate Copilot's suggestion interface
- Use Copilot Chat for explanations and guidance
- Apply basic slash commands (`/explain`, `/doc`, `/fix`, `/tests`)
- Provide effective context using chat variables (`#file`, `#selection`, `@workspace`)
- Understand when to use different interaction modes (Ask, Edit, Agent)

### Session Structure

#### Part 1: Welcome and Introduction (30 minutes)

**Topics to Cover:**
1. **What is GitHub Copilot?**
   - AI pair programmer trained on billions of lines of code
   - Not just autocomplete—understands context and intent
   - Available in multiple IDEs

2. **Demo: The "Wow" Moment** (10 minutes)
   - Show a live example of Copilot generating a complete function
   - Open `Backend/WeatherForecast.cs`
   - Type: `// Method to check if this forecast indicates extreme weather`
   - Let Copilot suggest the implementation
   - Accept with Tab and show it works

3. **Project Overview** (10 minutes)
   - Quick walkthrough of the Weather Forecast application
   - Explain: Backend (ASP.NET Core), BlazorUI (frontend), Tests
   - Show how to run: `dotnet run --project Backend`
   - Emphasize: Don't worry about understanding everything—Copilot will help!

4. **Set Expectations** (10 minutes)
   - This is hands-on learning
   - Copilot is a tool, not magic—you're still in control
   - It's okay to make mistakes
   - Questions are encouraged

#### Part 2: Inline Suggestions and Basic Interface (45 minutes)

**Follow:** Exercises 1.1-1.3 in the session materials

**Teaching Tips:**
- **Live Demo First**: Show each feature before students try
- **Common Issue**: Students accepting wrong suggestions
  - Solution: Show `Alt+]` / `Alt+[` (VS Code) or `Alt+.` / `Alt+,` (Visual Studio) to cycle
- **Encourage Experimentation**: Let them try different comment styles

**Key Takeaways:**
- Comments guide Copilot's suggestions
- You can cycle through alternatives
- You control what gets accepted

#### Part 3: Copilot Chat Basics (45 minutes)

**Follow:** Exercises 1.4-1.5 in the session materials

**Teaching Tips:**
- **Show the Difference**: Ask vs Edit vs Agent modes
  - **Ask**: "Explain this code" (for understanding)
  - **Edit**: "Add validation" (for changes)
  - **Agent/Generate**: "Create a new service class" (for new code)
- **Common Confusion**: When to use Chat vs Inline
  - Rule of thumb: Complex questions = Chat, Quick completions = Inline

**Practice Exercise (15 min):**
Students should:
1. Open `Backend/Controllers/WeatherForecastController.cs`
2. Use Chat to ask: "Explain what this controller does"
3. Select a method and use Edit mode to: "Add error handling"

#### Part 4: Project Context and Custom Instructions (30 minutes)

**Follow:** Exercise 1.6 in the session materials

**Teaching Tips:**
- **VS Code**: Show the gear icon and "Generate Instructions for Copilot" feature
- **Visual Studio**: Walk through manual creation using Copilot Chat
- **Why This Matters**: Better context = better suggestions

**Live Demo:**
1. Before custom instructions: Ask "How should I add a new controller?"
2. After custom instructions: Ask the same question
3. Show how responses are more specific and aligned with project patterns

#### Break (15 minutes)

#### Part 5: Slash Commands Mastery (60 minutes)

**Follow:** Exercises 2.1-2.4 in the session materials

**Cover Each Command:**
1. **`/explain`** (10 min)
   - Best for understanding unfamiliar code
   - Demo: Explain WeatherForecastController

2. **`/doc`** (10 min)
   - Generates XML documentation
   - Demo: Document the WeatherForecast class

3. **`/fix`** (10 min)
   - Quick fixes for errors
   - Demo: Create an intentional error, then fix it

4. **`/tests`** (15 min)
   - Generates unit tests
   - Demo: Generate tests for a method
   - **Important**: Show students the Tests project structure

5. **`/new` or `/generate`** (15 min)
   - Creates new components
   - Demo: Create a simple utility class
   - VS Code uses `/new`, Visual Studio uses `/generate`

**Hands-On Exercise (30 min):**
Students complete Exercise 2.4 (Generating Tests):
1. Select a method in `WeatherForecast.cs`
2. Use `/tests #selection`
3. Review and understand the generated tests
4. Run the tests: `dotnet test`

#### Part 6: Context Control with Chat Variables (45 minutes)

**Follow:** Exercise 3.1 in the session materials

**Teach the Context Hierarchy:**
1. **No context**: "How do I add validation?"
   - Vague answer
2. **File context**: "How do I add validation to #file:WeatherForecastController.cs?"
   - Better, file-specific answer
3. **Selection context**: "Improve #selection"
   - Precise, targeted answer
4. **Workspace context**: "@workspace How is validation handled across the codebase?"
   - Project-wide patterns

**Common Variables:**
- `#file` - Reference a specific file
- `#selection` - Current selected code
- `#editor` - Current cursor position
- `@workspace` - Entire project context

**Practice Exercise (20 min):**
Students try different context levels for the same question and compare results.

#### Part 7: Practical Scenarios and Wrap-Up (45 minutes)

**Follow:** Exercises 5.1-5.2 in the session materials

**Real-World Scenarios:**
1. **Planning a New Feature** (15 min)
   - Walk through: "I want to add weather alerts. How should I implement this?"
   - Show how Copilot provides step-by-step guidance

2. **Debugging Help** (15 min)
   - Create a bug (e.g., null reference)
   - Ask Copilot: "Why might this code throw an exception?"
   - Show how to fix it with Copilot's help

**Q&A and Reflection** (15 min)
- What surprised you about Copilot?
- What will you use most in your daily work?
- Common questions review

**Homework for Session 2:**
- Practice exercises 6-7 (Security reviews, performance analysis)
- Read through the Session 2 materials introduction
- Optional: Try exercises in Phase 8 (Prompt Engineering)

### Session 1 Timing Summary
- Introduction: 30 min
- Inline Suggestions: 45 min
- Chat Basics: 45 min
- Custom Instructions: 30 min
- Break: 15 min
- Slash Commands: 60 min
- Context Control: 45 min
- Practical Scenarios: 45 min
- **Total: 4 hours 15 minutes** (adjust based on group pace)

### Common Session 1 Challenges and Solutions

| Challenge | Solution |
|-----------|----------|
| Copilot not showing suggestions | Check extension is installed, verify license, restart IDE |
| Suggestions are irrelevant | Improve context with better comments or chat variables |
| Students overwhelmed by options | Focus on one feature at a time, encourage note-taking |
| Build errors | Have a working project ready to share, or pair students |
| Different pace among students | Prepare bonus exercises for faster learners |

---

## Session 2: Advanced Agent-Based Workflows (3-4 hours)

### Prerequisites
- Completed Session 1 or equivalent experience
- Comfortable with basic Copilot features
- Understanding of multi-file projects and Git workflows

### Learning Objectives
By the end of Session 2, students will be able to:
- Use role-based prompting for specialized agent behavior
- Implement multi-agent workflows for complex features
- Break down large features into manageable tasks
- Use reusable prompts and custom chatmodes (VS Code)
- Apply systematic debugging and testing workflows
- (Visual Studio 2026 Insiders only) Use Profiler Agent for performance optimization

### Session Structure

#### Part 1: Introduction to Agent-Based Development (30 minutes)

**Key Concepts:**
1. **What are Agent-Based Workflows?**
   - Using different "roles" for different tasks
   - Lead Developer (planning), Implementer (coding), QA (testing)
   - More structured approach to complex features

2. **Why Use Multiple Agents?**
   - Separation of concerns
   - Better quality through specialized focus
   - Mimics real team collaboration

3. **Tools We'll Use:**
   - **VS Code**: Custom chatmodes (`.chatmode.md` files)
   - **Visual Studio**: Agent priming prompts (`.prompt.md` files)
   - Both approaches teach the same concepts!

**Demo: The Difference** (10 min)
- Show a simple task without agents (chaotic)
- Show the same task with agent structure (organized)
- Highlight: More upfront planning = better results

#### Part 2: Multi-Agent Feature Planning (60 minutes)

**Follow:** Exercise 1, Phase 1 in the session materials

**Scenario Setup:**
"We need to add user management to our Weather Forecast app: registration, authentication, user profiles, and weather preferences."

**Agent 1: Requirements Analysis (15 min)**
- Use standard Chat (Ask mode)
- Questions to ask:
  - "What are the impacts of adding user management?"
  - "What security considerations do we have?"
  - "What files will need modification?"
- Create `REQUIREMENT-ANALYSIS.md`

**Agent 2: Lead Developer Planning (30 min)**
- **VS Code**: Switch to "Lead Developer" chatmode
- **Visual Studio**: Use `#prompt:VS_lead-plan`
- Provide: Requirement analysis document
- Agent creates:
  - Implementation plan
  - Decision log
  - Numbered task files (01_task.md, 02_task.md, etc.)
  - Manifest

**Review and Critique (15 min)**
- Look at generated task files together
- Discuss: Are tasks small enough?
- Check: Do paths use project root correctly?
- Learn: What makes a good task specification?

#### Break (15 minutes)

#### Part 3: Implementing Tasks with Implementer Agent (75 minutes)

**Follow:** Exercise 1, Phase 2 in the session materials

**Implementer Workflow (30 min for first task):**
1. Start fresh chat session
2. **VS Code**: Switch to "Implementer" chatmode, use `/implement`
3. **Visual Studio**: Use `#prompt:VS_implement`
4. Attach first task file: `01_[task_name].md`
5. Agent summarizes plan and asks for approval
6. Review and approve
7. Agent implements, builds, and tests
8. Review the results

**Teaching Tips:**
- **Emphasize**: Each task = fresh session
- **Show**: How to review generated code
- **Demonstrate**: Running `dotnet build` and `dotnet test`
- **Common Issue**: Agent gets confused
  - Solution: Start new session, clearer context

**Hands-On (45 min):**
Students implement the first 2-3 tasks:
- Work through task 01 together (guided)
- Students do task 02 independently
- Share results and discuss challenges

#### Part 4: Systematic Testing and QA (60 minutes)

**Follow:** Exercise 2 in the session materials

**QA Agent Workflow:**
1. **Analyze What Needs Testing** (20 min)
   - Use QA-focused prompts
   - Generate test case list
   - Identify security vulnerabilities
   - Create `TEST-ANALYSIS.md`

2. **Generate Test Implementation Plan** (15 min)
   - Lead Developer creates test epic
   - Break into tasks: setup, unit tests, integration tests, security tests

3. **Implement Tests** (25 min)
   - Use Implementer agent with test tasks
   - Generate xUnit tests
   - Run tests: `dotnet test`
   - Debug failures together

**Key Teaching Points:**
- Testing is a separate workflow with its own planning
- Tests validate that implementations work correctly
- TDD (Test-Driven Development) mindset

#### Break (15 minutes)

#### Part 5: Performance Optimization (Visual Studio 2026 Insiders Only) (45 minutes)

**Follow:** Exercise 3 in the session materials (Visual Studio only)

**⚠️ Note**: This section only works with Visual Studio 2026 Insiders

**Profiler Agent Demo:**
1. **Identify Bottlenecks** (10 min)
   - Use `@profiler` to analyze app performance
   - Show CPU hotspots and memory allocations

2. **Generate Benchmarks** (15 min)
   - Create BenchmarkDotNet benchmarks
   - Run baseline performance tests

3. **Optimize and Validate** (20 min)
   - Implement optimization (e.g., caching, Span<T>)
   - Re-run benchmarks
   - Show before/after metrics

**For VS Code Users:**
- Skip this section or demonstrate with manual performance analysis
- Focus on concepts: profiling, benchmarking, optimization patterns

#### Part 6: Advanced Techniques and Best Practices (45 minutes)

**Topics to Cover:**

1. **Multi-Thread Agent Management** (15 min)
   - Exercise 9.3 from Session 1 materials
   - Use separate chat threads for different roles
   - Lead Developer reviews Implementer's work

2. **Reusable Prompts** (15 min)
   - Exercise 8.3 from Session 1 materials
   - Show: Creating prompt templates
   - Demo: Thread dump for context handoff

3. **Multi-Model Workflows** (15 min)
   - Exercise 7.3 from Session 1 materials
   - Use different models for different tasks:
     - o1/Claude for deep reasoning
     - GPT-4/Sonnet for implementation
   - Show how to switch models mid-workflow

#### Part 7: Real-World Application and Wrap-Up (45 minutes)

**Group Exercise: Plan Your Own Feature (30 min)**
Students work in pairs:
1. Choose a feature to add (weather history, notifications, etc.)
2. Use Lead Developer to create a plan
3. Present approach to the group
4. Get feedback

**Best Practices Discussion (15 min)**
- When to use agent workflows vs simple Chat
- How to structure prompts effectively
- Dealing with agent confusion
- Version control for prompt templates
- Team collaboration strategies

**Session 2 Wrap-Up:**
- What's the biggest benefit of agent workflows?
- How will you apply this to your projects?
- Resources for continued learning

### Session 2 Timing Summary
- Introduction: 30 min
- Feature Planning: 60 min
- Break: 15 min
- Implementation: 75 min
- Testing & QA: 60 min
- Break: 15 min
- Performance (VS only): 45 min
- Advanced Techniques: 45 min
- Real-World Application: 45 min
- **Total: 5 hours 30 minutes** (adjust based on group and IDE)

### Common Session 2 Challenges and Solutions

| Challenge | Solution |
|-----------|----------|
| Agent produces inconsistent results | Start fresh sessions, clearer role definitions, better context |
| Tasks too large or unclear | Go back to Lead Developer, ask for task breakdown |
| Students struggle with workflow | Provide flowchart handout, walk through step-by-step |
| Different IDEs in same class | Focus on concepts, not specific commands. Pair VS/VS Code users |
| Profiler Agent not available | Skip Exercise 3 or demonstrate with manual profiling concepts |
| Time management issues | Prioritize Exercises 1-2, make Exercise 3 optional |

---

## Teaching Tips and Best Practices

### General Advice

1. **Live Coding is Essential**
   - Don't just show slides—demonstrate everything
   - Make mistakes intentionally to show problem-solving
   - Let students see your thought process

2. **Pace Management**
   - Check in frequently: "Everyone with me?"
   - Use polls/hand raises to gauge understanding
   - Have backup exercises ready for fast finishers

3. **Encourage Exploration**
   - "There's no one right way to use Copilot"
   - Celebrate creative solutions
   - Share interesting discoveries students make

4. **Handle Failures Gracefully**
   - When Copilot gives wrong answers: teaching opportunity!
   - Show how to refine prompts
   - Emphasize: You're still in control

### For Remote Teaching

1. **Screen Sharing**
   - Share your IDE full screen
   - Use zoom features to highlight sections
   - Record sessions for later review

2. **Engagement Strategies**
   - Breakout rooms for pair exercises
   - Use chat for questions during demos
   - Quick polls to check understanding

3. **Technical Issues**
   - Have a backup plan (pre-recorded demos)
   - Share your working repository if builds fail
   - Co-host can help with individual issues

### For In-Person Teaching

1. **Room Setup**
   - Ensure everyone can see the screen
   - Walk around during exercises
   - Encourage peer learning

2. **Energy Management**
   - Stand and move during teaching
   - Use varied teaching methods (demo, hands-on, discussion)
   - Monitor for fatigue

### Assessment and Follow-Up

**During Sessions:**
- Quick checks: "Show me your screen" or "thumbs up if working"
- Observe: Are students completing exercises?
- Ask: "What questions do you have?"

**After Session 1:**
- Optional quiz on basic concepts
- Encourage practice with homework
- Set up a Slack/Teams channel for questions

**After Session 2:**
- Capstone project: Implement a feature using agent workflows
- Peer code review of implementations
- Share learnings with team

**Long-Term:**
- Schedule follow-up session in 1 month
- Create internal knowledge base of prompts
- Build library of custom chatmodes/prompts for your org

---

## Customization for Your Organization

### Industry-Specific Examples

**Financial Services:**
- Add compliance checking examples
- Security-focused prompts
- Audit trail workflows

**Healthcare:**
- HIPAA compliance scenarios
- Patient data handling
- Medical terminology assistance

**E-commerce:**
- Shopping cart implementation
- Payment gateway integration
- Inventory management

### Team-Specific Adjustments

**Junior Developers:**
- Spend more time on Session 1 fundamentals
- Provide more guided exercises
- Focus on understanding over speed

**Senior Developers:**
- Fast-track through Session 1 basics
- Deep dive on advanced prompting
- Focus on prompt engineering and customization

**Mixed Experience:**
- Pair juniors with seniors
- Offer "fast track" and "detailed" paths
- Prepare bonus advanced exercises

---

## Resources and Materials

### Handouts to Prepare

1. **Quick Reference Card**
   - Common slash commands
   - Chat variables
   - Keyboard shortcuts

2. **Workflow Diagrams**
   - Agent-based workflow flowchart
   - When to use which mode/agent

3. **Prompt Template Library**
   - Examples of effective prompts
   - Role-based prompt starters

### Links to Share

- GitHub Copilot Documentation: https://docs.github.com/copilot
- This repository: https://github.com/EficodeDemoOrg/csharp-copilot-training
- .NET Documentation: https://learn.microsoft.com/dotnet
- Community best practices: (your org's internal wiki)

### Preparation Checklist for Each Session

**One Week Before:**
- [ ] Send prerequisites email to students
- [ ] Test all exercises on your machine
- [ ] Prepare any custom examples for your org
- [ ] Set up communication channel (Slack, Teams)

**One Day Before:**
- [ ] Verify room/virtual meeting setup
- [ ] Test screen sharing and recording
- [ ] Print/share handouts
- [ ] Prepare backup plans for technical issues

**Morning Of:**
- [ ] Arrive 15 minutes early
- [ ] Test projector/screen sharing
- [ ] Have the repository open and ready
- [ ] Start with a clean working directory

---

## Troubleshooting Guide for Educators

### Copilot Not Working

**Symptoms:** No suggestions appearing
**Solutions:**
1. Check GitHub Copilot extension is installed
2. Verify license is active: Settings → GitHub Copilot
3. Restart IDE
4. Check internet connection
5. Try signing out and back in to GitHub

### Build Failures

**Symptoms:** `dotnet build` fails
**Solutions:**
1. Ensure .NET 8 SDK is installed: `dotnet --version`
2. Clean solution: `dotnet clean`
3. Restore packages: `dotnet restore`
4. Check for typos in generated code
5. Share your working copy with student

### Performance Issues

**Symptoms:** Copilot slow to respond
**Solutions:**
1. Check internet speed
2. Close unnecessary applications
3. Use lighter context (fewer files)
4. Switch to faster model if available

### Confusion About IDE Differences

**VS Code vs Visual Studio:**
- **Commands differ**: `/new` vs `/generate`
- **Shortcuts differ**: Document in handout
- **Chatmodes**: VS Code only (for now)
- **Profiler Agent**: VS 2026 Insiders only
- **Core concepts**: Same for both!

---

## Success Metrics

### Immediate (End of Training)
- [ ] 90%+ students can generate code with inline suggestions
- [ ] 80%+ students can use Chat effectively
- [ ] 70%+ students understand agent workflows (Session 2)
- [ ] Positive feedback on training quality

### Short-Term (1 Month After)
- [ ] Students using Copilot in daily work
- [ ] Reduced time for common coding tasks
- [ ] Increased code quality (fewer bugs)
- [ ] Students creating own prompt templates

### Long-Term (3-6 Months After)
- [ ] Team productivity improvement
- [ ] Standardized agent workflows adopted
- [ ] Internal prompt library established
- [ ] Junior developers onboarding faster

---

## FAQ for Educators

**Q: What if students have different IDEs?**
A: Focus on concepts that apply to both. Demonstrate in one IDE, but emphasize the underlying principles. Pair VS Code and Visual Studio users together.

**Q: How much C# knowledge do students need?**
A: Basic understanding of C#, classes, and methods. They don't need to be experts—Copilot will help with syntax!

**Q: Can I extend this to 3 sessions?**
A: Absolutely! Consider:
- Session 1: Basics (Phases 1-5 from Exercise 1)
- Session 2: Advanced Features (Phases 6-9 from Exercise 1)
- Session 3: Agent Workflows (All of Exercise 2)

**Q: What if Copilot suggests wrong code?**
A: Great learning moment! Show how to:
1. Recognize the issue
2. Refine the prompt
3. Provide better context
4. Review suggestions critically

**Q: Should I use real production code?**
A: Not for initial training. Use this sandbox repo first. Later, apply to real projects with guidance.

**Q: How do I handle security concerns?**
A: Emphasize:
- Never paste sensitive data into Chat
- Review all suggestions for security issues
- Use Copilot for learning, not blind copy-paste
- Your organization's security policies apply

---

## Conclusion

This training is designed to transform how developers work with AI-assisted coding. By the end of two sessions, your students will:
- Write code faster with inline suggestions
- Leverage Chat for complex problems
- Use agent workflows for large features
- Apply prompt engineering skills
- Understand when and how to use each Copilot feature

**Remember**: Copilot is a tool that augments developers, not replaces them. Your role as educator is to help students become effective AI-assisted developers who maintain control, think critically, and write quality code.

Good luck with your training sessions! 🚀

---

## Appendix: Session Slides Outline

### Session 1 Slides (15-20 slides)
1. Title: GitHub Copilot Fundamentals
2. About the Trainer
3. Agenda Overview
4. What is GitHub Copilot?
5. How Copilot Works (architecture diagram)
6. Project Overview
7. Inline Suggestions Demo
8. Chat Modes Comparison
9. Slash Commands Reference
10. Context Variables Explained
11. Best Practices
12. Common Mistakes to Avoid
13. Exercise Time! (blank slide while students work)
14. Q&A
15. Session 1 Recap
16. Homework / Next Steps

### Session 2 Slides (15-20 slides)
1. Title: Advanced Agent Workflows
2. Session 1 Recap Quiz
3. Agenda Overview
4. What are Agent Workflows?
5. Multi-Agent Architecture
6. Lead Developer Agent Role
7. Implementer Agent Role
8. QA Agent Role
9. Workflow Diagram (full cycle)
10. When to Use Agents vs Simple Chat
11. Prompt Engineering Best Practices
12. Demo: Epic Creation
13. Exercise Time! (blank slide while students work)
14. Profiler Agent (Visual Studio only)
15. Real-World Applications
16. Best Practices Recap
17. Q&A
18. Next Steps / Resources
19. Feedback Survey

---

**Version:** 1.0  
**Last Updated:** 2026-01-12  
**Maintainer:** GitHub Copilot Training Team
