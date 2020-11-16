using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class LinkedList<T>
    {
        public int linkedListSize;

        public LinkedList(T[] initialData)
        {
            linkedListSize = initialData.Length;
            PopulateLinkedList(initialData);
        }

        public void Append(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            if (Head == null)
                Head = newNode;

            newNode.Next = null;

            // Traverse the whole list
            Node<T> last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }

            last.Next = newNode;
            return;
        }

        public void DeleteKey(T key)
        {
            Node<T> temp = Head, prev = null;

            if (Head == null)
                return;

            // Check if head contains the key
            if (temp != null && EqualityComparer<T>.Default.Equals(temp.Value, key))
            {
                Head = temp.Next;
                return;
            }

            // Search for the key
            while (temp != null && !EqualityComparer<T>.Default.Equals(temp.Value, key))
            {
                prev = temp;
                temp = temp.Next;
            }

            // Key not present in list
            if (temp == null)
                return;

            // Unlink the node from the list
            prev.Next = temp.Next;
        }

        public void DeleteList()
        {
            Head = null;
        }

        public void DeletePosition(int position)
        {
            if (Head == null)
                return;

            Node<T> temp = Head;

            // If head needs to be removed
            if (position == 0)
            {
                Head = temp.Next;
                return;
            }

            // Find the previous node of the node that needs to be deleted
            for (int i = 0; temp != null && i < position - 1; i++)
                temp = temp.Next;

            // Variable next is the node after the one we need to delete
            Node<T> next = temp.Next.Next;
            temp.Next = next;
        }

        private Node<T> FindNode(string id)
        {
            Node<T> node = Head;
            while (node!= null)
            {
                if (node.Id == id)
                    return node;

                node = node.Next;
            }

            return node;
        }

        public List<string> GetAllIds()
        {
            List<string> AllNodeIds = new List<string>();

            Node<T> node = Head;

            while (node != null)
            {
                AllNodeIds.Add(node.Id);
                node = node.Next;
            }

            return AllNodeIds;
        }

        public void InsertAfter(string prevNodeId, T newData)
        {
            if (prevNodeId == null)
            {
                Console.WriteLine("The given node after which to insert is null!");
                return;
            }

            Node<T> prevNode = FindNode(prevNodeId);

            Node<T> newNode = new Node<T>(newData) { Next = prevNode.Next };
            prevNode.Next = newNode;
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

        /// <summary>
        /// Push to the front of the list.
        /// </summary>
        /// <param name="newData">Value of the new node.</param>
        public void Push(T newData)
        {
            Node<T> newNode = new Node<T>(newData);
            newNode.Next = Head;
            Head = newNode;

            linkedListSize += 1;
        }

        public void PrintList()
        {
            Node<T> node = Head;
            while (node != null)
            {
                node.Print();
                node = node.Next;
            }
        }
    
    }
}
