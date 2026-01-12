# Quick Start Guide for Educators

## TL;DR - Teaching This Repo in 2 Sessions

### Session 1: Fundamentals (3-4 hours)
**Goal:** Get students comfortable with basic Copilot features

**Materials:** 
- VS Code: `github_copilot_exercises.md`
- Visual Studio: `VS_github_copilot_exercises.md`

**What to Cover:**
1. Inline suggestions and auto-complete
2. Copilot Chat basics (Ask/Edit/Agent modes)
3. Slash commands (`/explain`, `/doc`, `/fix`, `/tests`, `/new`)
4. Context variables (`#file`, `#selection`, `@workspace`)
5. Custom instructions setup

**Key Exercises:** 1.1-1.6, 2.1-2.4, 3.1, 5.1-5.2

**End Goal:** Students can write code faster and get help from Copilot

---

### Session 2: Advanced Workflows (3-4 hours)
**Goal:** Teach structured multi-agent development for complex features

**Materials:**
- VS Code: `github_copilot_exercises_2.md`
- Visual Studio: `VS_github_copilot_exercises_2.md`

**What to Cover:**
1. Agent-based development (Lead Developer, Implementer, QA roles)
2. Breaking features into tasks
3. Systematic implementation and testing workflows
4. Performance optimization with Profiler Agent (VS 2026 Insiders only)

**Key Exercises:** Exercise 1 (complete), Exercise 2 (complete)

**End Goal:** Students can use agent workflows to build entire features

---

## Before You Start

### 1 Week Before Training
- [ ] Send prerequisites email (see EDUCATOR_GUIDE.md)
- [ ] Verify students have Copilot access
- [ ] Test all exercises yourself
- [ ] Prepare custom examples for your organization

### 1 Day Before Training
- [ ] Test screen sharing setup
- [ ] Clone fresh repo: `git clone https://github.com/EficodeDemoOrg/csharp-copilot-training.git`
- [ ] Verify project builds: `dotnet build`
- [ ] Print/share quick reference handouts

### Morning of Training
- [ ] Arrive 15 minutes early
- [ ] Test projector/screen sharing
- [ ] Have repository open in your IDE
- [ ] Have backup plan ready (recorded demos)

---

## Teaching Strategy

### Live Demo → Guided Practice → Independent Work

**For Each Topic:**
1. **Demo** (5-10 min): Show the feature working
2. **Guided** (10-15 min): Walk through exercise together
3. **Independent** (15-20 min): Students try on their own
4. **Debrief** (5 min): Share results, Q&A

### Common Pitfalls

| Issue | Quick Fix |
|-------|-----------|
| Copilot not working | Check extension, verify license, restart IDE |
| Build fails | Share your working copy or pair students |
| Students at different paces | Prepare bonus exercises for fast finishers |
| Confusing IDE differences | Focus on concepts, not specific commands |

---

## Session Templates

### Session 1 Template

**0:00-0:30** - Welcome & Introduction
- What is Copilot? Demo the "wow" moment
- Project overview
- Set expectations

**0:30-1:15** - Inline Suggestions (Exercises 1.1-1.3)
- Demo → Guided → Independent

**1:15-2:00** - Chat Basics (Exercises 1.4-1.6)
- Ask/Edit/Agent modes
- Custom instructions setup

**2:00-2:15** - BREAK

**2:15-3:15** - Slash Commands (Exercises 2.1-2.4)
- `/explain`, `/doc`, `/fix`, `/tests`, `/new`

**3:15-4:00** - Context Control (Exercise 3.1)
- Chat variables and context hierarchy

**4:00-4:15** - Practical Scenarios & Wrap-Up
- Q&A, homework assignment

### Session 2 Template

**0:00-0:30** - Introduction to Agents
- What are agent workflows?
- Why use multiple agents?

**0:30-1:30** - Feature Planning (Exercise 1, Phase 1)
- Requirements analysis
- Lead Developer planning
- Task breakdown

**1:30-1:45** - BREAK

**1:45-3:00** - Implementation (Exercise 1, Phase 2)
- Implementer agent workflow
- Hands-on: First 2-3 tasks

**3:00-4:00** - Testing & QA (Exercise 2)
- QA agent workflow
- Test implementation
- Debug failures

**4:00-4:15** - BREAK (if needed)

**4:15-4:45** - Advanced Topics
- Performance optimization (VS 2026 Insiders)
- Multi-model workflows
- Best practices

**4:45-5:00** - Wrap-Up
- Group exercise
- Q&A, next steps

---

## Quick Reference: IDE Differences

| Feature | VS Code | Visual Studio |
|---------|---------|---------------|
| **New component** | `/new` | `/generate` |
| **Cycle suggestions** | `Alt+]` / `Alt+[` | `Alt+.` / `Alt+,` |
| **Custom agents** | Chatmodes (.chatmode.md) | Prompt files (.prompt.md) |
| **Profiler Agent** | Not available | VS 2026 Insiders only |
| **Accept word-by-word** | `Ctrl+→` | `Ctrl+Right arrow` |

Both IDEs share:
- Chat concepts (Ask/Edit/Agent)
- Context variables (`#file`, `#selection`, `@workspace`)
- Slash commands (`/explain`, `/doc`, `/fix`, `/tests`)

---

## Success Checklist

### End of Session 1
- [ ] Students can generate code with inline suggestions
- [ ] Students can use Chat for questions and explanations
- [ ] Students understand slash commands
- [ ] Students can provide context with variables

### End of Session 2
- [ ] Students understand agent workflow concept
- [ ] Students can break features into tasks
- [ ] Students can use Implementer agent
- [ ] Students can apply this to their own projects

---

## Emergency Resources

### If Copilot Stops Working
1. Share pre-generated code examples
2. Switch to discussing concepts without live coding
3. Use recorded demos as backup
4. Help students troubleshoot during breaks

### If Running Behind Schedule
**Session 1:** Cut exercises 6-7 (move to homework)
**Session 2:** Cut Exercise 3 (performance), make it optional

### If Running Ahead of Schedule
- Deep dive into prompt engineering (Exercise 8)
- Explore multi-model workflows (Exercise 7.3)
- Start capstone project early
- Open floor for project-specific questions

---

## One-Sentence Summary

**Session 1:** Learn to use Copilot for everyday coding with inline suggestions, chat, and context control.

**Session 2:** Master multi-agent workflows to build complex features systematically with planning, implementation, and testing agents.

---

## Need More Details?

See **EDUCATOR_GUIDE.md** for:
- Comprehensive session plans
- Detailed exercise walkthroughs
- Troubleshooting guide
- Customization for your organization
- Assessment strategies
- Long-term success metrics

---

**Questions?** Check the FAQ section in EDUCATOR_GUIDE.md or open an issue in this repository.

Good luck with your training! 🎓
