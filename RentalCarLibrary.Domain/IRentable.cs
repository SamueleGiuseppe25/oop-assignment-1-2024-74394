using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarLibrary.Domain
{
    public interface IRentable
    {
        void Borrow();
        void ReturnRentalCar();
        bool CheckBorrowed();
    }
}
