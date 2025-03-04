using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Train
{
    public class part_1
    {
        public int start_number;
        public int end_number;
        public int date;
        public int month;
        private int selectedDate;
        private int Mainchoice;
        protected int distance; 
        private int trainNumber;



        public void Main_menu()
        {
            Console.WriteLine("_____Hello welcome to SLRD_____");
            Console.WriteLine();
            Console.WriteLine("1.Train shedule");
            Console.WriteLine("2.Ticket Reservation");
            Console.WriteLine("3.Seat Booking");
            Console.WriteLine("4.Check the special train availability");
            Console.WriteLine("5.Exit");
            Console.WriteLine();

            Console.WriteLine(" Enter your choice: ");

            Mainchoice = Convert.ToInt32(Console.ReadLine());

            switch (Mainchoice)
            {
                case 1:
                    show_schedule();

                    break;

                case 2:
                    {
                        Console.WriteLine("____Ticket Reservation____");
                        get_journey();
                    }

                    break;

                case 3:
                    {
                        Console.WriteLine("____Seat booking____");
                        get_journey();
                    }
                    break;

                case 4: special_tarin();
                    break;

                case 5:;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        Main_menu();
                    }

                    break;



            }
        }

        public void show_schedule()
        {
           
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("        WEEKLY TRAIN SCHEDULE          ");
                Console.WriteLine("=======================================");

                Console.WriteLine("\nMonday - Friday:");
                Console.WriteLine("1. Train 1 (Express - Beliatta to Maradana)");
                Console.WriteLine("   - Starting at Beliatta: 4:15 AM");
                Console.WriteLine("   - Arrival at Maradana: 8:30 AM");

                Console.WriteLine("\n2. Train 2 (Slow - Beliatta to Matara)");
                Console.WriteLine("   - Starting at Beliatta: 7:20 AM");
                Console.WriteLine("   - Arrival at Matara: 8:00 AM");

                Console.WriteLine("\n3. Train 3 (Express - Maradana to Beliatta)");
                Console.WriteLine("   - Starting at Maradana: 9:20 AM");
                Console.WriteLine("   - Arrival at Beliatta: 2:30 PM");

                Console.WriteLine("\n4. Train 4 (Slow - Matara to Beliatta)");
                Console.WriteLine("   - Starting at Matara: 10:20 AM");
                Console.WriteLine("   - Arrival at Beliatta: 10:55 AM");

                Console.WriteLine("\nSaturday & Sunday: No trains available!");
            }






            //normal time schedule (weekly)

            Console.WriteLine();
            Console.WriteLine("1.Ticket Reservation");
            Console.WriteLine("2.Seat Booking");
            Console.WriteLine("3.Check the special train availability");
            Console.WriteLine("4.Back to Main menu");
            Console.WriteLine("5.Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());

            switch (choice1)
            {
                case 1:
                    get_journey();
                    break;

                case 2:
                    get_journey();
                    break;

                case 3:
                    special_tarin();
                    break;
                case 4:
                    Main_menu();
                    break;
                case 5:
                    ;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        show_schedule();
                    }

                    break;


            }


        }
        public void special_tarin()
        {
            Console.WriteLine("No special trains in this week!");

            Console.WriteLine();
            Console.WriteLine("1.Back to Main menu");
            Console.WriteLine("2.Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());

            switch (choice2)
            {
                case 1:
                    Main_menu();
                    break;
                case 2:
                    ;
                    break;
                default:
                    {
                        Console.WriteLine("Invalid number...! Try again");


                        special_tarin();
                    }

                    break;


            }

        }



        public void get_journey()
        {

            Console.WriteLine();
            Console.WriteLine("Chooes your journey");
            Console.WriteLine();

            Console.WriteLine("1.Banbaranda\r\n2.Beliatta\r\n3.Kekanadura\r\n4.Matara\r\n5.Nakulugamuwa\r\n6.Piladuwa\r" +
                "\n7.Wawrukannala\r\n8.Weherahena");

            Console.WriteLine();
            Console.WriteLine("Enter the number starting station:");
            start_number = Convert.ToInt32(Console.ReadLine());//get the starting station of the journey 

            Console.WriteLine();
            Console.WriteLine("Enter the number Ending station:");
            end_number = Convert.ToInt32(Console.ReadLine());//get the endinging station of the journey



            if (start_number == end_number)
            {
                Console.WriteLine("Invalid destination..! Please re-enter your stations");
                get_journey();
            }
            check_correction();

        }



        public void check_correction()
        {

            // Creating train routes using our custom linked list
            CustomLinkedList train_1 = new CustomLinkedList();//upgoing trains(Express)
            train_1.Insert(1);
            train_1.Insert(2);
            train_1.Insert(3);
            train_1.Insert(4);
            train_1.Insert(7);
            train_1.Insert(8);


            CustomLinkedList train_2 = new CustomLinkedList();//upgoing train(slow)
            train_2.Insert(1);
            train_2.Insert(2);
            train_2.Insert(3);
            train_2.Insert(4);
            train_2.Insert(5);
            train_2.Insert(6);
            train_2.Insert(7);
            train_2.Insert(8);

            CustomLinkedList train_3 = new CustomLinkedList(); // Downgoing Train
            train_3.Insert(8);
            train_3.Insert(7);
            train_3.Insert(6);
            train_3.Insert(5);
            train_3.Insert(4);
            train_3.Insert(3);
            train_3.Insert(2);
            train_3.Insert(1);

            CustomLinkedList train_4 = new CustomLinkedList(); // Downgoing Train (slow)
            train_4.Insert(8);
            train_4.Insert(7);
            train_4.Insert(4);
            train_4.Insert(3);
            train_4.Insert(2);
            train_4.Insert(1);

            bool istrain1Available = train_1.Contains(start_number) && train_1.Contains(end_number);
            bool istrain2Available = train_2.Contains(start_number) && train_2.Contains(end_number);
            if (istrain1Available || istrain2Available)
            {
                get_date();
            }

            else
            {
                Console.WriteLine("Invalid station...! Try again....");
                get_journey();

            }

        }

        // get the date
        public void get_date()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("__ Select Your Journey Date __");
            Console.WriteLine();

            // Display today and the next 3 days
            for (int i = 0; i < 3; i++)
            {
                DateTime nextDay = today.AddDays(i);
                string dayOfWeek = nextDay.DayOfWeek.ToString();
                Console.WriteLine($"Day {i + 1}: {nextDay.ToShortDateString()} ({dayOfWeek})");
            }

            Console.WriteLine();
            Console.WriteLine("Select a date (1 for today, 2 or 3):");

            bool isValid = int.TryParse(Console.ReadLine(), out selectedDate); 

            if (isValid && (selectedDate >= 1 && selectedDate <= 3))
            {
                Console.WriteLine($"You selected Day {selectedDate}.");
                check_availbleTrain(); 
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");
                get_date();  
            }
        }






        public void check_availbleTrain()
        {
            DateTime today = DateTime.Now;
            DateTime selectedDay = today.AddDays(selectedDate - 1);  
            string dayName = selectedDay.DayOfWeek.ToString();

            Console.WriteLine($"Day {selectedDate}: {selectedDay.ToShortDateString()} ({dayName})");

            // Check if it's a weekend
            bool isWeekend = (selectedDay.DayOfWeek == DayOfWeek.Saturday || selectedDay.DayOfWeek == DayOfWeek.Sunday);

            if (isWeekend)
            {
                Console.WriteLine("No trains available on weekends!");
                return;
            }

          

            // Creating train routes using our custom linked list
            CustomLinkedList train_1 = new CustomLinkedList();
            train_1.Insert(1);
            train_1.Insert(2);
            train_1.Insert(3);
            train_1.Insert(4);
            train_1.Insert(7);
            train_1.Insert(8);

            CustomLinkedList train_2 = new CustomLinkedList();
            train_2.Insert(1);
            train_2.Insert(2);
            train_2.Insert(3);
            train_2.Insert(4);
            train_2.Insert(5);
            train_2.Insert(6);
            train_2.Insert(7);
            train_2.Insert(8);

            CustomLinkedList train_3 = new CustomLinkedList(); // Downgoing Train
            train_3.Insert(8);
            train_3.Insert(7);
            train_3.Insert(6);
            train_3.Insert(5);
            train_3.Insert(4);
            train_3.Insert(3);
            train_3.Insert(2);
            train_3.Insert(1);

            CustomLinkedList train_4 = new CustomLinkedList(); // Downgoing Train (slow)
            train_4.Insert(8);
            train_4.Insert(7);
            train_4.Insert(4);
            train_4.Insert(3);
            train_4.Insert(2);
            train_4.Insert(1);

            if (start_number == 0 || end_number == 0)
            {
                Console.WriteLine("Error: Start or End station not selected!");
                return;
            }

            bool isUpgoing = start_number < end_number;
            bool isTrain1Available = isUpgoing && train_1.Contains(start_number) && train_1.Contains(end_number);
            bool isTrain2Available = isUpgoing && train_2.Contains(start_number) && train_2.Contains(end_number);
            bool isTrain3Available = !isUpgoing && train_3.Contains(start_number) && train_3.Contains(end_number);
            bool isTrain4Available = !isUpgoing && train_4.Contains(start_number) && train_4.Contains(end_number);

            TrainSchedule trainSchedule = new TrainSchedule();

            // Sort the trains before displaying(use merge sort.)
            trainSchedule.MergeSortTrains();

            //Executional Time Analysis
            Console.WriteLine();
            Console.WriteLine("___Executional Time Analysis___");
            Console.WriteLine();

            TrainSchedule bubbleSortSchedule = new TrainSchedule();
            Stopwatch stopwatchBubble = Stopwatch.StartNew();
            bubbleSortSchedule.BubbleSort();
            stopwatchBubble.Stop();
            Console.WriteLine($"Bubble Sort Time: {stopwatchBubble.Elapsed.TotalMilliseconds} ms");

            TrainSchedule mergeSortSchedule = new TrainSchedule();
            Stopwatch stopwatchMerge = Stopwatch.StartNew();
            mergeSortSchedule.MergeSortTrains();
            stopwatchMerge.Stop();
            Console.WriteLine($"Merge Sort Time: {stopwatchMerge.Elapsed.TotalMilliseconds} ms");

            TrainSchedule quickSortSchedule = new TrainSchedule();
            Stopwatch stopwatchQuick = Stopwatch.StartNew();
            quickSortSchedule.QuickSortTrains(0, quickSortSchedule.Trains.Count - 1);
            stopwatchQuick.Stop();
            Console.WriteLine($"Quick Sort Time: {stopwatchQuick.Elapsed.TotalMilliseconds} ms");







            bool trainDisplayed = false;

            // Check and display available upgoing trains
            if (isTrain1Available || isTrain2Available)
            {
                Console.WriteLine("\nAvailable Upgoing Trains:");
                foreach (var train in trainSchedule.Trains)
                {
                    if ((isTrain1Available && train.Name == "Train 1" && train.StartLocation == "Beliatta") ||
                        (isTrain2Available && train.Name == "Train 2" && train.StartLocation == "Beliatta"))
                    {
                        Console.WriteLine($"- {train.Name} ({train.Type}): {train.StartLocation} to {train.EndLocation} at {train.StartTime}");
                        trainDisplayed = true;
                    }
                }
            }

            // Check and display available downgoing trains
            if (isTrain3Available || isTrain4Available)
            {
                Console.WriteLine("\nAvailable Downgoing Trains:");
                foreach (var train in trainSchedule.Trains)
                {
                    if ((isTrain3Available && train.Name == "Train 3" && train.StartLocation == "Maradana") ||
                        (isTrain4Available && train.Name == "Train 4" && train.StartLocation == "Maradana"))
                    {
                        Console.WriteLine($"- {train.Name} ({train.Type}): {train.StartLocation} to {train.EndLocation} at {train.StartTime}");
                        trainDisplayed = true;
                    }
                }
            }

            // Call select_train() only once after displaying available trains
            if (trainDisplayed)
            {
                select_train();

            }
            else
            {
                Console.WriteLine("No available trains for the selected route.");
            }
        }




        public void select_train()
        {

            Console.WriteLine();
            Console.WriteLine("Choose your train number:");
            trainNumber = Convert.ToInt32(Console.ReadLine());


            switch (trainNumber)
            {
                case 1:
                    {
                        Console.WriteLine();
                        Console.WriteLine("___1. Train 1 (Express-Beliatta to Maradana)___");
                        Console.WriteLine();
                        Console.WriteLine("starting at Beliatta: 4.15 am-----arrivale to Maradana: 8.30 am");
                        Console.WriteLine("Delay time:0 ");
                        Console.WriteLine();

                        Console.WriteLine("\n_____Seat Availability_____");
                        Console.WriteLine($"No. of 1st class seats: {Part2.GetAvailableSeats(1)}");
                        Console.WriteLine($"No. of 2nd class seats: {Part2.GetAvailableSeats(2)}");
                        Console.WriteLine($"No. of 3rd class seats: {Part2.GetAvailableSeats(3)}");




                    }
                    break;

                case 2:
                    {
                        Console.WriteLine();
                        Console.WriteLine("___2. Train 2 (Slow-Beliatta to Matara)___");
                        Console.WriteLine();
                        Console.WriteLine("starting at Beliatta: 7.20 am-----arrivale to Matara: 8.00 am ");
                        Console.WriteLine("Delay time:10min");
                        Console.WriteLine();
                        Console.WriteLine("\n_____Seat Availability_____");
                        Console.WriteLine($"No. of 1st class seats: {Part2.GetAvailableSeats(1)}");
                        Console.WriteLine($"No. of 2nd class seats: {Part2.GetAvailableSeats(2)}");
                        Console.WriteLine($"No. of 3rd class seats: {Part2.GetAvailableSeats(3)}");

                    }
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("___3. Train 3 (Express-Maradana to Beliatta)___");
                    Console.WriteLine();
                    Console.WriteLine("Starting at Maradana: 9.20 am ----- Arrival at Beliatta: 2.30 pm");
                    Console.WriteLine("Delay time: 0");
                    Console.WriteLine();
                    Console.WriteLine("\n_____Seat Availability_____");
                    Console.WriteLine($"No. of 1st class seats: {Part2.GetAvailableSeats(1)}");
                    Console.WriteLine($"No. of 2nd class seats: {Part2.GetAvailableSeats(2)}");
                    Console.WriteLine($"No. of 3rd class seats: {Part2.GetAvailableSeats(3)}");
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("___4. Train 4 (Slow-Matara to Beliatta)___");
                    Console.WriteLine();
                    Console.WriteLine("Starting at Matara: 10.20 am ----- Arrival at Beliatta: 10.55 am");
                    Console.WriteLine("Delay time: 0");
                    Console.WriteLine();
                    Console.WriteLine("\n_____Seat Availability_____");
                    Console.WriteLine($"No. of 1st class seats: {Part2.GetAvailableSeats(1)}");
                    Console.WriteLine($"No. of 2nd class seats: {Part2.GetAvailableSeats(2)}");
                    Console.WriteLine($"No. of 3rd class seats: {Part2.GetAvailableSeats(3)}");
                    break;

            }
            get_distance();

        }

        //get  distance between the stations
        public void get_distance()
        {
            StationLinkedList Ds = new StationLinkedList();

            // Insert distances into the linked list
            int[] distances = { 8, 0, 10, 16, 3, 14, 5, 12 };
            foreach (int d in distances)
            {
                Ds.Insert(d);
            }

            // Validate station numbers before accessing the list
            if (start_number < 1 || start_number > distances.Length || end_number < 1 || end_number > distances.Length)
            {
                Console.WriteLine("Invalid station number!");
                return;
            }

            int startDistance = Ds.get_distance(start_number - 1);
            int endDistance = Ds.get_distance(end_number - 1);

            if (startDistance == -1 || endDistance == -1)
            {
                Console.WriteLine("Invalid station number!");
                return;
            }

            int calculatedDistance;
            if (start_number == 2 && end_number != 2)
            {
                calculatedDistance = startDistance + endDistance;
            }
            else
            {
                calculatedDistance = Math.Abs(endDistance - startDistance);
            }

            // Store the distance in the class variable
            this.distance = calculatedDistance;
            Console.WriteLine($" Your travel distance: {distance} km.");

            arrival_time();
        }




        //get the arrival time to choosen stations

        public void arrival_time()
        {
            TimeLinkedList A1_time = new TimeLinkedList();
            TimeLinkedList S1_time = new TimeLinkedList();
            TimeLinkedList station_name = new TimeLinkedList();

            // Insert Arrival & Start Times
            string[] arrivalTimes = {
        "0.0", "4.15", "4.30", "5.00", "4.40", "4.50", "5.00", "5.05", "5.10",  // Train 1
        "0.0", "7.20", "7.30", "7.35", "7.45", "7.55", "8.00", "8.05", "8.10",  // Train 2
        "0.0", "13.00", "13.10", "13.15", "13.45", "13.50", "14.20", "14.25", "14.30",  // Train 3
        "0.0", "10.20", "10.25", "10.35", "10.35", "10.40", "10.45", "10.50", "10.55"   // Train 4
    };

            string[] stationNames = { "0", "Banbaranda", "Beliatta", "Kekanadura", "Matara", "Nakulugamuwa", "Piladuwa", "Wawrukannala", "Weherahena" };

            foreach (string name in stationNames) { station_name.Insert(name); }

            // Determine the starting index based on selected train number
            int trainOffset = (trainNumber - 1) * 9; 
            string[] trainTimes = new string[9];

            for (int i = 0; i < 9; i++)
            {
                trainTimes[i] = arrivalTimes[trainOffset + i];
            }


            for (int i = 0; i < 9; i++)
            {
                A1_time.Insert(trainTimes[i]);
                S1_time.Insert(trainTimes[i]);
            }

            if (start_number < 1 || start_number > 9 || end_number < 1 || end_number > 9)
            {
                Console.WriteLine("Invalid station number!");
                return;
            }

            // Retrieve the correct arrival times based on train offset
            string s1 = S1_time.GetTime(start_number - 1);
            string a1 = A1_time.GetTime(end_number - 1);
            string startStation = station_name.GetTime(start_number);
            string endStation = station_name.GetTime(end_number);

            Console.WriteLine($" Starting at {startStation}: {s1} am ---- Arrival at {endStation}: {a1} am");


            // Move to Part2_Main() after arrival time
            switch (Mainchoice)
            {
                case 3:
                    {
                        Part2 seatReservation = new Part2();
                        seatReservation.SetDistance(distance);
                        seatReservation.Part2_Main();
                        Console.WriteLine();
                    }
                    break;

                case 2:
                    {
                        part3 ticketReservation = new part3();
                        ticketReservation.SetDistance(distance);
                        ticketReservation.Part3_Main();
                        Console.WriteLine();
                    }
                    break;

                default:
                    Console.WriteLine("No further action defined for this option.");
                    break;

            }

        }

    }
}
