// PracticeProgChallenges.cpp : This file contains the 'main' function. Program execution begins and ends there.
/*
Given a text string and a sample string.
Find if the characters of the sample string is in the same order in the text string..
Give a simple algo..

Eg.. TextString: abcNjhgAhGjhfhAljhRkhgRbhjbevfhO
Sample string :NAGARRO
*/

#include <iostream>
#include "FindIfOrderofcharinSubstrSameAsInOrigString.h"
using namespace std;

int main()
{
    {
        char origStr[] = "abcNjhgAhGjhfhAljhRkhgRbhjbevfhO";
        char subStr[] = "NAGARRO";
        bool found = FindIfOrderOfcharInSubstrSameAsInOrigString(origStr, subStr);
        cout << "found = " << found << endl;
    }

}

