using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore
{
    public class ShippingProcessor
    {
        public void MailProduct(ProductEnum productEnum)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.ReduceStock(productEnum);

            Console.WriteLine("call to shipping api");
        }
    }
}
