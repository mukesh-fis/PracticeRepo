// ConstVariables.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "file.h"

int main()
{
    std::cout << "Const Variables!\n";

    /*
    Sometimes we have a const variable that we want to share across multiple files but whose initializer is not a constant expression.
    In this case we do not want the compiler to generate a separate variable in each file. Instead we want to define the const variable 
    in one file and declare in other files that use that object.

    To define a single instance of a const variable, we use the keyword extern on both its defintion and declaration.
    Example:

    file1.cpp defines an extern const int and file2.h declares that variable to use this const variable inside a function.
    Here we cll that function in file2.h
    */

    std::cout << "bufSize :" << buffsize << std::endl;
    std::cout << "fcnInFile2 returns :" << fcnInFile2() << std::endl;

    /*
    Note: C++ 17 provides a new feature called inline variable to substitute the need of extern const. 
    This is described in another project created - 04_InlineVariableForExternConst_C++17
    */
}
