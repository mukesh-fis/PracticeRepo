// shared_pointer.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<memory>
using namespace std;

int main()
{
    std::cout << "Shared Pointer!\n";

    //Use make_shared<int> to create a shared pointerto an int with value 10 and bind it with isp
    shared_ptr<int> isp = make_shared<int>(10);
    cout << "isp = " << isp << endl;;
    cout << "*isp = " << *isp << endl;

    //Copying a shared pointer to another increases refernce count to the object the pointer refers to. 
    shared_ptr<int> isp2 = isp;
    cout << "isp2 = " << isp2 << endl;;
    cout << "*isp2 = " << *isp2 << endl;

    //Use a raw pointer to create a shared_ptr
    shared_ptr<float> fsp(new float(20.5));
    cout << "fsp = " << fsp << endl;;
    cout << "*fsp = " << *fsp << endl;

    return 0;
}

