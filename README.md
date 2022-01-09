# ProjectTracker

Simple Web API project for working with projects and tasks.

Project uses:
1. .NET Core 5
2. ASP.NET Core 5
3. SQLite as database engine
4. Developed and tested on Windows 10

## Configuration

1. For database:
   - ensure folder where database file placed is writable (e.g. `c:\temp`). 
   - ensure `PojectTracker.API\appsettings.json` has apropriate connection string
```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=c:\\temp\\project-tracker.db"
  },
```

## Build and run (Visual Studio 2019+)

1. Open solution in Visual Studio (Community edition is enough)

2. Build solution

3. Run solution with `PojectTracker.API` startup project.

## Build and run (command line)

1. Clone sources into desired folder (e.g. `project`)

2. In terminal:
```console
> cd project/src/ProjectTracker
> dotnet build
> cd ProjectTracker.API
> dotnet run
```
3. Open in your browser:\
`http://localhost:5000/swagger/index.html` or\
`https://localhost:5001/swagger/index.html`.
