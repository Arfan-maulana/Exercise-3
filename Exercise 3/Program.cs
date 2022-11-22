using System;
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
        public Node prev;
    }
    class CircularList
    {
        Node LAST;
        Node START;
        public CircularList()
        {
            LAST = null;
        }

        public void List()
        {
            START = null;
        }

        public void addNote() //add a node in the list 
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the roll name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = rollNo;
            newNode.name = nm;
            // if the node to be interested is the firts node
            if (LAST == null)
            {
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            else if (rollNo <= LAST.rollNumber)
            {
                if (LAST != null && rollNo == LAST.rollNumber)
                {
                    Console.WriteLine("\n Dupliacte student number are not allowed \n");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = LAST; current != null && rollNo >= current.rollNumber; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDulicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }
        public bool delnode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (rollNo == LAST.next.rollNumber)
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }
            if (rollNo <= LAST.rollNumber)
            {
                current = LAST.next;
                previous = LAST.next;
                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            if (rollNo == LAST.rollNumber)
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                    previous = previous.next;
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }
            return true;
        }


        public bool listEmty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()
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
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmty())
                Console.WriteLine("\nlist is empty");
            else
                Console.WriteLine("\n ]The first record in the list is:\n\n" + LAST.next.rollNumber + " " + LAST.next.name);

        }
        class Program
        {
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Add a record to the list");
                        Console.WriteLine("2. Delete a record from the list");
                        Console.WriteLine("3. View all records in the list");
                        Console.WriteLine("4. Search for a record in the list");
                        Console.WriteLine("5. Display the first record in the list");
                        Console.WriteLine("6. Exit\n");
                        Console.WriteLine("Enter your choice (1-6): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNote();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmty())
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Console.Write("Enter the roll number of the student" + "whose record is to be deleted: ");
                                    int StudentNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delnode(StudentNo) == false)
                                        Console.WriteLine("record not found");
                                    else
                                        Console.WriteLine("Record with roll number" + StudentNo + "deleted\n");
                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.listEmty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                        Console.WriteLine("\nName: " + curr.name);
                                    }
                                }
                                break;
                            case '5':
                                {
                                    obj.firstNode();
                                }
                                break;
                            case '6':
                                {
                                    return;
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine("\nInvalid option");
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Check for the values entered.");
                    }
                }
            }
        }
    } }



