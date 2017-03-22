using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public interface IOrderer
    {
        /// <summary>
        /// Define a method to order a clusterable object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        T[] OrderData<T>(IEnumerable<T> list);
    }
}
