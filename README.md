
# Soft Books School System

## 🏫 Comprehensive School Management Software

Soft Books School is a robust school management software designed to streamline and automate core administrative and academic functions for educational institutions of all sizes. This system provides a **dynamic** and **user-friendly** solution for managing daily school operations, improving efficiency and communication across the board.

-----

## ✨ Key Features

This system integrates all aspects of school functions, offering unparalleled flexibility and control:

  * **Centralized Data Management:** Provides a single source of truth for all school data, from student records to staff information and financial details.
  * **Multi-User Client/Server Architecture:** A desktop application built with C\# Windows Forms connects to a central Microsoft SQL Server database for secure, multi-user access.
  * **Comprehensive School Management:**
      * Tracking and management of **student information** (enrollment, attendance, grades).
      * Support for multiple **grading systems** and **evaluation types**.
      * Integrated module for **lesson planning** and **curriculum management**.
  * **Reporting & Analytics:** Provides essential reporting tools for administrators and teachers to track student performance, attendance, and overall school metrics.
  * **Administrative Efficiency:** Designed to ease day-to-day activities by automating repetitive tasks, allowing teachers and staff to focus on teaching and constructive activities.
  * **Scalable Use:** Supports an **unlimited number of students** and **users**, making it suitable for any size of institution.

-----

## 💻 Installation

The installation process involves two main components: the **Microsoft SQL Server Database** (backend) and the **C\# Windows Forms Application** (client).

### Server Setup (SQL Server)

1.  **Install SQL Server:** Install a supported version of Microsoft SQL Server on a central server.
2.  **Restore Database:** Restore the project database from the provided backup file (`SoftBooksSchool.bak`) or run the SQL scripts to create the schema and tables.
3.  **Create User:** Create a dedicated SQL Server user with appropriate permissions for the application to access the database.
4.  **Configure Network Access:** Ensure the server is configured to accept remote connections and that the firewall allows incoming traffic on the SQL Server port (default is **1433**).

### Client Setup (C\# Windows Forms Application)

There are two methods for setting up the client application on a user's workstation:

#### **Method 1: Using the Installer**

The easiest way to install the application is by running the provided installer.

1.  Locate the `setup.msi` file in the project's `dist` or `publish` folder.
2.  Double-click the `setup.msi` file to launch the installation wizard.
3.  Follow the on-screen instructions to complete the installation.
4.  After installation, you may need to manually update the database connection string in the application's configuration file.

#### **Method 2: Building from Source**

This method is recommended for developers who need to modify the code.

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/iProjects/soft_books_school.git
    ```
2.  **Open in Visual Studio:** Open the solution file (`SoftBooksSchool.sln`) in **Visual Studio 2010**.
3.  **Configure Connection String:** Navigate to the application's configuration file (`App.config` or similar) and update the database **connection string** to point to your SQL Server instance.
4.  **Build and Run:** Build the solution and run the application.

-----

## 🚀 Usage

The Soft Books School system provides a user-friendly interface for managing all school-related tasks.

### Administration & Configuration

  * **Users Management:** Create, modify, and manage user accounts with secure access credentials.
  * **Roles & Rights Management:** Assign specific roles and permissions to control user access to different parts of the system.
  * **Database Control Panel:** An administrative panel for database maintenance and operations, including:
      * **Database Backup & Restore:** Perform backups and restores of the entire school database.
      * **Create Database:** Tools for creating a new database instance.
      * **Create Database Users:** Functionality to create and manage database users directly from the application.
  * **Settings Management:** Configure general system settings, including school policies and academic rules.

### School Management

  * **Student Profiles:** Add, edit, and manage student profiles, including personal details, academic history, and contact information.
  * **Staff & Teacher Management:** Manage profiles for all school employees, including assigned roles and responsibilities.
  * **Department and Class Management:** Organize students and teachers into different departments and classes for structured management and reporting.

### Academic Processing

  * **Attendance Tracking:** Easily track and manage daily attendance for students.
  * **Grading:** Input and manage student grades, with automatic calculations for overall performance.
  * **Lesson Planning:** Dedicated module for teachers to plan and track their lessons.
  * **Reporting:** Generate comprehensive reports on student performance, attendance, and other key metrics.

-----

## 🛠️ Technology Stack

  * **Client:** C\# / .NET Framework (Windows Forms)
  * **Development Environment:** Visual Studio 2010
  * **Database:** Microsoft SQL Server

-----

## 📜 License

This project is licensed under the MIT License.

-----

## 🤝 Contribution

Contributions are welcome\! If you would like to contribute to the development of this school management system, please:

1.  Fork the repository.
2.  Create a new feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add amazing feature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

-----

## 📧 Contact

For support, feature requests, or collaboration, please contact the project maintainers.

| Role | Contact |
| :--- | :--- |
| **Project Lead** | Kevin Mutugi Kithinji |
| **Email** | kevinmutugikithinji254@gmail.com |
| **Website** | [https://kevin-mutugi-kithinji-portfolio.onrender.com/](https://kevin-mutugi-kithinji-portfolio.onrender.com/) |