using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_NetCore.Without_DependencyInjection
{
    public class ProductStockRepository_WithoutDI
    {
        private static Dictionary<ProductEnum, int> _productStockDatabase = Setup();

       
        private static Dictionary<ProductEnum, int> Setup()
        {

            var productStockDatabase = new Dictionary<ProductEnum, int>();
            productStockDatabase.Add(ProductEnum.KeyBoard, 1);
            productStockDatabase.Add(ProductEnum.Mic, 1);
            productStockDatabase.Add(ProductEnum.Mouse, 1);
            productStockDatabase.Add(ProductEnum.Speaker, 1);

            return productStockDatabase;

        }   


        public bool IsInStock(ProductEnum productEnum)
        {
            Console.WriteLine("query on database....");
            return _productStockDatabase[productEnum] > 0;
        }

        public void ReduceStock(ProductEnum productEnum)
        {
            Console.WriteLine("update on database....");
            _productStockDatabase[productEnum]--;
        }

        public void AddStock(ProductEnum productEnum)
        {
            Console.WriteLine("update on database....");
            _productStockDatabase[productEnum]++;
        }


    }
}
