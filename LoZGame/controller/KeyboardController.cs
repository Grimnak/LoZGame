using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class KeyboardController : IController
    {
        LoZGame game;
        CommandLoader allCommands;
        KeyboardState oldState;
        Dictionary<Keys, ICommand> dict;
        

        private ICommand currentCommand;

        public KeyboardController(LoZGame game, CommandLoader allCommands)
        {
            this.game = game;
            this.allCommands = allCommands;
            oldState = Keyboard.GetState();
            dict = allCommands.getDict;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            

            Keys[] pressed = state.GetPressedKeys();


            if (pressed.Contains(Keys.Z) && oldState.IsKeyUp(Keys.Z))
            {

                dict[Keys.Z].execute();
            }
            else if (pressed.Contains(Keys.N) && oldState.IsKeyUp(Keys.N))
            {
                dict[Keys.N].execute();
            }
            else if (pressed.Contains(Keys.D1) && oldState.IsKeyUp(Keys.D1))
            {
                dict[Keys.D1].execute();
            }
            else if (pressed.Contains(Keys.D2) && oldState.IsKeyUp(Keys.D2))
            {
                dict[Keys.D2].execute();
            }
            else if (pressed.Contains(Keys.D3) && oldState.IsKeyUp(Keys.D3))
            {
                dict[Keys.D3].execute();
            }
            else if (pressed.Contains(Keys.D4) && oldState.IsKeyUp(Keys.D4))
            {
                dict[Keys.D4].execute();
            }
            else if (pressed.Contains(Keys.D5) && oldState.IsKeyUp(Keys.D5))
            {
                dict[Keys.D5].execute();
            }
            else if (pressed.Contains(Keys.D6) && oldState.IsKeyUp(Keys.D6))
            {
                dict[Keys.D6].execute();
            }
            else if (pressed.Contains(Keys.D7) && oldState.IsKeyUp(Keys.D7))
            {
                dict[Keys.D7].execute();
            }
            else if (pressed.Contains(Keys.D8) && oldState.IsKeyUp(Keys.D8))
            {
                dict[Keys.D8].execute();
            }
            else if (pressed.Contains(Keys.W))
            {
                dict[Keys.W].execute();
            }
            else if (pressed.Contains(Keys.A))
            {
                dict[Keys.A].execute();
            }
            else if (pressed.Contains(Keys.S))
            {
                dict[Keys.S].execute();
            }
            else if (pressed.Contains(Keys.D))
            {
                dict[Keys.D].execute();
            }
            else
            {
                currentCommand = allCommands.getIdle;
                currentCommand.execute();
            }


            if (pressed.Contains(Keys.U) && oldState.IsKeyUp(Keys.U))
            {
                dict[Keys.U].execute();
            }
            else if (pressed.Contains(Keys.I) && oldState.IsKeyUp(Keys.I))
            {
                dict[Keys.I].execute();
            }


            if (pressed.Contains(Keys.O))
            {
                dict[Keys.O].execute();
            }
            else if (pressed.Contains(Keys.P))
            {
                dict[Keys.P].execute();
            }
        

            if (pressed.Contains(Keys.L) && oldState.IsKeyUp(Keys.L))
            {
                dict[Keys.L].execute();
            }
            else if (pressed.Contains(Keys.K) && oldState.IsKeyUp(Keys.K))
            {
                dict[Keys.K].execute();
            }


            if (pressed.Contains(Keys.E))
            {
                dict[Keys.E].execute();
            }


            if (pressed.Contains(Keys.Q))
            {
                dict[Keys.Q].execute();
            }


            if (pressed.Contains(Keys.R))
            {
                dict[Keys.R].execute();
            }

                
            oldState = state;
        }
    }
}
