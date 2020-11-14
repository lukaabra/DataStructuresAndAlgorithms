using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class Node<T>
    {
        public Node(T _value)
        {
            Value = _value;

            Guid guid = Guid.NewGuid();
            Id = guid.ToString();
        }

        public List<Node<T>> Edges { get; set; } = null;

        public string Id { get; set; }

        public Node<T> Next { get; set; } = null;

        public void Print()
        {
            try
            {
                Console.WriteLine($"Node value: {Value}\nNode ID: {Id}\nNext node: {Next.Id}\n========================================");
            }
            catch (Exception)
            {
                Console.WriteLine($"Node value: {Value}\nNode ID: {Id}\nNext node: {Next}\n========================================");
            }
        }

        public T Value { get; set; }
    }
}
