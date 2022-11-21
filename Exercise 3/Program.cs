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
    }
    
    
    
        static void Main(string[] args)
        {
        }
    }

}

