# Lurnyx - Knowledge Site

This project is the primary codebase for the Lurnyx application, originally based on the ASI Bridge/JumpStart Program BaseCode. This guide provides instructions for setting up and running the project.

---

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET 6.0 SDK
- node or npm
- Visual Studio 2022 or Visual Studio Code
- Docker and Docker Compose (for non-Windows users)

---

## Installation and First-Time Setup

Follow these steps in order to get the project running on your local machine.

### 1. Rename the Project

The first and most important step is to rename the solution from the generic `ASI.Basecode` template to `Lurnyx`. We have an automated script for this.

> **Note for Linux/macOS users:** You may need to make the script executable first by running:

```bash
chmod +x rename_project.sh
```

From the root directory of the project, run the script:

```bash
./rename_project.sh
```

This will rename all projects, files, and namespaces automatically.

### 2. Database Setup

#### For Windows Users (with Visual Studio)

Your local SQL Server Express (LocalDB) instance that comes with Visual Studio should work out of the box. Proceed to the next step.

#### For Linux, macOS, and Docker Users

1.  Make sure Docker and Docker Compose are installed on your system.
2.  There is a `docker-compose.yml` file in the project's root directory. Open it and set a strong `SA_PASSWORD`.
3.  Open a terminal in the root directory and start the database container:
    ```bash
    docker compose up -d
    ```
    This will download and start a SQL Server instance running in the background.

### 3. Configure App Secrets (appsettings.json)

The `appsettings.json` file contains secrets like your database connection string and is **not** included in source control. You must create this file locally by using the development template.

1.  Navigate to the `Lurnyx.WebApp` folder.
2.  Create a new file named `appsettings.json`.
3.  Copy the entire content from `appsettings.Development.json` and paste it into your new `appsettings.json` file.
4.  Modify the necessary configuration sections as described below.

### Database Connection

**Example `DefaultConnection` for Docker users:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=LurnyxDB;User Id=sa;Password=YOUR_STRONG_PASSWORD_HERE;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

> **Important:** Replace `YOUR_STRONG_PASSWORD_HERE` with the `SA_PASSWORD` set in the `docker-compose.yml` file.

### Supabase and Email Configuration

You must also fill in the credentials for file storage (Supabase) and email sending (Gmail SMTP).

```base
"SmtpSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Lurnyx",
    "SenderEmail": "your-email@gmail.com",
    "Username": "your-email@gmail.com",
    "Password": "your gmail app password"
},
 "Supabase": {
    "ProjectName": "Lurnyx",
    "DatabasePassword": "your-supabase-database-password",
    "Url": "YOUR_SUPABASE_URL",
    "ApiKey": "YOUR_SUPABASE_API_KEY",
    "ImageBucketName": "lurnyx-images",
    "FileBucketName": "lurnyx-files"
  }

```

- Gmail App Password: To get a password for the SmtpSettings, you must enable 2-Factor Authentication on your Google Account and then generate an "App Password". Do not use your regular account password.

- Supabase Credentials: Get your URL and public ApiKey from your Supabase project dashboard under Project Settings > API.

### 4. Apply Database Migrations

Once the database is running and the connection string is set, you need to create the database schema.

1.  **Install EF Core Tools Locally:** The project requires a specific version of the Entity Framework tools. Open a terminal in the root directory and run these commands to install it locally for the project:

    ```bash
    dotnet new tool-manifest
    dotnet tool install dotnet-ef --version 6.0.25
    ```

2.  **Create the First Migration:** This command generates the initial database schema from your C# models.

    ```bash
    dotnet ef migrations add InitialCreate --project Lurnyx.Data --startup-project Lurnyx.WebApp
    ```

3.  **Update the Database:** This command applies the migration to your database, creating the tables.
    ```bash
    dotnet ef database update --project Lurnyx.Data --startup-project Lurnyx.WebApp
    ```

### 5. Restore Dependencies

Open a terminal in the root directory and run the `dotnet restore` command. This will download all the necessary packages for the solution.

```bash
dotnet restore
```

### 6. Frontend Asset Setup (Tailwind CSS)

This project uses Tailwind CSS for styling. You'll need to install the npm packages and run the build script.

1. Install Frontend Dependencies: From the root directory, run the following command. This will download all the necessary packages defined in package.json, including Tailwind CSS.
   ```bash
   npm install
   ```
2. Build and Watch CSS: This command will compile the input.css file into output.css and will continue watching for any changes you make to your view files or the input CSS. It's recommended to keep this running in a separate terminal while you are doing frontend development.
   ```bash
   npx tailwindcss -i Lurnyx.WebApp/wwwroot/css/input.css -o Lurnyx.WebApp/wwwroot/css/output.css --watch
   ```

### 7. Run the Application

#### For Visual Studio Users

1.  Open the `Lurnyx.sln` file in Visual Studio 2022.
2.  In the Solution Explorer, right-click the **`Lurnyx.WebApp`** project and select "Set as Startup Project".
3.  Press `F5` or the Run button to build and launch the application.

#### For Visual Studio Code Users

1.  Open the root `lurnyx` folder in VS Code.
2.  Install the recommended **C# Dev Kit** extension if prompted.
3.  Go to the **Run and Debug** view (`Ctrl+Shift+D`).
4.  A pre-configured launch profile named **"Lurnyx: Launch Web App"** should be available in the dropdown.
5.  Press the green play button or `F5` to build and launch the application.

---

## Code Structure (From Alliance Software Inc. Base Code)

The solution is divided into four main projects, promoting a clean separation of concerns.

- **`Lurnyx.WebApp`**
  - This is the main ASP.NET Core MVC project, containing the `Controllers` and `Views`. The controllers should be lightweight, acting as a bridge between the user interface and the `Lurnyx.Services` layer. All complex business logic should be delegated to the service layer.
- **`Lurnyx.Infrastructure`**
  - This project contains the concrete implementations for services that communicate with external systems. It implements the interfaces defined in the `Lurnyx.Services` project.
- **`Lurnyx.Services`**
  - This project contains the core business logic. It processes data and performs operations before sending data to or receiving it from the `Lurnyx.Data` repositories.
- **`Lurnyx.Data`**
  - This project contains the repositories, database context (`LurnyxDbContext`), and other logic that interacts directly with the database. Repositories should only be used for data processing (CRUD operations).
- **`Lurnyx.Resources`**
  - A dedicated project for storing messages, labels, and other resources used by the website. It serves as a centralized location for managing static content and localization strings.
