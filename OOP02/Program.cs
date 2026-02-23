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
        }
    }
}
