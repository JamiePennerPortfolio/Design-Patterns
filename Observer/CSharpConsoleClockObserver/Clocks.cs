using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpConsoleClockObserver
{
    public class SecondClock : Clock
    {
        private Ticker t;
        public SecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            t = ticker;
            t.OnSecondsTick += Second;
        }
        protected override void Dispose(bool disposing)
        {
            t.OnSecondsTick += Second;
        }
        public void Second()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
        }         
    }

    public class HundredthSecondClock : Clock
    {
        private Ticker t;
        public HundredthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            t = ticker;
            t.OnHundredthsTick += HundredthSecond;
        }
        protected override void Dispose(bool disposing)
        {
            t.OnHundredthsTick -= HundredthSecond;
        }
        public void HundredthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 10, 9, 0, 2);
        }
    }

    public class TenthSecondClock : Clock
    {
        private Ticker t;
        public TenthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            t = ticker;
            t.OnTenthsTick += TenthSecond;
        }
        protected override void Dispose(bool disposing)
        {
            t.OnTenthsTick -= TenthSecond;
        }
        private void TenthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 100, 9, 0, 1);
        }   
    }
}
