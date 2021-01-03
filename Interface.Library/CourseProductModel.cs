using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Library
{
    public class CourseProductModel : IProductModel
    {
        public string Title { get; set; }

        public bool HasOrderBeenCompleted { get; private set; }

        public void ShipItem(CustomerModel customerModel)
        {
            if (!HasOrderBeenCompleted)
            {
                Console.WriteLine($"Added the {Title} course to {customerModel.FirstName}'s account");
                HasOrderBeenCompleted = true;
            }
        }
    }
}
