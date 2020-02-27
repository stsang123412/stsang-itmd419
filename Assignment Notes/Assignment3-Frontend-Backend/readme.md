# Assignment 3 - Frontend Backend
**Objective:** 

## Walkthrough
1. First we have the user input 3 fields of data:  
* Principal
* Number of Years
* Interest Rate
2. In the ``index.cshtml.cs`` file of the ``C:\Users\Steve\stsang\itmd419\frontend-queue-backend`` directory:  
``OnGet()`` displays the Msg
``OnPost()``:  
1. sets the stephan connection string (found on azure portal) to ``connectionSting``
2. parses the string and puts it into the ``storageAccountVariable`` var
```csharp
CloudStorageAccount storageAccountVariable = CloudStorageAccount.Parse(connectionString);
```
3. creates a queue client:  
```csharp
CloudQueueClient queueClient = storageAccountVariable.CreateCloudQueueClient();
```
4. gets the queue referal created on the azure portal (storage account service)
```csharp
CloudQueue queueName = queueClient.GetQueueReference("project3queue");
```  

### variableUser
```csharp
    ClassLibraryStandard.UserMortgageInputObject variableUser = new ClassLibraryStandard.UserMortgageInputObject
    {
        //populates a new user object **variableUser** with uer input data
        principalString = Request.Form["principalString"],
        yearString = Request.Form["yearString"],
        rateString = Request.Form["rateString"]
    };
```
This is an important piece of code. What we're doing here is this:  
1. From the ``ClassLibraryStandard`` library,
2. Create a new object ``UserMortgageInputObject`` named **variableUser**
3. From the ``index.cshtml`` file, take the 3 ``["variable"]`` data fields,  
4. request the data input to be put into the local fields of that object
This is **KEY**. There should now be a new object called **variableUser** that has been populated with the user input data.  
  
This piece of code will wrap the object up into JSON text:
```csharp
var boxedUpData = JsonConvert.SerializeObject(variableUser);
```
  
Finally, we add the new message into our ``queue name`` variable, which references the azure queue that we created via portal / script.
```csharp
queueName.AddMessage(new CloudQueueMessage(boxedUpData));
```


