using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class AStarAlgorithm<V> where V : IComparable, IEqualityComparer<V>
    {
        public void Perform(DirectedGraph<V> graph, GraphNode<V> start, GraphNode<V> target)
        {
            List<GraphNode<V>> Openlist = new List<GraphNode<V>> { start };
            List<GraphNode<V>> Closedlist = new List<GraphNode<V>>();

            Dictionary<int, int> GCost = new Dictionary<int, int> { [start.Index] = 0 };
            Dictionary<int, int> FCost = new Dictionary<int, int> { [start.Index] = 0 };

            while (Openlist.Count != 0)
            {
                GraphNode<V> currentNode = GetLowestF(Openlist);
                if (currentNode.Equals(target))
                {
                    return;
                }
                Closedlist.Add(currentNode);
                ExpandNode(currentNode, graph, Openlist, Closedlist);
            }
        }

        private GraphNode<V> GetLowestF(List<GraphNode<V>> openlist)
        {
            throw new NotImplementedException();
        }

        private void ExpandNode(GraphNode<V> currentNode, DirectedGraph<V> graph, List<GraphNode<V>> Openlist, List<GraphNode<V>> Closedlist)
        {
            foreach (var suc in graph.GetSucessors(currentNode))
                if (Closedlist.Contains(suc))
                {
 
                }
        }
    }
}
