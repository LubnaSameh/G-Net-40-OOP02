namespace OOP02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01: Theoretical Questions - Q1
            /*
             * Q1(a):
             * 1. No Protection: The fields 'Owner' and 'Balance' are public. Anyone can change the balance 
             * to a negative number from outside the class.
             * 2. Skipping Rules: A person can change the balance directly without using the 'Withdraw' method, 
             * so we lose control over the business rules.
             *
             * Q1(b)
             * 1. Change fields from 'public' to 'private'.
             * 2. Create 'Properties' with (get and set). Inside the 'set', we can add a check 
             * to make sure the data is correct before saving it.
             *
             * Q1(c)
             * 1. It breaks "Data Hiding": The internal data is not safe and can be changed by mistake.
             * 2. Hard to Update: If we want to add a new rule later, we will have to change the code 
             * everywhere in the project. Properties make it easy to change rules in one place.
             */
            #endregion

            #region Part 01: Theoretical Questions - Q2

            /*
             * Q2:
             * - Field: It is a simple variable used to store data inside a class (Example: private int age;).
             * - Property: It acts like a smart gatekeeper for the data.
             * It uses 'get' to read the data and 'set' to write or change the data.
 
             * - Yes! You can write code, like 'if' conditions or math equations, 
             * inside the 'get' or 'set' blocks to check the data before saving it.
             */
            //public class Rectangle
            // {
            //     // These are normal properties
            //     public double Length { get; set; }
            //     public double Width { get; set; }

            //     // This is a Read-Only property (it only has 'get', no 'set').
            //     // It calculates the value every time you ask for it.
            //     public double Area
            //     {
            //         get { return Length * Width; }
            //     }
            // }

            #endregion

            #region Part 01: Theoretical Questions - Q3
            /*
             * Q3(a):
             * - It is called an "Indexer".
             * - Its purpose is to allow you to treat an object like an array. 
             * You can get or set values using the [ ] brackets directly on the object.
             *
             * Q3(b):
             * - What happens: It will cause an "IndexOutOfRangeException" error (the program will crash) 
             * because the array size is only 5.
             * - To make it safer: Add an 'if' condition inside the 'get' and 'set' to check if the index 
             * is between 0 and the array length before accessing it.
             *
             * Q3(c):
             * - Yes, a class can have multiple indexers (this is called Indexer Overloading).
             * - Example: You can have one indexer that uses an 'int' index (like an ID) 
             * and another indexer that uses a 'string' (like a name) to find data in the same class.
             */
            #endregion

            #region Part 01: Theoretical Questions - Q4
            /*
             * Q4(a):
             * - Static Keyword: It means that TotalOrders belongs to the Class itself, not to a specific object
             * There is only one copy of this variable shared by all orders
             * - Difference from Item: The Item field belongs to the object instance
             * Every time you create a new order, it has its own unique Item name
             * But 'TotalOrders' is one counter that increases every time any order is made
             
             * Q4(b):
             * - Answer: No, a static method cannot access the Item field directly.
             * - Why: Because static methods belong to the class and can run even if no objects exist
             * The Item field needs a specific object to exist
             * The static method doesn't know which object's Item it should look at.
             */
            #endregion
        }
    }
}
