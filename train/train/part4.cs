using System;
using System.Collections.Generic;

namespace Train
{
    public class part4 : Part2
    {
        public int firstClassSeatCount;
        public int secondClassSeatCount;
        public int thirdClassSeatCount;
        public int travelDistance;
        private List<string> referenceNumbers = new List<string>();

        public void SetSeatCounts(int first, int second, int third, int distance)
        {
            firstClassSeatCount = first;
            secondClassSeatCount = second;
            thirdClassSeatCount = third;
            travelDistance = distance;
        }

        public void Part4_Main()
        {
            Console.WriteLine("\n=== Welcome to the Passenger Information System ===");

            Console.Write("Please select your status (Local [L] or Foreign [F]): ");
            string choice = Console.ReadLine().Trim().ToUpper();

            string idOrPassport = "";
            string passengerType = "";

            if (choice == "L")
            {
                passengerType = "Local";
                Console.Write("Enter your ID Number: ");
                idOrPassport = Console.ReadLine();
            }
            else if (choice == "F")
            {
                passengerType = "Foreign";
                Console.Write("Enter your Passport Number: ");
                idOrPassport = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'L' for Local or 'F' for Foreign.");
                Part4_Main();
                return;
            }

            Console.Write("Enter your full name: ");
            string name = Console.ReadLine();

            // Generate multiple reference numbers (one per ticket)
            Random random = new Random();
            int totalTickets = firstClassSeatCount + secondClassSeatCount + thirdClassSeatCount;
            for (int i = 0; i < totalTickets; i++)
            {
                string refNum = "TRN" + random.Next(1000,9999);
                referenceNumbers.Add(refNum);
            }

            Console.WriteLine("\n=== Passenger Information ===");
            Console.WriteLine($"{(passengerType == "Local" ? "ID Number" : "Passport Number")}: {idOrPassport}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Passenger Type: {passengerType}");

            // Calculate Ticket Prices
            int firstClassPrice = travelDistance * 5;
            int secondClassPrice = travelDistance * 4;
            int thirdClassPrice = travelDistance * 3;

            int totalFirstClassPrice = firstClassPrice * firstClassSeatCount;
            int totalSecondClassPrice = secondClassPrice * secondClassSeatCount;
            int totalThirdClassPrice = thirdClassPrice * thirdClassSeatCount;
            int totalTicketPrice = totalFirstClassPrice + totalSecondClassPrice + totalThirdClassPrice;

            Console.WriteLine("\n=== Ticket Prices ===");
            Console.WriteLine($"Your first class tickets price: Rs.{totalFirstClassPrice}");
            Console.WriteLine($"Your second class tickets price: Rs.{totalSecondClassPrice}");
            Console.WriteLine($"Your third class tickets price: Rs.{totalThirdClassPrice}");
            Console.WriteLine($"Your total tickets price: Rs.{totalTicketPrice}");
            
            // Sort ticket prices before displaying
            int[] ticketPrices = { totalFirstClassPrice, totalSecondClassPrice, totalThirdClassPrice };
            SortingMethods.BubbleSort(ticketPrices);

            //bubblesort
            Console.WriteLine("\n=== Sorted Ticket Prices (Ascending) ===");
            Console.WriteLine($"1: Rs.{ticketPrices[0]}");
            Console.WriteLine($"2: Rs.{ticketPrices[1]}");
            Console.WriteLine($"3: Rs.{ticketPrices[2]}");
            Console.WriteLine($"Total: Rs.{totalTicketPrice}");
            string[] refArray = referenceNumbers.ToArray();
            

            Console.WriteLine("\n=== Sorted Reference Numbers (Bubble Sort) ===");
            foreach (var refNum in refArray)
            {
                Console.WriteLine($"Reference Number: {refNum}");
            }


                //merge sort
                /* Convert list to array and sort
                string[] refArray = referenceNumbers.ToArray();
                SortingMethods.MergeSort(refArray, 0, refArray.Length - 1);

                Console.WriteLine("\n=== Sorted Reference Numbers ===");
                foreach (var refNum in refArray)
                {
                    Console.WriteLine($"Reference Number: {refNum}");
                }*/


                //quick sort
                /*
                int[] ticketCounts = { firstClassSeatCount, secondClassSeatCount, thirdClassSeatCount };
                SortingMethods.QuickSort(ticketCounts, 0, ticketCounts.Length - 1);

                Console.WriteLine("\n=== Sorted Ticket Counts ===");
                Console.WriteLine($"Lowest to Highest: {string.Join(", ", ticketCounts)}");



                Console.WriteLine("\n=== Your Ticket Reference Numbers ===");
                foreach (var refNum in referenceNumbers)
                {
                    Console.WriteLine($"Reference Number: {refNum}");
                }
                */


            Console.WriteLine("\nThank you for choosing Sri Lanka Railway.");
            Console.WriteLine("Press 1 to return to the Main Menu...");
            Console.WriteLine("Press 0 to exit...");

            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Main_menu();
            }
        }
    }
}
