using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Library
{
    public class DigitalProductModel : IDigitalProductModel
    {
        public string Title { get; set; }

        public bool HasOrderBeenCompleted { get; private set; }

        public int TotalDownloadLeft { get; private set; } = 5;


        public void ShipItem(CustomerModel customerModel)
        {

            if (!HasOrderBeenCompleted)
            {
                Console.WriteLine($"Simulating email {Title} to {customerModel.EmailAddress}");
                TotalDownloadLeft -= 1;

                if (TotalDownloadLeft < 1)
                {
                    HasOrderBeenCompleted = true;
                    TotalDownloadLeft = 0;
                }
            }

        }
    }
}
