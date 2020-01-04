using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spreadsheet
{
    
    public interface ISpreadsheet
    {
        string Name { get; }

        int GetValue(int nRow, int nCol);
        void SetValue(int nRow, int nCol, int value);
        
        int NumberOfColumns { get; }
        int NumberOfRows { get; }

        void Save(string filename);        
    }
}
