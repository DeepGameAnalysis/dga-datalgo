using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gau_spatial.Binary_Trees
{
    public class SearchAlgorithms
    {

        public static void main(String[] args)
        {
            int searchelement = 17;
            int[] nums = { 42, 17, 12, 15, 4, 11, 31, 14 };
            Console.WriteLine(string.Join("",nums));
            CountingSorts.BucketSort(nums);
            Console.WriteLine(string.Join("", nums));
            try
            {
                int result = BinarySeek(searchelement, nums);
                Console.WriteLine("Found: " + (nums[result] == searchelement));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }

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
        public static int LinearSeek(int s, int[] A)
        {
            //Iteriere bis gesuchtes Element gefunden.
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == s)
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
        public static int BinarySeek(int s, int[] A)
        {

            int lowerbound = 0;
            int upperbound = A.Length - 1;
            while (lowerbound <= upperbound)
            {
                int mid = (lowerbound + upperbound) / 2;
                if (s == A[mid])
                {
                    return mid; // Gesuchte element war Wurzel der binären Suche
                }
                else
                {
                    if (s < A[mid])
                    {
                        /*
                         * Aktuelles Element is größer als s -> suche im linken Teilintervall indem
                         * dessen upperbound auf links vom Mittelpunkt gesetzt wird
                         */
                        upperbound = mid - 1;
                    }
                    else if (s > A[mid])
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
        public static int BinaryInterpolatedSeek(int s, int[] A)
        {
            int lowerbound = 0;
            int upperbound = A.Length - 1;
            while (lowerbound <= upperbound)
            {
                // Schätze den gesuchten Index durch Interpolation
                int i = lowerbound + (s - A[lowerbound]) * (upperbound - lowerbound) / (A[upperbound] - A[lowerbound]);
                if (s == A[i])
                {
                    return i; // Gesuchte wurde richtig Interpoliert
                }
                else
                {
                    if (s < A[i])
                    {
                        /*
                         * Aktuelles Element is größer als s -> suche im linken Teilintervall indem
                         * dessen upperbound auf links vom interpolierten Index gesetzt wird
                         */
                        upperbound = i - 1;
                    }
                    else if (s > A[i])
                    {
                        /*
                         * Aktuelles Element is kleiner als s -> suche im rechten Teilintervall indem
                         * dessen lowerbound auf rechts vom interpolierten Index gesetzt wird
                         */
                        lowerbound = i + 1;
                    }
                }
            }
            throw new Exception("The element: " + s + " could not be found in the given array.");
        }
    }
}