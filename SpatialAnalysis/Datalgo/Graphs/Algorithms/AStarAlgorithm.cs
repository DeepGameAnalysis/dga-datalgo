using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class AStarAlgorithm<V> where V : IComparable, IEqualityComparer<V>
    {
        List<GraphNode<V>> Openlist = new List<GraphNode<V>>();
        List<GraphNode<V>> Closedlist = new List<GraphNode<V>>();

        public void Perform(DirectedGraph<V> graph, GraphNode<V> start, GraphNode<V> target)
        {

            Openlist.Add(start);
            while (Openlist.Count != 0)
            {
                GraphNode<V> currentNode = RemoveNode(Openlist);
                if (currentNode.Equals(target))
                {
                    return;
                }
                Closedlist.Add(currentNode);
                ExpandNode(currentNode, graph);
            }
        }

        private GraphNode<V> RemoveNode(List<GraphNode<V>> openlist)
        {
            throw new NotImplementedException();
        }

        private void ExpandNode(GraphNode<V> currentNode, DirectedGraph<V> graph)
        {
            foreach(var suc in graph.GetSucessors(currentNode))
                if (Closedlist.Contains(suc))
                {
                    int f = 0;
                    if(Openlist[suc.Index] == null || Openlist[suc.Index] > f)
                    {
                        suc.predecessor = currentNode;
                        Openlist[suc.Index] = f;
                    }
                }
        }
    }
}
