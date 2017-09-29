using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Provides every sorting algorithm with elementary functions and defines core functions that an algorithm has to fullfil
    /// </summary>
    public abstract class ISorting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap(int[] a, int i, int j)
        {
            Console.WriteLine("Swap: " + i + " with " + j);
            Console.WriteLine("Values are: " + a[i] + " with " + a[j]);
            int h = a[i];
            a[i] = a[j];
            a[j] = h;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="mid"></param>
        /// <param name="LeftSubArray"></param>
        /// <param name="RightSubArray"></param>
        public static void SplitArray(int[] A, int mid, out int[] LeftSubArray, out int[] RightSubArray)
        {
            int n = A.Length;
            LeftSubArray = new int[mid];
            RightSubArray = new int[n - mid];
            // Fülle linkes Array
            for (int i = 0; i < mid; i++)
            {
                LeftSubArray[i] = A[i];
            }

            // Fülle rechtes Array
            for (int j = mid; j < n; j++)
            {
                RightSubArray[j - mid] = A[j];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        public static void MergeArrays(int[] A, int[] L, int[] R)
        {
            int i = 0; // Pointer für Array L
            int j = 0; // Pointer für Array R
            int k = 0; // Pointer für Array A
            int lL = L.Length;
            int rL = R.Length;
            while (i < lL && j < rL)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < lL)
            {
                A[k] = L[i];
                i++;
                k++;
            }

            while (j < rL)
            {
                A[k] = R[j];
                j++;
                k++;
            }
        }
        /// <summary>
        /// Sort function for a algorithm
        /// </summary>
        /// <param name="a"></param>
        public virtual void Sort(int[] a) { }

        /// <summary>
        /// Parameterized Sort Function
        /// </summary>
        /// <param name="A"></param>
        /// <param name="start">Index from where to start the enumeration</param>
        /// <param name="end">Index where to end the sorting</param>
        public virtual void Sort(int[] A, int start, int end) { }
        
        //public abstract void PrintProgress();

    }
}
