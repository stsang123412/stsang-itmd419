# Assignment 1 - F2C  Converter
So for this assignment, we were tasked to created a basic, functional, single web page.  
These are the steps:  

1. We fired up Visual Studio 2019.

2. Created a new project called ``F2C-converter-3``. It was the third one because the first two wasn't razer pages. (Was react and something else.)  

3. Now we've created our project directory:
![alt text](https://github.com/stsang123412/stsang-itmd419/blob/master/Assignment%20Notes/Assignment1-F2C/images/1-project-directory.png "1-project-directory.png")

4. Nice right? So now we need to create the actual functioning front end of our site. The actual page using using Razor/Razer pages.

  * How do we do this?
  * Well first we need to create the actual form to get user data. We do this in the ``index.cshtml`` file. 
  * (Yes it's a pain in the ass to look for. One's ``.cshtml``, other is ``.cshtml.cs``) Use the Solution Explorer on the right side of the IDE.
  * Great, now pull up the ``index.cshtml`` file and now we can start editing. Here's our front end (single web page)
  ![alt text](https://github.com/stsang123412/stsang-itmd419/blob/master/Assignment%20Notes/Assignment1-F2C/images/2-index.cshtml.png "2-index.cshtml")
  * Here's the code for it. As you can see, I created a ``<form>`` which posts the user input (string) into the **Temperature** variable 
  inside of ``index.cshtml.cs`` via ``asp-for="Temperature"``.
  * Oh yeah, we also made a little ``<p>`` text area for our message variable.

4. Now we need to take that user input and **DO** something with it. (backend?)
    - First Step
        * We first make a ``public class Msg`` variable that has a **get** and **private set**. We need to be able to get the Msg as well as not letting anyone else set it. (private).
        * Okay that's done. Now we do the same thing for ``public class Temperature``. Same get + set, except set is not private this time. The form needs to be able to set the value.
    - Second Step
        * Now the fun ``OnGet()`` and ``OnPost()`` methods. Refer to [here.](https://www.mikesdotnetting.com/article/308/razor-pages-understanding-handler-methods)
        * ``OnGet()`` contains the ``Msg`` variable which contains the preset string / message we set for the user.
        * ``OnPost()`` is what happens after the user hits that juicy, sweet, submit button. (Takes the user input and converts it)
    - OnPost()
      * Alright, this is the meaty part of the program. 
      * After the user hits the submit button, their value is entered into ``string s = Temperature;`` (Entered in s)
      * Now we have a class ``TempConverter`` with the function ``ChangeF2C(string Temperature)`` which takes the string input ``s`` and shoves it into a Temperature variable to work with.
![alt text](https://github.com/stsang123412/stsang-itmd419/blob/master/Assignment%20Notes/Assignment1-F2C/images/3-temperatureConverter-class.png "3-temperatureConverter-class")
      * Read the //comments
5. Final step?
  * So finally, we've passed the value(s) as a tuple.
  * ``if(PassedOrNot)`` which is a boolean, is true; 
    * execute the message with their conversion. take note of the ${} string passing / concatonation thing. 
  * else...
    * Not valid  
![alt text](https://github.com/stsang123412/stsang-itmd419/blob/master/Assignment%20Notes/Assignment1-F2C/images/4-final-process.png "4-final-process")

      


