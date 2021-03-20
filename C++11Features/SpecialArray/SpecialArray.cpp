// FindMoveToMakeArraySpecial.cpp : This file contains the 'main' function. Program execution begins and ends there.
/*
Given an integer array arr of length N and an integer X,
the task is to find the minimum number of array elements to be replaced by a value from the range [1, X]
 such that each pair (arr[i], arr[N – 1 – i]) have equal sum.
*/

#include <iostream>
#include <vector>
#include<map>
#include <algorithm> 
#include<cmath>
using namespace std;
const int MAXNUM = 10 * 5;

//Function to validate constraints
int ValidateInput(int A[], int N, int X)
{
    //Validate Input
    if (N < 2 || N > MAXNUM)
        return -1;

    if (X < 1 || X > MAXNUM)
        return -1;

    for (int ii = 0; ii < N; ii++)
        if (A[ii] > X)
            return -1;

    return 0;
}

// Function to find the minimum 
// replacements required 
int FindMoveToMakeArraySpecial(int A[], int N, int X)
{
    if (ValidateInput(A, N, X) < 0) return -1;
    int ans = MAXNUM;

    // Stores the maximum and minimum 
    // values for every pair of 
    // the form A[i], A[n-i-1] 
    vector<int> max_values;
    vector<int> min_values;

    // Map for storing frequencies 
    // of every sum formed by pairs 
    map<int, int> sum_equal_to_x;

    for (int i = 0; i < N / 2; i++) {

        // Minimum element in the pair 
        int mn = min(A[i], A[N - i - 1]);

        // Maximum element in the pair 
        int mx = max(A[i], A[N - i - 1]);

        // Incrementing the frequency of 
        // sum encountered 
        sum_equal_to_x[A[i]
            + A[N - i - 1]]++;

        // Insert minimum and maximum values 
        min_values.push_back(mn);
        max_values.push_back(mx);
    }

    // Sorting the vectors 
    sort(max_values.begin(),
        max_values.end());

    sort(min_values.begin(),
        min_values.end());

    // Iterate over all possible values of x 
    for (int x = 2; x <= 2 * X; x++) {

        // Count of pairs for which x > x + k 
        int mp1
            = lower_bound(max_values.begin(),
                max_values.end(), x - X)
            - max_values.begin();

        // Count of pairs for which x < mn + 1 
        int mp2
            = lower_bound(min_values.begin(),
                min_values.end(), x)
            - min_values.begin();

        // Count of pairs requiring 2 replacements 
        int rep2 = mp1 + (N / 2 - mp2);

        // Count of pairs requiring no replacements 
        int rep0 = sum_equal_to_x[x];

        // Count of pairs requiring 1 replacement 
        int rep1 = (N / 2 - rep2 - rep0);

        // Update the answer 
        ans = min(ans, rep2 * 2 + rep1);
    }

    // Return the answer 
    return ans;
}




void main()
{
    std::cout << "Special Array Program!\n";
    int A[] = { 2, 2, 3, 1};

    int moveCount = FindMoveToMakeArraySpecial(A, 4, 3);
    if (moveCount == -1)
    {
        cout << "Contraints not fulfilled. Please pass correct prameter values. " << endl;
        return ;
    }
    else
    {
        cout << "Move needed =" << moveCount << endl;
    }
    return ;
}





