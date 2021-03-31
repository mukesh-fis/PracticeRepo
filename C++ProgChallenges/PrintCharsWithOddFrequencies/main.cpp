#include "PrintCharsWithOddFrequencies.h"
#include "PrintCharWithPrimeFrequency.h"
#include "PrintCharsWithTheirFrequencies.h"
#include "BinaryTree.h"

int main()
{
	std::cout << "Finding characters with odd frequency in order of their occurrence!\n";
	string input = "geeksforgeeks";
	cout << endl;

	cout << "Printing Char With odd Frequency in string: " << input << endl;
	cout << PrintCharsWithOddFrequencies(input) << endl;

	cout << "Printing Char With Prime Frequency in string: " << input  << endl;
	cout << PrintCharWithPrimeFrequency(input) << endl;

	cout << "Printing Chars followed by Frequencies in string: " << input << endl;
	cout << GetCharFrequencyInOrder(input) <<  endl;

	cout << "Printing Chars followed by Frequencies using GetCharFrequencyInOrderUsingArray()" << endl;
	cout << GetCharFrequencyInOrderUsingArray(input) << endl;

	char p[] = "geeksforgeeks";
	cout << "Printing Chars followed by Frequencies using GetCharFrequencyInOrderUsingArrayCStyle()" << endl;
	cout << GetCharFrequencyInOrderUsingArrayCStyle(p) << endl;

	cout << "Printing Chars followed by Frequencies using BinaryTree in input: " << input << endl;
	BinaryTree tree2;
	for (int i = 0; i < input.size(); i++) {
		tree2.InsertIntoTree(input[i]);
	}
	tree2.PrintTree();
	
}

