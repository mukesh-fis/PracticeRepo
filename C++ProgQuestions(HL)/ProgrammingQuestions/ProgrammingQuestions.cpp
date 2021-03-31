/*
Anagram
Given two strings a and b consisting of lowercase characters.
The task is to check whether two given strings are an anagram of each other or not. 
An anagram of a string is another string that contains the same characters, only the order of characters can be different. 
For example, “act” and “tac” are an anagram of each other.

Example 1:
Input:
a = geeksforgeeks, b = forgeeksgeeks
Output: YES
Explanation: Both the string have same characters with same frequency. So,
both are anagrams.

Example 2:

Input:
a = allergy, b = allergic
Output: NO
Explanation:Characters in both the strings are not same, so they are not anagrams.
*/

#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

class Solution
{

public:

	/*  Function to check if two strings are anagram
	*   a, b: input string
	*/
	bool isAnagram(string a, string b)
	{
		//cout << "Before sorting string 1 is " + a  << endl;
		sort(begin(a), end(a));
		//cout << "After sorting string 1 is " + a   << endl;

		//cout << "Before sorting string 2 is " + b << endl;
		sort(begin(b), end(b));
		//cout << "After sorting string 2 is " + b << endl;

		return (a == b) ? true : false;

	}

};


int main()
{
    std::cout << "Hello World!\n";
	Solution s;
	string str1 = "cat";
	string str2 = "tac";
	cout << (s.isAnagram(str1, str2) ? "Strings are anagram." : "Not anagrams") << endl;

	cout << (s.isAnagram("allergy",  "allergic") ? "Strings are anagram." : "Not anagrams") << endl;

	cout << (s.isAnagram("geeksforgeeks", "forgeeksgeeks") ? "Strings are anagram." : "Not anagrams") << endl;

}



