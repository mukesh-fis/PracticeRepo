#pragma once
#include <iostream>
using namespace std;



class MyException
{
public:
	string message;
	MyException(string m)
	{
		message = m;
	}

};

class MyExceptionTest 
{
public:

	void ThrowExceptionFun() throw(MyException)
	{
		cout << "Going to throw exception out of ThrowExceptionFun() " << endl;
		throw  new MyException("Exception thrown out of ThrowExceptionFun()");
	}
};
