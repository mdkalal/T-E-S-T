using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestDemo.Domain;
using TestDemo.Models;
using TestDemo.Controllers;
using Moq;


namespace TestDemoTests.Examples
{
    [TestClass]
    public class ExampleTests
    {

        [TestMethod]
        public void MockTest_SetProperties_ShowSetProperties()
        {
            // "Fake" properties
            //Arrange
            var fakeTest = new Mock<IMovieMockTest>();

            //Act
            fakeTest.SetupGet(p => p.Rating).Returns("2");
            fakeTest.SetupGet(p => p.Title).Returns("Return Of The Jedi");

            //Assert
            Assert.AreEqual("2", fakeTest.Object.Rating);
            Assert.AreEqual("Return Of The Jedi", fakeTest.Object.Title);

        }


        [TestMethod]
        public void MockTest_DoMethodCall_VerifyTrue()
        {
            //"Fake" method call

            var fakeTest = new Mock<IMovieMockTest>();
            fakeTest.Setup(p => p.GetActorName("Darth Vader")).Returns("James Earl Jones");
            //fakeTest.Setup(p => p.GetActorName(It.IsAny<String>())).Returns("Harrison Ford");

            //Assert
            Assert.AreEqual("James Earl Jones", fakeTest.Object.GetActorName("Darth Vader"));
        }


        [TestMethod]
        public void TestController()
        {
            //Arrange
            var trackOrderModel = new TrackOrderModel();
            var orderController = new OrderController();

            trackOrderModel.EmailAddress = "mark@outlook.com";
            trackOrderModel.OrderNumber = "123";

            //Act
            var result = orderController.OrderTrack(trackOrderModel);

            //Assert
            Assert.AreEqual("OrderStatus", ((Microsoft.AspNetCore.Mvc.ViewResult)result).ViewName);

        }


        [TestMethod]
        public void TestPrivate()
        {
            //Arrange
            Type type = typeof(OrderServices);
            var orderServices = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "IsValidEmailFormat" && x.IsPrivate)
            .First();

            //Act
            var result = (bool)method.Invoke(orderServices, new object[] { "mark@.com" });

            //Assert
            Assert.IsFalse(result);

        }
    }


    public interface IMovieMockTest
    {
        string Title { get; set; }
        string Rating { get; set; }

        public string GetActorName(string CharacterName);
        
    }


}
