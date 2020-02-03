using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    class CommandQ : ICommand
    {

        Game game;

        public CommandQ(Game game)
        {
            this.game = game;
        }

        public void execute()
        {
            game.Exit();
        }
    }
}
