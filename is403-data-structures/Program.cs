using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is403_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize queue of customers
            Queue<string> customers = new Queue<string>();

            // initialize Dictionary with keys: string and values: int
            Dictionary<string, int> customerInfo = new Dictionary<string, int>();

            // number of customers in queue
            const int NUMBER_OF_CUSTOMERS = 100;

            for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
            {
                string name = randomName();
                customers.Enqueue(name); // add 100 customers to the queue
            }

            // simulate an order for each person in the queue while keeping track of how many burgers they order
            while (customers.Count > 0) // use count over enumerator to not crash program while dequeing in loop
            {
                // check if that customer exists
                if (customerInfo.ContainsKey(customers.Peek()))
                {
                    // if that customer exists, add a random number to his tally
                    customerInfo[customers.Peek()] += randomNumberInRange();
                }
                else
                {
                    // if that customer does not exist, make a new entry in the dictionary
                    customerInfo.Add(customers.Peek(), randomNumberInRange());
                }
                customers.Dequeue(); // remove leader from queue 
            }

            // output customers and orders
            foreach (KeyValuePair<string, int> custOrder in customerInfo)
            {
                Console.WriteLine(custOrder.Key + "\t" + custOrder.Value);
            }


            // end program
            Console.ReadKey();
        }


        // given code
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
    }
}
