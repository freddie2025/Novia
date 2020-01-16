using ParkingChargeCalculator.UserInterfaces;
using System;

namespace ParkingChargeCalculator
{
    class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("#==========================#");
            Console.WriteLine("# Welcome to Novia Parking #");
            Console.WriteLine("#==========================#");

            StartingUserInterface.CommandLoop();

            Console.WriteLine("Thank you for using Novia Parking!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
	}
}
