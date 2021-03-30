// C++ implementation of
// the above approach

#include <iostream>
#include <queue>
#include "BinaryTree.h"
using namespace std;

// Node in the tree where
// data holds the character
// of the string and cnt
// holds the frequency

class BinaryTree
{
	typedef struct node {
		char data;
		int cnt;
		node *left, *right;
	}Node;

	Node* root;
public:

	BinaryTree()
	{
		root = NULL;
	}

	// Function to add a new
	// node to the Binary Tree
	node* add(char data)
	{
		// Create a new node and
		// populate its data part,
		// set cnt as 1 and left
		// and right children as NULL
		node* newnode = new node;
		newnode->data = data;
		newnode->cnt = 1;
		newnode->left = newnode->right = NULL;

		return newnode;
	}

	// Function to add a node
	// to the Binary Tree in
	// level order
	node* addinlvlorder(char data)
	{
		if (root == NULL) {
			return root = add(data);
		}
		// Use the queue data structure
		// for level order insertion
		// and push the root of tree to Queue
		queue<node*> Q;
		Q.push(root);

		while (!Q.empty()) {

			node* temp = Q.front();
			Q.pop();

			// If the character to be
			// inserted is present,
			// update the cnt
			if (temp->data == data) {
				temp->cnt++;
				break;
			}
			// If the left child is
			// empty add a new node
			// as the left child
			if (temp->left == NULL) {
				temp->left = add(data);
				break;
			}
			else {
				// If the character is present
				// as a left child, update the
				// cnt and exit the loop
				if (temp->left->data == data) {
					temp->left->cnt++;
					break;
				}
				// Add the left child to
				// the queue for further
				// processing
				Q.push(temp->left);
			}
			// If the right child is empty,
			// add a new node to the right
			if (temp->right == NULL) {
				temp->right = add(data);
				break;
			}
			else {
				// If the character is present
				// as a right child, update the
				// cnt and exit the loop
				if (temp->right->data == data) {
					temp->right->cnt++;
					break;
				}
				// Add the right child to
				// the queue for further
				// processing
				Q.push(temp->right);
			}
		}

		return root;
	}

	// Function to print the
	// level order traversal of
	// the Binary Tree
	void printlvlorder()
	{
		// Add the root to the queue
		queue<node*> Q;
		Q.push(root);

		while (!Q.empty()) {
			node* temp = Q.front();
			// If the cnt of the character
			// is more then one, display cnt
			if (temp->cnt > 1) {
				cout << temp->data << temp->cnt;
			}
			// If the cnt of character
			// is one, display character only
			else {
				cout << temp->data;
			}
			Q.pop();
			// Add the left child to
			// the queue for further
			// processing
			if (temp->left != NULL) {
				Q.push(temp->left);
			}
			// Add the right child to
			// the queue for further
			// processing
			if (temp->right != NULL) {
				Q.push(temp->right);
			}
		}
	}
};

// Driver code
int main()
{

	string s = "geeksforgeeks";
	BinaryTree tree;
	

	// Add individual characters
	// to the string one by one
	// in level order
	for (int i = 0; i < s.size(); i++) {
		tree.addinlvlorder(s[i]);
	}

	// Print the level order
	// of the constructed
	// binary tree
	tree.printlvlorder();
	cout << endl;

	LevelledBinaryTree ltree;
	for (int i = 0; i < s.size(); i++) {
		ltree.InsertIntoTree(s[i]);
	}
	ltree.printTree();

	return 0;
}
