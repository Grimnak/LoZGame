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

        private enum Direction{
            Up,
            Down,
            Left,
            Right
        }


        Game game;
        CommandLoader allCommands;
        Direction previousDirection;

        private ICommand currentCommand;

        public KeyboardController(Game game, CommandLoader allCommands)
        {
            this.game = game;
            this.allCommands = allCommands;
            previousDirection = Direction.Down;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            if (pressed.Length == 0)
            {
                switch (previousDirection) {

                    case Direction.Up:
                        currentCommand = allCommands.getIdleUp;
                        currentCommand.execute();
                        break;

                    case Direction.Down:
                        currentCommand = allCommands.getIdleDown;
                        currentCommand.execute();
                        break;

                    case Direction.Left:
                        currentCommand = allCommands.getIdleLeft;
                        currentCommand.execute();
                        break;

                    case Direction.Right:
                        currentCommand = allCommands.getIdleRight;
                        currentCommand.execute();
                        break;

                    default:
                        break;

                }
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
                    previousDirection = Direction.Up;
                }
                else if (pressed.Contains(Keys.A))
                {
                    currentCommand = allCommands.getA;
                    currentCommand.execute();
                    previousDirection = Direction.Left;
                }
                else if (pressed.Contains(Keys.S))
                {
                    currentCommand = allCommands.getS;
                    currentCommand.execute();
                    previousDirection = Direction.Down;
                }
                else if (pressed.Contains(Keys.D))
                {
                    currentCommand = allCommands.getD;
                    currentCommand.execute();
                    previousDirection = Direction.Right;
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
                else if (pressed.Contains(Keys.D3))
                {
                    currentCommand = allCommands.getThree;
                    currentCommand.execute();
                }
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
