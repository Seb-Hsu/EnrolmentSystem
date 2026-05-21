# Student Enrolment System

A RESTful Web API built with ASP.NET Core for managing student enrolments, courses, and academic records. Developed as part of the Diploma of Information Technology (Advanced Programming) at TAFE SA.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Database](#database)
- [Testing](#testing)
- [Author](#author)

---

## Overview

The Student Enrolment System provides a backend API for managing the core operations of an educational institution — including student registration, course management, and enrolment tracking. The system follows RESTful design principles and uses Entity Framework Core for data persistence.

---

## Features

- Create, read, update, and delete (CRUD) student records
- Manage course listings and availability
- Enrol and withdraw students from courses
- Retrieve enrolment history per student
- Input validation and structured error responses
- Swagger/OpenAPI documentation for all endpoints

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 8) |
| Language | C# |
| ORM | Entity Framework Core |
| Database | SQL Server |
| API Docs | Swagger / Swashbuckle |
| Testing | Postman |
| Version Control | Git / GitHub |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-au/sql-server/sql-server-downloads) (or SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/student-enrolment-system.git
   cd student-enrolment-system
   ```

2. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=StudentEnrolmentDB;Trusted_Connection=True;"
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open the Swagger UI in your browser:
   ```
   https://localhost:{port}/swagger
   ```

---

## API Endpoints

### Students

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/students` | Get all students |
| GET | `/api/students/{id}` | Get student by ID |
| POST | `/api/students` | Create a new student |
| PUT | `/api/students/{id}` | Update student details |
| DELETE | `/api/students/{id}` | Delete a student |

### Courses

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/courses` | Get all courses |
| GET | `/api/courses/{id}` | Get course by ID |
| POST | `/api/courses` | Create a new course |
| PUT | `/api/courses/{id}` | Update course details |
| DELETE | `/api/courses/{id}` | Delete a course |

### Enrolments

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/enrolments` | Get all enrolments |
| GET | `/api/enrolments/student/{studentId}` | Get enrolments by student |
| POST | `/api/enrolments` | Enrol a student in a course |
| DELETE | `/api/enrolments/{id}` | Withdraw a student from a course |

---

## Project Structure

```
StudentEnrolmentSystem/
├── Controllers/
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   └── EnrolmentsController.cs
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   └── Enrolment.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── StudentDto.cs
│   ├── CourseDto.cs
│   └── EnrolmentDto.cs
├── Migrations/
├── appsettings.json
├── Program.cs
└── README.md
```

---

## Database

The system uses SQL Server with Entity Framework Core (Code First). The schema includes three core tables:

- **Students** — stores student personal and contact information
- **Courses** — stores course name, code, and capacity
- **Enrolments** — junction table linking students to courses, with enrolment date and status

To regenerate migrations from scratch:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Testing

API endpoints were tested using **Postman**. A Postman collection covering all CRUD operations is included in the `/postman` directory (if applicable).

To run any automated tests:

```bash
dotnet test
```

---

## Author

**Che-Hao (Sebastian) Hsu**
Diploma of Information Technology (Advanced Programming) — TAFE SA
[LinkedIn](https://linkedin.com/in/your-profile) · [GitHub](https://github.com/your-username)
