// NullPointer.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
    std::cout << "Null Pointers!\n";
    /*
    Note 1:
    A null pointer does not point to any object. There are several ways to obtain null pointer.
    Method 1: Directly initialize with literal constant 0.
    */
    int *p1 = 0;

    /*
    Method 2: 
    Use NULL instead of 0. NULL is a preprocessor variab;e defined in cstdlib header.
    */
    int *p2 = NULL;

    /*
    Method 3:
    C++ 11 introduces nullptr to be used in such cases.
    */
    int* p3 = nullptr;

}

