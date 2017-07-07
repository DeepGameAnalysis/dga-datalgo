using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadTree.QTreeRectF;
using QuadTree.QTreePoint2D;
using MathNet.Spatial.Euclidean;

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

    public struct DataPoint<T> : IRectQuadTreeStorable, IPointQuadTreeStorable
    {
        /// <summary>
        /// Has this datapoint be visited by an algorithm accessing this variable
        /// </summary>
        public bool isVisited;
        public T clusterPoint;
        public int clusterID;

        public Rectangle2D Rect
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Point2D Point
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DataPoint(T point)
        {
            clusterPoint = point;
            isVisited = false;
            clusterID = (int)ClusterIDs.Unclassified;
        }

        public T extractData()
        {
            return clusterPoint;
        }


    }
}
