﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Node
    {
        // create nodes for circular nexted list
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous=current, current = current.next)
            {
                if(rollNo == current.rollNumber)
                return (true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }
        public bool listEmty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public bool traverse()
        {
            if (listEmty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the list are:\n ");
                Node curretNode;
                curretNode = LAST.next;
                while (curretNode != LAST)
                {
                    Console.Write(curretNode.rollNumber + " " + curretNode.name + "\n");
                    curretNode = curretNode.next;
                }
                Console.Write(LAST.rollNumber+ " "+ LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmty())
                Console.WriteLine("\nlist is empty");
            else
                Console.WriteLine("\n ]The first record in the list is:\n\n"+ LAST.next.rollNumber+" "+ LAST.next.name);

        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while(true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the record in the list");
                    Console.WriteLine("2. Seacrh for a record in the list ");
                    Console.WriteLine("3. Dispalay the  record in the list ");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\nEnter your choice (1-4) ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch(ch)

                }
            }
        }
    }

    
    
    
       
    

