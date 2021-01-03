using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Library
{
    public class PhysicalProductModel
    {
        public string Title { get; set; }
        public bool HasOrderBeenCompleted { get; private set; }

        public void ShipItem (CustomerModel customerModel)
        {
            if (!HasOrderBeenCompleted)
            {
                Console.WriteLine($"Simulating shipping {Title} to {customerModel.FirstName} in {customerModel.City}");
                HasOrderBeenCompleted = true;
            }
        }
    }
}
