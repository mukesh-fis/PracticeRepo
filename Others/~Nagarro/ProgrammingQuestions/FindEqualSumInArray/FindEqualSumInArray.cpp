/*
WAP to find subsets that contains equal sum in an array:

Example - 
{1,2,3,4,2}->{1,2,3}&&{4,2}

{1,1,3,3,2,8}->{1,3,3,2}&&{1,8}

{1,3,4,7}->no subset
*/

// C++ implementation of the approach
#include <iostream>
#include<vector>
#include<map>
using namespace std;
void findEqualSumPairs(int A[], int n) {
	map<int, vector<pair<int, int> > >map1;
	for (int i = 0; i < n - 1; i++) {
		for (int j = i + 1; j < n; j++) {
			pair<int, int> p = make_pair(A[i], A[j]);
			map1[A[i] + A[j]].push_back(p);
		}
	}
	for (auto value = map1.begin(); value != map1.end(); value++) {
		if (value->second.size() > 1) {
			for (int i = 0; i < value->second.size(); i++) {
				cout << "[ " << value->second[i].first << ", " << value->second[i].second << "] ";
			}
			cout << "have sum : " << value->first << endl;
		}
	}
}
int main() {
	int A[] = { 6, 4, 12, 10, 22,11, 8, 2 };
	int n = sizeof(A) / sizeof(A[0]);
	cout << "Pairs with same sum are : \n";
	findEqualSumPairs(A, n);
	return 0;
}
