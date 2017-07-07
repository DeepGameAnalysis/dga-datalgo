using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDTree;
using KDTree.Math;

namespace Clustering
{
    /// <summary>
    /// Main Codeparts from http://codereview.stackexchange.com/questions/108965/implementing-a-fast-dbscan-in-c
    /// </summary>
    public class DBSCAN<T> where T : IClusterable<double, T>
    {
        private T[] datapoints;
        private double epsilon;
        private int minPts;


        public DBSCAN(T[] allPoints, double epsilon, int minPts)
        {
            this.datapoints = allPoints;
            this.epsilon = epsilon;
            this.minPts = minPts;
        }

        public HashSet<T[]> CreateClusters(bool removeoutliers)
        {
            var allPointsDBScan = datapoints.Select(x => new DataPoint<T>(x)).ToArray();

            var kdtree = new KDTree<double, DataPoint<T>>(2, new DoubleMath());
            for (var i = 0; i < allPointsDBScan.Length; ++i)
            {
                kdtree.Add(allPointsDBScan[i].clusterPoint.GetDataAsArray(), allPointsDBScan[i]);
            }

            var expandcounter = 0;
            for (int i = 0; i < allPointsDBScan.Length; i++)
            {
                var p = allPointsDBScan[i];
                if (p.isVisited)
                    continue;
                p.isVisited = true;

                DataPoint<T>[] neighborPts = RegionQuery(kdtree, p, epsilon);
                if (neighborPts.Length < minPts)
                    p.clusterID = (int)ClusterIDs.Noise;
                else
                {
                    expandcounter++;
                    ExpandCluster(kdtree, p, neighborPts, expandcounter, epsilon, minPts);
                }
            }
            if(removeoutliers)
                return new HashSet<T[]>(
                    allPointsDBScan
                        .Where(x => x.clusterID > 0)
                        .GroupBy(x => x.clusterID)
                        .Select(x => x.Select(y => y.clusterPoint).ToArray())
                    );
            else
                return new HashSet<T[]>(
                allPointsDBScan
                    .GroupBy(x => x.clusterID) //All ClusterIDs
                    .Select(x => x.Select(y => y.clusterPoint).ToArray())
                );
        }

        private static void ExpandCluster(KDTree<double, DataPoint<T>> tree, DataPoint<T> p, DataPoint<T>[] neighborPts, int clusterid, double epsilon, int minPts)
        {
            p.clusterID = clusterid;

            var queue = new Queue<DataPoint<T>>(neighborPts);
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (point.clusterID == (int)ClusterIDs.Unclassified)
                {
                    point.clusterID = clusterid;
                }

                if (point.isVisited)
                {
                    continue;
                }

                point.isVisited = true;
                var neighbors = RegionQuery(tree, point, epsilon);
                if (neighbors.Length >= minPts)
                {
                    foreach (var neighbor in neighbors.Where(neighbor => !neighbor.isVisited))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        private static DataPoint<T>[] RegionQuery(KDTree<double, DataPoint<T>> tree, DataPoint<T> p, double epsilon)
        {
            var neighbors = new List<DataPoint<T>>();
            var e = tree.RangeQuery(p.clusterPoint.GetDataAsArray(), epsilon, 10);
            foreach(var entry in e)
                neighbors.Add(entry.Value);
            
            return neighbors.ToArray();
        }
    }

}
