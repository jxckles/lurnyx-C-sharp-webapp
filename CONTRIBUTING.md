# Lurnyx - C# and Project Coding Conventions

## 1. Introduction

This document outlines the standard coding conventions and best practices for the Lurnyx project. The purpose of these standards is to ensure our codebase is consistent, readable, and easy to maintain for all team members.

---

## 2. C# Naming Conventions

We will follow the standard Microsoft C# naming conventions.

### 2.1. PascalCase

Use `PascalCase` for all public members, types, and classes.

- **Classes, Structs, Enums, Records:**

  ```csharp
  public class TrainingService { }
  public enum UserRole { }
  ```

- **Methods & Properties:**

  ```csharp
  public int TrainingId { get; set; }
  public async Task<User> GetUserByIdAsync(int id) { }
  ```

- **Constants (`public const`, `public static readonly`):**
  ```csharp
  public const int DefaultPageSize = 20;
  ```

### 2.2. camelCase

Use `camelCase` for local variables and method parameters.

```csharp
public void UpdateUser(int userId, UserDto updatedUser)
{
    var userFromDb = _repository.GetUserById(userId);
    // ...
}
```

### 2.3. Private and Internal Fields

Private or internal fields must be prefixed with an underscore (`_`) and use `camelCase`.

```csharp
public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly ILogger<TrainingService> _logger;

    public TrainingService(ITrainingRepository trainingRepository, ILogger<TrainingService> logger)
    {
        _trainingRepository = trainingRepository;
        _logger = logger;
    }
}
```

### 2.4. Interfaces

Interface names must be prefixed with a capital `I` and use `PascalCase`.

```csharp
public interface IUserService
{
    // ...
}
```

### 2.5. Asynchronous Methods

All methods that are awaitable must have the `Async` suffix.

```csharp
public async Task<bool> SaveChangesAsync()
{
    // ...
}
```

---

## 3. File and Folder Naming Conventions

### 3.1. File Naming

- C# file names must match the name of the public class they contain (e.g., `TrainingService.cs` contains the `TrainingService` class).
- Partial view files must be prefixed with an underscore (e.g., `_Layout.cshtml`, `_CardPartial.cshtml`).

### 3.2. Folder Naming

- All folder names should use `PascalCase` (e.g., `Controllers`, `Services`, `Dto`).

- **ViewModels:** These are specific to the UI and live in the `Lurnyx.WebApp` project. They should be organized into sub-folders based on their feature or controller.

  - `Lurnyx.WebApp/Models/ViewModels/Auth/LoginViewModel.cs`
  - `Lurnyx.WebApp/Models/ViewModels/Users/ChangePasswordViewModel.cs`

- **Data Transfer Objects (DTOs):** These are used to transfer data to and from the service layer. They live in the `Lurnyx.Services` project.
  - `Lurnyx.Services/ServiceModels/Users/UserDto.cs`
  - `Lurnyx.Services/ServiceModels/Trainings/TrainingDto.cs`

---

## 4. C# Best Practices

### 4.1. File Organization & `using` Directives

- Organize `using` statements with system namespaces first, followed by third-party libraries, and finally our own project's namespaces.

### 4.2. Asynchronous Programming

- **Always** use the `async` and `await` keywords for I/O-bound operations, including database calls (`ToListAsync`, `SaveChangesAsync`), file access, and external API calls.
- Controller actions that perform I/O should return `Task<IActionResult>`.

### 4.3. Dependency Injection (DI)

- Services, repositories, and other dependencies should always be injected into a class via its constructor. Never use `new` to instantiate a service or repository.

  ```csharp
  // Correct way
  public class AccountController : Controller
  {
      private readonly IUserService _userService;

      public AccountController(IUserService userService)
      {
          _userService = userService;
      }
  }
  ```

### 4.4. Controllers

- Controllers should be "thin." Their job is to handle web requests, call a service, and return a response.
- **No business logic** should be in controllers. Delegate all logic to the `Lurnyx.Services` layer.
- Controllers receive and return **ViewModel** objects to the Views.
- When communicating with services, controllers are responsible for mapping ViewModels to DTOs (for sending data) and mapping DTOs to ViewModels (for displaying data).

### 4.5. Services

- The `Lurnyx.Services` project contains all business logic.
- A service method takes input (primitive types or DTOs), performs operations, and returns a result (typically a DTO or a collection of DTOs).

### 4.6. Repositories

- The `Lurnyx.Data` project contains repositories. A repository's only responsibility is to execute database operations (CRUD - Create, Read, Update, Delete).
- Repositories should not contain any business logic.

---

## 5. Data Transfer Objects (DTOs)

- **Purpose:** DTOs are the data contracts for our service layer. They define the shape of data moving between the web application layer and the service layer. This decouples our business logic from the specific needs of the UI.
- **Location:** All DTOs reside in the `Lurnyx.Services/ServiceModels/` directory.
- **Usage:** Services accept DTOs as parameters and return DTOs as results. They contain no behavior and are only used for carrying data.

---

## 6. ViewModels

- **Purpose:** ViewModels are classes specifically designed to carry data to and from a View. They are tailored to the needs of the UI, containing only the data and properties required for a specific screen.

- **Usage Flow:**
  1. A controller action receives a ViewModel from a user's form submission or prepares a ViewModel to be displayed.
  2. The controller maps the ViewModel to a DTO before passing it to a service.
  3. When retrieving data, a service returns a DTO to the controller.
  4. The controller then maps that DTO to a ViewModel before passing it to the View.
