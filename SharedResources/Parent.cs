using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pieces;
using Game_Defination;

namespace SharedResources
{
    public abstract class Parent<T, U> 
    {
        // Determines whether elements can switch the current pattern.
        protected List<bool> canSwitchList;
        // Determines wheter this object can switch the current pattern.
        protected bool canSwitch;

        // Letters are made up of directions, each piece of a direction equals to divisor.
        protected MyLinkedList<U> linkedList;

        // The number of times the linkedList data structure is traversed.
        protected int numberOfTimes;


        public List<bool> CanSwitchList
        {

            get { return canSwitchList; }
            set
            {
                if (value != null && value.Count == canSwitchList.Count)
                    canSwitchList = value;
            }
        }
        public bool CanSwitch { get; set; }

        public MyLinkedList<U> LinkedList
        {
            get
            {
                return linkedList;
            }

            set
            {
                if (value != null)
                    linkedList = value;
            }
        }

        public int NumberOfTimes { set; get; }

        protected Parent()
        {
            canSwitchList = new List<bool>();
            canSwitch = true;
            numberOfTimes = 2;
        }

        protected Parent(List<bool> canSwitchList, bool canSwitch,
        int numberOfTimes)
        {
            if (numberOfTimes < 1)
                throw new Exception("The passed number of repeatations/rotations is incorrect, it must be at least 1.");
            this.numberOfTimes = numberOfTimes;

            if (canSwitchList.Count> 1)
                throw new Exception("The number of elements in the can shoot " +
                    "list must be atleast 2.");
            this.canSwitchList = canSwitchList;
        }

        // Get the string presentation of the can switch list.
        public string GetCanSwitchListPresentation()
        {
            string output = "[ ";


            for (int i = 0; i < canSwitchList.Count - 1; i++)
                if (canSwitchList[i])
                    output += "True, ";
                else
                    output += "False, ";

            if (canSwitchList[canSwitchList.Count - 1])
                output += "True ]";
            else
                output += "False ]\n";


            return output;
        }

        // Display whether or not each point/direction/letter can do another strategy such as shooting.
        public void DisplayCanSwitchList()
        {
            int count = 0;

            for (int i = 0; i < canSwitchList.Count; i++)
            {
                if (count % 10 == 0 && count != 0)
                    Console.WriteLine(canSwitchList[i] + " ");
                else
                    Console.Write(canSwitchList[i] + " ");
                count++;
            }
            Console.WriteLine();
        }

        // Get the last point on this direction.
        // I double this is needed here.
        public U GetLast()
        {
            return linkedList.GetLast();
        }

        // Get the first point on this direction.
        // I double this is needed here.
        public U GetFirst()
        {
            return linkedList.GetFirst();
        }

        // Fill this parent using elements from the helper class.
        public void Fill(U[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
                linkedList.Add(elements[i]);
        }

        // Fill the can shoot list using a list from the helper class.
        public void FillCanSwitchList(List<bool> canSwitchList)
        {
            if (this.canSwitchList.Count == 0)
                for (int i = 0; i < canSwitchList.Count; i++)
                    this.canSwitchList.Add(canSwitchList[i]);
        }

        // Remove the last element on this direction.
        public void RemoveLast()
        {
            linkedList.RemoveLast();
        }

        // Remove the last element on this direction.
        public void RemoveFist()
        {
            linkedList.RemoveFirst();
        }

        // Remove all elements in the containing data structure.
        public void Clear() { linkedList.Clear(); }

        public override string ToString()
        {
            return GetCanSwitchListPresentation()
            + "How many times? " + numberOfTimes + "\n";
        }

        // The starting point for the direction following this one when making a letter.
        public Point RetrieveNextStartingPoint(int direction) { return null; }


    }
}
