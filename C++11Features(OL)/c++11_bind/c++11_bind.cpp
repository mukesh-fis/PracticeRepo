// c++11_bind.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <functional>
using namespace std;
using namespace std::placeholders;

int fun(int x, int y = 10)
{
    return x + y;
}


int main()
{
    cout << fun(20) << endl;
    auto func = bind(fun, _1, 20);
    cout << func(30) << endl;

    auto f = [](int x, int y = 30) {return x + y; };
    cout << f(40, 60) << endl;
    cout << f(40) << endl;

    int a = 15, b = 25;
    cout << a << "\t" << b << endl;
    auto g = [&b, a](int x, int y) {return (x + y) - (a + b); };
    cout << g(20, 30) << endl;

    return 0;
}

