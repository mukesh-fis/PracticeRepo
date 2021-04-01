// WinsockProject.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
/*
Sockets are the fundamental "things" behind any kind of network communications done by your computer. 
For example when you type www.google.com in your web browser, 
it opens a socket and connects to google.com to fetch the page and show it to you.

Same with any chat client like gtalk or skype. Any network communication goes through a socket.

The windows api to socket programming is called winsock.
*/
#ifndef _WINSOCK_DEPRECATED_NO_WARNINGS
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#endif

#include <iostream>
#include<winsock2.h> //The Winsock2.h header file contains most of the Winsock functions, structures, and definitions. 
#include <ws2tcpip.h> //Ws2tcpip.h contains definitions introduced in the WinSock 2 Protocol-Specific Annex document for TCP/IP that includes newer functions and structures used to retrieve IP addresses.
using namespace std;

//Winsock Library=> way of telling the VC++ compiler to link with library ws2_32.lib so on VC++ it does this
//The #pragma comment indicates to the linker that the Ws2_32.lib file is needed.
#pragma comment(lib, "ws2_32.lib") 

int main()
{
    std::cout << "Winsock Project!\n"; 

	//Initialising Winsock
	std::cout << "Initialising Winsock" << endl;

	//Create a WSADATA object called wsaData.
	//The WSADATA structure contains information about the Windows Sockets implementation. 
	WSADATA wsa;

	//MAKEWORD(2,2) parameter of WSAStartup makes a request for version 2.2 of Winsock on the system, 
	//and sets the passed version as the highest version of Windows Sockets support that the caller can use.
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		//If any error occurs then the WSAStartup function would return a non zero value 
		//and WSAGetLastError can be used to get more information about what error happened.
		cout << "Initialization failed.= with error - " << WSAGetLastError();
		return 1;
	}

	cout << "Winsock initialized successfully.";

	//Creating a socket. 

	/*
	Function socket() creates a socket and returns a socket descriptor which can be used in other network commands.

	Address Family : 
		AF_INET (this is IP version 4), 
		AF_INET6 for Internet Protocol version 6 (IPv6) address family, 
		AF_BTH ( Bluetooth address family)
		AF_UNSPEC (The address family is unspecified) etc.

	Type : 
		SOCK_STREAM (this means connection oriented TCP protocol 
				- A socket type that provides sequenced, reliable, two-way, connection-based byte streams.
				- This socket type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).

		SOCK_DGRAM 
				- A socket type that supports datagrams, which are connectionless, unreliable buffers of a fixed
				- This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		
		SOCK_RAW
				- A socket type that provides a raw socket that allows an application to manipulate the next upper-layer protocol header.
				- To manipulate the IPv4 header, the IP_HDRINCL socket option must be set on the socket. 
				- To manipulate the IPv6 header, the IPV6_HDRINCL socket option must be set on the socket.

		SOCK_RDM
				- A socket type that provides a reliable message datagram. 
				- An example of this type is the Pragmatic General Multicast (PGM) multicast protocol implementation in Windows, 
				- often referred to as reliable multicast programming.

	Protocol : 0 [ or IPPROTO_TCP , IPPROTO_UDP ]
		IPPROTO_TCP
				- The Transmission Control Protocol (TCP). 
				- This is a possible value when the af parameter is AF_INET or AF_INET6 and the type parameter is SOCK_STREAM.

		IPPROTO_UDP
				- The User Datagram Protocol (UDP). 
				- This is a possible value when the af parameter is AF_INET or AF_INET6 and the type parameter is SOCK_DGRAM.
	

		IPPROTO_ICMP
				- The Internet Control Message Protocol (ICMP). 
				- This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or AF_INET6 
				- and the type parameter is SOCK_RAW or unspecified.
				- supported on Windows XP and later

		IPPROTO_IGMP
				- The Internet Group Management Protocol (IGMP). 
				- This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or AF_INET6 
				- and the type parameter is SOCK_RAW or unspecified.
				- supported on Windows XP and later.

		BTHPROTO_RFCOMM
				- The Bluetooth Radio Frequency Communications (Bluetooth RFCOMM) protocol.
				- This is a possible value when the af parameter is AF_BTH and the type parameter is SOCK_STREAM
				- supported on Windows XP with SP2 or later.

		IPPROTO_RM
				- The PGM protocol for reliable multicast. This is a possible value when the af parameter is AF_INET
				- and the type parameter is SOCK_RDM. 
				- On the Windows SDK released for Windows Vista and later, this protocol is also called IPPROTO_PGM.
				- Only supported if the Reliable Multicast Protocol is installed.
	*/

	SOCKET s;
	if ((s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP) == INVALID_SOCKET))
	{
		cout << "Socket could not be created. Error - " << WSAGetLastError();
		return 1;
	}
	cout << "Socket created" << endl;

	/*
	We have created a socket successfully. But what next? 
	Next we shall try to connect to some server using this socket. We can connect to www.google.com.

	We connect to a remote server on a certain port number. So we need 2 things , IP address and port number to connect to.
	To connect to a remote server we need to do a couple of things. 
	First is create a sockaddr_in structure with proper values filled in. Lets create one for ourselves.

	// IPv4 AF_INET sockets:
	struct sockaddr_in {
		short            sin_family;   // e.g. AF_INET, AF_INET6
		unsigned short   sin_port;     // e.g. htons(3490)
		struct in_addr   sin_addr;     // see struct in_addr, below
		char             sin_zero[8];  // zero this if you want to
	};
	The sockaddr_in has a member called sin_addr of type in_addr which has a s_addr which is nothing but a long. 
	It contains the IP address in long format.

	Function inet_addr is a very handy function to convert an IP address to a long format. This is how you do it :
	server.sin_addr.s_addr = inet_addr("74.125.235.20");
	*/
	
	sockaddr_in server;
	server.sin_addr.s_addr = inet_addr("10.236.165.102");   //10.236.165.102
	server.sin_family = AF_INET;
	server.sin_port = htons(80);

	//Connect to remote server
	if (connect(s, (struct sockaddr *)&server, sizeof(server)) != 0)
	{
		cout << "connect Error - " << WSAGetLastError() << endl;
		return 1;
	}
	cout << "connected" << endl;

	return 0;
}
