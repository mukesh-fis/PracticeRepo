// Exception.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "MyException.h"
using namespace std;

void myUnexpected() throw()
{
    cout << "Flow reached inside myUnexpected: " << endl;
    //terminate();
    return;
}

void myTerminate() throw()
{
    cout << "Flow reached inside myTerminate: " << endl;
    return;
}

int main()
{
    set_unexpected(myUnexpected);
    set_terminate(myTerminate);

    std::cout << "creating MyExceptionTest class object.\n";
    MyExceptionTest met;
    try
    {
        met.ThrowExceptionFun();
    }
    catch (MyException m)
    {
        cout << "Caught MyException. Here is exception detail:" << endl;
        cout << m.message << endl;
        return -1;
    }
    catch (bad_alloc)
    {
        cout << "Caught bad_alloc" << endl;
        return -1;
    }
    //catch (...)
    //{
    //    cout << "caught generic exception" << endl;
    //}

}

