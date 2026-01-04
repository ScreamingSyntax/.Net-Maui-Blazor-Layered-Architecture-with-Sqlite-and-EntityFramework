

```markdown
# Layered .NET MAUI Blazor App with SQLite & Entity Framework Core

A clean, maintainable cross-platform application built with **.NET MAUI + Blazor Hybrid**, using **SQLite** for local data persistence and **Entity Framework Core** as the ORM — all following a proper layered architecture.

Perfect for learning or as a reference for offline-first MAUI apps with separation of concerns, dependency injection, async operations, and consistent service responses.

## Features
- Clean layered architecture (UI → Services → Data → Entities)
- Blazor Hybrid UI with form validation & data binding
- SQLite local database (stored in app data folder)
- EF Core for CRUD operations
- ServiceResult<T> pattern for standardized success/error handling
- ViewModel ↔ Entity mapping
- Dependency Injection via MauiProgram.cs
- Simple user management demo (Add, List, Delete)

## Project Structure
```
MauiApp8/
├── Common/               → ServiceResult<T> wrapper
├── Entities/             → Database models (User.cs)
├── Models/               → UI-specific models (ViewModel & DisplayModel)
├── Data/                 → AppDbContext (EF Core configuration)
├── Services/             → Business logic & data access (UserService)
├── Pages/                → Blazor components (Users.razor)
└── MauiProgram.cs        → App startup & DI registration
```

## Tech Stack
- .NET 9 (or .NET 8+)
- .NET MAUI Blazor Hybrid
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Blazor components with DataAnnotations validation

## Getting Started

### Prerequisites
- .NET 9 SDK (or latest .NET 8)
- Visual Studio 2022 (with MAUI workload) or JetBrains Rider
- Android/iOS/Windows emulator or physical device

### Installation
1. Clone the repository
   ```
   git clone https://github.com/ScreamingSyntax/.Net-Maui-Blazor-Layered-Architecture-with-Sqlite-and-EntityFramework.git
   cd .Net-Maui-Blazor-Layered-Architecture-with-Sqlite-and-EntityFramework
   ```

2. Restore packages
   ```
   dotnet restore
   ```

3. Build & run
   ```
   dotnet build
   dotnet run --project MauiApp8
   ```
   Or open the solution in Visual Studio/Rider and run/debug.

The database (`app.db`) will be automatically created in your local app data folder on first run.

## Detailed Guide
Full step-by-step walkthrough including code explanations, diagrams (Mermaid), and best practices:  
→ [Read the Medium Article](https://medium.com/@yourusername/building-a-layered-maui-blazor-app-with-sqlite-and-entity-framework-core-...)  
*(Replace with your actual Medium link once published)*

## Screenshots / Demo
(Add your screenshots here – drag & drop images into GitHub when editing README)

## Contributing
Feel free to open issues or submit pull requests!  
Especially welcome:  
- Adding Edit/Update functionality  
- Implementing EF Core migrations  
- Adding search/filter  
- Unit/integration tests

## License
MIT License – feel free to use this as a starting point for your own projects.

---

Built with ❤️ by Aaryan Jha  
Happy coding! 🚀
```

### Quick Fix for Copy-Paste Issues
If indentation still breaks when you paste:
- Use a plain text editor (Notepad++, VS Code, etc.) instead of Word/Google Docs
- After pasting, select all → press `Tab` to indent or `Shift+Tab` to outdent if needed
- GitHub renders Markdown perfectly once the file is saved as `.md`

This version should paste cleanly 99% of the time. Let me know if you still face issues — I can make it even simpler or split it into smaller parts! Good luck with the repo! 🚀
