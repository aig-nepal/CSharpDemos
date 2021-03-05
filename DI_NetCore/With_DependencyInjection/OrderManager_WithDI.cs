using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.With_DependencyInjection
{
    public interface IOrderManager_WithDI
    {
        void Submit(ProductEnum productEnum, string CreditCardNumber, string expiryDate);
    }

    public class OrderManager_WithDI : IOrderManager_WithDI
    {
        private readonly IProductStockRepository_WithDI _productStockRepository;
        private readonly IPaymentProcessor_WithDI _paymentProcessor;
        private readonly IShippingProcessor_WithDI _shippingProcessor;

        public OrderManager_WithDI(
            IProductStockRepository_WithDI productStockRepository,
            IPaymentProcessor_WithDI paymentProcessor,
            IShippingProcessor_WithDI shippingProcessor
            )
        {
            this._productStockRepository = productStockRepository;
            this._paymentProcessor = paymentProcessor;
            this._shippingProcessor = shippingProcessor;
        }
        public void Submit(ProductEnum productEnum, string CreditCardNumber, string expiryDate)
        {

            // Step-1 => check product stock          
            if (!_productStockRepository.IsInStock(productEnum))
            {
                throw new Exception($"{productEnum.ToString()} not in stock");
            }


            // Step-2 => payment

            _paymentProcessor.ChargeCreditCard(CreditCardNumber, expiryDate);


            //Step-3 => shiping the product

            _shippingProcessor.MailProduct(productEnum);


        }
    }
}
