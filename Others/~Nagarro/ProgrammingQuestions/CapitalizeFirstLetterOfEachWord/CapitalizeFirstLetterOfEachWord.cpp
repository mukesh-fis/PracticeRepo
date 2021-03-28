/*
Write a program to convert the first character uppercase in a sentence 
and if apart from the first character if any other character is in Uppercase then convert into Lowercase?
*/

// C++ program to convert
// first character uppercase
// in a sentence
#include <iostream>
#include <string>
using namespace std;

string convert(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		// If first character of a
		// word is found
		if (i == 0 && str[i] != ' ' ||
			str[i] != ' ' && str[i - 1] == ' ')
		{
			// If it is in lower-case
			if (str[i] >= 'a' && str[i] <= 'z')
			{
				// Convert into Upper-case
				str[i] = (char)(str[i] - 'a' + 'A');
			}
		}

		// If apart from first character
		// Any one is in Upper-case
		else if (str[i] >= 'A' &&
				str[i] <= 'Z')

		// Convert into Lower-Case
		str[i] = (char)(str[i] + 'a' - 'A');
	}

	return str;
}

// Driver code
int main()
{
string str = "gEEks fOr GeeKs";
std::cout << str << endl;;
cout << convert(str) << endl;
return 0;
}

// This code is contributed by Chitranayal
