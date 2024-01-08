# BioBank - Technical Assessment Application
-----------------------------------------------------------------------------------------------------------------
## Description
This web application has been written as a ASP.NET Core Web App using the  .Net 8 SDK. Entity Framework packages were also required such as, SQLite (to act as the local database), the Microsoft.VisualStudio.Web.CodeGeneration.Design package (to generate the Create, Remove, Update and Delete (CRUD) web pages from the database context file) and SQLServer (in order to use the code generation package for the scaffolding of the CRUD pages). Additional frameworks such as Bootstrap and JQuery were already in present in the project files.

The project is split up into sections. The 'Data' folder contains the context file (used to connect to the database) and an initialise file used to seed the database. 'Models' is a folder containing the models for a collection and sample for the context to configure  database entities. Within the 'Pages' folder, are the CRUD pages for Collections (in the 'Collections' folder' and the CRUD pages for Samples (in the 'Samples' folder). Finally, the 'Pages' folder also contains the index page (the initial page displayed), the shared page code with the page layout and navigation menu (within the 'Shared' folder). Outside of the 'Pages' folder in the project is the program file which sets up the program when initially run and the pagination file used to add pages to a table.

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
## How to Install and Run the Project

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
## How to use the system

- When run the 'Collections' button on the navigation menu at the top of the page must be clicked
  
- To create a collection, click 'Create New', fill out the form and click 'Create'
- To edit a collection, click 'Edit' at the end of a collection's row, changed the form entries as required and click 'Save'
- To delete a collection, click 'Delete' at the end of a collection's row, making sure to double-check before clicking 'Delete'
- To view the data of a collection, click 'Details' at the end of a collection's row and this will show the details of a collection and the samples held

- When within the 'Details' page of a collection:
  - To create a sample, click 'Create New Sample', fill out the form and click 'Create'
  - To edit a sample, click 'Edit' at the end of a sample's row, changed the form entries as required and click 'Save'
  - To delete a sample, click 'Delete' at the end of a sample's row, making sure to double-check before clicking 'Delete'
  - To view a sample's details, click 'Details' at the end of a sample's row

-----------------------------------------------------------------------------------------------------------------
## Acknowledgements

The creation of this project could not have been done without the .NET 6 Razor Pages with Entity Framework Core in ASP.NET Core tutorial on Microsoft Learn:
https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-8.0&tabs=visual-studio

A copyright free image from Pexels was used within the program's welcome page.
