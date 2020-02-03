using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandW : ICommand
    {

        IPlayer player;
        public CommandW(IPlayer player)
        {

            this.player = player; 
        }


        public void execute()
        {

            player.MoveUp();
        }

    }
}
