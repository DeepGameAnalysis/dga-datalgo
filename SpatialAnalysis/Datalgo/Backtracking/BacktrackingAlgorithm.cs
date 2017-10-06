using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    public class Candidate
    {

    }

    public interface IProblem
    {

    }

    public class BacktrackingAlgorithm<V> where V : IProblem
    {
        IProblem P;

        public void Backtrack(Candidate candidate)
        {
            if (Reject(P, candidate)) return;
            if (Accept(P, candidate)) Output(P,candidate);
            Candidate successor = First(P,candidate);

            while(successor != null)
            {
                Backtrack(successor);
                successor = Next(P,successor);
            }
        }

        /// <summary>
        /// Generate a alternative extension for a successing candidate (from First)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="successor"></param>
        /// <returns></returns>
        private Candidate Next(IProblem p, Candidate successor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate a first extension of a candidate
        /// </summary>
        /// <param name="p"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        private Candidate First(IProblem p, Candidate candidate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// return true if candidate is a solution for the problem
        /// </summary>
        /// <param name="p"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        private bool Accept(IProblem p, Candidate candidate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the accepted solution c of problem p
        /// </summary>
        /// <param name="p"></param>
        /// <param name="candidate"></param>
        private void Output(IProblem p, Candidate candidate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return true if partial candidate is not worth completing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        private bool Reject(IProblem p, Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
