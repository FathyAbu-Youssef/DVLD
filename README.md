# 🚗 Drivers And Vehicle License Department (DVLD) System

**A Desktop Application for License Management**

## ✨ Project Showcase & Overview

This project is a full-scale **Desktop Application** designed to simulate the operations of a real-world Drivers And Vehicle License Department (DVLD). It serves as a practical demonstration of applying core **C#**, **Object-Oriented Programming (OOP)**, and **3-Tier Architecture** principles.

## 💡 Core Business Logic & Challenges

The complexity of this project lies in managing the strict sequential flow and business rules. The most significant challenge was implementing the **New Local Driving License Application** workflow:

1.  **Application Initiation:** Processing applications for various license classes (Ordinary, Motorcycle, Commercial).
2.  **Sequential Testing:** Enforcing a dependency chain where the applicant must pass 3 distinct tests: Vision, Written/Theoretical, and Street/Practical.
3.  **Retake Management:** Handling test failures by requiring a specific **Retake Test Application** and calculating associated fees before a new appointment can be scheduled.
4.  **License Issuance:** Validating the successful completion of all tests and updating the database to issue the license, including adding the person to the `Drivers` table if they are a first-time applicant.
5.  **Additional Features:** Implementation of **Detain/Release License** and **Lost/Damaged License Replacement** processes.

## 🛠 Technology Stack

| Category | Technology | Purpose & Implementation |
| :--- | :--- | :--- |
| **Frontend** | **C# / Windows Forms (WinForms)** | Desktop application UI development. |
| **Architecture** | **3-Tier Architecture** | Separation into Presentation, Business Logic (BLL), and Data Access (DAL) layers for maintainability and scalability. |
| **Data Access** | **ADO.NET (Raw SQL)** | Used raw SQL queries |
| **Database** | **SQL Server** | Relational Database Management System (RDBMS). |

## 🚀 Getting Started (Local Setup)

To run this project on your local machine, follow these steps:

1.  **Clone the Repository:** Locate the repository folder on your machine after downloading.
2.  **Database Deployment:**
    * The application is designed to execute the necessary SQL script upon first run if the database is not found, or the developer can run the `DVLD_Schema_Setup.sql` manually.
3.  **Connection String:**
    * The project uses **Integrated Security=True** (Windows Authentication), which simplifies the setup as no explicit SQL user credentials are required in the connection string.
4.  **Run:**
    * Open the solution in Visual Studio and press **F5** to start the application.
    * Enter     UserName:***Fathy2003***     Password:***1234***

---
