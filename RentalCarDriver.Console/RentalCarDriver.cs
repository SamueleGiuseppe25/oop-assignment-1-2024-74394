using System;
using RentalCarLibrary.Domain;



namespace RentalCarDriver
{
    public class RentalCarDriver
    {
        public static void Main(string[] args)
        {
            // Create instances of RentalCar using different constructors
            RentalCar car1 = new RentalCar("Ford", "Mustang", "Saloon", "FOR123", 100.0, false);
            RentalCar car2 = new RentalCar("Toyota", "Corolla", "Sedan", "TOY123", 200.00);
            RentalCar car3 = new RentalCar("Honda", "CR-V", "Suv");
            RentalCar car4 = new RentalCar("Tesla", "Model-X", "Crossover", "TESLA123", 300.0, true);


            Console.WriteLine("Welcome to my Rental Car. Here we have initial details of all Rental Cars...");
            car1.DisplayInfo();
            car2.DisplayInfo();
            car3.DisplayInfo();
            car4.DisplayInfo();

            Console.WriteLine("|||||||||||||||||||||||||||||||||");//Separating the output for better readability
            Console.WriteLine("Attempt Borrowing car1...");
            car1.Borrow();
            car1.DisplayInfo();

            Console.WriteLine("Borrowing car1 again...");
            car1.Borrow();
            car1.DisplayInfo();

            Console.WriteLine("Returning car1 ");
            car1.ReturnRentalCar();
            car1.DisplayInfo();

            Console.WriteLine("Changing Price for car2 ");
            car2.ChangePrice(150.00);
            car2.DisplayInfo();

            Console.WriteLine("Borrowing car2 and then we check its status");
            car2.Borrow();
            Console.WriteLine($"is car2 borrowed? {(car2.CheckBorrowed() ? "Yes" : "No")}");
            car2.DisplayInfo();

            Console.WriteLine("Returning car3 that is not in loan ");
            car3.ReturnRentalCar();
            car3.DisplayInfo();

            Console.WriteLine("Summary for the Status of all Rental Cars:");
            car1.DisplayInfo();
            car2.DisplayInfo();
            car3.DisplayInfo();
            car4.DisplayInfo();

            Console.WriteLine("Thank you for using our Rental Car Service. Have a great day!");




        }
    }
}


 