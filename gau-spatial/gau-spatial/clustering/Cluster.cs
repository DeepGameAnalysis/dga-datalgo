using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gau_math.data;
using System.Collections;

/// <summary>
/// TODO: make generic some time
/// </summary>
namespace Clustering
{
    public class Cluster
    {
        public List<Vector> data;

        public Vector centroid;


        public Cluster()
        {
            this.data = new List<Vector>();

        }

        public Cluster(Vector[] data)
        {
            this.data = data.ToList();
        }

        public Cluster(Vector datapoint)
        {
            this.data = new List<Vector>();
            assignToCluster(datapoint);
        }


        internal void assignToCluster(Vector p)
        {
            data.Add(p);
        }

        public EDRect getBoundings()
        {
            var min_x = data.Min(point => point.X);
            var min_y = data.Min(point => point.Y);
            var max_x = data.Max(point => point.X);
            var max_y = data.Max(point => point.Y);
            var dx = max_x - min_x;
            var dy = max_y - min_y;
            return new EDRect { X = min_x, Y = max_y, Width = dx, Height = dy };
        }


        public void AddPosition(Vector p)
        {
            data.Add(p);
        }
    }
}
