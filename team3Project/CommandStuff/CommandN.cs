using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandN : ICommand
    {
        //TODO potentially combine this class with CommandZ

        IPlayer player;
        public CommandN(IPlayer player)
        {

            this.player = player; 
        }
        public void execute()
        {

            player.attack();
        }
    }
}
