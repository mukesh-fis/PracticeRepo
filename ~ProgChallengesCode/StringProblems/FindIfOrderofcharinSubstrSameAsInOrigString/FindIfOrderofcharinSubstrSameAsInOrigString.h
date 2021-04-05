#pragma once
#include<iostream>
#include<cstring>
#include"FindIfOrderofcharinSubstrSameAsInOrigString.h"
using namespace std;

bool FindIfOrderOfcharInSubstrSameAsInOrigString(char * origStr, char* subStr)
{
	if (origStr == NULL || subStr == NULL)
		return false;

	int lenOrigStr = strlen(origStr);
	int lenSubStr = strlen(subStr);

	if (lenSubStr > lenOrigStr)
		return false;
	
	bool inOrder = true;
	int lastCharPosInOrigStr = -1;
	bool charFound = false;

	int ii = 0;
	for (; ii < lenSubStr; ii++)
	{
		charFound = false;
		for (int jj = ++lastCharPosInOrigStr; jj < lenOrigStr; jj++)
		{
			if (subStr[ii] == origStr[jj])
			{
				lastCharPosInOrigStr = jj;
				charFound = true;
				break;
			}
		}
		if (!charFound)
		{
			inOrder = false;
			break;
		}

	}

	if (ii < lenSubStr) inOrder = false;
	return inOrder;

}
