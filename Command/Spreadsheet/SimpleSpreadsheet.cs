using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Spreadsheet
{
    [Serializable]
    public class SimpleSpreadsheet : ISpreadsheet
    {
        private string name;
        const int NUM_COLS = 10;
        const int NUM_ROWS = 10;
        private int[,] cells = new int[NUM_ROWS, NUM_COLS];

        public SimpleSpreadsheet(string name)
        {
            this.name = name;
            SpreadsheetRegistrySingleton.GetInstance().RegisterSheet(name, this);
        }

        public int GetValue(int nRow, int nCol)
        {
            return cells[nRow, nCol];
        }

        public void SetValue(int nRow, int nCol, int value)
        {
            cells[nRow, nCol] = value;
        }

        public string Name
        {
            get { return name; }
        }

        public int NumberOfColumns
        {
            get { return NUM_COLS; }
        }

        public int NumberOfRows
        {
            get { return NUM_ROWS; }
        }

        public void Save(string filename)
        {
            using (FileStream stream = File.OpenWrite(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);
            }
        }

        public static ISpreadsheet Load(string filename)
        {
            SimpleSpreadsheet sheet;

            using (FileStream stream = File.OpenRead(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                sheet = (SimpleSpreadsheet)formatter.Deserialize(stream);

                SpreadsheetRegistrySingleton.GetInstance().RegisterSheet(sheet.Name, sheet);
            }

            return sheet;
        }
    }
}
