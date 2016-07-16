using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBalticSoft.Interfaces;

namespace TestBalticSoft
{
    public class ProcessOrders
    {
        public Order CalculateOrderSum(Order order)
        {
            switch(order.TypeOrder)
            {
                case Enumerations.EnumTypeOrder.Person:
                    order.OrderSum = order.OrderSum * (1 + ((double)Enumerations.EnumProcents.Person/100));
                    order.OrderSum = Math.Round(order.OrderSum, 2);
                    break;
                case Enumerations.EnumTypeOrder.Organization:
                    order.OrderSum = order.OrderSum * (1 + ((double)Enumerations.EnumProcents.Organization/100));
                    order.OrderSum = Math.Round(order.OrderSum, 2);
                    break;
            }

            return order;

        }
        
    }
}
