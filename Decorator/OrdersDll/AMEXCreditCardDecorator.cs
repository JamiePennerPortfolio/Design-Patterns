using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
   public class AMEXCreditCardDecorator : OrderDecorator
    {
        public AMEXCreditCardDecorator(AbstractOrderBase abstractOrder)
            :base(abstractOrder)
        {

        }
        public override double GetTotalCost()
        {
            return base.GetTotalCost() + 5;
        }
        public override void PrintOrderItems()
        {
            Console.WriteLine("A $5.00 Credit Card Fee Will Apply ");
            Console.WriteLine();
            base.PrintOrderItems();
            Console.WriteLine("Credit Card Fee: $5.00");
            Console.WriteLine("Grand Total: {0:C}", GetTotalCost());
            Console.WriteLine();
        }
    }
}
