# TaskManager
The Task Manager RESTful API designed to manage a list of tasks. This project is implemented in C# using Microsoft .NET 6 and follows the Onion Architecture pattern to ensure modularity and maintainability.

## Description

The Task Manager Web provides a solution for managing tasks. It allows users to create, retrieve, update, and delete tasks while also providing extended information about each task. Key features include:

- **Add New Task:** Easily add new tasks to the list, including task name, description, start date, allotted time, and more.

- **List All Tasks:** Retrieve a list of all tasks with detailed information, including end date, due date, days overdue, and days late.

- **Get Task By ID:** Retrieve detailed information about a specific task using its unique ID.

- **Delete Task By ID:** Remove a task from the list based on its ID.

## Table of Contents
Features
Getting Started
Prerequisites
Installation
Configuration
Usage
API Documentation
Architecture

## Features
Add New Task
List All Tasks with extended task information
Get Task By ID with extended task information
Delete Task By ID
Calculate task parameters such as End Date, Due Date, Days Overdue, and Days Late

## Getting Started
## Prerequisites
.NET 6 SDK
Your preferred code editor (e.g., Visual Studio, Visual Studio Code)
Clone this project and run it.

## Usage
You can use tools like Postman or curl to interact with the Task List Manager API. Below are some common API endpoints:

POST /todo: Add a new task.
GET /todo: List all tasks with extended information.
GET /todo/{id}: Get a task by ID with extended information.
DELETE /todo/{id}: Delete a task by ID.

## Architecture
This project follows the Onion Architecture pattern to ensure separation of concerns, modularity, and maintainability. It consists of the following layers:

Core: Contains the domain models, business logic, and application contracts (interfaces).
Service: Contains services responsible for handling specific business operations or external integrations.
Infrastructure: Implements data access, external service integration, cross-cutting concerns, and repository implementations.
Application: Provides the API endpoints and acts as the entry point for external clients.

## Design
Please refer to the "TaskManagerDesign" file in the root of the project.


