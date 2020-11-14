using System;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraySorter sorter = new ArraySorter();

            string algorithm;
            string elapsedTime;

            algorithm = "Insertion sort";
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
            Console.WriteLine($"{algorithm}: {elapsedTime}");
        }
    }
}
