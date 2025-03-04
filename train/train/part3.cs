using System;
using System.Collections.Generic;

namespace Train
{
 

    public class part3 : part_1
    {
        public void SetDistance(int d)
        {
            distance = d;
        }
        public void Part3_Main()
        {
            Console.WriteLine();
            Console.WriteLine("_____Welcome to the Ticket Reservation System!_____");

            int totalFirstClassTickets = 0;
            int totalSecondClassTickets = 0;
            int totalThirdClassTickets = 0;

            while (true)
            {
                int classChoice = GetClassChoice();
                if (classChoice == 0)
                {
                    if (totalFirstClassTickets == 0 && totalSecondClassTickets == 0 && totalThirdClassTickets == 0)
                    {
                        Console.WriteLine("\nNo tickets booked! Please book at least one ticket before proceeding.");
                        continue;
                    }

                    // Proceed to passenger info
                    part4 passengerInfo = new part4();
                    passengerInfo.SetSeatCounts(totalFirstClassTickets, totalSecondClassTickets, totalThirdClassTickets, distance);
                    passengerInfo.Part4_Main();
                    break;
                }

                DisplayAvailableTickets(classChoice);

                int ticketCount = GetTicketCount();
                if (ticketCount == 0)
                {
                    Console.WriteLine("Booking cancelled.");
                    continue;
                }

                if (classChoice == 1) totalFirstClassTickets += ticketCount;
                else if (classChoice == 2) totalSecondClassTickets += ticketCount;
                else if (classChoice == 3) totalThirdClassTickets += ticketCount;

                Console.WriteLine($"Successfully booked {ticketCount} ticket(s) in {(classChoice == 1 ? "First" : classChoice == 2 ? "Second" : "Third")} Class.");
            }

      
            if (distance <= 0)
            {
                Console.WriteLine("Error: Travel distance is not set. Ticket prices cannot be calculated.");
                return;
            }

            // Calculate ticket prices
            int firstClassPrice = distance * 5 * totalFirstClassTickets;
            int secondClassPrice = distance * 4 * totalSecondClassTickets;
            int thirdClassPrice = distance * 3 * totalThirdClassTickets;
            int totalPrice = firstClassPrice + secondClassPrice + thirdClassPrice;

            Console.WriteLine("\n=== Ticket Price Summary ===");
            Console.WriteLine($"First Class Tickets: {totalFirstClassTickets} | Price: Rs.{firstClassPrice}");
            Console.WriteLine($"Second Class Tickets: {totalSecondClassTickets} | Price: Rs.{secondClassPrice}");
            Console.WriteLine($"Third Class Tickets: {totalThirdClassTickets} | Price: Rs.{thirdClassPrice}");
            Console.WriteLine($"Total Price: Rs.{totalPrice}");
        }

        private static int GetClassChoice()
        {
            while (true)
            {
                Console.WriteLine("\nWhich class ticket do you want to book?");
                Console.WriteLine("1 - First Class");
                Console.WriteLine("2 - Second Class");
                Console.WriteLine("3 - Third Class");
                Console.WriteLine("0 - Confirm booking");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= 3)
                {
                    return choice;
                }
                Console.WriteLine("Invalid input. Please enter 0, 1, 2, or 3.");
            }
        }

        private static int GetTicketCount()
        {
            while (true)
            {
                Console.WriteLine("How many tickets would you like to book? (Enter 0 to confirm the booking):");
                if (int.TryParse(Console.ReadLine(), out int count) && count >= 0)
                {
                    return count;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private static void DisplayAvailableTickets(int classChoice)
        {
            Console.WriteLine($"\nTickets available for {(classChoice == 1 ? "First" : classChoice == 2 ? "Second" : "Third")} Class.");
        }
    }
}
