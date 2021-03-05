using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.With_DependencyInjection.MicrosoftIOC
{
    public class ContainerBuilder
    {
        public IServiceProvider BuildMyContainer()
        {
            var containers = new ServiceCollection();

            containers.AddSingleton<IOrderManager_WithDI, OrderManager_WithDI>();
            containers.AddSingleton<IPaymentProcessor_WithDI, PaymentProcessor_WithDI>();
            containers.AddSingleton<IProductStockRepository_WithDI, ProductStockRepository_WithDI>();
            containers.AddSingleton<IShippingProcessor_WithDI, ShippingProcessor_WithDI>();


            return containers.BuildServiceProvider();
        }
    }
}
