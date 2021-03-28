/*
Given a matrix, clockwise rotate elements in it.
Examples:

Input
1    2    3
4    5    6
7    8    9

Output:
4    1    2
7    5    3
8    9    6

For 4*4 matrix
Input:
1    2    3    4
5    6    7    8
9    10   11   12
13   14   15   16

Output:
5    1    2    3
9    10   6    4
13   11   7    8
14   15   16   12

*/

#include <iostream>
#include <string>
#include <vector>
using namespace std;


class Solution
{
public:
	vector<int> output;
	int startRow = 2, startCol = 0;

	vector<int> RotateMatrixElemsClockwise(vector<vector<int> > matrix, int MAXROW, int MAXCOL)
	{
		int row = startRow, col = startCol - 1, iter = 0;

		while (output.size() < size_t(MAXROW * MAXCOL))
		{
			RotateUp(matrix, iter, row, col, MAXROW, MAXCOL);
			RotateRight(matrix, iter, row, col, MAXROW, MAXCOL);
			RotateDown(matrix, iter, row, col, MAXROW, MAXCOL);
			RotateLeft(matrix, iter, row, col, MAXROW, MAXCOL);
			
			iter++;
		}
		return output;
	}


	void RotateUp(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		//if(row == startRow)

		//if (col == -1) col = 0;

		for (++col, --row; row >= iter + 1; row--) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
		if (row == startRow - 1)
			row = iter, col = iter;
	}

	void RotateRight(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (row = iter, col = iter; col < MAXCOL - iter; col++)
		{
			output.push_back(matrix[row][col]);
			if (output.size() > MAXROW * MAXCOL)
				break;
		}
	}

	void RotateDown(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (--col, row = row + 1; row < MAXROW - iter; row++) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
	}

	void RotateLeft(vector<vector<int> > matrix, int &iter, int &row, int &col, int &MAXROW, int &MAXCOL)
	{
		for (--row, col = col - 1; col >= iter; col--) {
			output.push_back(matrix[row][col]);
			if (output.size() >= MAXROW * MAXCOL)
				break;
		}
	}


};
	
/*
int main()
{
	std::cout << "Hello World!\n";

	{
		vector<vector<int> > matrix =
		{   vector<int>{ 1, 2,  3, 4},
			vector<int>{ 5, 6,  7, 8 },
			vector<int>{ 9, 10, 11, 12 },
			vector<int>{ 13, 14, 15,16 }
		};

		Solution s;
		vector<int> output = s.RotateMatrixElemsClockwise(matrix, 4, 4);

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
		vector<int> output = s.RotateMatrixElemsClockwise(matrix, 4, 5);

		for (auto i : output)
			cout << i << " ";
		cout << endl;
		
	}
}

*/