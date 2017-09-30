using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class FloydAlgorithm<V> where V : IComparable, IEqualityComparer<V>
    {
        public void Perform(DirectedGraph<V> graph, GraphNode<V> root)
        {
            int n = graph.Nodes.Count();
            int[][] A = new int[n][];
            int[][] P = new int[n][];

            for (int i = 0; i < n; i++)
            {
                A[i] = new int[n];
                P[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    A[i][j] = 0;
                    P[i][j] = 0;
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        if (A[j][k] > A[j][i] + A[i][k])
                        {
                            A[j][k] = A[j][i] + A[i][k];
                            P[j][k] = k;
                        }
                    
        }
    }
}
