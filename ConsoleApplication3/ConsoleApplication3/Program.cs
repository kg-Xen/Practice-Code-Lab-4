/*This code was written as part of an assignment called Vehicles Sold (Arrays) given to
year one computer programming students during the first semester at Durham College.
*/


using System;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            int[] carsDay = new int[7];
            bool[] lowestDays = new bool[7];
            bool[] highestDays = new bool[7];

            double carsAverage = 0;
            int carsHighestCheck = 0;
            int carsLowestCheck = 50;
            bool goAgain = true;
            string multipleSame = null;

            do
            {
                // set variables to their default values
                Console.Clear();
                goAgain = false;

                carsDay = new int[7];
                lowestDays = new bool[7];
                highestDays = new bool[7];

                carsAverage = 0;
                carsHighestCheck = 0;
                carsLowestCheck = 50;

                // Get the values for the array
                for (int i = 0; i < 7; i++)
                {
                    // Try to get user input for each day.
                    try
                    {
                        Console.Write("Cars sold on day {0}: ", i + 1);
                        carsDay[i] = Int32.Parse(Console.ReadLine());

                        // Check to see if integer is within range 0 - 50, if not, rerun loop.
                        if (carsDay[i] > 50 || carsDay[i] < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: The amount must be between 0 and 50");
                            Console.ForegroundColor = ConsoleColor.White;
                            i--;
                        }
                    }

                    // Catch an error caused by user not typing an integer as input. Rerun loop.
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: The amount must be numeric.");
                        Console.ForegroundColor = ConsoleColor.White;
                        i--;
                    }
                }

                // Array completely filled
                //------------------------------------------------------------------------------------------------------
                // Process the array

                for (int i = 0; i < 7; i++)
                {
                    // Write the day and how many cars are sold
                    Console.Write(" D{0}:{1}", i + 1, carsDay[i]);

                    // Add the current day being processed to a running total of cars sold for calculating average later
                    carsAverage += carsDay[i];

                    // Determine if the day being processed had the highest number of cars sold compared
                    // to all previously processed days. If so, store the number of vehicles
                    if (carsDay[i] > carsHighestCheck)
                    {
                        carsHighestCheck = carsDay[i];
                    }

                    // Determine if the day being processed had the lowest number of cars sold compared
                    // to all previously processed days. If so, store the number of vehicles
                    if (carsDay[i] < carsLowestCheck)
                    {
                        carsLowestCheck = carsDay[i];
                    }
                }
                // Take the average of the running
                carsAverage = Math.Round(carsAverage / 7, 0);

                // Store all the days with equal highest cars sold in an array and
                // store all the days with equal lowest cars sold in an array where the index
                // represents the day and true represents it was found highest/lowest
                for (int i = 0; i < 7; i++)
                {
                    if (carsDay[i] == carsLowestCheck) lowestDays[i] = true;
                    if (carsDay[i] == carsHighestCheck) highestDays[i] = true;
                }

                // Array completely processed
                //------------------------------------------------------------------------------------------------------
                // Print results of processing

                // Clear the console and write all the results of processing to the console
                Console.Clear();
                Console.WriteLine("=============================================================");
                Console.WriteLine("                        VEHICLES SOLD           ");
                Console.WriteLine("-------------------------------------------------------------");
                // Prints cars sold each day on same line
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("   D{0}:{1}", i + 1, carsDay[i]);
                }
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.WriteLine("The average number of vehicles sold per day was {0} vehicles", carsAverage);

                // Print every highest day
                Console.Write("The highest number of vehicles sold was on day(s) ");
                for (int i = 0; i < 7; i++)
                {
                    if (highestDays[i] == true)
                    {
                        Console.Write("{0}{1}", multipleSame, i + 1);
                        multipleSame = ", "; // If there is more than 1 day, this is added to the next write for formatting
                    }                    
                }
                multipleSame = null;
                Console.WriteLine();

                // Print every lowest day
                Console.Write("The lowest number of vehicles sold was on day(s) ");
                for (int i = 0; i < 7; i++)
                {
                    if (lowestDays[i] == true)
                    {
                        Console.Write("{0}{1}", multipleSame, i + 1);
                        multipleSame = ", "; // If there is more than 1 day, this is added to the next write for formatting
                    }                    
                }
                multipleSame = null;

                Console.WriteLine();
                Console.WriteLine("=============================================================\n");
                Console.WriteLine("Would you like to process another week?\n\n");

                // Check if the user presses the [y] key to rerun the application
                Console.WriteLine("Please press [y] to continue or any other key to exit:");
                if (Console.ReadKey(true).Key == ConsoleKey.Y) goAgain = true;
            } while (goAgain == true);            
        }
    }
}
