using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAUMath.Data;
using System.Collections;
using MathNet.Spatial.Euclidean;

/// <summary>
/// TODO: make generic some time
/// </summary>
namespace Clustering
{
    public class Cluster<T>
    {
        /// <summary>
        /// Data points assigned to this cluster
        /// </summary>
        public List<T> data;

        /// <summary>
        /// Centroid of this cluster 
        /// </summary>
        public T centroid;

        /// <summary>
        /// Create an empty cluster - add datapoints
        /// </summary>
        public Cluster()
        {
            this.data = new List<T>();
        }

        /// <summary>
        /// Create a cluster with three-dimensional data
        /// </summary>
        /// <param name="data"></param>
        public Cluster(T[] data)
        {
            this.data = data.ToList();
        }

        /// <summary>
        /// Create cluster with one starting datapoint
        /// </summary>
        /// <param name="datapoint"></param>
        public Cluster(T datapoint)
        {
            this.data = new List<T>();
            assignToCluster(datapoint);
        }

        /// <summary>
        /// Add a datapoint to the cluster
        /// </summary>
        /// <param name="p"></param>
        internal void assignToCluster(T p)
        {
            data.Add(p);
        }

        public Rectangle getBoundings()
        {
            var min_x = data.Min(point => point.X);
            var min_y = data.Min(point => point.Y);
            var max_x = data.Max(point => point.X);
            var max_y = data.Max(point => point.Y);
            var dx = max_x - min_x;
            var dy = max_y - min_y;
            return new Rectangle { X = min_x, Y = max_y, Width = dx, Height = dy };
        }
    }
}
