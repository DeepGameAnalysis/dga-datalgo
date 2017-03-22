using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory
{
    /// <summary>
    /// Trajectory is holding a series of (position, time) tuples of a given entity
    /// </summary>
    public class Trajectory<T> where T : IEntity
    {
        /// <summary>
        /// Start time of this trajectory.
        /// </summary>
        public int starttick;

        /// <summary>
        /// Player running this trajectory
        /// </summary>
        public T entity;

        /// <summary>
        /// Hashtabe all the (time,position) pairs of this players trajectory
        /// </summary>
        private OrderedDictionary positions = new OrderedDictionary();

        /// <summary>
        /// Describes the movement of a player in one life/round
        /// </summary>
        /// <param name="start"></param>
        /// <param name="player"></param>
        public Trajectory(T ent, int starttick)
        {
            this.starttick = starttick;
            this.entity = ent;
        }

        /// <summary>
        /// Add a position to the trajectory
        /// </summary>
        /// <param name="tick_id"></param>
        /// <param name="pos"></param>
        public void AddPosition(int tick_id, T pos)
        {
            positions[tick_id] = pos;
        }

        /// <summary>
        /// Get position at time index (tick_id)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            return (T)positions[index];
        }

        /// <summary>
        /// Compress the trajectory
        /// </summary>
        private void compress()
        {

        }

    }
}
