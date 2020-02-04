using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandD : ICommand
    {

        IPlayer player;
        public CommandD(IPlayer player)
        {

            this.player = player; 
        }
        public void execute()
        {

            player.moveRight();
        }
    }
}
