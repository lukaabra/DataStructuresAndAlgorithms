using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class LinkedList<T>
    {
        public LinkedList(T[] initialData)
        {
            PopulateLinkedList(initialData);
        }

        public Node<T> Head { get; set; }

        private void PopulateLinkedList(T[] data)
        {
            Node<T> currentNode = new Node<T>(data[0]) { Next = new Node<T>(data[1]) };
            Node<T> prevNode = currentNode;

            Head = currentNode;

            for (int i = 1; i < data.Length; i++)
            {
                try
                {
                    currentNode = prevNode.Next;
                    currentNode.Next = new Node<T>(data[i + 1]);
                    prevNode = currentNode;
                }
                catch (IndexOutOfRangeException)
                {
                    currentNode = prevNode.Next;
                    currentNode.Next = null;
                }
            }
        }

        public void TraverseList()
        {
            // Add delegate so any function can be executed on each node during traversal
            Node<T> node = Head;
            while (node != null)
            {
                node.Print();
                node = node.Next;
            }
        }
    
    }
}
