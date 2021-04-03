// FindNthPrimeNumber.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;
#define MAX_SIZE 1000005

/*

//Sol 1:

bool isPrime(int n) {
	if (n < 2) return false; // add this line
	bool answer = true;
	for (int i = 2; i < n; i++) {
		if (n % i == 0) {
			answer = false;
		}
	}
	return answer;
}

int main() {
	int userInput;
	cout << "Please indicate which prime number do you want to see: ";
	cin >> userInput;

	for (int i = 0, counter = 0; counter <= userInput; i++) { // note: the global "counter" is shadowed here
		if (isPrime(i)) {
			counter++;
			if (counter == userInput) {
				cout << counter << "th prime number is : " << i << endl;
			}
		}
	}

	return 0;
}
*/


//Sol 2:

void SieveOfEratosthenes(vector<int>& primes)
{
	// Create a boolean array "IsPrime[0..MAX_SIZE]" and
	// initialize all entries it as true. A value in
	// IsPrime[i] will finally be false if i is
	// Not a IsPrime, else true.
	bool IsPrime[MAX_SIZE];
	memset(IsPrime, true, sizeof(IsPrime));

	for (int p = 2; p * p < MAX_SIZE; p++) {
		// If IsPrime[p] is not changed, then it is a prime
		if (IsPrime[p] == true) {
			// Update all multiples of p greater than or
			// equal to the square of it
			// numbers which are multiple of p and are
			// less than p^2 are already been marked.
			for (int i = p * p; i < MAX_SIZE; i += p)
				IsPrime[i] = false;
		}
	}

	// Store all prime numbers
	for (int p = 2; p < MAX_SIZE; p++)
		if (IsPrime[p])
			primes.push_back(p);
}

int main()
{
	// To store all prime numbers
	vector<int> primes;

	// Function call
	SieveOfEratosthenes(primes);

	cout << "5th prime number is " << primes[4] << endl;
	cout << "16th prime number is " << primes[15] << endl;
	cout << "1049th prime number is " << primes[1048];

	return 0;
}

