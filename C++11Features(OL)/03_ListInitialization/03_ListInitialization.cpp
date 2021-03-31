// 03_ListInitialization.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
    /*
    Initialization is not assignment.
    Initialization happens when a variable is given a value when it is ceated. 
    Assignment obliterates an object's current value and replaces that value with a new one.
    */
    std::cout << "List initialization!\n";
    std::cout << "Language defins several different forms of Initialization. \nBelow are 4 different ways to initialize an int:" << std::endl;
    int units = 0;
    int units2(0);
    int units3 = {0};
    int units4{0};

    /*
    Note 1:
    The generalized use of curly braces for initialization was introduced as part of the new standard.
    The last two examples above fall under this category. 

    Note 2:
    But when used with built in data types, this form of initialization has one important property. 
    The compiler will not let us list initialize variables of built in type if the initializer might lead to loss of information.
    Example below:
    */

    long double ld = 3.14159;
    int c(ld), d = ld; //Allowed with warning using conventional initialization 
    
    //int a{ld}; //Error - Narrowing conversion required
    //int b = {ld}; /Error - Narrowing conversion required

    /*
    Note 3:
    Built in variables defined outside any function body are initialized to 0.

    Note 4:
    The value of an unitialized variable inside a function is undefined. 
    It is an error to copy or access the value of such variables whose value is undefined.

    Note 5:
    Declaration Vs Definition:
    --------------------------
    Declaration makes a name known to the program. A file that wants to use a name defined elsewhere includes a declaration for that name.
    Definition creates the associated entity. In addition to specifying the name and type, a definition also allocates storage and may additionally 
    provide an initial value.

    Extern Keyword:
    ---------------
    To obtain a declaration that is also not a definition, we add the extern keyword and may not provide an explicit intializer.

    extern int i; // declares but not defines i
    int j;        //declares and defines j

    Note:
    Variables must be defined exactly once but may be declared many times.
    */

    /*
    Note 6:
    List Initialization for data members:
    -------------------------------------
    Under the new standard c++11, we can supply an in-class initializers for a data member.
    When we create objects, the in-class initializers will be used to initialize the data members. 
    Members without an initializer are default initialized. 

    The in-class initializers are restricted as to the form we can use. 
    They must either be enclosed inside curly braces or follow an = sign. 
    We may not specify in-class initializer inside parenthesis.
    */


}

