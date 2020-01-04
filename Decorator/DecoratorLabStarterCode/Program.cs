using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersDll;

namespace DecoratorLabStarterCode
{
    class Program
    {
        static void Main(string[] args)
        {
          
            AbstractOrderBase abstractOrder = new Order();
            abstractOrder = new ExpressDeliveryOrderDecorator(abstractOrder);
            AbstractOrderBase abstractOrderVisa = new Order();
            abstractOrderVisa = new VisaCreditCardDecorator(abstractOrder);
            AbstractOrderBase abstractOrderAMEX = new Order();
            abstractOrderAMEX = new AMEXCreditCardDecorator(abstractOrder);

            abstractOrder.AddItem("BroncoHats", 2, 1.5, 0.2);
            abstractOrder.AddItem("BroncoGloves", 1, 3.0, 0.5);
            abstractOrder.AddItem("BroncoSocks", 6, 1.9, 0.1);
            abstractOrder.AddItem("BroncoBanners", 3, 8.0, 1.5);
            abstractOrder.AddItem("BroncoFootBalls", 4, 5.6, 0.6);
            abstractOrder.AddItem("BroncoJerseys", 2, 2.3, 0.4);

            abstractOrder.PrintOrderItems();
            abstractOrder.GrandTotal();

            abstractOrderVisa.PrintOrderItems();

            abstractOrderAMEX.PrintOrderItems();

            Console.ReadLine();
        }
    }
}
