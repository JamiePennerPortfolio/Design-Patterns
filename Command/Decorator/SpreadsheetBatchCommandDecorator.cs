using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spreadsheet;

namespace Decorator
{
    public class SpreadsheetBatchCommandDecorator : SpreadsheetDecorator
    {
        private BatchInvoker invoker;
        public SpreadsheetBatchCommandDecorator(ISpreadsheet spreadsheet)
            : base(spreadsheet)
        {
            invoker = new BatchInvoker();
        }
        public override void SetValue(int nRow, int nCol, int value)
        {
            ICommand command = new SetValueCommand(inner, nRow, nCol, value);
            invoker.Execute(command);
        }
    }
}
