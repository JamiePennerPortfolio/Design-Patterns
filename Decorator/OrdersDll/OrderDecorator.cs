using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
    public class OrderDecorator : AbstractOrderBase
    {
        protected AbstractOrderBase _AbstractOrder;

        protected OrderDecorator(AbstractOrderBase abstractOrder)
        {
            _AbstractOrder = abstractOrder;
        }

        public override void AddItem(string productCode, int quantity, double cost, double weight)
        {
            _AbstractOrder.AddItem(productCode, quantity, cost, weight);
        }

        public override double GetTotalCost()
        {
            return _AbstractOrder.GetTotalCost();
        }

        public override void PrintOrderItems()
        {
           _AbstractOrder.PrintOrderItems();
        }
        public override void GrandTotal()
        {
            _AbstractOrder.GrandTotal();

        }
    }
}
