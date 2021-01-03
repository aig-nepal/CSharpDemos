using Interface.Library;
using System;
using System.Collections.Generic;

namespace Interface.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PhysicalProductModel> physicalProductModels = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (var physicalProductModel in physicalProductModels)
            {
                physicalProductModel.ShipItem(customer);
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

        private static List<PhysicalProductModel> AddSampleData()
        {
            List<PhysicalProductModel> physicalProductModels = new List<PhysicalProductModel>();
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 1" });
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 2" });
            physicalProductModels.Add(new PhysicalProductModel { Title = "Product 3" });

            return physicalProductModels;
        }
    }
}
