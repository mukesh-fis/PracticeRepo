// ConvertToCamelCase.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Input: a variable name with possibly underscore.
//output: a variable name with all underscore removed and all first letter after each underscore capitalized
//

#include <iostream>
#include <cstring>
#include <string>
using namespace std;

char* modify_variableName(char* inputStr)
{
	if (inputStr == NULL)
		return inputStr;

	int len = strlen(inputStr);
	char *outValue = new char[len + 1];
	memset(outValue, '\0', sizeof(outValue));

	char* nextToekn = strtok(inputStr, "_");
	outValue = strcat(outValue, nextToekn);

	while (nextToekn)
	{
		//cout << nextToekn << endl;
		nextToekn = strtok(NULL, "_");

		if (nextToekn != NULL)
		{
			if (nextToekn[0] >= 'a' && nextToekn[0] <= 'z')
				nextToekn[0] -= 32;

			outValue = strcat(outValue, nextToekn);
		}
				
	}
	return outValue;
}


string modify_variableName2(string inputStr)
{
	if (inputStr.length() == 0)
		return inputStr;

	string outValue;

	for (int i = 0; i < inputStr.length(); i++)
	{
		if (inputStr[i] == '_')	continue;

		if (i >= 1 && inputStr[i - 1] == '_')
			inputStr[i] = toupper(inputStr[i]);

		outValue += inputStr[i];
	}

	return outValue;
}

int main()
{
	char str[] = "hello__World_where_are_you_";
	cout << endl << "modify_variableName = " << modify_variableName(str);

	string str2 = "hello__World_where_are_you_";
	cout << endl << "modify_variableName2 = " << modify_variableName2(str2);
}

