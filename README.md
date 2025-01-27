Here is the updated README.md content with a detailed description:

```markdown
# Online Examination System

## Overview
The Online Examination System is a web-based application developed in C# that allows educational institutions to conduct exams online. The system provides a user-friendly interface for both administrators and students.

## Description
The Online Examination System aims to streamline the examination process by providing a secure and efficient platform for conducting exams. Administrators can easily create and manage exams, schedule them, and monitor ongoing exams in real-time. The system also supports automatic grading for objective questions, thus saving time and reducing the possibility of human error. Students can take exams from the comfort of their homes, and the responsive design ensures compatibility across various devices.

## Features
- **User Management**: Admins can add, remove, and manage users.
- **Exam Creation**: Admins can create exams with various question types like multiple-choice, true/false, and short answer.
- **Exam Scheduling**: Admins can schedule exams and manage exam timings.
- **Real-time Monitoring**: Monitor ongoing exams in real-time.
- **Automatic Grading**: Automatically grade multiple-choice and true/false questions.
- **Result Generation**: Generate and download results after exam completion.
- **Secure Login**: Secure authentication for both admins and students.
- **Responsive Design**: Fully responsive design compatible with all devices.

## Technologies Used
- **Backend**: C# with ASP.NET Core
- **Frontend**: HTML, CSS, JavaScript
- **Database**: Microsoft SQL Server

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/gedyzed/OnlineExaminationSystem.git
   ```
2. Navigate to the project directory:
   ```bash
   cd OnlineExaminationSystem
   ```
3. Restore the .NET packages:
   ```bash
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`.
5. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
6. Run the application:
   ```bash
   dotnet run
   ```

## Usage
1. Open your browser and navigate to `http://localhost:5000`.
2. Login with the admin credentials.
3. Start managing users and creating exams.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.

## Contact
For any inquiries, please contact [your-email@example.com].
```

You can copy and paste this into your `README.md` file. Feel free to customize it further to better fit your project. 
