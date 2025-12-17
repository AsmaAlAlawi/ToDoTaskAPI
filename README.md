ToDo Tasks
 *Overview

The ToDo Tasks System is a simple application designed to help users manage their tasks efficiently.
It allows users to add, update, view, and delete tasks, making it easier to organize and track daily responsibilities.

The project is built using C#, connected to a Database, and exposes functionality through a RESTful API.

 *Features

 Add new daily tasks

Update existing tasks

Delete tasks

View all tasks

RESTful API for task management

Persistent data storage using a database

 *Technologies Used

C#

ASP.NET Web API

Database ( SQL Server)

Entity Framework (if applicable)

RESTful API

📂 Project Structure
/DailyTasksProject
│── Controllers
│── Models
│── Data
│── Services
│── Program.cs
│── appsettings.json

* API Endpoints
Method	Endpoint	Description
GET	/api/tasks	Get all tasks
POST	/api/tasks	Add a new task
PUT	/api/tasks/{id}	Update a task
DELETE	/api/tasks/{id}	Delete a task


* Usage

Use tools like Postman or Swagger to test the API.

Perform CRUD operations to manage daily tasks.
