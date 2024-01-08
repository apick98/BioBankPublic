# BioBank - Technical Assessment Application
-----------------------------------------------------------------------------------------------------------------
## Description
This web application has been written as a ASP.NET Core Web App using the  .Net 8 SDK. Entity Framework packages were also required such as, SQLite (to act as the local database), the Microsoft.VisualStudio.Web.CodeGeneration.Design package (to generate the Create, Remove, Update and Delete (CRUD) web pages from the database context file) and SQLServer (in order to use the code generation package for the scaffolding of the CRUD pages). Additional frameworks such as Bootstrap and JQuery were already in present in the project files.

The system created provides the following features:
- Displaying the collections in a table (loading in from a local SQLite database)
- Adding, editing and deleting collections from the database
- Further displaying the details of a collection as well as the attributed samples
- Displays the details of a sample
- Adding, editing and deleting samples from the database (in addition to modifying the corresponding collection table through the relational database)
- Sorting, filtering and pagination in both the collection and sample interface tables

The main difficulty of this project was deciding on the technologies to use to build it. Initially, Blazor was chosen to create the application. However, the learning curve and lack of an appropriate tutorial meant considering alternatives.

In future, improvements to the system could be the following:
- Add authentication to the system to protect the data
- Create a friendly and intuitive user interface (making it less clinical and more specific when given organisation themes and icons)
- Allow users to change a sample's collection on the 'Edit' page (instead of deleting and re-adding) 
- Store the data online for security
- Integrate database migrations so when the model changes the database and schema can change without being dropped
- Change the layering of the solution to a pattern such as MVC
- Introduce concurrency to handle multiple users on the site
- Possibly add 2-factor authentication
-----------------------------------------------------------------------------------------------------------------
## How to Install and Run the Project

- Download a zip folder of the project via the repository page. (By clicking the 'Code' button then 'Download ZIP')

- Unzip the folder once it has downloaded (by using 'Extract All')

- Open the command line on the PC

- Navigate to the root directory using a file explorer

- Write 'cd' followed by the filepath to project directory

- Next write 'dotnet restore BioBank' to reestablish the packages in the project

- Following that write 'dotnet build BioBank' to compile the code

- After this type into the terminal 'dotnet run --project ./BioBank/BioBank.csproj' (this will attempt to run the project)

- (Any issues with checking the program for malicious content must be handled individually depending on security settings.

- Wait for the terminal to carry out the projects startup code.

- Within the info messages will be a local url where the app is running e.g. 'http://localhost:9999'

- Copy the address to a web browser and the app will be running

- Press 'CTRL+C' within the terminal to close the local host when finished looking at the web app

- (Alternative to using the terminal is opening via an IDE such as VSCode (packages will have to be installed through these))

-----------------------------------------------------------------------------------------------------------------
## Acknowledgements

The creation of this project could not have been done without the .NET 6 Razor Pages with Entity Framework Core in ASP.NET Core tutorial on Microsoft Learn:
https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-8.0&tabs=visual-studio

A copyright free image from Pexels was used within the program's welcome page.
