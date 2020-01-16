using ParkingChargeCalculator.Stays;
using System;

namespace ParkingChargeCalculator.UserInterfaces
{
    public static class StartingUserInterface
	{
        private static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do? (not sure type 'help')");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("stay"))
                StayCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void StayCommand(string command)
        {     
            BaseStay baseStay;
            try
            {
                var parts = command.Split(' ');
                
                if (parts.Length != 4)
                {
                    Console.WriteLine("Command not valid, a stay requires a stay type (short/long), a start date (dd/MM/yyyy) and an end date (dd/MM/yyyy).");
                    return;
                }
                
                var type = parts[1];
                var startDate = DateTime.Parse(parts[2]); // Code Review - Could use TryParse
                var endDate = DateTime.Parse(parts[3]);

                if (type == "long")
                    baseStay = new LongStay(startDate, endDate);
                else if (type == "short")
                    baseStay = new ShortStay(startDate, endDate);
                else
                {
                    Console.WriteLine("{0} is not a supported type of stay, please try again", type);
                    return;
                }
                Console.WriteLine("The charge for your stay is: £{0}.", baseStay.CalculateCharge());
            }
            catch (FormatException)
            {
                Console.WriteLine(); // TODO - Write useful message
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(); // TODO - Write useful message
            }
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("Novia parking accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Stay 'Type' 'Start Date' 'EndDate' - Calculates parking charge");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }
    }
}