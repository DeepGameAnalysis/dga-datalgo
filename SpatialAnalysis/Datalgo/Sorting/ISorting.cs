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
    public abstract class ISorting<T> where T:IComparable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap(T[] a, int i, int j)
        {
            Console.WriteLine("Swap: " + i + " with " + j);
            Console.WriteLine("Values are: " + a[i] + " with " + a[j]);
            T h = a[i];
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
        public static void SplitArray(T[] A, int mid, out T[] LeftSubArray, out T[] RightSubArray)
        {
            int n = A.Length;
            LeftSubArray = new T[mid];
            RightSubArray = new T[n - mid];
            // Fülle linkes Array
            for (int i = 0; i < mid; i++)
                LeftSubArray[i] = A[i];

            // Fülle rechtes Array
            for (int j = mid; j < n; j++)
                RightSubArray[j - mid] = A[j];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        public static void MergeArrays(T[] A, T[] L, T[] R)
        {
            int i = 0; // Pointer für Array L
            int j = 0; // Pointer für Array R
            int k = 0; // Pointer für Array A
            int lL = L.Length;
            int rL = R.Length;
            while (i < lL && j < rL)
            {
                if (GreaterEqual(L[i], R[j]))
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

        public static bool GreaterEqual(T value, T other)
        {
            return value.CompareTo(other) > 0 || Equals(value, other);
        }

        public static bool LessEqual(T value, T other)
        {
            return value.CompareTo(other) < 0 || Equals(value, other);
        }

        public static bool Greater(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }

        public static bool Less(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }

        public static bool Equals(T value, T other)
        {
            return value.CompareTo(other) == 0;
        }
    }
}
