using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SearchAlgorithms<T> : ISorting<T> where T : IComparable
    {


        /**
         * 
         * @param s
         *            - gesuchtes element
         * @param A
         *            - muss ein sortiertes Array sein, mit Gleichverteilung.
         * @return index des gesuchten elements im array
         * @throws Exception
         *             - falls element nicht gefunden
         */
        public static int LinearSeek(T s, T[] A)
        {
            //Iteriere bis gesuchtes Element gefunden.
            for (int i = 0; i < A.Length; i++)
            {
                if (Equals(A[i], s))
                {
                    return i;
                }
            }
            throw new Exception("The element: " + s + " could not be found in the given array.");
        }

        /**
         * 
         * @param s
         *            - gesuchtes element
         * @param A
         *            - muss ein sortiertes Array sein!!
         * @return index des gesuchten elements im array
         * @throws Exception
         *             - falls element nicht gefunden
         */
        public static int BinarySeek(T s, T[] A)
        {

            int lowerbound = 0;
            int upperbound = A.Length - 1;
            while (lowerbound <= upperbound)
            {
                int mid = (lowerbound + upperbound) / 2;
                if (Equals(s, A[mid]))
                {
                    return mid; // Gesuchte element war Wurzel der binären Suche
                }
                else
                {
                    if (Less(s, A[mid]))
                    {
                        /*
                         * Aktuelles Element is größer als s -> suche im linken Teilintervall indem
                         * dessen upperbound auf links vom Mittelpunkt gesetzt wird
                         */
                        upperbound = mid - 1;
                    }
                    else if (Greater(s, A[mid]))
                    {
                        /*
                         * Aktuelles Element is kleiner als s -> suche im rechten Teilintervall indem
                         * dessen lowerbound auf rechts vom Mittelpunkt gesetzt wird
                         */
                        lowerbound = mid + 1;
                    }
                }
            }
            throw new Exception("The element: " + s + " could not be found in the given array.");
        }

        /**
         * 
         * @param s
         *            - gesuchtes element
         * @param A
         *            - muss ein sortiertes Array sein, mit Gleichverteilung.
         * @return index des gesuchten elements im array
         * @throws Exception
         *             - falls element nicht gefunden
         */
        public static int BinaryInterpolatedSeek(T s, T[] A)
        {
            int lowerbound = 0;
            int upperbound = A.Length - 1;
            while (lowerbound <= upperbound)
            {
                // Schätze den gesuchten Index durch Interpolation
                dynamic lower = A[lowerbound];
                dynamic upper = A[upperbound];

                dynamic dsl = s - lower;
                dynamic dul = upper - lower;
                int i = lowerbound + dsl * (upperbound - lowerbound) / dul;

                if (Equals(s, A[i]))
                    return i; // Gesuchte wurde richtig Interpoliert
            /*
               * Aktuelles Element is größer als s -> suche im linken Teilintervall indem
               * dessen upperbound auf links vom interpolierten Index gesetzt wird
               */
            /*
                * Aktuelles Element is kleiner als s -> suche im rechten Teilintervall indem
                * dessen lowerbound auf rechts vom interpolierten Index gesetzt wird
                */
                else
                    if (Less(s, A[i]))
                    upperbound = i - 1;
                else if (Greater(s, A[i]))

                    lowerbound = i + 1;
            }
            throw new Exception("The element: " + s + " could not be found in the given array.");
        }
    }
}