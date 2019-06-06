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

Remember to create the tables with their columns according to your needs. I've created a table only, called "Person" with columns: "Id" (PK), "Name", "Gender" and "Phone".
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

## Step 3. Create the models

### First, create the model in the folder "Models"

Note that for each entity that you have created, there must be a model associated with each with the same name, followed by the suffix "Model". In my case, i only have one entity called "Person", so, its model must be called "PersonModel".

* On the folder called "Models", right click -> Add -> Class...
* A window will open. Select "Class" and name it as the entity that you've created, followed by the suffix "Model". In my case, it will be called "PersonModel".

Now, you must have written a similar code in this way:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People.Models
{
    public class PersonModel
    {
    }
}
```

Now, you must to write all the attributes corresponding to each field of the entity, besides, a ArrayList of the same model. This attribute will save a list of model elements, in my case, a list of people.

According to my example, my entity is "Person" and its fields are: "Id", "Name", "Gender" and "Phone", so, I wrote these attributes with the same name in my model as follows:

```c#
        public decimal Id { get; set; }

        [Display(Name = "Full name")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string Gender { get; set; }

        [Display(Name = "Phone")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string Phone { get; set; }

        public List<PersonModel> List { get; set; }
```

"Id" is decimal because is the primary key and a auto increment field of my entity "Person".
"Name", "Gender" and "Phone" are string, because these fields save text strings in my entity "Person".
Remember, the type of each attribute will depend on the type of data that you have assigned to each field of your table.

The methods get and set are to access (read and write), from other classes once initialized and declared a variable of the model type.

Finally, "Display" and "StringLength" are data annotations for to validate the data that is sent in the forms. With "Display", an attribute is named, which will later be displayed in the view by the "Label" helper. While, "StringLength" works to validate the maximum and minimum length of a string that can be sent.

NOTE: The data annotations are OPTIONAL, if you want to use this on your proyect, don't forget to import its class (using System.ComponentModel.DataAnnotations;)

### Then, create the data access to work with the database

Now, in the folder "Models", create a new folder called "DataAccess" which will contain each class of data access for each model created.

* Now, right click on "DataAccess" -> Add -> Class...
* A window will open. Select "Class" and name it as the model that you've created, followed by the suffix what you want. In my case, it will be called "PersonDao".

You must have written a similar code in this way:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People.Models.DataAccess
{
    public class PersonDao
    {
    }
}
```

This class will contain the code which will work with the crud (create, read, update and delete). Therefore, here we are going to program 4 methods, each one corresponding to create, read, modify or eliminate.

Remember to import your model and your data model here. In my case, I did it like this:

```c#
using People.Models.DataModel;
```

You must do something like this:

```c#
using {Your namespace}.Models.DataModel;
```

#### The create method

In my case, i've created my method as follows:

```c#
        public void Create(PersonModel p)
        {
            using (var context = new PersonEntities())
            {
                Person pe = new Person();
                pe.Name = p.Name;
                pe.Gender = p.Gender;
                pe.Phone = p.Phone;

                context.Person.Add(pe);
                context.SaveChanges();
            }
        }
```

As you can see, the method receives like param my model of Person. You must declare your model there with any variable name (i've named it as "p").

Do you remember when we named to the configuration of the connection of the database? Well, here we need to declare it and instantiate it in a variable of type var. I've named this variable as "context". Besides, this line code must be enclosed by "using" as written above.

Inside, I've Inside, I have declared and instantiated an object of the type of the entity "Person". To that object I assign in each of its attributes, the values that "p" has. You must do the same according to your entity and your model.

After, I've added that new person to the database (context.Person.Add(pe)) and i've saved changes (context.SaveChanges()).

#### The read method

In my case, i've created my method as follows:

```c#
        public List<PersonModel> Consult()
        {
            List<PersonModel> peoplelist = new List<PersonModel>();
            using (var context = new PersonEntities())
            {
                var query = (from d in context.Person select d).ToList();
                foreach (var item in query)
                {
                    PersonModel p = new PersonModel();
                    p.Id = item.Id;
                    p.Name = item.Name;
                    p.Gender = item.Gender;
                    p.Phone = item.Phone;

                    peoplelist.Add(p);
                }
            }
            return peoplelist;
        }
```

I've declared and instantiated an array list of PersonModel, which will have all the people in my "Person" table. You must declare and instantiate an array list of your model there.

After, as in the method "create", I've declared and instantiated the variable context which contains the configuration of the connection of the database. Inside the "using", I've defined a variable called "query", which will do a query to the table "Person" and it will bring me all its records. You have to change the "context.Person" according to the name that you have assigned to that variable and to the entity from which you want to obtain all its tuples ({Context}.{Table}). "d" is only a variable that EntityFramework uses to bring a record of a table, you can call it like you want.

Then, in a foreach cycle, for each record of the "Person" table, it is added to my array list of people. But first, you must declare and instantiate an object of the type of your model and to it, the values of each record are assigned (In my case: PersonModel p = new PersonModel()).

Finally, I return the array list of people. You must return the array list of your model.

#### The obtain a record method

This method is very important to work the update method. In my case, i've created my method as follows:

```c#
        public PersonModel ConsultOne(decimal id)
        {
            using (var context = new PersonEntities())
            {
                PersonModel person = new PersonModel();
                var record = (from d in context.Person select d).Where(d => d.Id.Equals(id)).FirstOrDefault();
                person.Id = record.Id;
                person.Name = record.Name;
                person.Gender = record.Gender;
                person.Phone = record.Phone;
                return person;
            }
        }
```

It is similar to "consult" method, only I've declared and initialized a object "person" of the type of my model "PersonModel", which will contain a person according to the id that the method has as param.

However, there is a big difference in the "record" variable, in which, it has something extra (Where(d => d.Id.Equals(id)).FirstOrDefault()). With "where", you're saying that searches certain record with a certain condition ((d => d.Id.Equals(id)). In my case, I'm saying to bring all the records that have the same id as my model (because the id is the primary key and cannot be repeated). Therefore, it would only bring me one person, which I need. You must do the same but according to your model and entity.

At the end of the instruction, you must add "FirstOrDefault()", because, even though you are only bringing a record, the variable will return an array. To fix this, with that method you are saying that it only brings you the first record or the one that is by default, instead of an array.

#### The update method

In my case, i've created my method as follows:

```c#
        public void Update(PersonModel p)
        {
            using (var context = new PersonEntities())
            {
                var query = (from d in context.Person select d).Where(d => d.Id.Equals(p.Id)).FirstOrDefault();
                query.Name = p.Name;
                query.Gender = p.Gender;
                query.Phone = p.Phone;
                context.SaveChanges();
            }
        }
```

As you can see, this method seems to be a fusion of the create and read methods, but there is a big difference in the "query" variable, in which, directly the values of the model that is brought by the method parameter are assigned (not only an id), this is because a new person is not being created, but an existing one is being modified, that is why an object of the type of the entity "Person" is not declared and instantiated.

As in the method "ConsultOne", I only bring one person, which I want to modify. You must do the same but according to your model and entity.

Finally, I've saved changes, as in the create method (context.SaveChanges()).

#### The delete method

In my case, i've created my method as follows:

```c#
        public void Delete(decimal id)
        {
            using (var context = new PersonEntities())
            {
                var record = (from d in context.Person select d).Where(d => d.Id.Equals(id)).FirstOrDefault();
                context.Person.Remove(record);
                context.SaveChanges();
            }
        }
```

As you can see, this method is similar to the update method, and more simple. The only difference is that it brings as parameter the id instead of the whole object of the model.

After, I delete the person of my entity (context.Person.Remove(record)). Remember, You must do it according to your table and your model.

Finally, I've saved changes in the database.

### Call the CRUD methods in the model

Return to the model and write the four methods according to those that are written in the Dao class. But these will only be responsible for calling them, not to communicate with the database.

Remember to import the Dao class in your model (using {Your namespace}.Models.DataAccess).

#### The create method

```c#
        public void Create()
        {
            PersonDao pdao = new PersonDao();
            pdao.Create(this);
        }
```

#### The read method

```c#
        public List<PersonModel> Consult()
        {
            PersonDao pdao = new PersonDao();
            return pdao.Consult();
        }
```

#### The consult one method


```c#
        public PersonModel ConsultOne(decimal id)
        {
            PersonDao pdao = new PersonDao();
            return pdao.ConsultOne(id);
        }
```

#### The update method

```c#
        public void Update()
        {
            PersonDao pdao = new PersonDao();
            pdao.Update(this);
        }
```

#### The delete method

```c#
        public void Delete(decimal id)
        {
            PersonDao pdao = new PersonDao();
            pdao.Delete(id);
        }
```

As you can see, this methods are very simple. The create and update method calls to the create and update methods respectively of the Dao class sending the model.

With the read method, you obtain an array list of data and return that array while with the method "ConsultOne", you obtain a data according to id that you send it.

And with the delete method, you send the id to the Dao class to be eliminated a record.

## Step 4. Create the controllers

Each model must have its own controller. For to create one, follow the next steps:

* On the folder "Controllers", right click -> Add... -> Controller
* A window will appear asking you for the type of controller. Choose "MVC 5 Controller - Empty".
* Name the controller like the entity, followed by the suffix "Controller". In my case, I only have one entity called "Person", so, its controller must be called "PersonController".

You must have something like this:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
    }
}
```

For now, the controller have only a action (method) called "Index" and only contain a return, which say to the view "Index" to be painted. I will use this action to show the list of people. You can to use it for a form to create or update a data, you can even change the name of this action, but remember, the view must have the same name as the action.

Another important fact, do not forget to import your model to the controller.

### Read and show data

This is my code:

```c#
        public ActionResult Index()
        {
            PersonModel pModel = new PersonModel();
            pModel.List = pModel.Consult();
            return View(pModel);
        }
```

* For to show my list of people, i've declared and instantiated a object "pModel" of the type of my model "PersonModel".
* After, to my list attribute I put the list of people calling to the method "Consult" created in the model.
* Finally, I've sent this model to the view to be painted (return View(pModel)).

You must do the same, according to your model, don't forget it!

### Create data

We need two actions with the same name, one will receive parameters by get, and another by post. This is my code:

```c#
        public ActionResult CreatePerson()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreatePerson(PersonModel pModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pModel);
            }
        }
```

In the first action, I only tell the view to be painted. Later a form will be programmed in the view.
In the second action, I receive a model by "post" and I validate if the data is correct. If this is the case, I redirect the view to show people, otherwise, I return the model to the same view.

You must do the same, according to your model.

### Update data

We will also need two actions, although with different names, and both will receive parameters through "post". This is my code:

```c#
        [HttpPost]
        public ActionResult UpdatePerson(decimal id)
        {
            PersonModel pModel = new PersonModel();
            pModel = pModel.ConsultOne(id);
            return View(pModel);
        }

        [HttpPost]
        public ActionResult SaveChanges(PersonModel pModel)
        {
            if (ModelState.IsValid)
            {
                pModel.Update();
                return RedirectToAction("Index");
            }
            else
            {
                return View(pModel);
            }            
        }
```

In the first action:
* The id is received by "post".
* I've declared and instantiated a object "pModel" of the type of my model "PersonModel".
* After, I get a person according to that id and I've saved it in the model.
* Finally, I've sent this model to the view to be painted (return View(pModel)).

In the second action, I receive a model by "post" and I validate if the data is correct. If this is the case, I update the model, after, I redirect the view to show people, otherwise, I return the model to the same view.

You must do the same, according to your model.

### Eliminate data

Here we only need a action that will receive parameters through "post". This is my code:

```c#
        [HttpPost]
        public ActionResult DeletePerson(decimal id)
        {
            PersonModel pModel = new PersonModel();
            pModel.Delete(id);
            return RedirectToAction("Index");
        }
```

In this action:

* I've declared and instantiated a object "pModel" of the type of my model "PersonModel".
* I've called the delete method of my model, for that I've sent it the id.
* Finally, I redirect the view that shows all the people.

