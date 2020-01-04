using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command
{
    public class BatchInvoker 
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void Execute(ICommand command)
        {
            for (int i = 0; i < 5; i++ )
            {
                _commands.Add(command);
            }

            foreach(var item in _commands)
            {
                item.Execute();
            }
            _commands.Clear();
            Thread.Sleep(500);
        }
        
    }
}
