# Employee Manager Application

This is a desktop application developed using the DevExpress XAF framework. It is designed to help companies manage their employees' data, including personal details, position, salary, and performance. The application uses XPO (DevExpress Persistent Objects) as its object-relational mapper (ORM) to interact with a Microsoft SQL Server database.

# Features
### Employee Management

The Employees tab allows users to view a list of all employees in the database. Users can add, edit, and delete employees as well as view their details.

The Employee Details form allows users to view and edit an employee's personal details, including their name, date of birth, gender, contact information, and photo.
### Employee Position Management

The Positions tab allows users to view a list of all positions in the database. Users can add, edit, and delete positions as well as view their details.

The Position Details form allows users to view and edit a position's title.

### Salary management

The Salaries tab allows users to view a list of all salaries in the database. Users can add, edit, and delete salaries as well as view their details.

The Salary Details form allows users to view and edit a salary's details, including the employee, position, start date, and end date.

### Performance/ Work hour Management

The Performance tab allows users to view a list of all performance reviews in the database. Users can add, edit, and delete performance reviews as well as view their details.

The Performance Details form allows users to view and edit a performance review's details, including the employee, review date, comments, and score.

### Notes Management

The Notes tab allows users to view a list of all notes in the database. Users can add, edit, and delete notes as well as view their details.

The Note Details form allows users to view and edit a note's details, including the author, date, and text.

### Payments

The Payments tab allows users to view a list of all payments in the database. Users can add, edit, and delete payments as well as view their details.

The Payment Details form allows users to view and edit a payment's details, including the employee, rate, hours, and amount.

# Technologies Used

- <b>Backend:</b> C#, ASP.NET, DevExpress XAF, DevExpress XPO ORM
- <b>Frontend:</b> HTML, CSS, JavaScript, DevExpress ASP.NET Controls
- <b>Database:</b> Microsoft SQL Server

# Installation

1. Clone the repository: git clone https://github.com/Freddy10035/Employee_Manager.git
2. Open the solution file Employee Manager.sln in Visual Studio.
3. Build the solution to restore NuGet packages and compile the application.
4. Run the application using IIS Express or a web server of your choice.
5. Access the application by navigating to http://localhost:44318 in your web browser.

# Usage
- Upon accessing the application, you will be prompted to log in using your username and password. which are "Admin","".
- Once logged in, you will be directed to the dashboard, which displays an overview of the current employees, salaries, and work hours.
- Use the navigation menu on the left-hand side of the screen to access the various management features of the application.
- To create a new record, click the "New" button and fill out the relevant fields in the form.
- To edit an existing record, click the record to view its details, then click the "Edit" button and make your changes in the form.
- To delete a record, click the record to view its details, then click the "Delete" button.
- To search for a specific record, use the search bar at the top of the screen and enter your search query.
- To view a report of the current employee data, click the "Reports" button in the navigation menu and select the desired report.

# Contributors

- Fredrick Ochieng - Project Owner
