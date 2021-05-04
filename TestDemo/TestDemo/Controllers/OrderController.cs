using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestDemo.Models;
using TestDemo.Domain;
using TestDemo.Data;
using System.Data.SqlClient;

namespace TestDemo.Controllers
{
    public class OrderController : Controller
    {

        public IActionResult OrderTrack()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderTrack(TrackOrderModel modelIn)
        {

            var orderServices = new OrderServices();  //methods
            var orderDateServices = new OrderDataServices(); //database
            
            bool emailValidation = orderServices.IsEmailValid(modelIn.EmailAddress);
            if (emailValidation == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email");
            }


            bool orderNumberValidation = orderServices.IsOrderNumberValid(modelIn.OrderNumber);
            if (orderNumberValidation == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid Order Number");
            }

            if (emailValidation == false || orderNumberValidation == false)
            {
                return View(modelIn);
            }


            string orderStatus = orderServices.GetOrderDetails(modelIn.EmailAddress, modelIn.OrderNumber, orderDateServices);

            OrderStatusModel orderStatusModel = new OrderStatusModel();
            orderStatusModel.OrderStatus = orderStatus;

            return View("OrderStatus", orderStatusModel);

        }
    }
}