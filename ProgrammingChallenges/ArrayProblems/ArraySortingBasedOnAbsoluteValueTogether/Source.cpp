/*
Resort the array taking the absolute value of negative numbers. Your complexity should be O(n)

Ex. A = {-8,-5,-3,-1,3,6,9}
Output: {-1,-3,3,-5,6,-8,9}
*/

#include<iostream>
#include<cstdlib>
using namespace std;


int main()
{
	cout << "Hello!" << endl;
	int arr[] = { -8,-5,-3,-1,3,6,9 };

	int size = sizeof(arr) / sizeof(*arr);
	cout << "Size of arr is " << size << endl;

	for (int ii = 0; ii < size - 1; ++ii)
	{
		for (int jj = ii + 1; jj < size ; ++jj)
		{
			if (abs(arr[ii]) > (arr[jj]))
			{
				int temp = arr[ii];
				arr[ii] = arr[jj];
				arr[jj] = temp;
			}
		}
	}

	for (int ii = 0; ii < size; ii++)
		cout << arr[ii] << " ";
	return 0;


}