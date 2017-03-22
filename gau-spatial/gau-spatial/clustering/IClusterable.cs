using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public interface IClusterable
    {
        /// <summary>
        /// Get the data of the clusterable object as a double array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        double[] getAsArray<T>();

        /// <summary>
        /// Add a double array of data to the clusterable object
        /// </summary>
        /// <param name="v"></param>
        void AddData(double[] v);

        /// <summary>
        /// A distance function for the clusterable object. Measure distance to t
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        double DistanceFunc<T>(T t);

    }
}
