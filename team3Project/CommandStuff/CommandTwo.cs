using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandTwo : ICommand
    {

        IPlayer player;
        public CommandTwo(IPlayer player)
        {

            this.player = player; 
        }
        public void execute()
        {
            player.UseItemTwo();
        }
    }
}
