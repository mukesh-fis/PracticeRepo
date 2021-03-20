#include<iostream>
#include<vector>
#include<cctype>
#include<string>
using namespace std;


/*
Read s set of integers into a vector. Print the sum of each pair of adjacent elements. 
v[0] + v[1]; v[2] +v[3], v[4] + v[5] and so on...

Change your program so that it prints the sum of first and last elements, 
followed by the sum of second and second to last elements and so on...
*/
void findSumOfAdjacentElements()
{
	vector<int> v{ 10, 20, 30, 40 };
	int sum = 0;

	/*
	Read s set of integers into a vector.Print the sum of each pair of adjacent elements.
		v[0] + v[1]; v[2] + v[3], v[4] + v[5] and so on...
	*/
	
	for (vector<int>::size_type sz = 0; sz < v.size(); )
	{
		if (sz == v.size() - 1)
		{
			cout << v[sz] << endl;
			break;
		}
		else if (sz > v.size() - 1)
		{
			break;
		}
		cout << v[sz] + v[sz + 1] << endl;
		sz += 2;
	}

	/*
	Change your program so that it prints the sum of first and last elements, 
	followed by the sum of second and second to last elements and so on...
	*/

	//for (vector<int>::size_type szbegin = 0, szend = v.size() - 1; szbegin <= szend; cout << v[szbegin] + v[szend] << endl, szbegin++, szend--);

}

void readAndPopulateIntVector(vector<int>& x)
{
	cout << "Enter integers that you wish to store into a vector separated by space. To end press control+D: ";
	int num = 0;
	while (cin >> num)
	{
		x.push_back(num);
	}
}

void printVector(vector<int>& x)
{
	decltype(x.size()) x_size = x.size();
	vector<int>::size_type size_x = x.size();
	cout << "\nx.size = " << x_size << " x.capacity = " << x.capacity() << endl;
	cout << "The elements inside the vector are:";
	for (auto a : x)
			cout << a << " ";
}

/// <summary>
/// 
/// </summary>
/// <param name="x"></param>
void readAndPopulateStringsInAVector()
{
	vector<string> x;
	string word;
	cout << "Enter your string separated by spaces or tabs\n";
	cout << "Terminate with '$'\n";
	while (getline(cin, word))
	{
		if (word != "$")
			x.push_back(word);
		else
			break;
	}

	cout << "Input Words are: " << endl;
	for (auto w : x)
	{
		cout << w << endl; 
	}

	cout << "\nConverting letters of each word to uppercases... " << endl;
	for (auto &w : x)
	{
		for (auto& c : w)
		{
			//cout << (char)toupper(c);
			c = ::toupper(c);
		}
		//cout << endl;
	}


	cout << "\nWords in uppercases are: " << endl;
	for (auto w : x)
	{
		cout << w << endl;
	}
}

int main()
{   
	findSumOfAdjacentElements();
	/*
	vector<int> x;
	cout << "x.size = " << x.size() << " x.capacity = " << x.capacity() << endl;

	
	vector<int> y(10);
	cout << "y.size = " << y.size() << " y.capacity = " << y.capacity() << endl;
	vector<int> z(5, 4);
	cout << "z.size = " << z.size() << " z.capacity = " << z.capacity() << endl;
	vector<int> a = { 1, 2, 3 };
	cout << "a.size = " << a.size() << " a.capacity = " << a.capacity() << endl;
	vector<int> b = a;
	cout << "b.size = " << b.size() << " b.capacity = " << b.capacity() << endl;
	vector<int>c(a);
	cout << "c.size = " << c.size() << " c.capacity = " << c.capacity() << endl;
	vector<int>d{ 1,2,3 };
	cout << "d.size = " << d.size() << " d.capacity = " << d.capacity() << endl;

	vector<vector<int>> ivec;
	//vector<string> svec = ivec;  //Not Allowed
	vector<string> svec(10, "hi");
	vector<string> svec2{ 10, "hi" }; //Here 10 is int, vector type is string, hence 10 can't be used as string, so compiler treats this ststement as vector<string svec2(10, "hi");
	
	readAndPopulateIntVector(x);
	printVector(x.);*/

	//readAndPopulateStringsInAVector();

	//three ways to define a vector of ten integers with value 42
	vector<int> v1(10, 42);
	vector<int> v2{42, 42, 42, 42, 42, 42, 42, 42, 42};
	vector<int> v = {42, 42, 42, 42, 42, 42, 42, 42, 42 };
	vector<int> v3(10);
	for (vector<int>::size_type sz = 0; sz < 10; sz++)
		v3.push_back(42);

	


}