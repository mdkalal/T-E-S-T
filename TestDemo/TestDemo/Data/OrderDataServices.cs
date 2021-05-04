using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDemo.Interfaces;

namespace TestDemo.Data
{
    public class OrderDataServices : IOrderDataServices
    {
        public int FetchOrder(int OrderNumber)
        {
            //dummy database lookup
            if (OrderNumber == 123 || OrderNumber == 456)
            {
                return 2;
            }

            return 0;

        }
    }
}
