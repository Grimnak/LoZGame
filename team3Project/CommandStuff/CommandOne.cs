using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandOne : ICommand
    {
        IPlayer player;
        public CommandOne(IPlayer player)
        {

            this.player = player; 
        }

        public void execute()
        {
            player.usePrimaryItem();
        }
    }
}
