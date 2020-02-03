using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandIdleUp : ICommand
    {
        IPlayer player;

        public CommandIdleUp(IPlayer player) {
            this.player = player;
        }

        public void execute() {
            player.IdleUp();
        }

    }
}
