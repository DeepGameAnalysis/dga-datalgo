using BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public enum MarkState
    {
        VISITED,
        NOT_VISITED,
        PROCESSED,
        TREENODE, //Already visited and processed -> is part of a searchtree
        FRINGENODE //Nodes connected by edge with a searchtreenode
    }

   
    public class DirectedGraph<V> where V : IComparable
    {
        public GraphNode<V>[] Nodes;
        public List<GraphEdge> Edges;

        public int[][] AdjacencyMatrix;
        public LinkedList<GraphNode<V>>[] AdjacencyList;

        public GraphNode<V>[] FromArray;
        public GraphNode<V>[] ToArray;

        public DirectedGraph(int Vs)
        {
            Nodes = new GraphNode<V>[Vs];
            Edges = new List<GraphEdge>();
        }

        public DirectedGraph(GraphNode<V>[] nodes)
        {
            Nodes = nodes;
            Edges = new List<GraphEdge>();
        }

        private int index = 0;
        public void AddNode(GraphNode<V> node)
        {
            if (index == Nodes.Length) throw new Exception("Graph is full!");
            Nodes[index] = node;
            index++;
        }

        public bool Contains(GraphNode<V> node)
        {
            return Nodes.Contains(node);
        }

        public void AddEdge(int v, int w, int weight)
        {
            var edge = new GraphEdge(v, w, weight);
            Edges.Add(edge);
            UpdateEdgeAdjacency(edge);
        }

        private void UpdateEdgeAdjacency(GraphEdge edge)
        {
            AdjacencyMatrix[edge.FromIndex][edge.ToIndex] = 1;
        }

        private void InitAdjacencyMatrix()
        {
            //Init base matrix
            AdjacencyMatrix = new int[Nodes.Length][];
            for (int i = 0; i < AdjacencyMatrix.Length; i++)
                AdjacencyMatrix[i] = new int[Nodes.Length];
            // Mark adjacent nodes by neighbors
            for (int i = 0; i < Edges.Count; i++)
                AdjacencyMatrix[Edges[i].FromIndex][Edges[i].ToIndex] = 1;
        }

        private void InitAdjacencyList()
        {
            //Create a linked list for every node. This list is marking his adjacent peers
            AdjacencyList = new LinkedList<GraphNode<V>>[Nodes.Length];
            for (int i = 0; i < AdjacencyList.Count(); i++)
                AdjacencyList[i] = new LinkedList<GraphNode<V>>();
            

            for (int i = 0; i < Edges.Count; i++)
            {
                var edge = Edges[i];
                var toNode = Nodes[edge.ToIndex];
                AdjacencyList[edge.FromIndex].AddLast(toNode);
            }
        }

        public bool IsAcyclicGraph()
        {
            return true;
        }

        public List<GraphNode<V>> GetSucessors(GraphNode<V> node)
        {
            List<GraphNode<V>>[] successors = new List<GraphNode<V>>[Nodes.Count()];
            if (successors[node.Index] != null) return successors[node.Index]; //if successor list was already built return

            List<GraphNode<V>> suc = new List<GraphNode<V>>(); //else build the successor list
            foreach (var toedge in Edges.Where(edge => edge.FromIndex == node.Index))
                suc.Add(Nodes[toedge.ToIndex]);

            successors[node.Index] = suc;
            return suc;
        }

        /// <summary>
        /// Breadthfirst
        /// </summary>
        /// <param name="node"></param>
        /// <param name="tree"></param>
        private void LevelOrderTraversal()
        {

        }


        /// <summary>
        /// Depthfirst
        /// </summary>
        /// <param name="node"></param>
        /// <param name="tree"></param>
        private void PreOrderTraversal()
        {

        }

        /// <summary>
        /// Build tree where node is the root and from there is pointing to all neighbors as new roots of his subtree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="tree"></param>
        /// <returns></returns>
        private BinarySearchTree<V> GetGraphExpansionFromNode(GraphNode<V> node, BinarySearchTree<V> tree)
        {
            //TODO but makes no sense atm
            return null;
        }
    }
}
