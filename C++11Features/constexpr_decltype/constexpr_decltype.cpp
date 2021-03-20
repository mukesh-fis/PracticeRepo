// constexpr_decltype.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

/// <summary>
/// 
/// </summary>
/// <returns></returns>
int f()
{
    return 40;
}

/// <summary>
/// 
/// </summary>
/// <returns></returns>
/*
int main()
{
    
    std::cout << "Introduction to constexpr!\n" << std::endl;
    {
        const int x = 42;
        std::cout << x << std::endl;

        constexpr int y = 43;
        std::cout << y << std::endl;

        constexpr auto z = 44;
        std::cout << z << endl;

        auto x2 = x;
        cout << x2 << " " << endl;

        ++x2;
        cout << "++x2= " << x2 << endl;

        const auto x3 = x;
        cout << "x3 = " << x3 << endl;
        //++x3;
        //cout << "++x3= " << x3 << endl;

        auto& rx = x;
        //++rx;

        {
            auto* px = &x;
            cout << *px << endl;
            px = &y;
            cout << *px << endl;
        }

        {
            const auto* px = &x;
            cout << *px << endl;
            px = &y;
            cout << *px << endl;
        }

        {
            const auto* const px = &x;
            cout << *px << endl;
            //px = &y;
            cout << *px << endl;
        }
    }

    std::cout << "Introduction to decltype!\n" << std::endl;
    {
        int i = 10, & ri = i;
        const int j = 20, & rj = j;
        int m = 80;
        
        decltype(i) di = 30; //The data type of di will be same as the type of i. Since i is an int, di will be an int type
        ++di;   //allowed

        //But if we wrap a variable inside an extra set of parenteses, the type deduced by decltype will be refernce only.
        //In this statement below - i is enclosed by a set paranthesis, so decltype will deduce the type as a refernce to int because i is an int and so the type of dri will be a refernce to an int and hence a literal is not allowed
        //decltype((i)) dri = 40; //not allowed 
        decltype((i)) dri = m; //allowed
        
        //dri is now a refernce to m, so let us change dri and see the value of m if that changes or not.
        cout << "dri = " << dri << " ; m = " << m << endl;
        ++dri;
        cout << "after incrementing dri by 1:" << endl;
        cout << "dri = " << dri << " ; m = " << m << endl;
        
        //Output :
        //dri = 80 ; m = 80
        //after incrementing dri by 1:
        //dri = 81 ; m = 81
        

        //decltype((i)) drjj = j; //Not allowed as j is a const int but the type deduced for drjj is a reference to int

        decltype((j)) drjj = i;  //allowed as the type deduced for drjj is reference to const int and so it can refer to i which is a non-const int

        decltype(j) dj = 40;
        //++dj;   //Not allowed as the type of dj is that of j and j is const int, hence dj also becomes const int, so increment not allowed. 

        decltype(f()) df = 50; //This will assign the return type of function f() as the data type of variable df. Since f() return int, df type is int
        ++df; 

        decltype(rj) drj = 60;

        //drj++;
         
        //int& const k = 70;  //not allowed

        int& const k = i; //allowed

        //int& const k2 = j; //Qualifiers dropped in binding reference of type "int &" to initializer of type "const int"	
   

    }

     
}
*/