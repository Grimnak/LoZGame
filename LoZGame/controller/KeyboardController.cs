namespace LoZClone
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardController : IController
    {
        readonly CommandLoader allCommands;
        KeyboardState oldState;
        readonly Dictionary<Keys, ICommand> dict;
        readonly List<KeyValuePair<Keys, ICommand>> playerCommands;

        private ICommand currentCommand;

        public KeyboardController(CommandLoader allCommands)
        {
            this.allCommands = allCommands;
            this.oldState = Keyboard.GetState();
            this.dict = allCommands.getDict;
            this.playerCommands = new List<KeyValuePair<Keys, ICommand>>();
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if (this.dict.ContainsKey(key) && this.dict[key].Priority != -1)
                {
                    this.playerCommands.Add(new KeyValuePair<Keys, ICommand>(key, this.dict[key]));
                }
            }

            this.playerCommands.Add(new KeyValuePair<Keys, ICommand>(Keys.Subtract, this.allCommands.getIdle));

            if (this.playerCommands.Count > 0)
            {
                this.playerCommands.Sort(new PriorityComparer());

                this.currentCommand = this.playerCommands[0].Value;

                if (this.currentCommand.Priority == 7 || this.currentCommand.Priority == 5)
                {
                    Keys currentKey = this.playerCommands[0].Key;
                    if (this.oldState.IsKeyUp(currentKey))
                    {
                        this.currentCommand.execute();
                    }
                    else
                    {
                        this.allCommands.getIdle.execute();
                    }
                }
                else if (this.currentCommand.Priority == 6)
                {
                    Keys currentKey = this.playerCommands[0].Key;
                    if (this.oldState.IsKeyUp(currentKey))
                    {
                        this.currentCommand.execute();
                    }
                }
                else
                {
                    this.currentCommand.execute();
                }

            }

            this.playerCommands.Clear();

            if (pressed.Contains(Keys.U) && this.oldState.IsKeyUp(Keys.U))
            {
                this.dict[Keys.U].execute();
            }
            else if (pressed.Contains(Keys.I) && this.oldState.IsKeyUp(Keys.I))
            {
                this.dict[Keys.I].execute();
            }

            if (pressed.Contains(Keys.O) && this.oldState.IsKeyUp(Keys.O))
            {
                this.dict[Keys.O].execute();
            }
            else if (pressed.Contains(Keys.P) && this.oldState.IsKeyUp(Keys.P))
            {
                this.dict[Keys.P].execute();
            }

            if (pressed.Contains(Keys.L) && this.oldState.IsKeyUp(Keys.L))
            {
                this.dict[Keys.L].execute();
            }
            else if (pressed.Contains(Keys.K) && this.oldState.IsKeyUp(Keys.K))
            {
                this.dict[Keys.K].execute();
            }

            if (pressed.Contains(Keys.E))
            {
                this.dict[Keys.E].execute();
            }

            if (pressed.Contains(Keys.Q))
            {
                this.dict[Keys.Q].execute();
            }

            if (pressed.Contains(Keys.R))
            {
                this.dict[Keys.R].execute();
            }

            this.oldState = state;
        }
    }
}
