#pragma once
#include <cstdlib>

void sortArray(int *a, int size)
{
	for (int ii = 0;  ii < size - 1; ii++)
	{
		for (int jj = ii + 1; jj < size; jj++)
		{
			if (abs(a[ii]) > abs(a[jj]))
			{
				int temp = a[ii];
				a[ii] = a[jj];
				a[jj] = temp;
			}
		}
	}
}


void sortArray2(int* a, const int size)
{
	int* finalArr = new int[size];
	finalArr[0] = 0;
	int posIndexStart = -1;
	while (a[++posIndexStart] < 0);

	//int A[] = { -8,-5,-3,-1,3,6,9 };
	//Now elements from 0 thorugh posIndexStart-1 are negative 
	//and elements from posIndexStart till end are positive
	//we need to traverse the first half of array of negative number with the second half of array of positive numbers
	//first half is -8, -5, -3, -1
	//second half is 3, 6, 9

	//To sort by absolute value we need to keep together -1 and 3, etc.
	int negIndexBackward = posIndexStart - 1;
	int ii = 0;

	while (negIndexBackward > 0 && posIndexStart < size)
	{
		if (abs(a[negIndexBackward]) <= abs(a[posIndexStart]))
		{
			finalArr[ii] = a[negIndexBackward--];
		}
		else
		{
			finalArr[ii] = a[posIndexStart++];
		}
		ii++;
	}

	while (negIndexBackward >= 0)
	{
		finalArr[ii++] = a[negIndexBackward--];
	}

	while (posIndexStart < size)
	{
		finalArr[ii++] = a[posIndexStart++];
	}

	for (int ii = 0; ii < size; ii++)
	{
		a[ii] = finalArr[ii];
	}
}
