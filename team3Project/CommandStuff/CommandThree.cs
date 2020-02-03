using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class CommandThree : ICommand
    {

        IPlayer player;
        public CommandThree(IPlayer player)
        {

            this.player = player; 
        }
        public void execute()
        {
            player.UseItemThree();
        }
    }
}
