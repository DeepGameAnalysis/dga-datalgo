using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphNode<V> : IEqualityComparer<GraphNode<V>> where V : IComparable
    {
        public int Index;

        /// <summary>
        /// Data associated with this Node of the Graph
        /// </summary>
        public V Value;

        public bool Visited = false;

        public MarkState State;

        public GraphNode(int index, V value)
        {
            this.Index = index;
            this.Value = value;
        }

        internal void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Node: " + Index + " Value: " + Value;
        }

        public bool Equals(GraphNode<V> x, GraphNode<V> y)
        {
            return x.Index == y.Index && x.Value.Equals(y.Value);
        }

        public int GetHashCode(GraphNode<V> obj)
        {
            return obj.Value.GetHashCode();
        }

    }
}
