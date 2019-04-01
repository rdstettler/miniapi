# miniapi
A minimum effort API for small scale data management. I use a simple json-file as "database" and I can use all typicall HTTP-verbs to interact with that database. The API allows for Oauth authorization

# How to use
This API uses asp.net core V 2.1 (I found this to be more stable than the newer one). The solution is split into 4 projects

1) MiniAPI: here you place all your controllers and the ASP.NET Core files (Program.cs and Startup.cs)
2) Definitions: here you can place all generic classes and interfaces
3) Repository: here the reading and writing of the json-Database is performed
4) Services: the injected services for the controllers


# The Database
Well, its not really a database, it just a json File with all "tables" as items in the first level, something like

{
    "Table1" : [
        {
            // anything
        }, 
        {
            // anything
        }, 
    ],
    "Table2" : [
        ....
    ]
}

etc.

All the references and id checks you'd have to perform yourself in the services or in the baserepository (I think its better in the services). 
