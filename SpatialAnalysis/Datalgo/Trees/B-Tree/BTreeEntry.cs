using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.BTree
{
    /// <summary>
    /// Inner class for entries in nodes
    /// </summary>
    public class BTreeEntry<K,V> where K : IComparable where V : IComparable
    {
        public K Key;

        public V Value;

        public BTreeNode<K,V> Next;

        public BTreeEntry(K key, V val, BTreeNode<K,V> next)
        {
            this.Key = key;
            this.Value = val;
            this.Next = next;
        }
    }
}
