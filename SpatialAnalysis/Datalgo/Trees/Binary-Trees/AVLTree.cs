using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class AVLTree<V> : BinarySearchTree<V> where V : IComparable
    {
        new AVLNode root;

        /// <summary>
        /// Inner class for nodes of this tree
        /// </summary>
        public class AVLNode
        {
            public int Height;
            public V Value;

            public AVLNode lnode;
            public AVLNode rnode;

            public AVLNode(V value)
            {
                Value = value;
                Height = 1;
            }
        }

        int Height(AVLNode N)
        {
            if (N == null)
                return 0;

            return N.Height;
        }

        /// <summary>
        /// A utility function to rnode rotate subtree rooted with y
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private AVLNode RightRotate(AVLNode n)
        {
            AVLNode y = n.lnode;
            AVLNode T2 = y.rnode;

            // Perform rotation
            y.rnode = n;
            n.lnode = T2;

            // Update heights
            n.Height = Math.Max(Height(n.lnode), Height(n.rnode)) + 1;
            y.Height = Math.Max(Height(y.lnode), Height(y.rnode)) + 1;

            // Return new root
            return y;
        }

        /// <summary>
        /// A utility function to lnode rotate subtree rooted with x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.rnode;
            AVLNode T2 = y.lnode;

            // Perform rotation
            y.lnode = x;
            x.rnode = T2;

            // Update heights
            x.Height = Math.Max(Height(x.lnode), Height(x.rnode)) + 1;
            y.Height = Math.Max(Height(y.lnode), Height(y.rnode)) + 1;

            // Return new root
            return y;
        }

        // Get Balance factor of node N
        private int GetBalance(AVLNode N)
        {
            if (N == null)
                return 0;

            return Height(N.lnode) - Height(N.rnode);
        }

        public AVLNode Insert(AVLNode node, V Value)
        {

            /* 1. Perform the normal BST insertion */
            if (node == null)
                return (new AVLNode(Value));

            if (Less(Value, node.Value))
                node.lnode = Insert(node.lnode, Value);
            else if (Greater(Value, node.Value))
                node.rnode = Insert(node.rnode, Value);
            else // Duplicate keys not allowed
                return node;

            /* 2. Update Height of this ancestor node */
            node.Height = 1 + Math.Max(Height(node.lnode), Height(node.rnode));

            /*
             * 3. Get the balance factor of this ancestor node to check whether this node
             * became unbalanced
             */
            int balance = GetBalance(node);
            
            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && Less(Value, node.lnode.Value))
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && Greater(Value, node.rnode.Value))
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && Greater(Value, node.lnode.Value))
            {
                node.lnode = LeftRotate(node.lnode);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && Less(Value, node.rnode.Value))
            {
                node.rnode = RightRotate(node.rnode);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }


        /// <summary>
        /// A utility function to print preorder traversal
        /// of the tree.
        /// The function also prints Height of every node
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(AVLNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value + " ");
                PreOrder(node.lnode);
                PreOrder(node.rnode);
            }
        }

        public static void main(String[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            /* Constructing tree given in the above figure */
            tree.root = tree.Insert(tree.root, 10);
            tree.root = tree.Insert(tree.root, 20);
            tree.root = tree.Insert(tree.root, 30);
            tree.root = tree.Insert(tree.root, 40);
            tree.root = tree.Insert(tree.root, 50);
            tree.root = tree.Insert(tree.root, 25);

            /*
             * The constructed AVL Tree would be 30 / \ 20 40 / \ \ 10 25 50
             */
            Console.WriteLine("Preorder traversal" + " of constructed tree is : ");
            tree.PreOrder(tree.root);
        }

    }

}
