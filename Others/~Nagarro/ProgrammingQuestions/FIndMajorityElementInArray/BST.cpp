#include<iostream>

class BST
{
	struct Node
	{
		int key;
		int frequency;
		Node *left;
		Node *right;

		Node(int k)
		{
			key = k;
			frequency = 1;
			left = nullptr;
			right = nullptr;
		}
	};


	Node* insert(int item, Node*& parent, int& elemWithMajority)
	{
		if (parent == nullptr)
		{
			parent = new Node(item);
			return parent;
		}

		if (item < parent->key)
		{
			insert(item, parent->left, elemWithMajority);
		}

		else if (item > parent->key)
		{
			insert(item, parent->right, elemWithMajority);
		}

		else
		{
			parent->frequency++;
			if (parent->frequency > MaxElem / 2)
				elemWithMajority = parent->key;
		}
		return nullptr;
	}

	void printBSTInorder(Node* root)
	{
		if (root == nullptr)
			return;

		printBSTInorder(root->left);

		std::cout << "Key = " << root->key << ", frequency = " << root->frequency << std::endl;

		printBSTInorder(root->right);

	}

	Node* tree;
	int   MaxElem; //This is the size of the array from which this BST will be populated

public:

	BST(int size)
	{
		tree = nullptr;
		MaxElem = size;
	}

	~BST()
	{
		deleteTree(tree);
	}


	void deleteTree(Node*& tree)
	{
		if (tree == nullptr)
			return;

		deleteTree(tree->left);
		deleteTree(tree->right);
		delete tree;
		tree = nullptr;
	}

	void insert(int item, int& elemWithMajority)
	{
		insert(item, tree, elemWithMajority);
	}

	void printBSTInorder()
	{
		printBSTInorder(tree);
	}

};