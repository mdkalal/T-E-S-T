using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TestDemo.Interfaces;


namespace TestDemo.Domain
{
    public class OrderServices
    {

        public bool IsOrderNumberValid(string orderNumber)
        {

            int n;
            bool isNumeric;

            if (orderNumber is null)
            {
                return false;
            }

            isNumeric = int.TryParse(orderNumber, out n);

            return isNumeric;
        }

        public bool IsEmailValid(string emailAddress)
        {

            if (emailAddress is null)
            {
                return false;
            }

            //email format
            //if (emailAddress.Contains("@") == false)
            //{
            //    return false;
            //}


            //if (!emailAddress.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
            //{
            //    return false;
            //}

            if (this.IsValidEmailFormat(emailAddress) == false)
            {
                return false;
            }


            // exclude disposable emails (mailinator, jetable)
            if (emailAddress.EndsWith("mailinator.com") == true || emailAddress.EndsWith("jetable.org") == true)
            {
                return false;
            }

            return true;
        }


        private bool IsValidEmailFormat(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            
        }

       
        public String GetOrderDetails(string emailAddress, string orderNumber, IOrderDataServices dataServices )
        {
            // Hit the database, check return value:
            // 2 means order is shipped
            // 1 means order is pending
            // anything else means order not found
           
            int returnValue;

            returnValue = dataServices.FetchOrder(Convert.ToInt32(orderNumber));

            if (returnValue == 2)
            {
                return "Shipped - Order is on it's way";
            }

            if (returnValue == 1)
            {
                return "Order pending";
            }


            return "Order not found";

        }
    }
}
