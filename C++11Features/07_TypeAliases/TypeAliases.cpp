// TypeAliases.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<iomanip>
#include <limits>  // std::numeric_limits
using namespace std;

int main()
{
    std::cout << "Type Aliases!\n";

    /*
    typedef has been used to create type aliases in C/C++
    */
    typedef wchar_t wc;  //wc is an alias to wchar_t
    typedef double base, *p; //base is synonym for double and p for double*

    typedef char *pstring;  //pstring is synonym for char*
    const pstring cstr = 0; //cstr is const pointer to char. We should not interpret it as pointer to a const char
    const pstring *ps;      //ps is a pointer to a const pointer to char

    /*
     New standard C++11 defines another way of creating a type alias with using statement.
    */
    using wc16 = char16_t;  //wc16 is a synonym for 
    cout << left << setw(12) << "char16_t" << setw(30) << "unicode char 16 bits" << setw(25) << "16 bits" << setw(25) << std::numeric_limits<wc16>::min() << setw(20) << std::numeric_limits<wc16>::max() << setw(10) << std::numeric_limits<wc16>::is_signed << endl;

}

