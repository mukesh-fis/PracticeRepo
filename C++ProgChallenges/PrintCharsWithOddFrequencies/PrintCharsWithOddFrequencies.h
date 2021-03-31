/*
Print characters having odd frequencies in order of occurrence.

Given a string str containing only lowercase characters. The task is to print the characters having an odd frequency in the order of their occurrence.
Note: Repeated elements with odd frequency are printed as many times they occur in order of their occurrences.
Examples:

Input: str = “geeksforgeeks”
Output: for

*/

#pragma once
#include <iostream>
#include <sstream>
using namespace std;


string PrintCharsWithOddFrequencies(string input)
{
	int frequency[26] = { 0 };
	for (auto c : input)
	{
		frequency[c - 'a']++;
	}

	stringstream ss;
	for (auto c : input)
	{
		if (frequency[c - 'a'] % 2 == 1)
		{
			ss << c << " " << frequency[c - 'a'] << endl;
			frequency[c - 'a'] = 0;
		}
	}
	return ss.str();
}

