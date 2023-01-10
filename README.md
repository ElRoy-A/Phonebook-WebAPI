# Phonebook-WebAPI

**Phonebook CRUD Application implemented using C#.**
* Database was created using Entity Framework Core and SQL Server.
* WebAPI was tested using Swagger.

<ins>**Must run the WebAPI project first, then run the UI project.**</ins> The UI project solution checks that there is a successful WebAPI connection before advancing to the Console App menu.

**CRUD Menu Screen:**
<p align="center">
    <img src="./images/CRUDmenu.png" />
</p>

**Database Sample View:**
<p align="center">
    <img src="./images/DBsample.png" />
</p>

**Swagger Test Sample Screen:**
<p align="center">
    <img src="./images/SwaggerSample.png" />
</p>

**Example of Swagger GET Method Test:**
<p align="center">
    <img src="./images/SwaggerGET.png" />
</p>

**Nuget Packages used:**

[Phonebook WebAPI]
* Microsoft Entity Framework Core
* Microsoft Entity Framework Core SqlServer
* Microsoft Entity Framework Core Tools
* Swashbuckle.AspNetCore


[Phonebook UI]
* Newtonsoft.Json
* RestSharp
* ConsoleTableExt
