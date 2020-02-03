using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandE : ICommand
    {

        IPlayer player;
        public CommandE(IPlayer player)
        {

            this.player = player;

        }

        public void execute()
        {
            player.takeDamage();
        }
    }
}
