using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class SplayTree<K, V> where K : IComparable where V : IComparable
    {
        /// <summary>
        /// Inner class for nodes of this tree
        /// </summary>
        public class SplayTreeNode
        {
            public V Value;
            public SplayTreeNode lnode;
            public SplayTreeNode rnode;
            public K Key;
            public SplayTreeNode(K key, V value)
            {
                this.Value = value;
                this.Key = key;
            }
        }
        private SplayTreeNode root;   // root of the BST

        public bool Contains(K key)
        {
            return get(key) != null;
        }

        // return value associated with the given key
        // if no such value, return null
        public V get(K key)
        {
            root = splay(root, key);
            int cmp = key.CompareTo(root.Key);
            if (cmp == 0) return root.Value;
            else return default(V);
        }


        public void put(K key, V value)
        {
            // splay key to root
            if (root == null)
            {
                root = new SplayTreeNode(key, value);
                return;
            }

            root = splay(root, key);

            int cmp = key.CompareTo(root.Key);

            // Insert new node at root
            if (cmp < 0)
            {
                SplayTreeNode n = new SplayTreeNode(key, value);
                n.lnode = root.lnode;
                n.rnode = root;
                root.lnode = null;
                root = n;
            }

            // Insert new node at root
            else if (cmp > 0)
            {
                SplayTreeNode n = new SplayTreeNode(key, value);
                n.rnode = root.rnode;
                n.lnode = root;
                root.rnode = null;
                root = n;
            }

            // It was a duplicate key. Simply replace the value
            else
            {
                root.Value = value;
            }

        }

        /***************************************************************************
         *  Splay tree deletion.
         ***************************************************************************/
        /* This splays the key, then does a slightly modified Hibbard deletion on
         * the root (if it is the node to be deleted; if it is not, the key was 
         * not in the tree). The modification is that rather than swapping the
         * root (call it node A) with its successor, it's successor (call it SplayTreeNode B)
         * is moved to the root position by splaying for the deletion key in A's 
         * rnode subtree. Finally, A's rnode child is made the new root's rnode 
         * child.
         */
        public void remove(K key)
        {
            if (root == null) return; // empty tree

            root = splay(root, key);

            int cmp = key.CompareTo(root.Key);

            if (cmp == 0)
            {
                if (root.lnode == null)
                {
                    root = root.rnode;
                }
                else
                {
                    SplayTreeNode x = root.rnode;
                    root = root.lnode;
                    splay(root, key);
                    root.rnode = x;
                }
            }

            // else: it wasn't in the tree to remove
        }


        /***************************************************************************
         * Splay tree function.
         * **********************************************************************/
        // splay key in the tree rooted at SplayTreeNode h. If a node with that key exists,
        //   it is splayed to the root of the tree. If it does not, the last node
        //   along the search path for the key is splayed to the root.
        private SplayTreeNode splay(SplayTreeNode h, K key)
        {
            if (h == null) return null;

            int cmp1 = key.CompareTo(h.Key);

            if (cmp1 < 0)
            {
                // key not in tree, so we're done
                if (h.lnode == null)
                {
                    return h;
                }
                int cmp2 = key.CompareTo(h.lnode.Key);
                if (cmp2 < 0)
                {
                    h.lnode.lnode = splay(h.lnode.lnode, key);
                    h = rotateRight(h);
                }
                else if (cmp2 > 0)
                {
                    h.lnode.rnode = splay(h.lnode.rnode, key);
                    if (h.lnode.rnode != null)
                        h.lnode = rotateLeft(h.lnode);
                }

                if (h.lnode == null) return h;
                else return rotateRight(h);
            }

            else if (cmp1 > 0)
            {
                // key not in tree, so we're done
                if (h.rnode == null)
                {
                    return h;
                }

                int cmp2 = key.CompareTo(h.rnode.Key);
                if (cmp2 < 0)
                {
                    h.rnode.lnode = splay(h.rnode.lnode, key);
                    if (h.rnode.lnode != null)
                        h.rnode = rotateRight(h.rnode);
                }
                else if (cmp2 > 0)
                {
                    h.rnode.rnode = splay(h.rnode.rnode, key);
                    h = rotateLeft(h);
                }

                if (h.rnode == null) return h;
                else return rotateLeft(h);
            }

            else return h;
        }


        /***************************************************************************
         *  Helper functions.
         ***************************************************************************/

        // height of tree (1-node tree has height 0)
        public int height() { return height(root); }
        private int height(SplayTreeNode x)
        {
            if (x == null) return -1;
            return 1 + Math.Max(height(x.lnode), height(x.rnode));
        }


        public int size()
        {
            return size(root);
        }

        private int size(SplayTreeNode x)
        {
            if (x == null) return 0;
            else return 1 + size(x.lnode) + size(x.rnode);
        }

        // rnode rotate
        private SplayTreeNode rotateRight(SplayTreeNode h)
        {
            SplayTreeNode x = h.lnode;
            h.lnode = x.rnode;
            x.rnode = h;
            return x;
        }

        // lnode rotate
        private SplayTreeNode rotateLeft(SplayTreeNode h)
        {
            SplayTreeNode x = h.rnode;
            h.rnode = x.lnode;
            x.lnode = h;
            return x;
        }

    }

}
