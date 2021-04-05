// ConvertToCamelCase.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Input: a variable name with possibly underscore.
//output: a variable name with all underscore removed and all first letter after each underscore capitalized
//

#include <iostream>
#include <cstring>
#include <string>
using namespace std;

//Method 1
char* modify_variableName(char* str)
{
	if (str == NULL)
		return str;

	int len = strlen(str);
	char* newstr = new char[len + 1];
	memset(newstr, '\0', sizeof(newstr));

	char* nextToken = strtok(str, "_");
	if (nextToken != NULL)
		strcat(newstr, nextToken);

	while (nextToken)
	{
		nextToken = strtok(NULL, "_");

		if (nextToken != NULL)
		{
			if (nextToken[0] >= 'a' && nextToken[0] <= 'z')
				nextToken[0] -= 32;
			strcat(newstr, nextToken);
		}
	}
	return newstr;
}

//Method 2

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

const char* modify_variableName3(char* input)
{
	string inputStr(input);

	if (inputStr.length() == 0)
		return NULL;

	string *outValue = new string();
	int underscoreFound = 0;
	underscoreFound = inputStr.find("_");

	if (underscoreFound != string::npos)  //string contains underscore, so convert to camelcase
	{
		for (int i = 0; i < inputStr.length(); i++)
		{
			if (inputStr[i] == '_')	continue;

			if (i >= 1 && inputStr[i - 1] == '_')
				inputStr[i] = toupper(inputStr[i]);

			*outValue += inputStr[i];
		}
	}
	else //convert to underscore format from camel case
	{
		for (int i = 0; i < inputStr.length(); i++)
		{
			if (inputStr[i] >= 'A' && inputStr[i] <= 'Z' && i >= 1)
			{
				*outValue += "_";
				*outValue += tolower(inputStr[i]);
			}
			else
				*outValue += inputStr[i];
		}
		*outValue += "\0";
	}

	return (*outValue).c_str();
}

int main()
{
	string str2 = "hello__World_where_are_you_";
	cout << endl << "modify_variableName2 = " << modify_variableName2(str2);

	{
		char str[] = "modify_Variable";
		cout << endl << "modify_variableName = " << modify_variableName(str);
	}

	{
		char str[] = "modifyVariable";
		string outVal = modify_variableName3(str);
		cout << endl << "modifyVariable = " << modify_variableName3(str);
	}
}

