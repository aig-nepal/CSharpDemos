using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore
{
    public class OrderManager
    {
        public void Submit(ProductEnum productEnum, string CreditCardNumber, string expiryDate)
        {

            // Step-1 => check product stock
            var productStockRepositry = new ProductStockRepository();
            if (!productStockRepositry.IsInStock(productEnum))
            {
                throw new Exception($"{productEnum.ToString()} not in stock");
            }


            // Step-2 => payment
            var creaditCardProcessor = new PaymentProcessor();
            creaditCardProcessor.ChargeCreditCard(CreditCardNumber, expiryDate);


            //Step-3 => shiping the product
            var shippingProcessor = new ShippingProcessor();
            shippingProcessor.MailProduct(productEnum);


        }
    }
}
