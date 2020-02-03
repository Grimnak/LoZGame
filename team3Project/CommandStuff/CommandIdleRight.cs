using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandIdleRight : ICommand
    {
        IPlayer player;

        public CommandIdleRight(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            player.IdleRight();
        }

    }
}
