using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Algorithms
{
    public class TopologicalSort<V> : ISorting<V> where V : IComparable
    {
        public static void Perform(DirectedGraph<V> graph)
        {
            if (!graph.IsAcyclicGraph()) throw new Exception("Cannot sort topological if graph contains cycles");
            int[] Predecessors = new int[graph.Nodes.Count()];
            List<GraphNode<V>>[] Successors = new List<GraphNode<V>>[graph.Nodes.Count()];

            List<GraphNode<V>> FinishedNodes = new List<GraphNode<V>>();
            for (int i = 0; i < Predecessors.Length; i++)
                Predecessors[i] = GetPredecessorsCount(graph.Nodes[i], graph);

            List<GraphNode<V>> DifferenceSet = graph.Nodes.ToList().Except(FinishedNodes).ToList();
            while (DifferenceSet.Count() != 0)
            {
                GraphNode<V> node = ChooseZeroPredecessorNode(DifferenceSet, Predecessors);
                node.Print();
                FinishedNodes.Add(node);
                //Node has finished -> decrement counter of all his Predecessors
                List<GraphNode<V>> Sucessors = graph.GetSucessors(node);
                for (int i = 0; i < Sucessors.Count; i++)
                    Predecessors[Sucessors[i].Index]--;
            }
        }

        private static int GetPredecessorsCount(GraphNode<V> node, DirectedGraph<V> graph)
        {
            return graph.Edges.Where(edge => edge.ToIndex == node.Index).Count();
        }

        private static GraphNode<V> ChooseZeroPredecessorNode(List<GraphNode<V>> differenceSet, int[] predecessors)
        {
            int minIndex = Array.IndexOf(predecessors, 0); //First index of the node with zero costs
            return differenceSet.FirstOrDefault(node => node.Index == minIndex); //Search this node
        }



    }
}
