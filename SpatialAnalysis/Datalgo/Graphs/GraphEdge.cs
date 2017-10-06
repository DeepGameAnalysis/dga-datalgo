using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public enum GraphEdgeType
    {
        DIRECTED,
        UNDIRECTED
    }

    public class GraphEdge
    {
        public int Weight;
        public int FromIndex;
        public int ToIndex;

        public GraphEdgeType GraphEdgeType = GraphEdgeType.DIRECTED;

        public GraphEdge(int v, int w, int weight)
        {
            this.FromIndex = v;
            this.ToIndex = w;
            this.Weight = weight;
        }
    }
}
