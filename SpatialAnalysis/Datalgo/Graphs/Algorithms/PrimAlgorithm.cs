using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Algorithms
{
    class PrimAlgorithm<V> where V : IComparable, IEqualityComparer<V>
    {
        public void Perform(DirectedGraph<V> graph, GraphNode<V> root)
        {
            List<GraphEdge> Edges = new List<GraphEdge>();
            List<GraphNode<V>> VisitedNodes = new List<GraphNode<V>> { root };

            while (!VisitedNodes.All(graph.Nodes.Contains))
            {
                Tuple<GraphNode<V>, GraphNode<V>> pair = ChooseMinimum(VisitedNodes, graph.Nodes);
                VisitedNodes.Add(pair.Item2);
                Edges.Add(new GraphEdge(pair.Item1.Index, pair.Item2.Index, 0));
            }
        }

        private Tuple<GraphNode<V>, GraphNode<V>> ChooseMinimum(List<GraphNode<V>> visitedNodes, GraphNode<V>[] nodes)
        {
            Tuple<GraphNode<V>, GraphNode<V>> pair = null;
            return pair;
        }
    }
}
