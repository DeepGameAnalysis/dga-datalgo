using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.BTree
{

    public class BTree<K, V> where K : IComparable where V : IComparable
    {

        public const int M = 4;

        public BTreeNode<K,V> Root;

        public int Height;

        public int N;

        public BTree()
        {
            Root = new BTreeNode<K,V>(0);
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return N;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            if (key == null) throw new Exception("Argument is null");
            return Search(Root, key, Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="key"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        private V Search(BTreeNode<K,V> x, K key, int ht)
        {
            BTreeEntry<K,V>[] children = x.Children;

            // external node
            if (ht == 0)
                for (int j = 0; j < x.M; j++)
                    if (Equal(key, children[j].Key)) return (V)children[j].Value;

            // internal node
            else
                for (int i = 0; i < x.M; i++)
                    if (i + 1 == x.M || Less(key, children[i + 1].Key))
                        return Search(children[i].Next, key, ht - 1);
            return default(V);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Put(K key, V val)
        {
            if (key == null) throw new Exception("argument key to put() is null");
            BTreeNode<K,V> u = Insert(Root, key, val, Height);
            N++;
            if (u == null) return;

            // need to split root
            BTreeNode<K,V> t = new BTreeNode<K,V>(2);
            t.Children[0] = new BTreeEntry<K,V>(Root.Children[0].Key, default(V), Root);
            t.Children[1] = new BTreeEntry<K,V>(u.Children[0].Key, default(V), u);
            Root = t;
            Height++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        private BTreeNode<K,V> Insert(BTreeNode<K,V> h, K key, V val, int ht)
        {
            int j;
            BTreeEntry<K,V> t = new BTreeEntry<K,V>(key, val, null);

            // external node
            if (ht == 0)
            {
                for (j = 0; j < h.M; j++)
                {
                    if (Less(key, h.Children[j].Key)) break;
                }
            }

            // internal node
            else
            {
                for (j = 0; j < h.M; j++)
                {
                    if ((j + 1 == h.M) || Less(key, h.Children[j + 1].Key))
                    {
                        BTreeNode<K,V> u = Insert(h.Children[j++].Next, key, val, ht - 1);
                        if (u == null) return null;
                        t.Key = u.Children[0].Key;
                        t.Next = u;
                        break;
                    }
                }
            }

            for (int i = h.M; i > j; i--)
                h.Children[i] = h.Children[i - 1];
            h.Children[j] = t;
            h.M++;
            if (h.M < M) return null;
            else return Split(h);
        }

        private BTreeNode<K,V> Split(BTreeNode<K,V> h)
        {
            BTreeNode<K,V> t = new BTreeNode<K,V>(M / 2);
            h.M = M / 2;
            for (int j = 0; j < M / 2; j++)
                t.Children[j] = h.Children[M / 2 + j];
            return t;
        }

        public override String ToString()
        {
            return ToString(Root, Height, "") + "\n";
        }

        private String ToString(BTreeNode<K,V> h, int ht, String indent)
        {
            StringBuilder s = new StringBuilder();
            BTreeEntry<K,V>[] children = h.Children;

            if (ht == 0)
            {
                for (int j = 0; j < h.M; j++)
                {
                    s.Append(indent + children[j].Key + " " + children[j].Value + "\n");
                }
            }
            else
            {
                for (int j = 0; j < h.M; j++)
                {
                    if (j > 0) s.Append(indent + "(" + children[j].Key + ")\n");
                    s.Append(ToString(children[j].Next, ht - 1, indent + "     "));
                }
            }
            return s.ToString();
        }


        private bool Less(K k1, K k2)
        {
            return k1.CompareTo(k2) < 0;
        }

        private bool Equal(K k1, K k2)
        {
            return k1.CompareTo(k2) == 0;
        }

    }
}
