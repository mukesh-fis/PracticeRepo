// 04_InlineVariableForExternConst_C++17.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "file.h"

int main()
{
    std::cout << "Inline Variables!\n";
    /*
    Note: C++ 17 provides a new feature called inline variable to substitute the need of extern const.
    This is described in this project.

    Note:
    To allow using c++14 or 17 features, we may need to follow the steps:
    There's now a drop down (at least since VS 2017.3.5) where you can specifically select C++17. 
    The available options are (under project > Properties > C/C++ > Language > C++ Language Standard)

    ISO C++14 Standard. msvc command line option: /std:c++14
    ISO C++17 Standard. msvc command line option: /std:c++17
    The latest draft standard. msvc command line option: /std:c++latest
    (I bet, once C++20 is out and more fully supported by Visual Studio it will be /std:c++20)
    */

    std::cout << "bufSize :" << buffsize << std::endl;
    std::cout << "fcnInFile2 returns :" << fcnInFile2() << std::endl;
}

