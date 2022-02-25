# MemberRestApi
A basic REST API which handles SQLite database containing members of arbitrary context

## Features
The API works in LocalHost\
Data access (Entity framework core)\
Database (SQLite)\
Logger

## Extra features
Database migrations (EF core migration)\
Unit testing (xUnit)\
Browser UI (Swagger)

## Demonstration of the functionalities

Swagger UI\
![image](https://user-images.githubusercontent.com/44393647/155768439-360b5d54-1d0e-404f-936c-43e7bd5dbd0d.png)

Retrieving all the members. Press: "Try it out" -> "Execute"\
![image](https://user-images.githubusercontent.com/44393647/155768682-c50311d4-aa0d-4565-a673-9e5a30373f3d.png)

Some objects should be retrieved
![image](https://user-images.githubusercontent.com/44393647/155769107-3e48d76f-df5a-4f02-81a4-c39ebac69022.png)

By using the ID, the user can **delete**, **update** or **retrieve** the corresponding member.\
User is also able to **create** new members with POST.\
These actions are logged to MemberRestApi/Logs\
If the database schema is changed, the migration can be done by applying the following Package Manager commands:\
Add-Migration [NameOfMigration]\
Update-Database
 
There are 3 basic unit tests implemented:\
![image](https://user-images.githubusercontent.com/44393647/155770427-484f1e25-1df5-4082-b224-8ca67dbfd879.png)


**Don't hesitate to contact me if something is not working or if you have any questions!**
