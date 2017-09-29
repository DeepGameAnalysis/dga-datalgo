using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

    public class SimpleSorts<T> : ISorting
    {
        public static void main(String[] args)
        {
            int[] nums = { 42, 17, 12, 15, 4, 11, 31, 14 };
            int[] A = new int[4];
            int[] R = { 4, 5 };
            int[] L = { 8, 9 };
            Console.WriteLine(string.Join(".", nums));
            Console.WriteLine(string.Join(".", nums));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        public static void InsertionSort(int[] A)
        {
            if (A.Length == 1)
                return;
            // Gehe ab dem zweiten Element los
            for (int i = 1; i < A.Length; ++i)
            {
                int v = A[i]; // Wert des aktuellen Elements
                int j = i; // Index des aktuellen Elements

                /*
                 * Solange man nicht beim Index des ersten Elements angekommen ist, und der
                 * Vorgängergewert größer als der aktuelle Wert ist: Setze den Vorgänger auf den
                 * aktuellen Wert (schiebe ihn nach rechts weiter) und gehe einen Index nach
                 * links
                 */
                while ((j >= 1) && (A[j - 1] > v))
                {
                    A[j] = A[j - 1];
                    j--;
                }
                // Füge den aktuellen Wert wieder ein sofern gilt:
                // Man ist am Index des ersten Elements angekommen Nachfolgewert größer
                A[j] = v;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        public static void SelectionSort(int[] A)
        {
            // Durchlauf jede Position des Array
            for (int i = 0; i < A.Length; ++i)
            {
                int min = i;
                // Suche den Index des kleinsten Elements
                for (int j = i + 1; j < A.Length; ++j)
                    if (A[j] < A[min])
                        min = j;


                // Vertausche das akutelle Element mit dem kleinsten
                Swap(A, i, min);
                // Beginne dann mit dem Element an i+1
                /*Dabei entsteht folgendes:
                 1. Iteration: kleinstes Element wird 1. Element
                 2. Iteration: 2. kleinstes Element wird 2. Element 
                 usw..*/
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        public static void BubbleSort(int[] A)
        {
            // Laufe ab dem zweiten Element bis zum letzten
            for (int i = 1; i < A.Length; i++)
            {
                int flag = 0;
                // Laufe ab dem ersten bis zum n-i-ten Element
                // Bsp:von 1 bis n-1, 2 bis n-2 usw -> legt rechte Grenze fest
                for (int j = 0; j < A.Length - i; j++)
                {
                    // Vergleiche jedes Element mit seinem Nachfolger
                    // wenn es größer als der Nachfolger ist
                    if (A[j] > A[j + 1])
                    {
                        // Vertausche die beiden
                        Swap(A, j, j + 1);
                        Console.WriteLine(string.Join(".", A));
                        flag = 1;
                    }
                }
                // Flag makiert ob eine Vertauschung durchgeführt wurde
                // -> äußere Schleife kann gestoppt werden
                if (flag == 0)
                    break;
            }

            /*
             * In jedem Durchgang der äußeren Schleife lässt man den größten Wert im Rest
             * des Arrays immer nach rechts vertauschen solange bis er an der rechten Grenze
             * des bereits sortierten Arrays ankommt(dort wo eine Zahl größer als der
             * momentane "aufsteigende" Wert liegt).
             */
        }
    }
}
