// ConsoleApplication.cpp : This file contains the 'main' function. 
// Program execution begins and ends there.
//

#include <iostream>
#include "FileParser.h"

int main()
{
    std::cout << "Map Data Exchange Program!\n";

    FileParser parser;
    
    try
    {
        //Load the components map from data.csv file
        parser.parseDataFile();

        //Load the mail links map from main.csv file
        parser.parseMainLinkFile();

        //Calculate the required averages and print result
        parser.printConsolidatedInfo();
    }
    catch (exception e)
    {
        cout << e.what() << endl;
        return -1;
    }
    catch (...)
    {
        cout << "Unknown Error..." << endl;
        return -1;
    }
}
