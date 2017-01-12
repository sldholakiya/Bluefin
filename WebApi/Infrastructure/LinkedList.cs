using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Infrastructure
{
    public class LinkedList
    {
        public LinkedList()
        {
            Length = 0;
        }
        public class Node
        {
            // link to next Node in list
            public Node next = null;
            // node value
            public int data;

        }
        private int Length { get; set; }
        private Node root = null;
        public Node First { get { return root; } }
        public Node Last
        {
            get
            {
                Node curr = root;
                if (curr == null)
                    return null;
                while (curr.next != null)
                    curr = curr.next;
                return curr;
            }
        }

        public void Append(int value)
        {
            Node n = new Node { data = value };
            if (root == null)
                root = n;
            else
                Last.next = n;
            Length++;
        }

        public int? GetElementAt(int index)
        {
            if (index > Length)
                return null;
            
            Node current = root;
            if (current == null)
                return null;
            int i = 0;
            
            while (current.next != null)
            {
                if(i == Length - index)
                    break;

                current = current.next;
                i++;
            }
            return current.data;
        }
    }
}