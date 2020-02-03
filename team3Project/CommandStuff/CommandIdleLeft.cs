using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandIdleLeft : ICommand
    {
        IPlayer player;

        public CommandIdleLeft(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            player.IdleLeft();
        }

    }
}
