﻿/*

This problem follows the 0/1 Knapsack pattern.
A basic brute-force solution could be to try all combinations of partitioning the given numbers into two sets
to see if any pair of sets has an equal sum.

Assume if S represents the total sum of all the given numbers,
then the two equal subsets must have a sum equal to S/2. This essentially transforms our problem to: "Find a subset of the given numbers that has a total sum of S/2".

So our brute-force algorithm will look like:

for each number 'i'
  create a new set which INCLUDES number 'i' if it does not exceed 'S/2', and recursively
	  process the remaining numbers
  create a new set WITHOUT number 'i', and recursively process the remaining items
return true if any of the above sets has a sum equal to 'S/2', otherwise return false

Note:
The time complexity of the above algorithm is exponential O(2^n)O(2^​n),
where ‘n’ represents the total number. The space complexity is O(n),
this memory which will be used to store the recursion stack.
*/

using namespace std;

#include <iostream>
#include <vector>

class PartitionSet {
public:
	bool canPartition(const vector<int> &num) {
		int sum = 0;
		for (int i = 0; i < num.size(); i++) {
			sum += num[i];
		}

		// if 'sum' is a an odd number, we can't have two subsets with equal sum
		if (sum % 2 != 0) {
			return false;
		}

		return this->canPartitionRecursive(num, sum / 2, 0);
	}

private:
	bool canPartitionRecursive(const vector<int> &num, int sum, int currentIndex) {
		// base check
		if (sum == 0) {
			return true;
		}

		if (num.empty() || currentIndex >= num.size()) {
			return false;
		}

		// recursive call after choosing the number at the currentIndex
		// if the number at currentIndex exceeds the sum, we shouldn't process this
		if (num[currentIndex] <= sum) {
			if (canPartitionRecursive(num, sum - num[currentIndex], currentIndex + 1)) {
				return true;
			}
		}

		// recursive call after excluding the number at the currentIndex
		return canPartitionRecursive(num, sum, currentIndex + 1);
	}
};

//int main(int argc, char *argv[]) {
//	PartitionSet ps;
//	vector<int> num = { 1, 2, 3, 4 };
//	cout << ps.canPartition(num) << endl;
//	num = vector<int>{ 1, 1, 3, 4, 7 };
//	cout << ps.canPartition(num) << endl;
//	num = vector<int>{ 2, 3, 4, 6 };
//	cout << ps.canPartition(num) << endl;
//}

/*
Solution 2:
Top-down Dynamic Programming with Memoization
We can use memoization to overcome the overlapping sub-problems.
As stated in previous lessons, memoization is when we store the results of
all the previously solved sub-problems return the results from memory
if we encounter a problem that has already been solved.

Since we need to store the results for every subset and for every possible sum,
therefore we will be using a two-dimensional array to store the results of the solved sub-problems.
The first dimension of the array will represent different subsets and the second dimension will represent
different ‘sums’ that we can calculate from each subset.
These two dimensions of the array can also be inferred from the two changing values (sum and currentIndex)
in our recursive function canPartitionRecursive().

*/

using namespace std;

#include <iostream>
#include <vector>

class PartitionSet2 {
public:
	bool canPartition(const vector<int> &num) {
		int sum = 0;
		for (int i = 0; i < num.size(); i++) {
			sum += num[i];
		}

		// if 'sum' is a an odd number, we can't have two subsets with equal sum
		if (sum % 2 != 0) {
			return false;
		}

		vector<vector<int>> dp(num.size(), vector<int>(sum / 2 + 1, -1));
		return this->canPartitionRecursive(dp, num, sum / 2, 0);
	}

private:
	bool canPartitionRecursive(vector<vector<int>> &dp, const vector<int> &num, int sum,
		int currentIndex) {
		// base check
		if (sum == 0) {
			return true;
		}

		if (num.empty() || currentIndex >= num.size()) {
			return false;
		}

		// if we have not already processed a similar problem
		if (dp[currentIndex][sum] == -1) {
			// recursive call after choosing the number at the currentIndex
			// if the number at currentIndex exceeds the sum, we shouldn't process this
			if (num[currentIndex] <= sum) {
				if (canPartitionRecursive(dp, num, sum - num[currentIndex], currentIndex + 1)) {
					dp[currentIndex][sum] = 1;
					return true;
				}
			}

			// recursive call after excluding the number at the currentIndex
			dp[currentIndex][sum] = canPartitionRecursive(dp, num, sum, currentIndex + 1) ? 1 : 0;
		}

		return dp[currentIndex][sum] == 1 ? true : false;
	}
};

int main(int argc, char *argv[]) {
	PartitionSet ps;
	vector<int> num = { 1, 2, 3, 4 };
	cout << ps.canPartition(num) << endl;
	num = vector<int>{ 1, 1, 3, 4, 7 };
	cout << ps.canPartition(num) << endl;
	num = vector<int>{ 2, 3, 4, 6 };
	cout << ps.canPartition(num) << endl;
}