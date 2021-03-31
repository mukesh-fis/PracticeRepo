// MatrixRotationBy90Degree.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Solution
{
public:
	void RoteteMatrixBy90Degree(vector<vector<int> > matrix, int MAXROW, int MAXCOL)
	{
		for (int col = 0; col < MAXCOL; ++col)
		{
			for (int row = MAXROW - 1; row >= 0; --row)
				cout << matrix[row][col] << " ";
			cout << endl;
		}
	}
};

int main()
{
	std::cout << "Matrix rotation by 90 degree!\n";

	vector<vector<int> > matrix =
	{   vector<int>{ 1,   2,  3,  4},
		vector<int>{ 5,   6,  7,  8 },
		vector<int>{ 9,  10,  11, 12 },
		vector<int>{ 13, 14,  15, 16 }
	};

	Solution s;
	s.RoteteMatrixBy90Degree(matrix, 4, 4);
}

