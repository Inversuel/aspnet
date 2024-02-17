# ASP.NET Data table CRUD

This directory contains the web app file.

## Requirements

Ensure you have the following installed on your system

### Docker 

Docker mainly is used for created local db. If you want your DB please update data connection string in appsettings.json

```
  "ConnectionStrings": {
    "RazorPagesAspnetContext": "Server=localhost;Database=db;User ID=user;Password=password"
  }
```


## Installation

Clone project 

```
git clone https://github.com/Inversuel/aspnet.git
```
Run Database 
```
docker compose up
```

Apply migration changes to DB
```
dotnet ef database update 
```

Run Dotnet project
```
dotnet run
```

To watch tailwindcss class translate to .css

```
npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/tailwind.css --watch
```

