using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestDemo.Domain;
using TestDemo.Data;
using Moq;
using TestDemo.Interfaces;

namespace TestDemoTests.Order
{

    [TestClass]
    public class OrderTests
    {

        [TestMethod]
        public void ValidateOrderNumber_EnterNumber_Pass()
        {
            //Arrange
            bool result;
            bool expectedResult = true;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsOrderNumberValid("12345");

            //Assert
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        public void ValidateOrderNumber_EnterSpace_Fail()
        {
            //Arrange
            bool result;
            bool expectedResult = false;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsOrderNumberValid(" ");

            //Assert
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        public void ValidateOrderNumber_EnterLetters_Fail()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices(); 

            //Act
            result = orderService.IsOrderNumberValid("ABCDE");

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ValidateOrderNumber_EnterNull_Fail()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsOrderNumberValid(null);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ValidateEmailAddressDisposable_EnterSpaces_Fail()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("");

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ValidateEmailAddressDisposable_DisposabelEmail_Fail()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mark@mailinator.com");

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ValidateEmailAddressDisposable_RegularEmail_Pass()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mark@outlook.com");

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ValidateEmailAddress_ORGDomain_pass()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mark@company.org");

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ValidateEmailAddress_NoDomain_fail()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mark.com");

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ValidateEmailAddress_GoodFormat_pass()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mark@gmail.com");

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ValidateEmailAddress_ForDemoBadFormat_FalsePositive()
        {
            //Arrange
            bool result;
            var orderService = new OrderServices();

            //Act
            result = orderService.IsEmailValid("mrk@outlook.com");

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ValidateEmailAddress_TextCase_Pass()
        {
            //Arrange
            bool mixedCapsResult;
            bool upperResult;
            bool lowerResult;

            var orderService = new OrderServices();

            //Act
            mixedCapsResult = orderService.IsEmailValid("MaRk@OuTlOoK.CoM");
            upperResult = orderService.IsEmailValid("MARK@OUTLOOK.COM");
            lowerResult = orderService.IsEmailValid("mark@outlook.com");

            //Assert
            Assert.IsTrue(mixedCapsResult);
            Assert.IsTrue(upperResult);
            Assert.IsTrue(lowerResult);
        }


        [TestMethod]
        public void OrderDetails_OrderShipped_OrderNotFound()
        {
            //Arrange
            string result;
            var orderDataServices = new OrderDataServices();
            var orderService = new OrderServices();

            //Act
            result = orderService.GetOrderDetails("email@address.com", "789", orderDataServices);

            //Assert
            Assert.AreEqual(result, "Order not found");
        }


        [TestMethod]
        public void OrderDetails_OrderShipped_OrderPending()
        {
            //Throw new NotImplementedException();

            //Arrange
            string result;

            var mockOrderDataServices = new Mock<IOrderDataServices>();
            mockOrderDataServices.Setup(x => x.FetchOrder(It.IsAny<int>())).Returns((int x) => 1);

            var orderService = new OrderServices();

            //Act
            result = orderService.GetOrderDetails("email@address.com", "789", mockOrderDataServices.Object);

            //Assert
            Assert.AreEqual(result, "Order pending");
        }


        [TestMethod]
        public void OrderDetails_OrderShipped_Ontheway()
        {
            //Arrange
            string result;
            var orderDataServices = new OrderDataServices();
            var orderService = new OrderServices();

            //Act
            result = orderService.GetOrderDetails("email@address.com", "123", orderDataServices);

            //Assert
            Assert.IsTrue(result.StartsWith("Shipped"));
        }
    }
}
