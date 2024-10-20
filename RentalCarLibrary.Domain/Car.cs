using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarLibrary.Domain
{
    public abstract class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public string RegistrationNumber { get; set; }
       
    


    public Car(string manufacturer, string model, string bodyType, string registrationNumber)
    {
        Manufacturer = manufacturer;
        Model = model;
        BodyType = bodyType;
        RegistrationNumber = registrationNumber;
        

    }

    // This abstrcat method it is used to use common functionality that should be implemented differently by each subclass
    public abstract void DisplayInfo();

    }
}

