using DI_NetCore.With_DependencyInjection;
using DI_NetCore.With_DependencyInjection.MicrosoftIOC;
using DI_NetCore.Without_DependencyInjection;
using System;

using Microsoft.Extensions.DependencyInjection;

namespace DI_NetCore
{
    class Program
    {
        // after add library =>  Microsoft.Extensions.DependencyInjection
        public static readonly IServiceProvider container = new ContainerBuilder().BuildMyContainer();

        static void Main(string[] args)
        {
            // OrderWithout_DependencyInjection();

            // OrderWithInterFace_ManualDependancyInjection();

            OrderWithIOC_MicrosoftDI();

        }

        private static void OrderWithIOC_MicrosoftDI()
        {
            // add library =>  Microsoft.Extensions.DependencyInjection
            // add => using Microsoft.Extensions.DependencyInjection;


            var orderMgr = container.GetService<IOrderManager_WithDI>();

            var cmd = string.Empty;
            while (cmd != "exit")
            {
                Console.WriteLine(@"Enter a Product: 
Keyboard = 0, 
Mouse=1, 
Mic=2, 
Speaker=3");
                cmd = Console.ReadLine();

                try
                {
                    if (Enum.TryParse(cmd, out ProductEnum productEnum))
                    {
                        Console.WriteLine("Please enter valid craeditcard number: xxxxxxxxxxxxxxxx;MMYY");
                        var paymentNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentNumber) || !(paymentNumber.Split(";").Length == 2))
                        {
                            throw new Exception("Invalid payment method");
                        }

                        orderMgr.Submit(productEnum, paymentNumber.Split(";")[0], paymentNumber.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} order has been completed..");

                    }
                    else
                    {
                        Console.WriteLine("invalid cmd");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine);

            }
        }

        private static void OrderWithInterFace_ManualDependancyInjection()
        {
            var productStockRepository_WithDI = new ProductStockRepository_WithDI();
            var orderMgr = new OrderManager_WithDI(
                productStockRepository: productStockRepository_WithDI,
                paymentProcessor: new PaymentProcessor_WithDI(),
                shippingProcessor: new ShippingProcessor_WithDI(productStockRepository: productStockRepository_WithDI)
                );

            var cmd = string.Empty;
            while (cmd != "exit")
            {
                Console.WriteLine(@"Enter a Product: 
Keyboard = 0, 
Mouse=1, 
Mic=2, 
Speaker=3");
                cmd = Console.ReadLine();

                try
                {
                    if (Enum.TryParse(cmd, out ProductEnum productEnum))
                    {
                        Console.WriteLine("Please enter valid craeditcard number: xxxxxxxxxxxxxxxx;MMYY");
                        var paymentNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentNumber) || !(paymentNumber.Split(";").Length == 2))
                        {
                            throw new Exception("Invalid payment method");
                        }

                        orderMgr.Submit(productEnum, paymentNumber.Split(";")[0], paymentNumber.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} order has been completed..");

                    }
                    else
                    {
                        Console.WriteLine("invalid cmd");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine);

            }
        }

        private static void OrderWithout_DependencyInjection()
        {
            var cmd = string.Empty;
            var orderMgr = new OrderManager_WithoutDI();


            while (cmd != "exit")
            {
                Console.WriteLine(@"Enter a Product: 
Keyboard = 0, 
Mouse=1, 
Mic=2, 
Speaker=3");
                cmd = Console.ReadLine();

                try
                {
                    if (Enum.TryParse(cmd, out ProductEnum productEnum))
                    {
                        Console.WriteLine("Please enter valid craeditcard number: xxxxxxxxxxxxxxxx;MMYY");
                        var paymentNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentNumber) || !(paymentNumber.Split(";").Length == 2))
                        {
                            throw new Exception("Invalid payment method");
                        }

                        orderMgr.Submit(productEnum, paymentNumber.Split(";")[0], paymentNumber.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} order has been completed..");

                    }
                    else
                    {
                        Console.WriteLine("invalid cmd");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine);

            }
        }
    }
}
