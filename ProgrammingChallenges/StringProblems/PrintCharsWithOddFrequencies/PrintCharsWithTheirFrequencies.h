// FindCharacterFrequencyAfterEachCharacter.cpp : This file contains the 'main' function. Program execution begins and ends there.
/*

Given a string str containing only lowercase characters.
The problem is to print the characters along with their frequency in the order of their occurrence and in the given format explained in the examples below.
Examples:

Input : str = "geeksforgeeks"
Output : g2 e4 k2 s2 f1 o1 r1

Input : str = "elephant"
Output : e2 l1 p1 h1 a1 n1 t1
*/

#include <iostream>
#include <sstream>
#include<unordered_map>
using namespace std; 

//Sol 1 - Using Hashmap (unordered_map)
string GetCharFrequencyInOrder(string str)
{
	stringstream result;
	unordered_map<char, int> letterFrequencyMap;

	for (auto c : str)
	{
		letterFrequencyMap[c]++;
	}

	for (auto c : str)
	{
		if (letterFrequencyMap[c] > 0)
		{
			result << c << letterFrequencyMap[c];
			letterFrequencyMap[c] = 0;
		}
	}
	return result.str();
}

//Sol-2 Using char Array Frequency
string GetCharFrequencyInOrderUsingArray(string str)
{
	stringstream resultStr;
	int letterPos[26];
	memset(letterPos, 0, sizeof(letterPos));

	for (auto c : str)
	{
		letterPos[c - 'a']++;
	}

	for (auto c : str)
	{
		if (letterPos[c - 'a'] > 0)
		{
			resultStr << c << letterPos[c - 'a'];
			letterPos[c - 'a'] = 0;
		}
	}
	return resultStr.str();
}

//Sol-3 Using char Array Frequency C-Style
char* GetCharFrequencyInOrderUsingArrayCStyle(char* str)
{
	if (str == NULL) return str;

	char* resultStr = new char[strlen(str) + 1];
	int   letterPos[26];
	char  tempStr[4];

	memset(letterPos, 0, sizeof(letterPos));
	memset(resultStr, 0, sizeof(resultStr));
	memset(tempStr,   0, sizeof(tempStr));

	for (int i = 0; i< strlen(str); i++)
	{
		letterPos[str[i] - 'a']++;
	}

	for (int i = 0; i < strlen(str); i++)
	{
		if (letterPos[str[i] - 'a'] > 0)
		{
			sprintf_s(tempStr, "%c%d", str[i], (letterPos[str[i] - 'a']));
			strcat(resultStr, tempStr);
			letterPos[str[i] - 'a'] = 0;
		}
	}

	return resultStr;
}

