using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadTree.QTreeRect;
using QuadTree.QTreePoint;

namespace Clustering
{
    /// <summary>
    /// Identify a cluster
    /// </summary>
    public enum ClusterIDs
    {
        Unclassified = 0,
        Noise = -1
    }

    public struct DataPoint<T> : IRectQuadStorable, IPointQuadStorable
    {
        public bool IsVisited;
        public T ClusterPoint;
        public int clusterID;

        public DataPoint(T point)
        {
            ClusterPoint = point;
            IsVisited = false;
            clusterID = (int)ClusterIDs.Unclassified;
        }

        public T extractData()
        {
            return ClusterPoint;
        }


        public Rectangle Rect
        {
            get
            {
                return new Rectangle();
            }
        }

        public Point Point
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
