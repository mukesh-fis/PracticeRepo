// CapitalizeWordsofStringThatAreNotInList.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
/*
Given a string, say sentence=" this is crazy and fun" and a list, say name=["is", "fun"]. 
Now you need to capitalize on the first letter of every word in the given string
which is not present in the list.
*/

#include <iostream>
#include<list>
#include<cstring>
#include "CapitalizeWordsofStringThatAreNotInList.h"
using namespace std;

int main()
{
    list<string> listStr = { "is", "fun" };
    string str = "this is crazy and fun"; //input string
    capitalize(str, listStr);
}

bool isInList(char* tokStr, list<string> listStr)
{
    bool found = false;
    for (auto item : listStr)
    {
        if(str)
    }
}

string capitalize(string str, list<string> listStr)
{
    char* cstr = new char[strlen(str.c_str()) + 1];
    strcpy(cstr, str.c_str());


    char token = ' ';
    char* tokStr = strtok(cstr, &token);


    while (tokStr)
    {

    }
}


