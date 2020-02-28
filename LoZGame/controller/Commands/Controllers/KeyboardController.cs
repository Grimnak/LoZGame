namespace LoZClone
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Controller for keyboard input.
    /// </summary>
    public class KeyboardController : IController
    {
        private readonly KeyboardCommandLoader allCommands;
        private readonly Dictionary<Keys, ICommand> dict;
        private readonly List<KeyValuePair<Keys, ICommand>> playerCommands;
        private ICommand currentCommand;
        private KeyboardState oldState;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardController"/> class.
        /// </summary>
        /// <param name="allCommands">Contains all commands for the controller to execute.</param>
        public KeyboardController(KeyboardCommandLoader allCommands)
        {
            this.allCommands = allCommands;
            this.oldState = Keyboard.GetState();
            this.dict = allCommands.GetDict;
            this.playerCommands = new List<KeyValuePair<Keys, ICommand>>();
        }

        /// <inheritdoc/>
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

            this.playerCommands.Add(new KeyValuePair<Keys, ICommand>(Keys.Subtract, this.allCommands.GetIdle));

            if (this.playerCommands.Count > 0)
            {
                this.playerCommands.Sort(new PriorityComparer());

                this.currentCommand = this.playerCommands[0].Value;

                if (this.currentCommand.Priority == 7 || this.currentCommand.Priority == 5)
                {
                    Keys currentKey = this.playerCommands[0].Key;
                    if (this.oldState.IsKeyUp(currentKey))
                    {
                        this.currentCommand.Execute();
                    }
                    else
                    {
                        this.allCommands.GetIdle.Execute();
                    }
                }
                else if (this.currentCommand.Priority == 6)
                {
                    Keys currentKey = this.playerCommands[0].Key;
                    if (this.oldState.IsKeyUp(currentKey))
                    {
                        this.currentCommand.Execute();
                    }
                }
                else
                {
                    this.currentCommand.Execute();
                }
            }

            this.playerCommands.Clear();

            if (pressed.Contains(Keys.E))
            {
                this.dict[Keys.E].Execute();
            }

            if (pressed.Contains(Keys.Q))
            {
                this.dict[Keys.Q].Execute();
            }

            if (pressed.Contains(Keys.R))
            {
                this.dict[Keys.R].Execute();
            }

            this.oldState = state;
        }
    }
}