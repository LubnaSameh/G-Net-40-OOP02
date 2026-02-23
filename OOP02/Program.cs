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

            #region Part 02 : Execution Logic
            Cinema myCinema = new Cinema();

            Console.WriteLine("========== Ticket Booking ==========");

            // 5a. Reading data for 3 tickets
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\nEnter data for Ticket {i}:");
                Console.Write("Movie Name: ");
                string name = Console.ReadLine();

                Console.Write("Ticket Type (0=Standard, 1=VIP, 2=IMAX): ");
                TicketType type = (TicketType)int.Parse(Console.ReadLine());

                Console.Write("Seat Row (A-Z): ");
                char row = char.Parse(Console.ReadLine().ToUpper());

                Console.Write("Seat Number: ");
                int seatNum = int.Parse(Console.ReadLine());

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                myCinema.AddTicket(new Ticket(name, type, new Seat(row, seatNum), price));
            }

            // 5b. Printing all tickets using indexer
            Console.WriteLine("\n========== All Tickets ==========");
            for (int i = 0; i < 3; i++)
            {
                if (myCinema[i] != null)
                    Console.WriteLine(myCinema[i]);
            }

            // 5c. Search by movie name
            Console.WriteLine("\n========== Search by Movie ==========");
            Console.Write("Enter movie name to search: ");
            string searchName = Console.ReadLine();
            Ticket found = myCinema.GetMovieByTitle(searchName);
            if (found != null)
                Console.WriteLine($"Found: {found}");
            else
                Console.WriteLine("Movie not found.");

            // 5d. Total tickets sold
            Console.WriteLine("\n========== Statistics ==========");
            Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketsSold()}");

            // 5e. Generate booking references
            Console.WriteLine($"Booking Reference 1: {BookingHelper.GenerateBookingReference()}");
            Console.WriteLine($"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");

            // 5f. Group discount calculation
            double groupTotal = BookingHelper.CalcGroupDiscount(5, 80);
            Console.WriteLine($"Group Discount (5 tickets x 80 EGP): {groupTotal} EGP (10% off applied)");
            #endregion
             }
           }

            #region Part 02 : Classes and Structs

            public enum TicketType { Standard, VIP, IMAX }

            public struct Seat
            {
                public char Row { get; set; }
                public int Number { get; set; }
                public Seat(char row, int number) { Row = row; Number = number; }
                public override string ToString() => $"{Row}-{Number}";
            }

            public class Ticket
            {
                private string movieName;
                private double price;
                private static int ticketCounter = 0;

                public int TicketId { get; private set; }
                public TicketType Type { get; set; }
                public Seat Seat { get; set; }

                public string MovieName
                {
                    get { return movieName; }
                    set { if (!string.IsNullOrWhiteSpace(value)) movieName = value; }
                }

                public double Price
                {
                    get { return price; }
                    set { if (value > 0) price = value; }
                }

                public double PriceAfterTax => price * 1.14;

                public Ticket(string name, TicketType type, Seat seat, double price)
                {
                    ticketCounter++;
                    TicketId = ticketCounter;
                    MovieName = name;
                    Type = type;
                    Seat = seat;
                    Price = price;
                }

                public static int GetTotalTicketsSold() => ticketCounter;

                public override string ToString() =>
                    $"Ticket #{TicketId} | {MovieName} | {Type} | Seat: {Seat} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
            }

            public class Cinema
            {
                private Ticket[] tickets = new Ticket[20];

                // Indexer with range validation
                public Ticket this[int index]
                {
                    get => (index >= 0 && index < 20) ? tickets[index] : null;
                    set { if (index >= 0 && index < 20) tickets[index] = value; }
                }

                public Ticket GetMovieByTitle(string name)
                {
                    foreach (var t in tickets)
                        if (t != null && t.MovieName.Equals(name, StringComparison.OrdinalIgnoreCase)) return t;
                    return null;
                }

                public bool AddTicket(Ticket t)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (tickets[i] == null) { tickets[i] = t; return true; }
                    }
                    return false;
                }
            }

            public static class BookingHelper
            {
                private static int refCounter = 0;
                public static double CalcGroupDiscount(int count, double price) =>
                    (count >= 5) ? (count * price * 0.9) : (count * price);

                public static string GenerateBookingReference() => $"BK-{++refCounter}";
            }
            #endregion
}