using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandI : ICommand
    {
        //class for a command when 'I' is pressed, not to be confused with the interface 'ICommand'

        //ItemManager? item;
        public CommandI(/*ItemManager? item*/)
        {

            //this.item = item; 
        }

        public void execute()
        {
            //item.CycleItemRight();
        }
    }
}
