using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAUMath.Library;
using GAUMath.Data;
using MathNet.Spatial.Euclidean;

namespace Clustering
{

    /// <summary>
    /// Cluster a pointcloud of three dimensional attackerpositions
    /// </summary>
    public class AttackerCluster : Cluster<Point3D>
    {
        /// <summary>
        /// Range average of all positions registered in this cluster
        /// </summary>
        public double cluster_attackrange_avg { get; set; }

        /// <summary>
        /// Median of all ranges registered in this cluster
        /// </summary>
        public double cluster_attackrange_med { get; set; }

        /// <summary>
        /// Maximal attackrange registered in this cluster
        /// </summary>
        public double max_attackrange { get; set; }

        /// <summary>
        /// Minimal attackrange registered in this cluster
        /// </summary>
        public double min_attackrange { get; set; }

        /// <summary>
        /// Boundings of this cluster as Rectangle
        /// </summary>
        public Rectangle boundings { get; set; }

        /// <summary>
        /// The two-dimensional bounding polygon of the datapoints
        /// </summary>
        public Polygon2D boundingpolygon2D { get; set; }

        /// <summary>
        /// The convex hull of all datapoints
        /// </summary>
        public Polygon2D convexhull
        {
            get {
                if(boundingpolygon2D == null) 
                    boundingpolygon2D = new Polygon2D(base.data.Cast<Point2D>()); //Save polygon in case for further use

                return Polygon2D.GetConvexHullFromPoints(base.data.Cast<Point2D>());
            }
        }

        /// <summary>
        /// Constructor delegate to base
        /// </summary>
        /// <param name="data"></param>
        public AttackerCluster(Point3D[] data) : base(data){ }


        /// <summary>
        /// Calculate all relevant ranges for this cluster
        /// </summary>
        /// <param name="ht"></param>
        internal void calculateClusterAttackrange(Hashtable ht)
        {
            double[] distances = new double[data.Count];
            int arr_ptr = 0;
            if (data.Count == 0) return;
            foreach (var pos in data)
            {
                Point3D value = (Point3D)ht[pos]; // No Z variable no hashtable entry -> null -.-
                distances[arr_ptr] = ExtendedMath.GetEuclidDistance3D(pos, value);
                arr_ptr++;
            }

            cluster_attackrange_avg = distances.Average();
            cluster_attackrange_med = ExtendedMath.GetMedian(distances.Cast<float>());
            max_attackrange = distances.Max();
            min_attackrange = distances.Min();
            Console.WriteLine("Attackrange for this cluster is: " + cluster_attackrange_avg);
            boundings = getBoundings();
        }
    }

}
