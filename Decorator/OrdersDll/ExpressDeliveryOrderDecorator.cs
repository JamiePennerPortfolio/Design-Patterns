using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
   public class ExpressDeliveryOrderDecorator : OrderDecorator
    {
        public ExpressDeliveryOrderDecorator(AbstractOrderBase abstractOrder)
            :base(abstractOrder)
        {

        }
        public override double GetTotalCost()
        {
            return base.GetTotalCost() + 4;
        }
        public override void PrintOrderItems()
        {
            Console.WriteLine("A Shipping Cost May Apply");
            Console.WriteLine();
            base.PrintOrderItems();
            Console.WriteLine("Shipping: $4.00");
        }
        public override void GrandTotal()
        {
            Console.WriteLine("Grand Total {0:C}", GetTotalCost());
            Console.WriteLine();
        }
    }
}
