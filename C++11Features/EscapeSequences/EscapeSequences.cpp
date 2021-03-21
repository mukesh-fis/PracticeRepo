// EscapeSequences.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
    std::cout << "Escape Sequences!\n";
    std::cout << "For Alert(bell) we use escape sequence a  - \a" << std::endl;
    std::cout << "For vertical tab we use escape sequence v  - \v in output" << std::endl;
    std::cout << "For horizontal tab we use escape sequence t  - \t in output" << std::endl;

    /*
    We can also write generalized escape sequence which is \x followed by one or more hexadecimal digits or
    a \ followed by one, two or three octal digits. The hex or octal value should represent numerical value of
    the character. For example - 
    \7  for   bell
    \12 for   newline
    \40 for   blank
    \x4d for 'M'
    */
    std::cout << "Bell sound: " << '\7' << std::endl;
    std::cout << "New line: " << '\12' << std::endl;
    std::cout << "Print M next: " << '\x4d' << std::endl;
}

