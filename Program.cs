using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ArraySorter sorter = new ArraySorter();

            string algorithm;
            string elapsedTime;*/

            /*algorithm = "Insertion sort";
            elapsedTime = sorter.Sort(algorithm);
            Console.WriteLine($"{algorithm}: {elapsedTime}");

            algorithm = "Selection sort";
            elapsedTime = sorter.Sort(algorithm);
            Console.WriteLine($"{algorithm}: {elapsedTime}");

            algorithm = "Quick sort";
            elapsedTime = sorter.Sort(algorithm);
            Console.WriteLine($"{algorithm}: {elapsedTime}");

            algorithm = "Merge sort";
            elapsedTime = sorter.Sort(algorithm);
            Console.WriteLine($"{algorithm}: {elapsedTime}");*/

            int[] array = { 1, 5, 7, 8, 10 };
            LinkedList<int> llist = new LinkedList<int>(array);
            llist.PrintList();
            List<string> nodeIds = llist.GetAllIds();
            llist.DeleteList();
            llist.PrintList();
        }
    }
}
