#include "FileParser.h"
#include <fstream>
#include <sstream>
#include <iostream>
#include <iomanip>
using namespace std;

//This function will replce the given token with space
void FileParser::replaceTokenWithSpace(string& line, char token)
{
    //find a token (or default ^) in the given line
    string::size_type pos = 0;
    while ((pos = line.find_first_of(token, pos)) != string::npos)
    {
        //replace ^ with space
        line[pos++] = ' ';
    }
}

//This function will return a vector of strings representing component Ids
vector<string> FileParser::getComponentsId(string& components)
{
    vector<string> v; 
    replaceTokenWithSpace(components, ',');
    istringstream is(components);
    string comp;
    while (is >> comp)
        v.push_back(comp);
    return v;
}


//This function will return a vector of strings representing component length
vector<string> FileParser::getComponentsLegth(string& subLengths)
{
    vector<string> v;
    replaceTokenWithSpace(subLengths, ',');
    istringstream is(subLengths);
    string compLen;
    while (is >> compLen)
        v.push_back(compLen);
    return v;
}

//This function will update the component map by adding length member
void FileParser::updateComponentsLength(vector<string>& vId, vector<string>&vLen)
{
    //Locate each component in the component map and update the length member
    for (vector<string>::size_type index = 0; index < vId.size(); index++)
    {
        auto pos = m_componentsMap.find(vId[index]);
        if (pos != m_componentsMap.end()) 
        {
            //element found, so update the component with length
            pos->second.length = std::stod(vLen[index]);
        }
    }
}

//Function to parse data.csv file and create a list of components
unordered_map<string, Component> FileParser::parseDataFile()
{
    ifstream ifs("data.csv", ifstream::in);
    string line;

    if (!ifs)
    {
        cerr << "File could not be opened: Error#: " << errno << endl;
        return m_componentsMap;
    }

    //Process all the lines in the file one by one
    while(getline(ifs, line))
    {
        replaceTokenWithSpace(line);
        Component c;

        istringstream record(line);
        while (record >> c.componentId >> c.actualSpeed)
        {
            //cout << c.componentId << " " << c.actualSpeed << endl;
            m_componentsMap.insert(make_pair(c.componentId, c));
        }
    }

    return m_componentsMap;
}

//Function to parse main.csv file and create a list of components
unordered_map<string, pair<MainLink, vector<string>>>
FileParser::parseMainLinkFile()
{ 
    ifstream ifs("main.csv", ifstream::in);
    string line;

    if (!ifs)
    {
        cerr << "File could not be opened: Error#: " << errno << endl;
        return m_mainMap;
    }

    //Process all the lines in the file one by one
    int nodesCount = 0;
    while (getline(ifs, line))
    {
        if (nodesCount++ == 0) continue;  //skip reading the header
        replaceTokenWithSpace(line);
        MainLink m;
        string components;
        string subLengths;

        istringstream record(line);
        while (record >> m.mainLinkId >> components >> m.mainLength 
                      >> subLengths   >> m.idealTravelTime)
        {
            vector<string> vId = getComponentsId(components);
            vector<string> vLen = getComponentsLegth(subLengths);

            if (vId.size() != vLen.size())
            {
                ostringstream os;
                os << "Components Count and length Mismatch Error in the row starting with "
                   << m.mainLinkId;
                //const char* cstr = os.str().c_str();
                throw exception(os.str().c_str());
            }

            updateComponentsLength(vId, vLen);
            pair<MainLink, vector<string>> p = make_pair(m, vId);
            m_mainMap.insert(make_pair(m.mainLinkId, p));
        }
    }

    return m_mainMap;
}

/*
Calculate the actual speed on the main links (A, B …) 
by doing a simple averaging on their component links
*/
double FileParser::calculateActualAvergaeSpeed(string mainLinkId)
{
    double actualAvgSpeed = 0.0;
    double sumSpeed = 0.0;

    auto linkData = m_mainMap.find(mainLinkId);
    if (linkData != m_mainMap.end())
    {
        //Get the vecotr having components for the given main link
        auto componentVec = linkData->second.second;

        //for each component in the vector, get the id and find the rest of the details from the component map
        for (auto component : componentVec)
        {
            auto componentData = m_componentsMap.find(component);
            if (componentData != m_componentsMap.end())
                sumSpeed += componentData->second.actualSpeed;
        }
        actualAvgSpeed = sumSpeed > 0.0 ? sumSpeed / componentVec.size() : 0.0;
    }
    return actualAvgSpeed;
}

/*
Calculate the length adjusted speed on the main links (A,B….).
E.g. (Length of the main component / The total length of the component links) * average speed

*/
double FileParser::calculateLengthAdjustedSpeed(string mainLinkId)
{
    double sumLength = 0.0;
    double adjustedSpeed = 0.0;
    double avgSpeed = calculateActualAvergaeSpeed(mainLinkId);
    auto linkData = m_mainMap.find(mainLinkId);
    if (linkData != m_mainMap.end())
    {
        //Get the vecotr having components for the given main link
        auto componentVec = linkData->second.second;

        //for each component in the vector, 
        //get the id and find the rest of the details from the component map
        for (auto component : componentVec)
        {
            auto compPos = m_componentsMap.find(component);
            if (compPos != m_componentsMap.end())
                sumLength += compPos->second.length;
        }
        adjustedSpeed = sumLength > 0 ? linkData->second.first.mainLength / sumLength * avgSpeed : 0.0;     
    }
    return adjustedSpeed;
}

/*
Taking into account of the ideal speed and the actual speed calculated, 
decide the condition on the main link by using the following rule:
•	> 80% deviation between the ideal and actual speed =>  green condition
•	> 50% deviation => yellow condition
•	<= 50% deviation => red condition

*/
double FileParser::determineDeviationPercent(string mainLinkId)
{
    double actualSpeed = calculateActualAvergaeSpeed(mainLinkId);
    double idealSpeed = 0.0;
    double differencePercent = 0.0;

    auto linkData = m_mainMap.find(mainLinkId);
    if (linkData != m_mainMap.end())
    {
        //Get the vecotr having components for the given main link
        idealSpeed = linkData->second.first.mainLength /  linkData->second.first.idealTravelTime ;

        differencePercent = (idealSpeed - actualSpeed) / idealSpeed * 100;
    }

    return differencePercent;
}

string FileParser::determineCondition(string mainLinkId)
{
    double actualSpeed = calculateActualAvergaeSpeed(mainLinkId);
    double idealSpeed = 0.0;
    double differencePercent = 0.0;

    auto linkData = m_mainMap.find(mainLinkId);
    if (linkData != m_mainMap.end())
    {
        //Get the vecotr having components for the given main link
        idealSpeed = linkData->second.first.mainLength / linkData->second.first.idealTravelTime;

        differencePercent = (idealSpeed - actualSpeed) / idealSpeed * 100;
    }

    if (differencePercent > 80)
        return "GREEN";
    else if (differencePercent > 50 && differencePercent <= 80)
        return "YELLOW";
    else
        return "RED";
}

//This function will print all the required information
void FileParser::printConsolidatedInfo()
{
    cout << left << setw(20) << "Link Id" 
         << left << setw(20) << "Actual Speed"
         << left << setw(20) << "Adjusted Speed"
         << left << setw(20) << "Percent Deviation" 
         << left << setw(20) << "Condition" << endl;

    for (auto linkData : m_mainMap)
    {
        cout << left << setw(20) << linkData.first << " "
             << left << setw(20) << calculateActualAvergaeSpeed(linkData.first) 
             << left << setw(20) << calculateLengthAdjustedSpeed(linkData.first) 
             << left << setw(20) << determineDeviationPercent(linkData.first) 
             << left << setw(20) << determineCondition(linkData.first) << endl;
    }
}
