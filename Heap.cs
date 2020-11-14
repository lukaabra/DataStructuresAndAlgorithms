using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    class Heap
    {
        List<int> heapList;
        int heapSize;
        private const int rootIndex = 1;
        int? root;
        string minOrMax = "MIN";

        /// <summary>
        /// The first element of the array implementation is 0.
        /// That means that the 0th index of the array implementation is not counted as part of the heap.
        /// </summary>
        /// <param name="array">Array representation of a heap</param>
        /// <param name="minOrMaxHeap">Flag used to differentiate if the heap in question is a minimum or maximum heap.</param>
        public Heap(int[] array, string minOrMaxHeap)
        {
            heapList = array.Length == 0 ? new List<int> {0} : array.OfType<int>().ToList();
            heapSize = heapList.Count - 1;

            /// Assign root value from the heap
            try
            {
                root = heapList[rootIndex];
            }
            catch (IndexOutOfRangeException)
            {
                root = null;
            }

            /// Assign if heap is MIN or MAX
            if (minOrMaxHeap == "MIN" || minOrMaxHeap == "MAX")
                minOrMax = minOrMaxHeap;
            else
                throw new ArgumentOutOfRangeException("The heap can either be a minimum (MIN) or a maximum (MAX) heap.");
        }

        /// <summary>
        /// The index of a parent of a given element in a heap is 2 times smaller than the elements (i / 2)
        /// </summary>
        /// <param name="index">Index of the key in the heap for which to return the parent</param>
        /// <returns>Value of the parent key which can be null if the key does not have a parent</returns>
        public int? GetParent(int index)
        {
            if (index == rootIndex)
                return null;
            else
                return heapList[index / 2];
        }

        /// <summary>
        /// The index of children for an element at a given index are 2 * i, and (2 * i) + 1.
        /// </summary>
        /// <param name="index">Index of the key in the heap for which to return children</param>
        /// <returns>Nullable int array of two elements: values of left child and right child (null if they do not exist)</returns>
        public int?[] GetChildren(int index)
        {
            int? leftChild = null, rightChild = null;

            /// If children index is smaller than the heap size return the children
            if (2 * index < heapList.Count)
            {
                leftChild = heapList[2 * index];
                if (2 * index + 1 < heapList.Count)
                    rightChild = heapList[2 * index + 1];
            }

            int?[] children = { leftChild, rightChild };
            return children;
        }

        /// <summary>
        /// The heap property is if in a MIN heap each child's value of a key is less the the key we are looking at.
        /// In a MAX heap each child's key value must be bigger than the key we are looking at.
        /// 
        /// Checks the heap propery of the whole heap by iterating over each key and checking if that key satisfies the
        /// heap property. If a single key does not satisfy, the heap property of the whole heap is not satisfied
        /// </summary>
        /// <returns>If the whole heap satisfies the heap property.</returns>
        public bool CheckHeapProperty()
        {
            for (int i = 1; i < heapList.Count; i++)
            {
                if (!CheckHeapPropertyOfKey(i))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the heap property of us each key. If the heap is a minimum heap then each child of a parent must
        /// have a smaller or equal key value than the parent. If it is a maximum heap, then each child must have a
        /// larger or equal key value than the parent.
        /// </summary>
        /// <param name="index">Index of the key to check in the array implementation</param>
        /// <returns>If a key at an <c>index</c> satisfies the heap property</returns>
        private bool CheckHeapPropertyOfKey(int index)
        {
            int key = heapList[index];
            int?[] children = GetChildren(index);
            int? parent = GetParent(index);

            /// Check children
            if (children.Any(child => child != null))
            {
                foreach (var child in children)
                {
                    if (minOrMax == "MIN")
                    {
                        /// Not respecting heap property in MIN heap
                        if (child != null && key > child)
                            return false;
                    }
                    else
                    {
                        /// Not respecting heap property in MAX heap
                        if (child != null && key < child)
                            return false;
                    }
                }
            }

            /// Check parent
            if (parent != null)
            {
                if (minOrMax == "MIN")
                {
                    if (key < parent)
                        return false;
                }
                else
                {
                    if (key > parent)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Inserts the key at the end of the heap and bubbles it up until the heap property is restored.
        /// 
        /// Runtime is O(logn).
        /// </summary>
        /// <param name="key">Value of the key that is inserted.</param>
        public void Insert(int key)
        {
            /// Insert at the end
            heapList.Add(key);
            int keyIndex = heapList.Count() - 1;
            int parentIndex = keyIndex / 2;


            /// Bubble up until heap property is restored
            while (!CheckHeapPropertyOfKey(keyIndex))
            {
                /// Swap key's parent and key
                Swap(heapList, parentIndex, keyIndex);

                keyIndex = parentIndex;
                parentIndex = keyIndex / 2;
            }

            root = heapList[rootIndex];
            heapSize = heapList.Count() - 1;
        }

        /// <summary>
        /// Extracts the root of the heap and returns it. If the heap is empty, it returns null.
        /// Delete the root and move the last leaf of the heap to be the new root. Iteratively bubble down until
        /// heap property is restored. Swaps with a smaller child in a MIN heap, and with a larger child in MAX heap.
        /// 
        /// Runtime O(logn).
        /// </summary>
        /// <returns>Root of the heap or null if the heap is empty.</returns>
        public int? Extract()
        {
            // Check if the heap is empty
            if (root != null)
            {
                // Move the last leaf to be the new root
                int lastLeaf = heapList[heapList.Count() - 1];
                heapList.RemoveAt(heapList.Count() - 1);

                int? newRoot = root;
                try
                {
                    heapList[rootIndex] = lastLeaf;
                }
                catch (IndexOutOfRangeException)
                {
                    return root;
                }

                // Index of the element to bubble down
                int bubbleDownIndex = rootIndex;
                int childToSwapWithValue, childToSwapWithIndex;

                // Bubble down until heap property is restored.
                // Swap with smaller child if MIN heap, larger child if MAX heap
                while (!CheckHeapPropertyOfKey(bubbleDownIndex))
                {
                    int?[] children = GetChildren(bubbleDownIndex);

                    if (children.Any(child => child != null))
                    {
                        // Assign value to child
                        if (minOrMax == "MIN")
                            childToSwapWithValue = (int)children.Min();
                        else
                            childToSwapWithValue = (int)children.Max();

                        // Assign index for child
                        if (childToSwapWithValue == heapList[2 * bubbleDownIndex])
                            childToSwapWithIndex = 2 * bubbleDownIndex;
                        else
                            childToSwapWithIndex = (2 * bubbleDownIndex) + 1;

                        // Swap the element to bubble down and it's child
                        Swap(heapList, bubbleDownIndex, childToSwapWithIndex);
                        bubbleDownIndex = childToSwapWithIndex;
                    }
                }

                root = heapList[rootIndex];
                heapSize = heapList.Count() - 1;

                return root;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Prints out all of the elements of the heap.
        /// </summary>
        public void Print()
        {
            foreach (var key in heapList)
            {
                Console.Write($"{key} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Swaps out two elements of a list.
        /// </summary>
        /// <param name="list">List containing the elements.</param>
        /// <param name="indexA">Index of an element to be swapped</param>
        /// <param name="indexB">Index of an element to be swapped</param>
        static void Swap(List<int> list, int indexA, int indexB)
        {
            int temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
