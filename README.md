# Smart Task Manager - Backend API

This is the backend API for **Smart Task Manager**, a task and project management system built with ASP.NET Core and Entity Framework Core. It provides secure JWT-based authentication and RESTful endpoints to manage users, projects, and tasks.

---

## 🔧 Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core** (SQL Server)
- **JWT Authentication**
- **Dependency Injection**
- **Swagger / OpenAPI**

---

## ✨ Features

- User registration and secure login with JWT tokens
- Role-based access control (Admin/User)
- CRUD operations for:
  - Users (Admin only)
  - Projects
  - Tasks
- Integrated Swagger documentation
- Clean architecture with repository pattern

---

## 📂 Project Structure

```text
SmartTaskManager.API/
├── Controllers/
├── Data/
├── DTOs/
├── Model/
├── Repositories/
├── Services/
├── Program.cs
├── appsettings.json
└── README.md
🚀 Getting Started
Prerequisites
.NET 7 SDK

SQL Server

Visual Studio 2022+

Git

Setup Instructions
Clone the repository

git clone https://github.com/your-username/SmartTaskManager-Backend.git
cd SmartTaskManager-Backend
Set up the database connection

Update your appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SmartTaskManagerDb;Trusted_Connection=True;"
}
Apply migrations and update the database

bash
Copy
Edit
dotnet ef database update
Run the application

dotnet run
The API will run at:
https://localhost:7260/

🔐 Authentication
The API uses JWT Bearer Tokens.

After login, include your token in the Authorization header:

Authorization: Bearer <your_token>
Swagger UI allows you to test endpoints with your token.
Click Authorize, paste your token (no need to include Bearer), and you’re ready to go.

📬 API Endpoints
Method	Endpoint	Description	Auth Required
POST	/api/Auth/register	Register a new user	❌ No
POST	/api/Auth/login	Login and receive JWT token	❌ No
GET	/api/User	Get all users (Admin only)	✅ Yes
GET	/api/Project	List projects	✅ Yes
POST	/api/Task	Create a new task	✅ Yes

Full API docs available at:
https://localhost:7260/swagger

📄 License
This project is licensed under the MIT License.

🙌 Contributing
Pull requests and contributions are welcome!
If you find a bug or want to add a feature, feel free to open an issue or submit a PR.

SmartTaskManager Backend — built with ❤️ using ASP.NET Core.


---

### ✅ Next Steps:

1. Save this as a file named `README.md` in your project root.
2. Commit and push it:

```bash
git add README.md
git commit -m "Add professional project README"
git push
