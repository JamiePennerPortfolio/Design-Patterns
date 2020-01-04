using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Spreadsheet;
using Decorator;
using System.Threading;


namespace CommandLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            BatchSpreadsheet();
            //ISpreadsheet Calcspreadsheet = new SimpleSpreadsheet("Calc");

            //Calcspreadsheet.Save("Calcspreadsheet.bin");

            //UpdateSpreadsheet(Calcspreadsheet);

            ////what if this doesn't happen
            //Calcspreadsheet.Save("Calcspreadsheet.bin");

            //Calcspreadsheet = null;
            //Calcspreadsheet = SimpleSpreadsheet.Load("Calcspreadsheet.bin");

            //ValidateSheet(Calcspreadsheet);

            // SuperSafeSpreadsheet();

            Console.ReadLine();
        }
        private static void BatchSpreadsheet()
        {
            ISpreadsheet simplespreadsheet = new SimpleSpreadsheet("Calc");
            simplespreadsheet = new SpreadsheetBatchCommandDecorator(simplespreadsheet);

            UpdateSpreadsheet(simplespreadsheet);
            ValidateSheet(simplespreadsheet);

        }
        private static void UpdateSpreadsheet(ISpreadsheet spreadsheet)
        {
            int cellnum = 0;
            for (int nRow = 0; nRow < spreadsheet.NumberOfRows; nRow++)
            {
                for (int nCol = 0; nCol < spreadsheet.NumberOfColumns; nCol++)
                {
                    spreadsheet.SetValue(nRow, nCol, cellnum);
                    Console.Write("{0} ", cellnum);
                    cellnum++;

                    //Could do but performance hit
                    //spreadsheet.Save("Calcspreadsheet.bin");
                    //Thread.Sleep(100);
                }
            }
            Console.WriteLine();
        }

        private static void ValidateSheet(ISpreadsheet spreadsheet)
        {
            int cellnum = 0;

            Console.WriteLine("Validating spreadsheet");

            for (int nRow = 0; nRow < spreadsheet.NumberOfRows; nRow++)
            {
                for (int nCol = 0; nCol < spreadsheet.NumberOfColumns; nCol++)
                {
                    Debug.Assert(spreadsheet.GetValue(nRow, nCol) == cellnum, "Not the correct value");
                    cellnum++;
                }
            }

            Console.WriteLine("Finished validating spreadsheet");
        }

        private static void SuperSafeSpreadsheet()
        {
            ISpreadsheet Calcspreadsheet = new SimpleSpreadsheet("Calc");

            SpreadsheetCommandLogDecorator safesheet =
                new SpreadsheetCommandLogDecorator(Calcspreadsheet);

            safesheet.Save("Calcspreadsheet.bin");
            //update the spreadsheet
            UpdateSpreadsheet(safesheet);

            //what if this doesn't happen
            //safesheet.Save("Calcspreadsheet.bin");

            //lose it and reload
            safesheet = null;

            Calcspreadsheet = SimpleSpreadsheet.Load("Calcspreadsheet.bin");

            safesheet =
                new SpreadsheetCommandLogDecorator(Calcspreadsheet);

            safesheet.Restore();

            //validate the values are correct
            ValidateSheet(safesheet);
        }
    }
}
