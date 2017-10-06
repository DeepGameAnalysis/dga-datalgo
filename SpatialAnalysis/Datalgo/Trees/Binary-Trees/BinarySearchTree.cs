using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Node<V> where V : IComparable
    {
        public V Value;
        public Node<V> lnode;
        public Node<V> rnode;
        internal int Height;

        public Node(V value)
        {
            this.Value = value;
        }

        public void InsertIntoNode(V newValue)
        {
            // Wert liegt links
            if (newValue.CompareTo(Value) < 0)
                if (lnode == null) // Leerer Knoten -> hier is Platz für neuen
                    lnode = new Node<V>(Value);
                else // Knoten war nicht leer -> suche weiter
                    lnode.InsertIntoNode(newValue);
            // Wert liegt rechts
            else if (rnode == null)
                rnode = new Node<V>(Value);
            else // Knoten war nicht leer -> suche weiter
                rnode.InsertIntoNode(newValue);
        }
    }

    public class BinarySearchTree<V> where V : IComparable
    {
        public Node<V> root;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Node<V> Search(V value)
        {
            Node<V> bn = root;
            if (root.Value.Equals(value))
                return root;
            /*
             * Steige solange den richtigen Teilbaum herrab bis der Wert gefunden wurde oder
             * gib null zurück falls er nicht im Baum gespeichert ist.
             */
            while (bn != null && !(bn.Value.CompareTo(value) == 0))
            {
                if (value.CompareTo(bn.Value) < 0) // kleiner als Knotenwert -> links
                    bn = bn.lnode;
                else
                    bn = bn.rnode; // größer als Knotenwert -> rechts
                return bn;
            }
            return bn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newValue"></param>
        public virtual void Insert(V newValue)
        {
            root.InsertIntoNode(newValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public virtual void Delete(V value)
        {
            if (root == null)
                return;

            Node<V> n = Search(value);

            // Fall 1: Beide leer -> einfach löschen
            if (n.lnode == null && n.rnode == null)
                n = null; // Lösche den Knoten

            // Fall 2: Nur einer leer
            if (n.lnode == null && n.rnode != null)
                n = n.rnode; // Ersetze durch nicht leeren Teilbaum
            else if (n.lnode != null && n.rnode == null)
                n = n.lnode; // Ersetze durch nicht leeren Teilbaum

            // Fall 3: Beide voll -> suche größten rechtesten Unterknoten im linken Teilbaum
            // und ersetze
            if (n.lnode != null && n.rnode != null)
            {
                Node<V> w = n.lnode;
                while (w.rnode != null)
                    w = w.rnode;
                n = w;
            }

        }

        private void DepthFirstTraversal(Node<V> root)
        {
            HashSet<Node<V>> Visited = new HashSet<Node<V>>();
            Stack<Node<V>> Stack = new Stack<Node<V>>(); //Last in First out
            Stack.Push(root);
            while(Stack.Count != 0)
            {
                Node<V> n = Stack.Pop();
                if (!Visited.Contains(n))
                {
                    Visited.Add(n);
                    Stack.Push(n.lnode);
                    Stack.Push(n.rnode);
                }
            }
        }

        private void BreadthFirstTraversal(Node<V> root)
        {
            HashSet<Node<V>> Visited = new HashSet<Node<V>>();
            Queue<Node<V>> Queue = new Queue<Node<V>>(); //First out first in
            Queue.Enqueue(root);

            while(Queue.Count != 0)
            {
                Node<V> n = Queue.Dequeue();
                Visit(n);
                if (n.lnode != null && !Visited.Contains(n.lnode))
                {
                    Queue.Enqueue(n.lnode);
                    Visited.Add(n.lnode);
                }
                if (n.rnode != null && !Visited.Contains(n.rnode))
                {
                    Queue.Enqueue(n.rnode);
                    Visited.Add(n.rnode);
                }
            }
            Visited.Clear();
        }

        //
        // Rekursive Tiefendurchläufe
        //
        private void Visit(Node<V> node)
        {
            Console.WriteLine(node.Value + " ");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void PreorderTraversal(Node<V> node)
        {
            if (node != null)
            {
                Visit(node);
                PreorderTraversal(node.lnode);
                PreorderTraversal(node.rnode);
            }
        }

        public void PostorderTraversal(Node<V> node)
        {
            if (node != null)
            {
                PostorderTraversal(node.lnode);
                PostorderTraversal(node.rnode);
                Visit(node);
            }
        }

        public void InorderTraversal(Node<V> node)
        {
            if (node != null)
            {
                InorderTraversal(node.lnode);
                Visit(node);
                InorderTraversal(node.rnode);
            }
        }


        public bool Greater(V value, V other)
        {
            return value.CompareTo(other) > 0;
        }

        public bool Less(V value, V other)
        {
            return value.CompareTo(other) < 0;
        }
    }
}
