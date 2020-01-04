using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
   public class VisaCreditCardDecorator : OrderDecorator
    {
        public VisaCreditCardDecorator(AbstractOrderBase abstractOrder)
            :base(abstractOrder)
        {

        }
        public override double GetTotalCost()
        {
            return base.GetTotalCost() + 2;
        }
        public override void PrintOrderItems()
        {
            Console.WriteLine("A $2.00 Credit Card Fee Will Apply ");
            Console.WriteLine();
            base.PrintOrderItems();
            Console.WriteLine("Credit Card Fee: $2.00");
            Console.WriteLine("Grand Total: {0:C}", GetTotalCost());
            Console.WriteLine();

        }
    }
}
