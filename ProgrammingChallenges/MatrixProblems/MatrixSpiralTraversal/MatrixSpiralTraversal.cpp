/*
Given a matrix of size R*C. Traverse the matrix in spiral form.

Example 1:

Input:
R = 4, C = 4
matrix[][] = {{1, 2, 3, 4},
			  {5, 6, 7, 8},
			  {9, 10, 11, 12},
			  {13, 14, 15,16}}
Output:
1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10
Explanation:

Example 2:

Input:
R = 3, C = 4
matrix[][] = {{1, 2, 3, 4},
		   {5, 6, 7, 8},
		   {9, 10, 11, 12}}
Output:
1 2 3 4 8 12 11 10 9 5 6 7
Explanation:
Applying same technique as shown above,
output for the 2nd testcase will be
1 2 3 4 8 12 11 10 9 5 6 7.

Your Task:
You dont need to read input or print anything. Complete the function spirallyTraverse() that takes matrix, R and C as input parameters and returns a list of integers denoting the spiral traversal of matrix.

Expected Time Complexity: O(R*C)
Expected Auxiliary Space: O(R*C)
*/

#include <iostream>
#include <string>
#include <vector>
using namespace std;


class Solution
{
public:
	vector<int> output;


	vector<int> spirallyTraverseV2(vector<vector<int> > matrix, int MAXROW, int MAXCOL)
	{
		int row = 0, col = 0, iter = 0;


		while (output.size() < size_t(MAXROW * MAXCOL))
		{
			printRight(matrix, iter, row, col, MAXROW, MAXCOL);
			printDown(matrix, iter, row, col, MAXROW, MAXCOL);
			printLeft(matrix, iter, row, col, MAXROW, MAXCOL);
			printUp(matrix, iter, row, col, MAXROW, MAXCOL);
			iter++;
		}
		return output;
	}

	vector<int> spirallyTraverse(vector<vector<int> > matrix, int MAXROW, int MAXCOL)
	{
		int row = 0, col = 0, iter = 0;


		while (output.size() < size_t(MAXROW * MAXCOL))
		{
			for (row = iter, col = iter; col < MAXCOL - iter; col++)
			{
				output.push_back(matrix[row][col]);
				if (output.size() > MAXROW * MAXCOL)
					break;
			}

			for (--col, row = row + 1; row < MAXROW - iter; row++) {
				output.push_back(matrix[row][col]);
				if (output.size() >= MAXROW * MAXCOL)
					break;
			}

			for (--row, col = col - 1; col >= iter; col--) {
				output.push_back(matrix[row][col]);
				if (output.size() >= MAXROW * MAXCOL)
					break;
			}

			for (++col, row--; row >= iter + 1; row--) {
				output.push_back(matrix[row][col]);
				if (output.size() >= MAXROW * MAXCOL)
					break;
			}
			iter++;
		}
		return output;
	}

	void printRight(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW,int &MAXCOL)
	{
		for (row = iter, col = iter; col < MAXCOL - iter; col++)
		{
			output.push_back(matrix[row][col]);
			if (output.size() > MAXROW * MAXCOL)
				break;
		}
	}

	void printDown(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (--col, row = row + 1; row < MAXROW - iter; row++) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
	}

	void printLeft(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (--row, col = col - 1; col >= iter; col--) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
	}

	void printUp(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (++col, row--; row >= iter + 1; row--) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
	}
};

int main()
{
	std::cout << "Hello World!\n";

	{
		vector<vector<int> > matrix =
		{ vector<int>{1, 2, 3, 4},
			vector<int>{ 5, 6, 7, 8 },
			vector<int>{ 9, 10, 11, 12 },
			vector<int>{ 13, 14, 15,16 }
		};

		Solution s;
		vector<int> output = s.spirallyTraverse(matrix, 4, 4);

		for (auto i : output)
			cout << i << " ";
		cout << endl;
	}

	
	{

		vector<vector<int> > matrix =
		{ vector<int>{1, 2, 3, 4, 5},
			vector<int>{ 5, 6, 7, 8, 9 },
			vector<int>{ 9, 10, 11, 12, 13 },
			vector<int>{ 13, 14, 15,16, 17 }
		};

		Solution s;
		vector<int> output = s.spirallyTraverse(matrix, 4, 5);

		for (auto i : output)
			cout << i << " ";
		cout << endl;
	}
}


