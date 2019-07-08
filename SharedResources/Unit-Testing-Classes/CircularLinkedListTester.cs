using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Unit_Testing_Classes
{
    public class CircularLinkedListTester
    {
        private CircularLinkedList<int> list1;
        private CircularLinkedList<string> list2;
        private CircularLinkedList<char> list3;


        public CircularLinkedListTester()
        {
            list1 = new CircularLinkedList<int>();
            list2 = new CircularLinkedList<string>();
            list3 = new CircularLinkedList<char>();


            AddNumbers(list1);
            AddWords(list2);
            AddAlphabets(list3);


            Console.Write("Display initial list of numbers :");
            DisplayNumbers(list1);
            Console.Write("\nDisplay initial list of words :");
            DisplayWords(list2);
            Console.Write("\nDisplay initial list of alphabets :");
            DisplayAlphabets(list3);




            // Test RemoveFirst
            TestRemoveFirst(list1);
            TestRemoveFirst(list2);
            TestRemoveFirst(list3);


            Console.WriteLine();
            Console.WriteLine("***********************RemoveFirst***********************");
            Console.WriteLine();

            Console.Write("\nTest the Remove First method on numbers :");
            DisplayNumbers(list1);
            Console.Write("\nTest the Remove First method on words :");
            DisplayWords(list2);
            Console.Write("\nTest the Remove First method on alphabets :");
            DisplayAlphabets(list3);

            // Test RemoveFirst
            TestRemoveLast(list1);
            TestRemoveLast(list2);
            TestRemoveLast(list3);

            Console.WriteLine();
            Console.WriteLine("***********************RemoveLast***********************");
            Console.WriteLine();

            Console.Write("\nTest the Remove Last method on numbers :");
            DisplayNumbers(list1);
            Console.Write("\nTest the Remove Last method on words :");
            DisplayWords(list2);
            Console.Write("\nTest the Remove Last method on alphabets :");
            DisplayAlphabets(list3);


            // Test RemoveFirst
            TestRemoveAt(list1, 1);
            //TestRemoveAt(list2, 2);
            TestRemoveAt(list3, 3);

            Console.WriteLine();
            Console.WriteLine("***********************RemoveAt***********************");
            Console.WriteLine();

            Console.Write("\nTest the Remove  At 1 method on numbers :");
            DisplayNumbers(list1);
            Console.Write("\nTest the Remove At 2 method on words :");
            DisplayWords(list2);
            Console.Write("\nTest the Remove At 3  method on alphabets :");
            DisplayAlphabets(list3);


            // Test AddLast
            AddLast(list1);
            AddLast(list2);
            AddLast(list3);


            Console.WriteLine();
            Console.WriteLine("***********************AddLast***********************");
            Console.WriteLine();

            Console.Write("\nTest the Add Last method on numbers :");
            DisplayNumbers(list1);
            Console.Write("\nTest the Add Last method on words :");
            DisplayWords(list2);
            Console.Write("\nTest the Add Last method on alphabets :");
            DisplayAlphabets(list3);


            // Test AddFirst
            AddFirst(list1);
            AddFirst(list2);
            AddFirst(list3);


            Console.WriteLine();
            Console.WriteLine("***********************AddFirst***********************");
            Console.WriteLine();

            Console.Write("\nTest the Add First method on numbers :");
            DisplayNumbers(list1);
            Console.Write("\nTest the Add First method on words :");
            DisplayWords(list2);
            Console.Write("\nTest the Add First method on alphabets :");
            DisplayAlphabets(list3);

        }

        // Testing the Add method.
        private void AddNumbers(CircularLinkedList<int> list)
        {
            for (int i = 1; i < 10; i++)
                list.Add(i);
        }

        private void AddWords(CircularLinkedList<string> list)
        {
            list.Add("Ndumiso Chamane");
            list.Add("Mfundo Mkhize");
            list.Add("Ntuthuko Cele");
            list.Add("Njabulo Khuzwayo");
        }

        private void AddAlphabets(CircularLinkedList<char> list)
        {
            list.Add('$');
            list.Add('!');
            list.Add('_');
            list.Add(';');
            list.Add('*');
            list.Add('@');
            list.Add('_');
            list.Add('/');
        }




        // Testing the DispalyList method.
        private void DisplayNumbers(CircularLinkedList<int> list)
        {
            /*for (int i = 0; i < list.Size; i++)
            {
                Console.WriteLine("------------------Digit number " + i + 1 + "-------------------");
                list.GetAt(i).ToString();
                Console.WriteLine();
            }*/
            list.DisplayList();
        }

        private void DisplayWords(CircularLinkedList<string> list)
        {
            /*for (int i = 0; i < list.Size; i++)
            {
                Console.WriteLine("------------------Word number " + i + 1 + "-------------------");
                list.GetAt(i).ToString();
                Console.WriteLine();
            }*/
            list.DisplayList();
        }

        private void DisplayAlphabets(CircularLinkedList<char> list)
        {
            /*for (int i = 0; i < list.Size; i++)
            {
                Console.WriteLine("------------------Character number " + i + 1 + "-------------------");
                list.GetAt(i).ToString();
                Console.WriteLine();
            }*/
            list.DisplayList();
        }




        // Testing the RemoveFirst method.


        private void TestRemoveFirst(CircularLinkedList<int> list)
        {
            list.RemoveFirst();
        }

        private void TestRemoveFirst(CircularLinkedList<char> list)
        {
            list.RemoveFirst();
        }

        private void TestRemoveFirst(CircularLinkedList<string> list)
        {
            list.RemoveFirst();
        }




        // Testing the RemoveLast method.
        private void TestRemoveLast(CircularLinkedList<int[]> list)
        {
            list.RemoveLast();
        }

        private void TestRemoveLast(CircularLinkedList<char> list)
        {
            list.RemoveLast();
        }

        private void TestRemoveLast(CircularLinkedList<string> list)
        {
            list.RemoveLast();
        }

        private void TestRemoveLast(CircularLinkedList<int> list)
        {
            list.RemoveLast();
        }



        // Testing the RemoveAt method.
        private void TestRemoveAt(CircularLinkedList<int> list, int index)
        {
            list.Remove(index);
        }

        private void TestRemoveAt(CircularLinkedList<char> list, int index)
        {
            list.Remove(index);
        }

        private void TestRemovAt(CircularLinkedList<string> list, int index)
        {
            list.Remove(index);
        }

        private void TestRemoveAt(CircularLinkedList<int[]> list, int index)
        {
            list.Remove(index);
        }

        // Testing the AddFirst method.
        private void AddFirst(CircularLinkedList<int> list)
        {

            list.AddFirst(0);
        }

        private void AddFirst(CircularLinkedList<string> list)
        {
            list.AddFirst("Happy Jele");

        }

        private void AddFirst(CircularLinkedList<char> list)
        {
            list.AddFirst('%');

        }

        private void AddFirst(CircularLinkedList<int[]> list)
        {
            list.AddFirst(new int[] { 0, 0, 0, 0, 0, 0 });

        }

        // Testing the AddLast method.
        private void AddLast(CircularLinkedList<int> list)
        {

            list.AddLast(1000);
        }

        private void AddLast(CircularLinkedList<string> list)
        {
            list.AddLast("Jimmy Tau");

        }

        private void AddLast(CircularLinkedList<char> list)
        {
            list.AddLast('~');

        }

        private void AddLast(CircularLinkedList<int[]> list)
        {
            list.AddLast(new int[] { 3390, 2200, 1100, 1290, 4330, 2130 });

        }



    }
}
