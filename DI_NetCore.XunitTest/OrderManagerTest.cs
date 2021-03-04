using System;
using Xunit;

namespace DI_NetCore.XunitTest
{
    public class OrderManagerTest
    {
        [Fact]
        public void Test1()
        {
            var orderManager = new OrderManager();
            orderManager.Submit(ProductEnum.KeyBoard, "1234567891234567", "1021");

            Assert.ThrowsAny<Exception>(() => orderManager.Submit(ProductEnum.KeyBoard, "1234567891234567", "1021") );
        }
    }
}
