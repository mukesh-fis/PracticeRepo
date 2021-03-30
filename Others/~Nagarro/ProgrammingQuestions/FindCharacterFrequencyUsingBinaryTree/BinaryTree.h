#pragma once
#include<iostream>
#include<queue>
using namespace std;

struct Node
{
	char key;
	int frequency;
	Node *left, *right;

	Node(char key)
	{
		this->key = key;
		this->frequency = 1;
		this->left = NULL;
		this->right = NULL;
	}
};

class LevelledBinaryTree
{
	Node* treeRoot;
	
	Node* AddNode(char k)
	{
		Node* n = new Node(k);
		return n;
	}

	void DeleteNode(Node* n)
	{
		if (n != NULL)
		{
			delete n;
		}
	}

public:
	LevelledBinaryTree()
	{
		treeRoot = NULL;
	}

	// Function to add a node to the Binary Tree in level order
	Node* InsertIntoTree(char key)
	{
		if (treeRoot == NULL)
		{
			return treeRoot = AddNode(key);
		}

		queue<Node*> Q;
		Q.push(treeRoot);

		while (!Q.empty())
		{
			Node* frontNode = Q.front();
			Q.pop();

			//If the data to be inserted is already present, update the frequency
			if (frontNode->key == key)
			{
				frontNode->frequency++;
				break;
			}

			//if key was not present in the root, look at the left chald.
			//If the left child is empty, add the new node to the left.
			if (frontNode->left == NULL)
			{
				frontNode->left = AddNode(key);
				break;
			}
			else
			{
				if (frontNode->left->key == key)
				{
					frontNode->left->frequency++;
					break;
				}
				Q.push(frontNode->left);
			}

			if (frontNode->right == NULL)
			{
				frontNode->right = AddNode(key);
				break;
			}
			else
			{
				if (frontNode->right->key == key)
				{
					frontNode->right->frequency++;
					break;
				}					
				Q.push(frontNode->right);

			}

		} //end of loop
		return treeRoot;

	} //end of function


	void printTree()
	{

		queue<Node*> Q;
		Q.push(treeRoot);

		while (!Q.empty())
		{
			Node* front = Q.front();
			front->frequency > 1 ? (cout << front->key << front->frequency) : (cout << front->key);
			Q.pop();

			if (front->left)
			{
				Q.push(front->left);
			}
			if (front->right)
			{
				Q.push(front->right);
			}
		}
			
	}

};