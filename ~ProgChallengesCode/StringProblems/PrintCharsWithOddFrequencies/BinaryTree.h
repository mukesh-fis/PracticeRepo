/*
Given a string str containing only lowercase characters.
The problem is to print the characters along with their frequency in the order of their occurrence
using Binary Tree

Examples:

Input: str = “aaaabbnnccccz”
Output: “a4b2n2c4z”
Explanation:

*/

#include<iostream>
#include<queue>
#define _CRT_SECURE_NO_WARNINGS
using namespace std;

//Levelled BinaryTree
class BinaryTree
{
	// Node in the tree where
	// data holds the character
	// of the string and cnt
	// holds the frequency
	class Node
	{
		char key;
		int  count;
		Node* left, *right;
		friend class BinaryTree;

		Node(char key)
		{
			this->key = key;
			this->count = 1;
			this->left = this->right = NULL;
		}
	};

	Node* root;

	Node* AddNode(char key)
	{
		return new Node(key);
	}

public:

	BinaryTree()
	{
		root = NULL;
	}

	void InsertIntoTree(char key)
	{
		if (!root)
		{
			root = AddNode(key);
			return;
		}

		queue<Node*> Q;
		Q.push(root);

		while (!Q.empty())
		{
			Node* front = Q.front();
			Q.pop();

			if (front->key == key)
			{
				front->count++;
				break;
			}

			if (!front->left)
			{
				front->left = AddNode(key);
				break;
			}
			else
			{
				if (front->left->key == key)
				{
					front->left->count++;
					break;
				}
				Q.push(front->left);
			}

			if (!front->right)
			{
				front->right = AddNode(key);
				break;
			}
			else
			{
				if (front->right->key == key)
				{
					front->right->count++;
					break;
				}
				Q.push(front->right);
			}
		}
	}

	void PrintTree()
	{
		if (root == NULL)
			return;

		queue<Node*> Q;
		Q.push(root);
		
		while (!Q.empty())
		{
			Node* front = Q.front();
			Q.pop();

			if (front->count > 0)
			{
				cout << front->key << front->count;
			}
			else
			{
				cout << front->key;
			}

			if (front->left)
				Q.push(front->left);

			if (front->right)
				Q.push(front->right);
		}
	}
};
