namespace DataStructuresAndAlgorithms
{
    interface IArraySorter
    {
        int[] InsertionSort(int[] array);

        int[] MergeSort(int[] array);

        int[] SelectionSort(int[] array);

        int[] QuickSort(int[] array, int low, int high);

        void PrintArray(int[] array);
    }
}
