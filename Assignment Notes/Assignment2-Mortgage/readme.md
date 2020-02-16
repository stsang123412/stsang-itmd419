# Assignment 2 - Mortgage
**Objective:** To modify the previous project ``F2C-converter3`` and create a mortgage calculator which takes:  
* Principal
* Interest Rate
* Number of Years 

## Walkthrough
1. When the application is first launched, the user will see the single razor page with 3 fields: ``Principal``, ``Years``, and ``Interest``.  
   * To access / make edits to this page, look for the ``index.cshtml`` file in solutions explorer.  
2. Backend
   * First made 3 getter-setter methods for ``principalString``, ``yearString``, and ``rateString``.
   ```csharp
   public string principalString
            // this variable is linked to index.cshtml
            // <input type="text" asp-for="loanAmount" value=""/>
            {
                get;            //public; anyone can get
                set;            //no private; must be set by the 
            }
    ```

