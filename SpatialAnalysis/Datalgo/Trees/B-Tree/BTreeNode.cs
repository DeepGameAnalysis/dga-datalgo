using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.BTree
{
    /// <summary>
    /// Inner class for nodes of this tree
    /// </summary>
    public class BTreeNode<K,V> where K : IComparable where V : IComparable
    {
        public int M;

        public BTreeEntry<K, V>[] Children = new BTreeEntry<K, V>[BTree<K, V>.M];

        public BTreeNode(int k)
        {
            M = k;
        }
    }
}
