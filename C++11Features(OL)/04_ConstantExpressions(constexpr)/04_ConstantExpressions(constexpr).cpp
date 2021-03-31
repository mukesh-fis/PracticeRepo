// 04_ConstantExpressions(constexpr).cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
    std::cout << "Constant Expressions!\n";
    /*

    Note 1:
    =======
    A constant expresion is an expression whose value can't change and that can be evaluated at compile time. 
    Examples:

    const int max_files = 20; ==> a constnat expression
    const int limit = max_files + 1; => a constant expression

    int staff_size = 27; ==> Not a constant expression and type is not constant and value can change
    const int sz = getSize(); => Not a constant expression because the value will be received at run time and can't be evaluated at compile time. 

    Note 2:
    =======
    Under the new standard we can ask the compiler to verfiy that a variable is a constant expression by declaring the variable
    in a constexpr declaration. 

    Variables declared as constexpr are implicitly const and must be initialized by constant expressions. 

    Examples:
    constexpr int max_files = 20; ==> a constnat expression
    constexpr int limit = max_files + 1; => a constant expression
    constexpr int sz = getSize(); => ok only if getSize() is a constexpr function.

    Note 3:
    =======
    Although we cannot use ordinary function as an initializer for a constexpr variable, the new standard lets us define certain
    functions as constexpr. Such functions must be simple enough that the compiler can evaluate them at compile time.
    We can use constexpr functions in the initializer of a constexpr variable.

    Generally its a good idea to use constexpr for variables that we intend to use as constant expressions. 

    Note 4:
    Literal Types:
    =============

    The types we can use in constexpr are known as literal types because they are simple enough to have literal values.For example, 
    Arithmetic, references and Pointer types are literal types. 

    Variables defined inside a function ordinarily are nots tored at a fixed address. Hence we can't use a constexpr pointer to
    point to such variables.  On the other hand the address of an object defined outside all functions is a constant expression 
    and so may be used to initialize a constexpr pointer.
    Similarly static variables defined inside a function also persis between function calls and hence can be associated with
    a constexpr refernce or constexpr pointer.

    Note 5:
    Pointers and constexpr
    ======================
    When we define  a pointer in a constexpr declaration, the constexpr specifier applies to the pointer
    and not to the type to which the pointer points:
    */

    const int *p = nullptr;  //==> Here ps is a non-const pointer nd the object(int type) to which it points is const.
    constexpr int *q = nullptr; //==> Here the pointer q itself is a constant pointer not the type to which it points.
    constexpr const int *r = nullptr;  //==> Here both the pointer and the type pointed are constants

    constexpr int i = 10;
    constexpr int j = 20;
    p = &i; //allowed
    p = &j; //allowed
    //q = &i; //Not allowed as q is a constexpr type
    //r = &i;   //Not allowed as r is a constexpr type 

    

     
}
