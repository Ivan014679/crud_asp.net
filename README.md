# Tutorial about a CRUD in ASP.NET

## Step 1. Create a project in Visual Studio 2017

First, you need to create a project using the MVC architectural pattern.

* Open Visual Studio. Go to File -> New -> Project. This will open a new window.
* Search Visual C# -> ASP.NET Web Application (.NET Framework).
* Write a name to your project and choose a location where it will be saved. I've named my project as "People" and i've saved it in a folder of my USB.
* After, you see a new window where you can choose a template for your project. You must choose MVC and check the MVC box. Then, click on OK.

And you already have your project created so you can start working on it.

## Step 2. DataModel

### First, create a database

* Go to View -> SQL Server Object Explorer.
* You will see a panel on the left side of the IDE window. Go to SQL Server -> (localdb)/MSSQLLocalDB -> Databases.
* Right click on the folder Databases -> Add new database. This will create our database in the local server of Visual Studio.
* Write a name to your database and choose a location where it will be saved. I've named my database as "Person" and i've saved it in the location by default (don't worry, later the database will be transferred to our project).

Remember to create the tables with their columns according to your needs.
RECOMMENDABLE: Set the primary key of a table as auto increment.

### After, create the DataModel using Entity Framework

You must see a panel with the name "Solution Explorer" on the right side of the IDE window. And you have to have a folder called "Models". If it doesn't exist, then create it.
By keeping an order, within "Models" we will create a new folder called "DataModel".

* Right click on "Models" -> Add -> New Folder. Name it as "DataModel".
* Right click on "DataModel" -> Add -> New Item.

You will see a window where you will watch several items you can add to the proyect. This time we will add a data model to work more easily with the database created.

* Go to Visual C# -> Data -> ADO.NET Entity Data Model. Write a name to your data model. I've named it as "PeopleDataModel".

After, a new window must appear. It This will help us configure our data model.

* First, it will ask us what the model will contain, leave the default option (EF Designer from Database). Then, click on next.
* Now, it will ask us the data connection that our application use to connect to the database. Click on "New Connection".
* Select "Microsoft SQL Server Database File". Click on "Continue".
* After, it will ask us the database file name. Click on "Browse..."
* Search where you saved the database. By default, it is in "C:\Users\{Your username}\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB". Click on "Ok".
* After, the database file will be charged. Then, puts a name to the configuration of the connection to the database. I've left the name that the IDE put me by default (PersonEntities). Click on "Next".
* Then, It will ask you if you want to copy the database file to your project and modify the connection. You must click on "Yes".
* Now, you must to choose the version of the Entity Framework. Check "Entity Framework 6.x" and click on "Next".
* After, it will ask you to choose the database objects and settings. Check the box "Tables".
* Write a name to the model namespace. I've left the name that the IDE put me by default (PersonModel).
* Finally, click on "Finish".

Done! your data model is ready. You must see a graphic of the entity relationship model of your database.
