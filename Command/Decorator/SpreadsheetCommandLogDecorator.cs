using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Spreadsheet;

namespace Decorator
{
    public class SpreadsheetCommandLogDecorator : SpreadsheetDecorator
    {
        CommandHistoryInvoker invoker;

        public SpreadsheetCommandLogDecorator(ISpreadsheet spreadsheet)
            : base(spreadsheet)
        {
            invoker = new CommandHistoryInvoker(String.Format("{0}.log", spreadsheet.Name));
        }

        public override void SetValue(int nRow, int nCol, int value)
        {
            ICommand command = new SetValueCommand(inner, nRow, nCol, value);
            invoker.Execute(command);
        }

        public override void Save(string filename)
        {
            inner.Save(filename);
            invoker.ClearHistory();
        }

        public void Restore()
        {
            invoker.Restore();
        }
    }
}
