using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.Without_DependencyInjection
{
    public class PaymentProcessor_WithoutDI
    {
        public void ChargeCreditCard(string creaditCardNumber, string expiryDate)
        {
            if (string.IsNullOrEmpty(creaditCardNumber))
            {
                throw new ArgumentException("Invalid creadit card number", nameof(creaditCardNumber));
            }

            if (string.IsNullOrEmpty(expiryDate))
            {
                throw new ArgumentException("Invalid creadit card number", nameof(expiryDate));
            }

            Console.WriteLine("call to credit card API");
        }
    }
}
