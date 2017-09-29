using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class CountingSorts : ISorting
    {
        /*
         * Kapazität des Counting Array Histogramms
         */
        const int MAX_COUNT_HISTO = 256;

        //
        // Spezielle Sortieralgorithmen
        //
        public override void Sort(int[] A)
        {
            int n = A.Length;

            int[] output = new int[n];

            // Erstelle ein Histogramm (max 256 unterschiedlichen Werten von 0-256)
            int[] histogram = new int[MAX_COUNT_HISTO];
            for (int i = 0; i < histogram.Length; ++i)
                histogram[i] = 0;

            // Erhöhe den Zähler jedes Elements aus dem übergebenen Array
            // Wenn eine "1" gefunden wurde -> Zähler im Histo an Index 1 erhöht
            for (int i = 0; i < n; ++i)
            {
                ++histogram[A[i]];
            }

            // Change count[i] so that count[i] now contains actual
            // position of this element in output array
            for (int i = 1; i <= MAX_COUNT_HISTO - 1; ++i)
                histogram[i] += histogram[i - 1];

            // Erzeuge das Ausgabearray
            for (int i = 0; i < n; ++i)
            {
                output[histogram[A[i]] - 1] = A[i];
                --histogram[A[i]];
            }

            // Kopiere das Ausgabearray nach A
            for (int i = 0; i < n; ++i)
                A[i] = output[i];
        }

        const int DEFAULT_BUCKET_SIZE = 5;

        public static void BucketSort(int[] array)
        {
            int bucketSize = DEFAULT_BUCKET_SIZE;
            if (array.Length == 0)
            {
                return;
            }

            // Determine minimum and maximum values
            int minValue = array[0];
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
                else if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            /* Initialisiere buckets. BucketCount legt maximal Anzahl an buckets fest. */
            int bucketCount = (maxValue - minValue) / bucketSize + 1;
            Console.WriteLine("---BucketCount: " + bucketCount);
            List<List<int>> buckets = new List<List<int>>(bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }

            // Verteile die Elemente in ihre passenden bucket
            Console.WriteLine("---Fill buckets");
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                /*
                 * Berechne hier den Index des Buckets. Der Abstand zum minimal Wert legt in
                 * Relation zur Bucketmenge fest wo das Element hineinfällt.
                 */
                int index = (element - minValue) / bucketSize;
                buckets.ElementAt(index).Add(element);
                Console.WriteLine("Add: " + element + " at index: " + index);
            }

            Console.WriteLine("---Buckets are:");
            for (int i = 0; i < bucketCount; i++)
            {
                Console.WriteLine("Index: " + i + " at index: " + buckets.ElementAt(i).ToString());
            }

            /*
             * Sortiere die buckets mittels insertionSort und füge sie im referenzierten
             * Array zusammen.
             */
            int currentIndex = 0;
            for (int i = 0; i < buckets.Count(); i++)
            {
                int[] bucketArray = buckets.ElementAt(i).ToArray();
                SimpleSorts<int>.insertionSort(bucketArray);
                for (int j = 0; j < bucketArray.Length; j++)
                {
                    array[currentIndex++] = bucketArray[j];
                    Console.WriteLine("Add to final array: " + bucketArray[j]);
                }
            }
        }
    }
}
