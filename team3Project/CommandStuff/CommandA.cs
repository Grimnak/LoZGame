using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandA : ICommand
    {

        IPlayer player;
        public CommandA(IPlayer player)
        {

            this.player = player;
        }

        public void execute()
        {

            player.moveLeft();
        }


    }
}
