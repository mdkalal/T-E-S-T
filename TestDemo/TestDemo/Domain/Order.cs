using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDemo.Domain
{
    public static class Order
    {
        // test first-
        // refactor
        //point out private method, and how to test those?  Should we test those
        // unit testing vs "unit of work" testing
        static public bool IsOrderNumberValid(string orderNumber)
        {

            int n;
            bool isNumeric = int.TryParse(orderNumber, out n);

            return isNumeric;

        }

        private static bool IsEmailValid(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            //bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            //return isValid;
        }

        public static bool DoSomething(string emailAddress)
        {
            // email format
            // exclude disposable emails (mailinator, etc)  jetable.org

            if (emailAddress.EndsWith("mailinator.com") == true && emailAddress.EndsWith("jetable.org") == true)
            {

            }


            if (emailAddress.Contains("@") == false && emailAddress.EndsWith(".com") == false)
            {
                return false;
            }

            return true;


        }



    }
}
