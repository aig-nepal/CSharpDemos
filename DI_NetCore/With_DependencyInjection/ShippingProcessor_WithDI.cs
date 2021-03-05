using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.With_DependencyInjection
{
    public interface IShippingProcessor_WithDI
    {
        void MailProduct(ProductEnum productEnum);
    }

    public class ShippingProcessor_WithDI : IShippingProcessor_WithDI
    {
        private readonly IProductStockRepository_WithDI _productStockRepository;

        public ShippingProcessor_WithDI(IProductStockRepository_WithDI productStockRepository)
        {
            this._productStockRepository = productStockRepository;
        }


        public void MailProduct(ProductEnum productEnum)
        {

            _productStockRepository.ReduceStock(productEnum);

            Console.WriteLine("call to shipping api");
        }
    }
}
