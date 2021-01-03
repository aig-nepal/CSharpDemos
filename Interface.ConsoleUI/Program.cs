using Interface.Library;
using System;
using System.Collections.Generic;

namespace Interface.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IProductModel> carts = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (var cart in carts)
            {
                cart.ShipItem(customer);

                if (cart is IDigitalProductModel digitalProduct)
                {
                    Console.WriteLine($"for the {digitalProduct.Title} you have {digitalProduct.TotalDownloadLeft} download left");
                }
            }
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Sagar",
                LastName = "Gupta",
                City = "BRT",
                EmailAddress = "sagar@yes.com",
                PhoneNumber = "98020202020"
            };
        }

        private static List<IProductModel> AddSampleData()
        {
            List<IProductModel> physicalProductModels = new List<IProductModel>();
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 1" });
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 2" });
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 3" });

            physicalProductModels.Add(new DigitalProductModel { Title = "Digital Product 1" });

            physicalProductModels.Add(new CourseProductModel { Title = "Course Product 1" });


            return physicalProductModels;
        }
    }
}
