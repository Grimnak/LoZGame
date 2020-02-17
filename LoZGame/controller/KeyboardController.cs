using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LoZClone
{
    public class KeyboardController : IController
    {
        CommandLoader allCommands;
        KeyboardState oldState;
        Dictionary<Keys, ICommand> dict;
        List<KeyValuePair<Keys, ICommand>> playerCommands;

        private ICommand currentCommand;

        public KeyboardController(CommandLoader allCommands)
        {
            this.allCommands = allCommands;
            oldState = Keyboard.GetState();
            dict = allCommands.getDict;
            playerCommands = new List<KeyValuePair<Keys, ICommand>>();
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            

            Keys[] pressed = state.GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if (dict.ContainsKey(key) && dict[key].Priority != -1)
                {
                    
                    playerCommands.Add(new KeyValuePair<Keys, ICommand>(key, dict[key]));
                }
            }
            playerCommands.Add(new KeyValuePair<Keys, ICommand>(Keys.Subtract, allCommands.getIdle));

            if (playerCommands.Count > 0)
            {
                playerCommands.Sort(new PriorityComparer());

                currentCommand = playerCommands[0].Value;

                if (currentCommand.Priority == 7 || currentCommand.Priority == 5)
                {
                    Keys currentKey = playerCommands[0].Key;
                    if (oldState.IsKeyUp(currentKey))
                    {
                        currentCommand.execute();
                    }
                    else
                    {
                        allCommands.getIdle.execute();
                    }
                }
                else if (currentCommand.Priority == 6)
                {
                    Keys currentKey = playerCommands[0].Key;
                    if (oldState.IsKeyUp(currentKey))
                    {
                        currentCommand.execute();
                    }
                }
                else
                {
                    currentCommand.execute();
                }

            }
            playerCommands.Clear();

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
