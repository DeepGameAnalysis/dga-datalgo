using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KdTree;
using KdTree.Math;


namespace Clustering
{
    /// <summary>
    /// Main Codeparts from http://codereview.stackexchange.com/questions/108965/implementing-a-fast-dbscan-in-c
    /// </summary>
    public class DBSCANClustering<T> where T : IClusterable
    {

        public DBSCANClustering()
        {
        }

        public HashSet<T[]> ComputeClusterDbscan(T[] allPoints, double epsilon, int minPts)
        {
            var allPointsDbscan = allPoints.Select(x => new DBSCANPoint<T>(x)).ToArray();

            var tree = new KdTree<double, DBSCANPoint<T>>(2, new DoubleMath());
            for (var i = 0; i < allPointsDbscan.Length; ++i)
            {
                tree.Add(new double[] { allPointsDbscan[i].ClusterPoint.X, allPointsDbscan[i].ClusterPoint.Y }, allPointsDbscan[i]);
            }

            var C = 0;
            for (int i = 0; i < allPointsDbscan.Length; i++)
            {
                var p = allPointsDbscan[i];
                if (p.IsVisited)
                    continue;
                p.IsVisited = true;

                DBSCANPoint<T>[] neighborPts = RegionQuery(tree, p.ClusterPoint, epsilon);
                if (neighborPts.Length < minPts)
                    p.ClusterId = (int)ClusterIDs.Noise;
                else
                {
                    C++;
                    ExpandCluster(tree, p, neighborPts, C, epsilon, minPts);
                }
            }
            return new HashSet<T[]>(
                allPointsDbscan
                    .Where(x => x.ClusterId > 0)
                    .GroupBy(x => x.ClusterId)
                    .Select(x => x.Select(y => y.ClusterPoint).ToArray())
                );
        }

        private static void ExpandCluster(KdTree<double, DBSCANPoint<T>> tree, DBSCANPoint<T> p, DBSCANPoint<T>[] neighborPts, int c, double epsilon, int minPts)
        {
            p.ClusterId = c;

            var queue = new Queue<DBSCANPoint<T>>(neighborPts);
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (point.ClusterId == (int)ClusterIDs.Unclassified)
                {
                    point.ClusterId = c;
                }

                if (point.IsVisited)
                {
                    continue;
                }

                point.IsVisited = true;
                var neighbors = RegionQuery(tree, point.ClusterPoint, epsilon);
                if (neighbors.Length >= minPts)
                {
                    foreach (var neighbor in neighbors.Where(neighbor => !neighbor.IsVisited))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        private static DBSCANPoint<T>[] RegionQuery(KdTree<double, DBSCANPoint<T>> tree, T p, double epsilon)
        {
            var neighbors = new List<DBSCANPoint<T>>();
            var e = tree.RadialSearch(p.getAsArray<T>(), epsilon, 10);
            foreach(var entry in e)
                neighbors.Add(entry.Value);
            
            return neighbors.ToArray();
        }
    }

    /// <summary>
    /// Container for DBSCAN clustering
    /// </summary>
    public class DBSCANPoint<T>
    {
        public bool IsVisited;
        public T ClusterPoint;
        public int ClusterId;

        public DBSCANPoint(T point)
        {
            ClusterPoint = point;
            IsVisited = false;
            ClusterId = (int)ClusterIDs.Unclassified;
        }
    }

    /// <summary>
    /// Identify a cluster
    /// </summary>
    public enum ClusterIDs
    {
        Unclassified = 0,
        Noise = -1
    }


}
