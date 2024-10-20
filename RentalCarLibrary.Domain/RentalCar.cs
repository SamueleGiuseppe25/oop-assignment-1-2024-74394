using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarLibrary.Domain
{
    //Attributes/Properties
    public class RentalCar : Car, IRentable //Inheritance
    {
        
        public double Price { get; set; }
        public bool Borrowed { get; set; }


        //Constructors

        
        public RentalCar(string manufacturer, string model, string bodyType, string registrationNumber, double price, bool borrowed)
            : base(manufacturer, model, bodyType, registrationNumber)
        {        
           if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            Price = price;
            Borrowed = borrowed;
        }

        public RentalCar(string manufacturer, string model, string bodyType, string registrationNumber, double price)
            : base(manufacturer, model, bodyType, registrationNumber)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            Price = price;
            Borrowed = false;
        }
        

        public RentalCar(string manufacturer, string model, string bodyType)
            : base(manufacturer, model, bodyType,"")
        {
            if (Price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            Price = 0.0;
            Borrowed = false;
        }

        //Overriding the abstract method from the base class "Car"
        public override void DisplayInfo()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Body Type: {BodyType}");
            Console.WriteLine($"Registration Number: {RegistrationNumber}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Borrowed: {(Borrowed ? "Yes" : "No")}");
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }


        //Methods
        public void Borrow()
        {
            if (!Borrowed)
            {
                Borrowed = true;

            }
            else
            {
                Console.WriteLine("The Rental Car is already on Loan");
            }
        }

        public void ReturnRentalCar()
        {
            if (Borrowed)
            {
                Borrowed = false;
                Console.WriteLine("The car has been successfully returned.");
            }
            else
            {
                Console.WriteLine("The car was not on loan.");
            }
        }

        public void ChangePrice(double price)
        {
            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative. Change request ignored.");
                return;
            }
            Price = price;
            Console.WriteLine($"The price has been updated to {Price}");

        }

        public double CheckPrice()
        {
            return Price;
        }

        public bool CheckBorrowed()
        {
            return Borrowed;
        }


    }

    
}
