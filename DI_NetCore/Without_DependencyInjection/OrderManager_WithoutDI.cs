using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.Without_DependencyInjection
{
    public class OrderManager_WithoutDI
    {
        public void Submit(ProductEnum productEnum, string CreditCardNumber, string expiryDate)
        {

            // Step-1 => check product stock
            var productStockRepositry = new ProductStockRepository_WithoutDI();
            if (!productStockRepositry.IsInStock(productEnum))
            {
                throw new Exception($"{productEnum.ToString()} not in stock");
            }


            // Step-2 => payment
            var creaditCardProcessor = new PaymentProcessor_WithoutDI();
            creaditCardProcessor.ChargeCreditCard(CreditCardNumber, expiryDate);


            //Step-3 => shiping the product
            var shippingProcessor = new ShippingProcessor_WithoutDI();
            shippingProcessor.MailProduct(productEnum);


        }
    }
}
