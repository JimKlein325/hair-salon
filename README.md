# Repeat Finder

#### C# skill demonstration project:  Week 3 - July, 2016

#### By Jim Klein

## Description

Repeat Finder is a sample application for demonstrating basic proficiency in BDD coding techniques and creating simple web apps using Nancy, Razor and related technologies.

A user can enter a sentence and a word to find and receives a count of the occurrences of that word in the input sentence.

##Database setup Notes
In SQLCMD:

CREATE DATABASE hair_salon
GO
USE hair_salon
GO
CREATE TABLE stylists
(
	name VARCHAR(255),
	id INT IDENTITY(1,1)
	)
GO
CREATE TABLE clients
(
	name VARCHAR(255),
	stylist_id INT,
	id INT IDENTITY(1,1)
	)
GO


##BDD Notes

Behavior           |inputSentence          |inputWord        |Output          |Remarks
------------------ | --------------------- |-----------------|----------------|--------------|
Match at least one occurrence of a string|The red fox chased the brown dog.|the|1|This is a simple sentence with multiple occurrences of search string.
Match case sensitive occurences of a string.|The red fox chased the brown dog through the heather.|the|3|This sentence has a single example of the word with differing capitalizaiton.
Match all occurences of letters in string, regardless of capitalizaiton.|The red fox chased the brown dog.|the|2|ditto
Match only full word occurrences of a string: case insensitive match of string preceded by a space and followed by a space or a punctuation mark character.|The red fox chased the brown dog through the heather.|the|3|This sentence adds an occurrence of the word characters within another word.
Match word when preceded by punctuation.|The red fox chased the brown \"dog.\" 'dog -dog (dog.|dog|4|This sentence contains simple examples for each of the supported punctuation marks.
Match word when followed by punctuation.|The red fox chased the brown dog. dog, dog- dog' dog\" dog\' dog! dog? dog) |dog|9|This sentence contains simple examples for each of the supported punctuation marks.

## Setup/Installation Requirements
* Install this project by cloning this repository:
    https://github.com/JimKlein325/repeatcounter.git
* Compile using the PowerShell "dnx kestrel" command in the project directory
* View the app in your browser at "localhost:5004"

## Technologies Used
* Nancy, a lightweight web application framework, used to create websites using C#.
* Razor, a view engine that gives us a way to combine C# code with markup with an easy-to-use syntax.
* HTML
* Bootstrap
* Microsoft SQL Server Management Studio (SSMS), is an integrated environment that provides a number of tools and an interface for managing and developing all parts of SQL Server.
* Using the same URL and different HTTP methods to convey what action the server should take is part of a widely-accepted approach for designing web applications called REST, or REpresentational State Transfer. If you follow REST, each part of your application is modeled as a resource. For now, you can think of each object in your application as a resource (for more complex applications, this isn't always true).
* CRUD functionality with HTTP Methods and RESTful naming conventions for routes:
      Create a vehicle: POST http://localhost:5004/vehicles
      View a vehicle: GET http://localhost:5004/vehicles/5 (where 5 is the ID)
      Update a vehicle: PATCH http://localhost:5004/vehicles/5
      Delete a vehicle: DELETE http://localhost:5004/vehicles/5



### License
MIT License  Copyright (c) 2016 **Jim Klein**
