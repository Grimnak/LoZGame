using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandZ : ICommand
    {
        //TODO potentially combine this class with CommandN

        IPlayer player;
        public CommandZ(IPlayer player)
        {

            this.player = player; 
        }

        public void execute()
        {
            player.attack();
        }
    }
}
