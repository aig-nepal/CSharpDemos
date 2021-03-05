using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.Without_DependencyInjection
{
    public class ShippingProcessor_WithoutDI
    {
        public void MailProduct(ProductEnum productEnum)
        {
            var productStockRepository = new ProductStockRepository_WithoutDI();
            productStockRepository.ReduceStock(productEnum);

            Console.WriteLine("call to shipping api");
        }
    }
}
