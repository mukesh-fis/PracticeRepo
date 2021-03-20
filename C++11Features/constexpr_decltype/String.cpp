#include<iostream>
#include<string>
using namespace std;

int printInHexFormat()
{
	string hex = "0123456789ABCDEF";
	string inputInDecimal = "";
	string outputInHex = "";
	string::size_type n;
	cout << "Enter decimal digits separated with spaces. Hit Control+D when finished." << endl;
	while (cin >> n)
	{
		if (n < hex.size())
		{
			outputInHex += hex[n];
		}
	}

	cout << "Hexified number is: " << outputInHex << endl;
	return 0;

}

int changeAllCharToX()
{
	string input = "";
	string output = "";
	cout << "Enter a line:" << endl;
	getline(cin, input);
	if (!input.empty())
	{
		for (decltype(input.size()) index = 0; index < input.size(); index++)
			input[index] = 'X';
	}

	cout << "After conversion: " << input << endl;
	return 0;
}

int changeAllCharToXUsingRangeFor()
{
	string input = "";
	string output = "";
	cout << "Enter a line:" << endl;
	getline(cin, input);
	//if (!input.empty())
	//{
	//	for (auto c: input)
	//		output+= 'X';
	//}
	//cout << "After conversion: " << output << endl;

	if (!input.empty())
	{
		for (auto &c : input)
		{
			c = 'x';
		}
	}

	cout << "After conversion: " << input << endl;
	return 0;
}

void RemovePunct()
{

	string input = "";
	string output = "";
	cout << "Enter a line with punctuation marks inside:" << endl;
	getline(cin, input);
	if (!input.empty())
	{
		for (decltype(input.size()) index = 0; index < input.size(); index++)
		{
			if (!ispunct(input[index]))
				output += input[index];
		}
	}

	cout << "After removing punctuation marks from the input: " << output << endl;

}

int main()
{
	//printInHexFormat();
	//changeAllCharToX();
	//changeAllCharToXUsingRangeFor();
	RemovePunct();


	//string s;
	//cout << s[0];
	return 0;
}

