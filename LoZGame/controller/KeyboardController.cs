using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    class KeyboardController : IController
    {
        Game game;
        CommandLoader loader;
        Dictionary<Keys, ICommand> commands;

        private ICommand currentCommand;

        public KeyboardController(Game game, CommandLoader loader)
        {
            this.game = game;
            this.loader = loader;
            commands = this.loader.getCommands;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            if (pressed.Length == 0)
            {
                currentCommand = loader.getIdle;
                currentCommand.execute();
            }
            else
            {
                foreach (Keys key in pressed)
                {
                    if (commands.ContainsKey(key))
                    {
                        commands[key].execute();
                    }
                }
            }
        }
    }
}
