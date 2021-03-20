#include<iostream>
using namespace std;

int main()
{
	int arr[] = { 10, 20, 30, 40, 50 };

	int* p2 = begin(arr), * p1 = end(arr);

	cout << p1 << " " << p2 << endl;
	p1 += p2 - p1;

	cout << p1 << " " << p2 << endl;
	return 0;
}


//Write a program to compare two arrays for equality

int arrayCompare()
{
	int arr1[] = { 10, 20, 30 };
	int arr2[] = { 10, 20, 30, 40 };
	int retVal = 0;
	auto lenArr1 = end(arr1) - begin(arr1);
	auto lenArr2 = end(arr1) - begin(arr1);

	if (lenArr1 != lenArr2)
	{
		cout << "Arrays are unequal!!!" << endl;
		retVal = -1;
		return retVal;
	}

	//for (auto )


	return retVal;
}
