using DI_NetCore.With_DependencyInjection;
using DI_NetCore.Without_DependencyInjection;
using Moq;
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


        [Fact]
        public void Test_OrderManager_DI_OutOfStock_ErrorMessage()
        {
            var productStockRepository_Mock = new Mock<IProductStockRepository_WithDI>();
            productStockRepository_Mock
                .Setup(m =>  m.IsInStock(It.IsAny<ProductEnum>()))
                .Returns(false);

            var paymentProcessorMock = new Mock<IPaymentProcessor_WithDI>();
            var shippingProcessorMock = new Mock<IShippingProcessor_WithDI>();


            var orderManager = new OrderManager_WithDI(productStockRepository_Mock.Object, paymentProcessorMock.Object, shippingProcessorMock.Object);


            Assert.ThrowsAny<Exception>(() => orderManager.Submit(ProductEnum.KeyBoard, "1234567891234567", "1021"));
        }


    }
}
