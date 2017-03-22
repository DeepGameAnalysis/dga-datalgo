using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    class LEADERClustering<T>  where T : IClusterable, IOrderer
    {
        public float delta { get; set; }

        private List<Cluster<T>> clusters = new List<Cluster<T>>();

        private List<T> leaders = new List<T>();

        /// <summary>
        /// Cluster the given data with LEADER. Pass a function to order the data as u wish
        /// </summary>
        /// <param name="pos"></param>
        public LEADERClustering(T[] pos, Func<T[], T[]> order)
        {
            var sorted_pos = order(pos);
            clusterData(sorted_pos);
        }

        public LEADERClustering(float delta)
        {
            this.delta = delta;
        }

        /// <summary>
        /// Probleme: Reihenfolge der Punkte
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Cluster<T>[] clusterData(T[] pos)
        {
            clusters.Clear();
            Cluster<T> start_cluster = new Cluster<T>(pos[0]);
            int leader_ind = 0;
            leaders.Add(pos.First());

            clusters.Add(start_cluster);

            for (int i = 1; i < pos.Length; i++)
            {
                var datapoint = pos[i];

                var min_dist = 0.0;
                var min_dist_leader_index = 0;
                for (int index = 0; index < leaders.Count; index++)
                {
                    var leader_distance = leaders[index].DistanceFunc<T>(datapoint);
                    if (index == 0) {
                        min_dist = leader_distance;
                        continue;
                    }
                    if (leader_distance < min_dist)
                    {
                        min_dist = leader_distance;
                        min_dist_leader_index = index;
                    }
                }

                if (min_dist < delta)
                {
                    clusters[min_dist_leader_index].assignToCluster(datapoint);
                }
                else
                {
                    Cluster<T> new_cluster = new Cluster<T>(datapoint);
                    clusters.Add(new_cluster);
                    leader_ind++;
                    leaders.Add(datapoint);
                }
            }
            leaders.Clear();
            return clusters.ToArray();
        }

    }
}
