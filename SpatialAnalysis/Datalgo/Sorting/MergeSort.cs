using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class MergeSort : ISorting
    {
        public override void Sort(int[] A)
        {
            int n = A.Length;
            if (n < 2) // Rekursionsbedingung für Abbruch
                return;
            /*
             * Teile das Teilarray in etwa zwei gleich große Hälften(bei ungeraden Zahlen
             * rechts größer)
             */
            int mid = n / 2; // Bsp.: n=7 wird mid = 3 da int abschneiden und nicht aufrunden
            Console.WriteLine(n);
            Console.WriteLine(mid);
            //Split the array A at mid into variables Left and Right
            SplitArray(A, mid, out int[] Left, out int[] Right);

            /*
             * Sortiere Rekursive das linke und rechte Teilarray und merge sie anschließend.
             * Die Merge-Funktion muss erfüllen, dass sie zwei sortierte Teilarrays zu einem
             * sortiertenArray zusammenfügt. Aufgrund der Tatsache, das mergeSort solange
             * die Arrays aufspaltet bis sie einzelne Elemente sind(Arrays mit nur einem
             * Element sind immer sortiert), kann mergeSort und mergeArrays ohne Vergleiche
             * ein sortiertes Array liefern.
             */
            Sort(Left);
            Sort(Right);
            MergeArrays(A, Left, Right);
        }
    }
}
