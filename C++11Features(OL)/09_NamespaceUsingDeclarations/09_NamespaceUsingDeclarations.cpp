// 09_NamespaceUsingDeclarations.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
    std::cout << "Namespace Using Declarations!\n";
    /*
    One way to use identifiers declared inside a namespace is to use using directive 
    like using namespace std to use cin, cout etc.
    But this will import all the symbols from that file into the project. 
    So, another way is that we use std::cin at every place instead of wiritng using directive. But then this can be cumbersome to type
    std::cin at all the places. 

    So, the third way is to use using declaration instead. Here we write using namespace::symbolName for example, using std::cin.
    Once we write this we may now use cout directly without writing std::cout.
    */
    using std::cout;
    using std::endl;
    cout << "An example of using declarations. " << endl;

    /*
    Note:
    Headers should not include using declarations otherwise every program that includes that header gets the same using declarations
    As a result a program that did not intend to use the specified lib name might encounter unexpected name conflicts.
    */

}

