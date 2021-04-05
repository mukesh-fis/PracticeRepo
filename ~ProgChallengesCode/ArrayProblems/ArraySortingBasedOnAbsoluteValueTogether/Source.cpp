/*
Resort the array taking the absolute value of negative numbers. Your complexity should be O(n)

Ex. A = {-8,-5,-3,-1,3,6,9}
Output: {-1,-3,3,-5,6,-8,9}
*/

#include <iostream>
#include"ArraySortingAbsoluteValueTogether.h"
using namespace std;

int main()
{
    {
        std::cout << "Hello World!\n";
        int A[] = { -8,-5,-3,-1,3,6,9 };

        cout << "Before Sorting Array is: " << endl;
        for (auto x = begin(A); x != end(A); x++)
            cout << *x << " ";
        cout << endl;

        sortArray(A, 7);
        cout << "After Sorting Array is: " << endl;
        for (auto x = begin(A); x != end(A); x++)
            cout << *x << " ";
        cout << endl;
    }

    {
        int A[] = { -8,-5,-3,-1,3,6,9 };
        cout << "Before Sorting Array using sortArray2 is: " << endl;
        for (auto x = begin(A); x != end(A); x++)
            cout << *x << " ";
        cout << endl;

        sortArray2(A, 7);
        cout << "After Sorting Array is: " << endl;
        for (auto x = begin(A); x != end(A); x++)
            cout << *x << " ";
        cout << endl;
    }

}