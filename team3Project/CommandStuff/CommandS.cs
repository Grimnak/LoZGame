﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{

    class CommandS : ICommand
    {

        IPlayer player;
        public CommandS(IPlayer player)
        {

            this.player = player; 
        }
        public void execute()
        {

            player.moveDown();
        }
    }
}
