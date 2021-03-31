// lambda_prctice.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<vector>
#include<algorithm>
using namespace std;

int main()
{
    std::cout << "Hello World!\n";

    cout << "*************************************************" << endl;
    auto f = [](int a, int b) -> int {return a + b; };
    std::cout << f(3, 5) << endl;

    cout << "*************************************************" << endl;
    vector<string> words = { "abc", "hi", "hello", "when", "love", "to", "abc", "cat", "hi" };
    cout << "Print words from the words vector" << endl;
    for (auto x : words)
        cout << x << "\t";
    cout << endl;
    cout << "*************************************************" << endl;

    //sort words alphabetically
    sort(words.begin(), words.end());

    //print words after sorting
    cout << "print words after sorting" << endl;
    for (auto x : words)
        cout << x << "\t";
    cout << endl;
    cout << "*************************************************" << endl;

    //eliminate duplicates
    auto unique_end = unique(words.begin(), words.end());

    words.erase(unique_end, words.end());

    cout << "Print words after removing duplicates" << endl; 
    for (auto x : words)
        cout << x << "\t";
    cout << endl;
    cout << "*************************************************" << endl;

    //Print words after sorting with stable_sort
    cout << "Print words with their lengths in ascending order" << endl;
    stable_sort(words.begin(), words.end());
    for (auto x : words)
        cout << x << "\t";
    cout << endl;
    cout << "*************************************************" << endl;


    //Print words with length in ascending order
    cout << "Print words with their lengths in ascending order" << endl;
    stable_sort(words.begin(), words.end(), [](const string& w1, const string& w2) {return w1.size() < w2.size(); });
    for (auto x : words)
        cout << x << "\t";
    cout << endl;
    cout << "*************************************************" << endl;

    {
        cout << "Find count of those words that are having length >= 3 " << endl;
        auto count = count_if(words.begin(), words.end(), [](const string& w1) {return w1.size() >= 3; });
        cout << "Total " << count << " word(s) having length >= 3 found" ;
        cout << endl;
        cout << "*************************************************" << endl;
    }

    {
        //Print only those words that are having length >= 3
        cout << "Those words having length >= 3 are:" << endl;

        auto iter = find_if(words.begin(), words.end(), [](const string& w1) {return w1.size() >= 3; });
        for (auto x = iter; x != words.end(); x++)
            cout << *x << "\t";
        cout << endl;
        cout << "*************************************************" << endl;
    }

}

