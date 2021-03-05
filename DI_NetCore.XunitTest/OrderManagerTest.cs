using DI_NetCore.Without_DependencyInjection;
using System;
using Xunit;

namespace DI_NetCore.XunitTest
{
    public class OrderManagerTest
    {
        [Fact]
        public void Test_OrderManager_WithoutDI_OutOfStock_ErrorMessage()
        {
            var orderManager = new OrderManager_WithoutDI();
            orderManager.Submit(ProductEnum.KeyBoard, "1234567891234567", "1021");

            Assert.ThrowsAny<Exception>(() => orderManager.Submit(ProductEnum.KeyBoard, "1234567891234567", "1021") );
        }
    }
}
