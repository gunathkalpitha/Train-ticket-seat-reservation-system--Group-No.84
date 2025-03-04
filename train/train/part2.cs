using System;
using System.Collections.Generic;

namespace Train
{
    public class Part2 : part_1
    {
        public void SetDistance(int d)
        {
            distance = d;
        }

        public void Part2_Main()
        {
            Console.WriteLine();
            Console.WriteLine("_____Welcome to the Seat Reservation system!_____");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Book Seats");
                Console.WriteLine("2 - Cancel Seats");
                Console.WriteLine("3 - Confirm Booking and Proceed");
                Console.WriteLine("4 - Exit");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            BookSeatsMenu();
                            break;
                        case 2:
                            CancelSeatsMenu();
                            break;
                        case 3:
                            ConfirmBooking();
                            break;
                        case 4:
                            Console.WriteLine("Exiting the system. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void BookSeatsMenu()
        {
            int classChoice = GetClassChoice();
            if (classChoice == 0)
            {
                return;
            }

            DisplayAvailableSeats(classChoice);

            int seatCount = GetSeatCount();
            if (seatCount == 0)
            {
                Console.WriteLine("Booking cancelled.");
                return;
            }

            List<int> selectedClassSeats = GetClassSeats(classChoice);
            if (selectedClassSeats == null)
            {
                Console.WriteLine("Unexpected error occurred. Please try again.");
                return;
            }

            if (!BookSeats(selectedClassSeats, seatCount))
            {
                Console.WriteLine("Sorry, not enough seats are available in this class.");
            }
        }

        private void CancelSeatsMenu()
        {
            int classChoice = GetClassChoice();
            if (classChoice == 0)
            {
                return;
            }

            List<int> selectedClassSeats = GetClassSeats(classChoice);
            if (selectedClassSeats == null || selectedClassSeats.Count == 0)
            {
                Console.WriteLine("No seats are booked in this class.");
                return;
            }

            Console.WriteLine($"Booked seats in {(classChoice == 1 ? "First" : classChoice == 2 ? "Second" : "Third")} Class: " + string.Join(", ", selectedClassSeats));
            Console.WriteLine("Enter the seat numbers to cancel (separated by commas):");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No seats selected for cancellation.");
                return;
            }

            List<int> seatsToCancel = new List<int>();
            foreach (string seat in input.Split(','))
            {
                if (int.TryParse(seat.Trim(), out int seatNumber) && selectedClassSeats.Contains(seatNumber))
                {
                    seatsToCancel.Add(seatNumber);
                }
                else
                {
                    Console.WriteLine($"Invalid seat number: {seat}");
                }
            }

            if (seatsToCancel.Count > 0)
            {
                CancelSeats(selectedClassSeats, seatsToCancel);
                Console.WriteLine("Cancellation successful! Cancelled seats: " + string.Join(", ", seatsToCancel));
            }
            else
            {
                Console.WriteLine("No valid seats were selected for cancellation.");
            }
        }

        private void ConfirmBooking()
        {
            if (firstClassSeats.Count == 0 && secondClassSeats.Count == 0 && thirdClassSeats.Count == 0)
            {
                Console.WriteLine("\nNo seats booked! Please book at least one seat before proceeding.");
                return;
            }

            // Proceed to passenger info
            part4 passengerInfo = new part4();
            passengerInfo.SetSeatCounts(firstClassSeats.Count, secondClassSeats.Count, thirdClassSeats.Count, distance);
            passengerInfo.Part4_Main();
        }

        public static List<int> firstClassSeats = new List<int>();
        public static List<int> secondClassSeats = new List<int>();
        public static List<int> thirdClassSeats = new List<int>();

        private const int TOTAL_SEATS_PER_CLASS = 50;

        public static int GetAvailableSeats(int classType)
        {
            return classType switch
            {
                1 => TOTAL_SEATS_PER_CLASS - firstClassSeats.Count,
                2 => TOTAL_SEATS_PER_CLASS - secondClassSeats.Count,
                3 => TOTAL_SEATS_PER_CLASS - thirdClassSeats.Count,
                _ => 0
            };
        }

        private static int GetClassChoice()
        {
            while (true)
            {
                Console.WriteLine("\nWhat class do you want to book or cancel seats for?");
                Console.WriteLine("1 - First Class");
                Console.WriteLine("2 - Second Class");
                Console.WriteLine("3 - Third Class");
                Console.WriteLine("0 - Back to Main Menu");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= 3)
                {
                    return choice;
                }
                Console.WriteLine("Invalid input. Please enter 0, 1, 2, or 3.");
            }
        }

        private static int GetSeatCount()
        {
            while (true)
            {
                Console.WriteLine("How many seats would you like to book? (Enter 0 to cancel):");
                if (int.TryParse(Console.ReadLine(), out int count) && count >= 0)
                {
                    return count;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private static List<int> GetClassSeats(int classChoice) => classChoice switch
        {
            1 => firstClassSeats,
            2 => secondClassSeats,
            3 => thirdClassSeats,
            _ => null,
        };

        private static bool BookSeats(List<int> classSeats, int seatCount)
        {
            if (seatCount > (TOTAL_SEATS_PER_CLASS - classSeats.Count))
            {
                return false;
            }

            List<int> seatsToBook = new List<int>();
            for (int i = 1; i <= TOTAL_SEATS_PER_CLASS; i++)
            {
                if (!classSeats.Contains(i))
                {
                    seatsToBook.Add(i);
                    if (seatsToBook.Count == seatCount)
                    {
                        break;
                    }
                }
            }
            classSeats.AddRange(seatsToBook);
            Console.WriteLine("Booking successful! Your booked seat numbers: " + string.Join(", ", seatsToBook));
            return true;
        }

        private static void CancelSeats(List<int> classSeats, List<int> seatsToCancel)
        {
            classSeats.RemoveAll(seat => seatsToCancel.Contains(seat));
        }

        private static void DisplayAvailableSeats(int classChoice)
        {
            int availableSeats = classChoice switch
            {
                1 => TOTAL_SEATS_PER_CLASS - firstClassSeats.Count,
                2 => TOTAL_SEATS_PER_CLASS - secondClassSeats.Count,
                3 => TOTAL_SEATS_PER_CLASS - thirdClassSeats.Count,
                _ => 0
            };

            Console.WriteLine($"\nAvailable seats in {(classChoice == 1 ? "First" : classChoice == 2 ? "Second" : "Third")} Class: {availableSeats}");
        }
    }
}