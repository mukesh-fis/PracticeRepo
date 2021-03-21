// ReadingUnknownNumOfInput.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
void printConsecutiveDistinct();
void readUnknownNumberOfInputsAmdSum();

int main()
{
    std::cout << "****************************************************************************************************\n";
    std::cout << "Reading Unknown number of inputs!\n";
    std::cout << "****************************************************************************************************\n";
    std::cout << "Note that when we use an ifstream as a condition, an istream becomes invalid when we hit end of file" <<
        "  or encounter an invalid input, such as reading a value that is not an integer." <<
        "  An instream that is in an invalid state will cause the condition to yield false and we get out of loop.  "<< 
        "  On Windows we enter end of file by pressing Control-z from keyboard, for unix it is control-d" << endl;
    std::cout << "****************************************************************************************************\n\n";

    readUnknownNumberOfInputsAmdSum();

    std::cout << "****************************************************************************************************\n";

    /*Before we again use cin to read next input, the input buffer needs to be flushed so that any unwanted character in 
    the input stream could be removed and cin could work properly.
    This would read inand ignore everything until EOF.
    Note: you can also supply a second argument which is the character to read until(ex: '\n' to ignore a single line).
    
    */
    cin.clear();
    cin.ignore(INT_MAX, '\n');

    printConsecutiveDistinct();

    std::cout << "****************************************************************************************************\n";
    return 0;

}

void readUnknownNumberOfInputsAmdSum()
{
    
    std::cout << "Enter integers separated by spaces. To end press control + Z or press any non-numeric character:" << endl;

    int sum = 0, value = 0;

    while (cin >> value)
        sum += value;

    cout << "Sum is " << sum << endl;
    
}

//Function to find how many consecutive times each distinct value appears in the input.
void printConsecutiveDistinct()
{
    std::cout << "Enter integers separated by spaces. To end press control + Z or press any non-numeric character:" << endl;
    int prevNum = 0, currNum = 0;
    
    if (cin >> prevNum)
    {
        int count = 1;

        while (cin >> currNum)
        {
            if (prevNum == currNum)
            {
                count++;
            }
            else
            {
                cout << prevNum << " appeared consecutively " << count << " time(s)" << endl;
                prevNum = currNum;
                count = 1;
            }
        }
        cout << prevNum << " appeared consecutively " << count << " time(s)" << endl;
    }
    
}

