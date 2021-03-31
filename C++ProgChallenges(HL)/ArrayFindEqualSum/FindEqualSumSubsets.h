/*
WAP to find subsets that contains equal sum in an array:

Example -
{1,2,3,4,2}->{1,2,3}&&{4,2}

{1,1,3,3,2,8}->{1,3,3,2}&&{1,8}

{1,3,4,7}->no subset
*/

#include<vector>
#include<iostream>
#include<map>
#include <numeric> 
using namespace std;

pair<vector<int>, vector<int>> GetPairOfSubsets(vector<int>& vec, size_t partition)
{
	vector<int> leftSubset;
	vector<int> rightSubset;

	for (vector<int>::size_type jj = 0; jj <= partition; jj++)
	{
		leftSubset.push_back(vec[jj]);
	}

	for (vector<int>::size_type jj = partition + 1; jj < vec.size(); jj++)
	{
		rightSubset.push_back(vec[jj]);
	}

	pair<vector<int>, vector<int>> p;
	p.first = leftSubset;
	p.second = rightSubset;

	return p;

}

vector<pair<vector<int>, vector<int>>> GetSubsetWithEqualSums(vector<int>& vec)
{
	vector<pair<vector<int>, vector<int>>> result;

	if (vec.size() < 2)
	{
		cout << "At least two values should be there in the subset" << endl;
		return result;
	}

	for (vector<int>::size_type jj = 1; jj < vec.size(); jj++)
	{
		pair<vector<int>, vector<int>> p = GetPairOfSubsets(vec, jj);

		if (accumulate(p.first.begin(), p.first.end(), 0) ==
			accumulate(p.second.begin(), p.second.end(), 0))
			result.push_back(p);
	}
	return result;
}

void printResult(vector<int>& v)
{
	vector<pair<vector<int>, vector<int>>> result = GetSubsetWithEqualSums(v);

	//if (result.size > 0)
	//{
	//	cout << "No Subset" << endl;
	//	return;
	//}

	for (auto a : result)
	{
		for (auto b : a.first)
			cout << b << ",";

		cout << "=>";

		for (auto b : a.second)
			cout << b << ",";

		cout << endl;
	}
}

/*
int main()
{
	{
		vector<int> v = { 1,2,3,4,2 };
		printResult(v);
	}
	{
		vector<int> v = { 1,1,3,3,2,8 };
		printResult(v);
	}
	{
		vector<int> v = { 1,3,4,7 };
		printResult(v);
	}


}
*/