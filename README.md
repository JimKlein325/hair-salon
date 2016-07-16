# Most Groovey Hair Salon

#### C# skill demonstration project:  Week 3 - July, 2016

#### By Jim Klein

## Description

Most Groovey Hair Salon is a sample application for demonstrating basic proficiency in HTTP CRUD method use, BDD coding techniques, and creating simple web apps using Nancy, Razor and related technologies.

A user can enter and track a salon's hair stylists and their clients.

##Database setup Notes
To set up the database and tables in SQLCMD:

1. CREATE DATABASE hair_salon
2. GO

3. USE hair_salon

4. GO

5. CREATE TABLE stylists
(
	name VARCHAR(255),
	id INT IDENTITY(1,1)
	)

6. GO

7. CREATE TABLE clients
(
	name VARCHAR(255),
	stylist_id INT,
	id INT IDENTITY(1,1)
	)

8. GO

## Setup/Installation Requirements
* Install this project by cloning this repository:
    https://github.com/JimKlein325/hair-salon.git
* Compile using the PowerShell "dnx kestrel" command in the project directory
* View the app in your browser at "localhost:5004"
* Microsoft SQL Server Management Studio (SSMS)
    1. Open SSMS
    2. Select File > Open > File and select the .sql files: hair_salon.sql & hair_salon_test.sql
        If the database does not already exist, add the following lines to the top of the script file:
        CREATE DATABASE hair_salon
        GO
    3. Save the file.
    4. Click ! Execute.
    5. Verify that the database has been created and the schema and/or data imported.

## Technologies Used
* Nancy, a lightweight web application framework, used to create websites using C#.
* Razor, a view engine that gives us a way to combine C# code with markup with an easy-to-use syntax.
* HTML
* Bootstrap
* Microsoft SQL Server Management Studio (SSMS), is an integrated environment that provides a number of tools and an interface for managing and developing all parts of SQL Server.
* Used the same URL and different HTTP methods to convey what action the server should take, which is part of a widely-accepted approach for designing web applications called REST, or REpresentational State Transfer. If you follow REST, each part of your application is modeled as a resource.
* CRUD functionality with HTTP Methods and RESTful naming conventions for routes:
      Create a stylist/client: POST
      Read (View) a stylist/client: GET
      Update a stylist/client: PATCH
      Delete a stylist/client: DELETE



### License
MIT License  Copyright (c) 2016 **Jim Klein**
