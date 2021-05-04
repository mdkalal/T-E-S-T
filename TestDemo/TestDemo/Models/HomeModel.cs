using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDemo.Models
{
    public class HomeModel
    {

        public string EmailAddress { get; set; }
        public string OrderNumber { get; set; }


        private static bool ValidateEmail(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            //bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            //return isValid;
        }

    }
}
