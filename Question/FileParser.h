#pragma once
#include <string>
#include<list>
#include<unordered_map>
using namespace std;

//structure to represent a small component like a, b, c etc.
struct Component
{
	string componentId;
	double actualSpeed;
	double length;

	Component()
	{
		componentId = "";
		actualSpeed = length = 0;
	}
};

//structure to represent a main component like A, B etc.
struct MainLink
{
	string mainLinkId;
	double mainLength;
	double idealTravelTime;

	MainLink()
	{
		mainLinkId = "";
		idealTravelTime = mainLength = 0;
	}
};


//File Reader class to parse the input files
class FileParser
{
	unordered_map<string, Component> m_componentsMap;
	unordered_map<string, pair<MainLink, vector<string>>> m_mainMap;

public:
	FileParser() {}
	void replaceTokenWithSpace(string& line, char token='^');
	vector<string> getComponentsId(string& components);
	vector<string> getComponentsLegth(string& subLengths);
	void updateComponentsLength(vector<string>& vId, vector<string>& vLen);
	unordered_map<string, Component> parseDataFile();
	unordered_map<string, pair<MainLink, vector<string>>> parseMainLinkFile();

	double calculateActualAvergaeSpeed(string mainLinkId);
	double calculateLengthAdjustedSpeed(string mainLinkId);
	double determineDeviationPercent(string mainLinkId);
	string determineCondition(string mainLinkId);
	void printConsolidatedInfo();
	
};