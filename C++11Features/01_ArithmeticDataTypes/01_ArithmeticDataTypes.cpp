// 01_ArithmeticDataTypes.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<iomanip>
#include <limits>  // std::numeric_limits
using namespace std; 

int main()
{
    std::cout << "==========================================================\n";
    std::cout << "Built in Arithmetic Data Types and their Sizes on Windows!\n";
    std::cout << "==========================================================\n\n";
    std::cout << std::boolalpha;
    cout << left << setw(12) << "Type"          << setw(30) << "Meaning"            		  << setw(25) << "Minimum Size"       			<< setw(25) << "Min Value"                                      << setw(20) << "Max Value"                            	<< setw(10) <<  "Is_Signed"                                 << endl;
    cout << left << setw(12) << "===="          << setw(30) << "======="            		  << setw(25) << "============"       			<< setw(25) << "========="                                      << setw(20) << "========="                            	<< setw(10) <<  "========="                                 << endl;
    cout << left << setw(12) << "bool"          << setw(30) << "boolean"            		  << setw(25) << "NA"                 			<< setw(25) << std::numeric_limits<bool>::min()                 << setw(20) << std::numeric_limits<bool>::max()       	<< setw(10) << std::numeric_limits<bool>::is_signed         << endl;
    cout << left << setw(12) << "char"          << setw(30) << "character"          		  << setw(25) << "8 bits"             			<< setw(25) << std::numeric_limits<char>::min()                 << setw(20) << std::numeric_limits<char>::max()       	<< setw(10) << std::numeric_limits<char>::is_signed         << endl;
    cout << left << setw(12) << "wchar_t"       << setw(30) << "wide character"     		  << setw(25) << "16 bits"            			<< setw(25) << std::numeric_limits<wchar_t>::min()              << setw(20) << std::numeric_limits<wchar_t>::max()    	<< setw(10) << std::numeric_limits<wchar_t>::is_signed      << endl;
    cout << left << setw(12) << "char16_t"      << setw(30) << "unicode char 16 bits"         << setw(25) << "16 bits"		    			<< setw(25) << std::numeric_limits<char16_t>::min()             << setw(20) << std::numeric_limits<char16_t>::max()   	<< setw(10) << std::numeric_limits<char16_t>::is_signed     << endl;
    cout << left << setw(12) << "char32_t"      << setw(30) << "Unicode char 32 bits"         << setw(25) << "32 bits"    	    			<< setw(25) << std::numeric_limits<char32_t>::min()             << setw(20) << std::numeric_limits<char32_t>::max()   	<< setw(10) << std::numeric_limits<char32_t>::is_signed     << endl;
    cout << left << setw(12) << "short"         << setw(30) << "short int"          		  << setw(25) << "16 bits"            			<< setw(25) << std::numeric_limits<short>::min()                << setw(20) << std::numeric_limits<short>::max()      	<< setw(10) << std::numeric_limits<short>::is_signed        << endl;
    cout << left << setw(12) << "int"           << setw(30) << "integer"            		  << setw(25) << "16 bits"            			<< setw(25) << std::numeric_limits<int>::min()                  << setw(20) << std::numeric_limits<int>::max()        	<< setw(10) << std::numeric_limits<int>::is_signed          << endl;																																																																
    cout << left << setw(12) << "long"      	<< setw(30) << "long integer"       		  << setw(25) << "32 bits"		    			<< setw(25) << std::numeric_limits<long>::min()                 << setw(20) << std::numeric_limits<long>::max()       	<< setw(10) << std::numeric_limits<long>::is_signed         << endl;
    cout << left << setw(12) << "long long"     << setw(30) << "long long integer"            << setw(25) << "64 bits"		    			<< setw(25) << std::numeric_limits<long long>::min()            << setw(20) << std::numeric_limits<long long>::max()  	<< setw(10) << std::numeric_limits<long long>::is_signed    << endl;
    cout << left << setw(12) << "float"         << setw(30) << "single precision floating"    << setw(25) << "6 significand digits"		    << setw(25) << std::numeric_limits<float>::min()                << setw(20) << std::numeric_limits<float>::max()      	<< setw(10) << std::numeric_limits<float>::is_signed        << endl;
    cout << left << setw(12) << "double"        << setw(30) << "double precision floating"    << setw(25) << "10 significand digits"        << setw(25) << std::numeric_limits<double>::min()               << setw(20) << std::numeric_limits<double>::max()     	<< setw(10) << std::numeric_limits<double>::is_signed       << endl;
	cout << left << setw(12) << "long double"   << setw(30) << "extended precision floating"  << setw(25) << "10 significand digits"		<< setw(25) << std::numeric_limits<long double>::min()          << setw(20) << std::numeric_limits<long double>::max() 	<< setw(10) << std::numeric_limits<long double>::is_signed  << endl;
    
    std::cout << endl << endl;
    std::cout << "==========================================================\n";
    std::cout << "Expression involving unsigned types can give surprising results" << endl;
    std::cout << "==========================================================\n";

    int i = -42;
    unsigned u = 10;
    cout << "i + i = " << i + i << endl;
    cout << "u + u = " << u + u << endl;
    cout << "i + u = " << i + u << endl;
    cout << "u + i = " << u + i << endl;

    /*

    Output:
    i + i = -84
    u + u = 20
    i + u = 4294967264   
    u + i = 4294967264

    Note:
    When we use both unsigned and int in an arithmetic expression, int value ordinarily gets converted to unsigned.
    To calculate u + i or i + u, 
    i = -42 gets converted to unsigned value which is 4294967254 and adding u - 10 yields the result shown
    */

    getchar();
    return 0;
}

