using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class AVLTree<V> : BinarySearchTree<V> where V : IComparable
    {


        int Height(Node<V> N)
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
        private Node<V> RightRotate(Node<V> n)
        {
            Node<V> y = n.lnode;
            Node<V> T2 = y.rnode;

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
        private Node<V> LeftRotate(Node<V> x)
        {
            Node<V> y = x.rnode;
            Node<V> T2 = y.lnode;

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
        private int GetBalance(Node<V> N)
        {
            if (N == null)
                return 0;

            return Height(N.lnode) - Height(N.rnode);
        }

        public Node<V> Insert(Node<V> node, V Value)
        {

            if (node == null)
                return (new Node<V>(Value));

            if (Less(Value, node.Value))
                node.lnode = Insert(node.lnode, Value);
            else if (Greater(Value, node.Value))
                node.rnode = Insert(node.rnode, Value);
            else // Duplicate keys not allowed
                return node;

            node.Height = 1 + Math.Max(Height(node.lnode), Height(node.rnode));

            int balance = GetBalance(node);
            
            if (balance > 1 && Less(Value, node.lnode.Value))
                return RightRotate(node);

            if (balance < -1 && Greater(Value, node.rnode.Value))
                return LeftRotate(node);

            if (balance > 1 && Greater(Value, node.lnode.Value))
            {
                node.lnode = LeftRotate(node.lnode);
                return RightRotate(node);
            }

            if (balance < -1 && Less(Value, node.rnode.Value))
            {
                node.rnode = RightRotate(node.rnode);
                return LeftRotate(node);
            }

            return node;
        }


        /// <summary>
        /// A utility function to print preorder traversal
        /// of the tree.
        /// The function also prints Height of every node
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(Node<V> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value + " ");
                PreOrder(node.lnode);
                PreOrder(node.rnode);
            }
        }

    }

}
