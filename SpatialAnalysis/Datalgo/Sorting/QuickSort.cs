using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class QuickSort<T>: ISorting<T> where T : IComparable
    {
        public static void Sort(T[] A, int start, int end)
        {
            if (start >= end)
                return; // Set recursion end

            /*
             * Partitioniere so, dass alle Zahlen kleiner dem Pivot-Element links liegen und
             * alle größeren rechts. Der zurückgelieferte Index zeigt die Stelle im Array an
             * dem sich jetzt das Pivot-Element befindet und ab dem neu getrennt werden kann
             * in zwei neue Subarrays siehe im folgenden. Start und End legen das Teilaray
             * Intervall fest. Zu Anfangs liegt dies bei 0 bis Length-1:
             */
            int index = Partition(A, start, end);
            /*
             * Wende die Partitionierung rekursiv auf die zwei Teilarrays(links/rechts vom
             * Pivotelement) an. Solange bis nurnoch ein Element im sortierten Teilarray
             * liegt(nicht das Pivot-Element!!). Die Funktion der Partitionierung hat
             * während des rekursiven Durchlaufs die Element so vertauscht, dass sie im
             * ganzen Array die richtigen Indizes erhalten haben.
             */
            Sort(A, start, index - 1);
            Sort(A, index + 1, end);
        }

        static int Partition(T[] A, int start, int end)
        {
            int pivindex = end;
            T pivot = A[pivindex];
            int pindex = start;
            // Laufe über das Teilarray von start bis end
            for (int i = start; i < end; i++)
            {
                /*
                 * Tausche alle Elemente die kleiner oder gleich Pivot-Element sind zum
                 * aktuellen Zeiger(pindex) für die Grenze des linken Teilarrays. Erhöhe den
                 * Zeiger für das nächste Element(oder um bei vollendung das Pivot-Element dort
                 * einzufügen) - PS: Flip Relation um absteigende Ordnung zu erzeugen
                 */
                if (LessEqual(A[i],pivot))
                {
                    Swap(A, i, pindex);
                    pindex++;
                }
            }
            /*
             * Tausche das Pivot-Element zu seinem Index(in der Mitte zwischne linkem und
             * rechtem Teilarray)
             */
            Swap(A, pivindex, pindex);
            return pindex;
        }
    }
}
