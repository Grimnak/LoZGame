using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandIdleDown : ICommand
    {
        IPlayer player;

        public CommandIdleDown(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            player.IdleDown();
        }

    }
}
