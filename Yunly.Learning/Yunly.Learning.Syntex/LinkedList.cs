using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.Syntex
{
    public class LinkedList<T>
    {
        private Node<T> head = null;

        public Node<T> current = null;

        public void add(T data)
        {
            Node<T> toAdd = new Node<T> { data = data };
            
            if (head == null)
            {
                head = toAdd;
                current = head;
            }
            else
            {             
                current.next = toAdd;
                current = current.next;
            }
        }

        public Node<T> find(T data)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.data.Equals(data))
                    return current;
                current = current.next;
            }

            return null;
        }

        public void printAll()
        {
            Node<T> current = head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }

    public class Node<T>
    {
        public Node<T> next;
        public T data;
    }
}
