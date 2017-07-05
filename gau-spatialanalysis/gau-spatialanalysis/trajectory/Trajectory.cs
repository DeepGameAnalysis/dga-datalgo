using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectories
{
    /// <summary>
    /// Trajectory is holding a series of (time , T) tuples of a given object. For example positions or other values
    /// </summary>
    public class Trajectory<E> where E : IMoveable
    {
        /// <summary>
        /// Start tickid of this trajectory.
        /// </summary>
        public int start_tick;

        /// <summary>
        /// Entity running this trajectory
        /// </summary>
        public E entity;

        /// <summary>
        /// OrderedDictionary holding all the (time,position) pairs of this entities trajectory
        /// </summary>
        private Hashtable data;

        /// <summary>
        /// Describes the movement of a entity in one life/round starting at a tickid
        /// </summary>
        /// <param name="start"></param>
        /// <param name="player"></param>
        public Trajectory(E ent, int starttick)
        {
            this.data = new Hashtable();
            this.start_tick = starttick;
            this.entity = ent;
        }

        /// <summary>
        /// Add a position to the trajectory
        /// </summary>
        /// <param name="tick_id"></param>
        /// <param name="pos"></param>
        public void AddPosition(int tick_id, E e)
        {
            if (tick_id < start_tick) throw new ArgumentException("New tick id cannot be smaller than the starting tick of this entity");
            if (tick_id == start_tick) throw new ArgumentException("There cannot be two positions at the same time registered for this trajectory ");
            data.Add(tick_id, e);
        }

        /// <summary>
        /// Get position at time index (tick_id)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public E Get(int index)
        {
            try
            {
                return (E)data[index];
            }
            catch (Exception e)
            {
                Console.WriteLine("No suitable entity for this index in this trajectory found");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return default(E);
            }
        }

        /// <summary>
        /// Compress the trajectory
        /// </summary>
        private void compress()
        {

        }

        public override string ToString()
        {
            foreach (DictionaryEntry de in data)
            {
                System.Console.WriteLine(de.Key + ", " + de.Value);
            }
            return "Trajectory of Player: "+" starting at Tick "+start_tick+":\n Count: "+data.Count;
        }
    }
}
