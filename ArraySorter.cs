using System;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    class ArraySorter : IArraySorter
    {
        readonly static int numOfElements = 1000;
        readonly static int numOfArrays = 10000;
        int[][] arraysToSort = new int[numOfArrays][];

        public ArraySorter()
        {
            Console.WriteLine($"Populating {numOfArrays} arrays with arrays of size {numOfElements}");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            PopulateArrays();

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            TimeSpan t = TimeSpan.FromMilliseconds(elapsedTime);
            string elapsedTimeHumanReadable = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);

            Console.WriteLine($"Populating arrays done in {elapsedTimeHumanReadable}");
            Console.WriteLine("Finished populating arrays!");
            Console.WriteLine("======================================================");
        }

        public int[] InsertionSort(int[] array)
        {
            var i = 1;
            while (i < array.Length)
            {
                var j = i;

                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(ref array[j], ref array[j - 1]);
                    j--;
                }
                i++;
            }

            return array;
        }

        public int[] MergeSort(int[] array)
        {
            // Base case
            if (array.Length == 0 || array.Length == 1)
                return array;

            int[] firstHalfArray = array.Take(array.Length / 2).ToArray();
            int[] secondHalfArray = array.Skip(array.Length / 2).ToArray();

            // Recursive calls
            var left = MergeSort(firstHalfArray);
            var right = MergeSort(secondHalfArray);

            int counterLeft = 0, counterRight = 0, k = 0;
            // Compares both halfs until one is exhausted
            while (counterLeft < left.Length && counterRight < right.Length)
            {
                if (left[counterLeft] < right[counterRight])
                {
                    array[k] = left[counterLeft];
                    counterLeft++;
                }
                else
                {
                    array[k] = right[counterRight];
                    counterRight++;
                }
                k++;
            }

            // Finish off both halfs
            for (var i = counterLeft; i < left.Length; i++)
            {
                array[k] = left[i];
                k++;
            }
            for (var j = counterRight; j < right.Length; j++)
            {
                array[k] = right[j];
                k++;
            }

            return array;
        }

        private int PartitionFront(int[] array, int low, int high)
        {
            int pivot = array[low];
            var i = low + 1;

            for (var j = low + 1; j < high + 1; j++)
            {
                if (array[j] < pivot)
                {
                    Swap(ref array[j], ref array[i]);
                    i++;
                }
            }

            Swap(ref array[low], ref array[i - 1]);

            return i - 1;
        }

        private void PopulateArrays()
        {
            Random rand = new Random();

            for (int i = 0; i < numOfArrays; i++)
            {
                int[] unsortedArray = new int[numOfElements];

                for (int j = 0; j < numOfElements; j++)
                {
                    // Avoid creating array with a lot of duplicates which might skew the results
                    // in favour of an algorithm.
                    int randomNum = rand.Next(numOfElements * 10);
                    while (unsortedArray.Contains(randomNum))
                    {
                        randomNum = rand.Next(numOfElements);
                    }

                    unsortedArray[j] = randomNum;
                }

                arraysToSort[i] = unsortedArray;
            }
        }

        public void PrintArray(int[] array)
        {
            foreach (int n in array)
                Console.Write(n + " ");
            Console.WriteLine();
        }

        public int[] QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pIndex = PartitionFront(array, low, high);
                QuickSort(array, low, pIndex - 1);
                QuickSort(array, pIndex + 1, high);
            }

            return array;
        }

        public int[] SelectionSort(int[] array)
        {
            int min;

            for (var i = 0; i < array.Length; i++)
            {
                min = i;
                for (var j = i; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }
                if (min != i)
                    Swap(ref array[i], ref array[min]);
            }

            return array;
        }

        public string Sort(string algorithm)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var array in arraysToSort)
            {
                switch (algorithm.ToLower())
                {
                    case "selection sort":
                        SelectionSort(array);
                        break;
                    case "quick sort":
                        QuickSort(array, 0, array.Length - 1);
                        break;
                    case "insertion sort":
                        InsertionSort(array);
                        break;
                    case "merge sort":
                        MergeSort(array);
                        break;
                    default:
                        break;
                }
            }

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            TimeSpan t = TimeSpan.FromMilliseconds(elapsedTime);
            string elapsedTimeHumanReadable = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);

            // Shuffle arrays
            PopulateArrays();

            return elapsedTimeHumanReadable;
        }

        private void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
