#pragma once
#include<iostream>
#include<sstream>
using namespace std;
/*
Given a string str containing only lowercase characters. 
The task is to print the characters having prime frequency in the order of their occurrence.

Note that repeated elements with prime frequencies are printed as many times as 
they occur in order of their occurrence.
Examples:

Input: str = “geeksforgeeks”
Output: gksgks
*/

bool isPrime(int num)
{
	bool isPrime = true;
	for (int ii = 2; ii < num; ii++)
	{
		if (num % ii == 0)
		{
			isPrime = false;
			break;
		}
	}

	return isPrime;
}

string PrintCharWithPrimeFrequency(string input)
{
	const int MAX_ALPHA_COUNT = 26;
	int frequencies[MAX_ALPHA_COUNT] = {0};

	for (auto c : input)
	{
		frequencies[c - 'a']++;
	}

	stringstream ss;
	for (auto c : input)
	{
		if (frequencies[c - 'a'] > 1 && isPrime(frequencies[c - 'a']))
		{
			ss << c << " " << frequencies[c - 'a'] << endl;
		}
	}

	return ss.str();
}