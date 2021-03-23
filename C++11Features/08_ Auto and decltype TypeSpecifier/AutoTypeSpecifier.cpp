// AutoTypeSpecifier.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

double f(double lhs, double rhs)
{
    return lhs + rhs;
}

int main()
{
    std::cout << "Auto Type Specifier!\n";

    /*
    Under the new standard we can let the compiler figure out the correct type of an expression for us by allowing us to use auto type
    specifier. auto tells the compiler to deduce the type from the initializer and hence a variable of auto type must have an initializer.
    */
    auto item = 3 + 5; //item is int type
    //auto sz = 0, pi = 3.14;  //error - inconsistent type for sz and pi

    /*
    We may also specify if we want a refernce to the auto deduced type.
    */
    const int ci = 0; 
    auto& g = ci;   //g is a const int reference bound to ci
    //auto& h = 42; //error - can't bind a plain refernce to a literal.
    const auto& i = 42; //ok - we can bind a const reference to a literal

    std::cout << "decltype Type Specifier!\n";

    /*
    Sometimes we want to define a variable with a type that the compiler deduces from an expression 
    but do not want to use that expression to initialize the variable. The new standard C++11 defines decltype for such cases.
    decltype returns the type of its operand. The compiler analyzes the expression to determine its type but does not evaluate the 
    expression. 
    
    For example - 
        decltype(f()) sum = x;
    Here the type of sum is deduced from the return type of function f().
    Here the compiler does not call f() but it uses its type that such a call would return as the type for sum.

    */
    decltype(f(10, 20)) sum = f(40.5, 50.5);  //here the parameters to f() inside decltype are dummy while the call to f on the roght hand side are actually used
    cout << "sum = f(40.5, 50.5) = " << sum << endl;


    /*
    When applied to a variable type, decltype returns the type of that variable including top-level const and references.
    */
    const int ci = 0, & cj = ci; 
    decltype(ci) x = 0;  //x has type const int
    decltype(cj) y = x;  //cj is a reference type and hence y has type const int& and is bound to x
    //decltype(cj) z;      //error - z isa reference and must be initialized

    /*
    It is worth noting that decltype is the only context in which 
    a variable defined as a reference is not treated as a synonym for the object to which it refers
    */

    /*
    decltype and references
    when applied to an expression decltype gives the type of the expression. But some expressions will cause
    decltype to yield a reference type. This happens when the expression yields objects that can stand on the left hand side
    of the assignment. Example:
    */
    int ii = 42, * pii = &ii, & rii = ii;
    decltype(rii + 0) b; //addition with rii yields an int, so b is an uninitialized int.
    //decltype(*pii) c; // error - c is int& and must be initialized. 
    decltype(*pii + 0) d; //if we add a number to the deduced ref type, we now get the value type that is int not int& so this statement is valid. 

    /*
    In the above example, r is a refernce, so decltype(r) is a reference type.
    If we want the type to which r refers, we may add a number like (r + 0) here to r, then decltype will yield the value type 
    which is a non-reference type.
    When we use decltype(*pii), the dereference operator with decltype yields a reference type,
    so decltype(*pii) yields int& and not plain int.
    if we add a number to the deduced ref type, we now get the value type that is int not int& so this statement is valid.
    This the type for d is int while the type for c was int&.

    Another Note:
    If we apply decltype to a variable without without parenthesis, we get the type of that variable 
    but when we warp up the variable in additional set of parenthesis inside decltype, we get reference type.

    so, decltype((variable)) yields reference type while decltype(variable) yields value type.
    Example:
    
    */

    decltype(ii) e; //e is int type
    //decltype((ii)) f; //f is int& type and hence must be initialized. 

    /*
     Another point to note is that - Assignment is an example of an expression that yields reference type.
     The type is areference to the type of the left hand operand. So if ii is an int, then decltype(ii = x) is int& type.
    */
    decltype(ii = 30) g; //Here the type deduced for g is int& and hence must be initialized.
}

