/*
Given an array A of N elements. Find the majority element in the array.
A majority element in an array A of size N is an element that appears more than N/2 times in the array.

Example 1:

Input:
N = 3
A[] = {1,2,3}
Output:
-1
Explanation:
Since, each element in {1,2,3} appears only once so there is no majority element.

Input:
N = 5
A[] = {3,1,3,3,2}
Output:
3
Explanation:
Since, 3 is present more than N/2 times, so it is the majority element.

Your Task:
The task is to complete the function majorityElement() which returns the majority element in the array. If no majority exists, return -1.


Expected Time Complexity: O(N).
Expected Auxiliary Space: O(1).


Constraints:
1 <= N <= 107
0 <= Ai <= 106

*/

#include <iostream>
#include <algorithm>
#include <vector>
#include "BST.cpp"
using namespace std;


class Solution {
public:
   // Function to find majority element in the array
   // a: input array
   // size: size of input array
   //Note: This approach uses two loops and complexity is O(N^2)
	int majorityElement(int a[], int size)
	{
		for (int ii = 0; ii <= size / 2 + 1; ii++)
		{
			int cnt_i = 0;

			for (int j = 0; j < size; ++j)
			{
				if (a[ii] == a[j]) cnt_i++;
			}

			if (cnt_i > size / 2)
			{
				return a[ii];
			}

		}

		return -1;
	}

	//Let's use BST improve performance 
	/*
	Approach: Insert elements in BST one by one and if an element is already present then increment the count of the node. At any stage, if the count of a node becomes more than n/2 then return.
	Algorithm: 
		Create a binary search tree, if same element is entered in the binary search tree the frequency of the node is increased.
		
		Traverse the array and insert the element in the binary search tree.

		If the maximum frequency of any node is greater than the half the size of the array, then perform a inorder traversal and find the node with frequency greater than half
		
		Else print No majority Element.
	*/

	int majorityElementUsingBST(int a[], int size)
	{
		BST bst(size);
		int majorityElement = -1;
		//read the array values and make a BST
		for (int ii = 0; ii < size; ii++)
		{
			//if key is not present in the BST, create a new node, find its correct place in the tree and insert the node.
			//Find if ii is present in BST. If yes, increment the frequency of the node. And if frequency exceeds size / 2, return key of this node.

			bst.insert(a[ii], majorityElement);
			if (majorityElement != -1)
			{
				bst.printBSTInorder();
				return majorityElement;
			}

		}
		return -1;
	}
};

int main()
{
    std::cout << "Finding Majority Element in an Array!\n";
	{
		int A[] = { 3,1,3,3,2 };
		int N = 5;
		Solution s;
		cout << s.majorityElement(A, N) << endl;
		cout << s.majorityElementUsingBST(A, N) << endl;
	}

	{
		int A[] = { 3, 1, 3, 3, 2, 2, 2, 2, 2};
		int N = 9;
		Solution s;
		//cout << s.majorityElement(A, N) << endl;
		cout << s.majorityElementUsingBST(A, N) << endl;
	}

	{
		int A[] = { 3,1,3,2 };
		int N = 4;
		Solution s;
		//cout << s.majorityElement(A, N) << endl;
		cout << s.majorityElementUsingBST(A, N) << endl;
	}
	return 0;
}

