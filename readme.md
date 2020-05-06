# Camp Manager

### Installation Guide

1. Clone the Project from this repo.
2. Open Project in Visual Studio. Then Right click on `Project.API` in SolutionExplorer and click on `Set as StartUp Project`.
3. Make sure "Project Url" is selected to `http://localhost:8080/` (Right click "Project.API" -> "Web" Tab)
4. Change the connection string to point to your database in "web.config" (line 23 -> `data source=RAHULSANGWAN\SQLEXPRESS`) in `Project.API`.
5.Then Start the Project
6. Go to `ProjectUI` folder open command prompt there and issue `ng serve` command.
7. Go to `localhost:4200` to access the site.