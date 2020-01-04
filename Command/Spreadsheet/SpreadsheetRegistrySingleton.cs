using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spreadsheet
{
    public class SpreadsheetRegistrySingleton
    {
        private Dictionary<string, ISpreadsheet> sheets = new Dictionary<string, ISpreadsheet>();

        private static object _initLock = new object();

        private static SpreadsheetRegistrySingleton _instance;

        public static SpreadsheetRegistrySingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_initLock)
                {
                   if (_instance == null)
                   {
                       _instance = new SpreadsheetRegistrySingleton();
                   }
                }
            }
            return _instance;
        }

        public ISpreadsheet GetSheetByName(string name)
        {
            return sheets[name];
        }

        public void RegisterSheet(string name, ISpreadsheet sheet)
        {
            sheets[name] = sheet;
        }

        public void UnregisterSheet(string name)
        {
            sheets[name] = null;
        }        
    }
}
