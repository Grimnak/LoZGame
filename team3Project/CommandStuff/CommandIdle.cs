using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandIdle : ICommand
    {
        IPlayer player;

        public CommandIdle(IPlayer player)
        {
            this.player = player;
        }

        public void execute()
        {
            player.idle();
        }

    }
}
