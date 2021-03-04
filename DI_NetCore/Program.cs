using System;

namespace DI_NetCore
{
    class Program
    {

        static void Main(string[] args)
        {

            var cmd = string.Empty;
            var orderMgr = new OrderManager();


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
