using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DijkstraAlgorithm<V> where V : IComparable, IEqualityComparer<V>
    {
        public void Perform(DirectedGraph<V> graph, GraphNode<V> root)
        {
            int[][] Costs = new int[graph.Nodes.Count()][];
            for (int i = 0; i < Costs.Length; i++)
                Costs[i] = new int[graph.Nodes.Count()];

            int[] CurrentCost = new int[graph.Nodes.Count()];

            List<GraphNode<V>> FinishedNodes = new List<GraphNode<V>> { root };

            foreach (var node in graph.Nodes)
                CurrentCost[node.Index] = 0;

            var arr = FinishedNodes.ToArray();
            List<GraphNode<V>> DifferenceSet = graph.Nodes.ToList().Except(FinishedNodes).ToList();
            while (DifferenceSet.Count() != 0)
            {
                GraphNode<V> node = SearchMinCostNode(DifferenceSet, CurrentCost);
                FinishedNodes.Add(node);

                for (int i = 0; i < DifferenceSet.Count; i++)
                    UpdateCost(DifferenceSet[i], node, CurrentCost, Costs);
            }
        }

        private GraphNode<V> SearchMinCostNode(List<GraphNode<V>> differenceSet, int[] CurrentCost)
        {
            int minIndex = Array.IndexOf(CurrentCost, CurrentCost.Min()); //Index of the node with min cost
            return differenceSet.FirstOrDefault(node => node.Index == minIndex); //Search this node
        }

        private void UpdateCost(GraphNode<V> graphNode, GraphNode<V> WNode, int[] CurrentCost, int[][] Costs)
        {
            CurrentCost[graphNode.Index] = Math.Min(CurrentCost[graphNode.Index], CurrentCost[WNode.Index] + Costs[WNode.Index][graphNode.Index]);
        }
    }
}
