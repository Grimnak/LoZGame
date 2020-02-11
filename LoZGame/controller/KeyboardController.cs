using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class KeyboardController : IController
    {
        LoZGame game;
        CommandLoader allCommands;

        private ICommand currentCommand;

        public KeyboardController(LoZGame game, CommandLoader allCommands)
        {
            this.game = game;
            this.allCommands = allCommands;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            if (pressed.Length == 0)
            {
                currentCommand = allCommands.getIdle;
                currentCommand.execute();
            }
            else
            {

                if (pressed.Contains(Keys.Z))
                {
                    currentCommand = allCommands.getZ;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.N))
                {
                    currentCommand = allCommands.getN;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.W))
                {
                    currentCommand = allCommands.getW;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.A))
                {
                    currentCommand = allCommands.getA;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.S))
                {
                    currentCommand = allCommands.getS;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.D))
                {
                    currentCommand = allCommands.getD;
                    currentCommand.execute();
                }
                //maybe change
                else if (pressed.Contains(Keys.D1))
                {
                    currentCommand = allCommands.getOne;
                    currentCommand.execute();
                }
                //maybe change
                else if (pressed.Contains(Keys.D2))
                {
                    currentCommand = allCommands.getTwo;
                    currentCommand.execute();
                }
                //maybe change
                else if (pressed.Contains(Keys.E))
                {
                    currentCommand = allCommands.getE;
                    currentCommand.execute();
                }

                if (pressed.Contains(Keys.U))
                {
                    currentCommand = allCommands.getU;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.I))
                {
                    currentCommand = allCommands.getI;
                    currentCommand.execute();
                }

                if (pressed.Contains(Keys.O))
                {
                    currentCommand = allCommands.getO;
                    currentCommand.execute();
                }
                else if (pressed.Contains(Keys.P))
                {
                    currentCommand = allCommands.getP;
                    currentCommand.execute();
                }

                if (pressed.Contains(Keys.Q))
                {
                    currentCommand = allCommands.getQ;
                    currentCommand.execute();
                }

                if (pressed.Contains(Keys.R))
                {
                    currentCommand = allCommands.getR;
                    currentCommand.execute();
                }
            }
        }
    }
}
