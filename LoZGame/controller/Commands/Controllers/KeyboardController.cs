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
        private ICommand currentCommand;
        private KeyboardState oldState;
        private List<Keys> playerKeys;
        private List<Keys> oneUseKeys;
        private Stack<KeyValuePair<Keys, ICommand>> playerCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardController"/> class.
        /// </summary>
        /// <param name="allCommands">Contains all commands for the controller to execute.</param>
        public KeyboardController(KeyboardCommandLoader allCommands)
        {
            this.allCommands = allCommands;
            this.oldState = Keyboard.GetState();
            this.dict = allCommands.GetDict;
            this.playerCommands = new Stack<KeyValuePair<Keys, ICommand>>();
            this.playerKeys = new List<Keys>
            {
                Keys.W, Keys.Up, Keys.A, Keys.Left, Keys.S, Keys.Down, Keys.D, Keys.Right,
                Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8,
                Keys.Z, Keys.N,
            };
            this.oneUseKeys = new List<Keys>
            {
                Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5,
                Keys.D6, Keys.D7, Keys.D8, Keys.Z, Keys.N,
            };
        }

        /// <inheritdoc/>
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            foreach (Keys key in pressed)
            {
                if (this.dict.ContainsKey(key) && this.playerKeys.Contains(key) && this.oldState.IsKeyUp(key))
                {
                    this.playerCommands.Push(new KeyValuePair<Keys, ICommand>(key, this.dict[key]));
                }
            }

            if (this.playerCommands.Count > 0)
            {
                this.currentCommand = this.playerCommands.Peek().Value;
                this.currentCommand.Execute();

                List<ICommand> removable = new List<ICommand>();
                foreach (KeyValuePair<Keys, ICommand> command in playerCommands)
                {
                    if (state.IsKeyUp(command.Key) || this.oneUseKeys.Contains(command.Key))
                    {
                        removable.Add(command.Value);
                    }
                }

                for (int i = 0; i < removable.Count; i++)
                {
                    if (removable[i].Equals(this.playerCommands.Peek().Value))
                    {
                        this.playerCommands.Pop();
                    }
                }
                removable.Clear();
            }
            else
            {
                this.allCommands.GetIdle.Execute();
            }

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