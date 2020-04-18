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
        private readonly Dictionary<Keys, ICommand> playerDict;
        private readonly Dictionary<Keys, ICommand> inventoryDict;
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
            this.playerDict = allCommands.GetPlayerDict;
            this.inventoryDict = allCommands.GetInventoryDict;
            this.playerCommands = new Stack<KeyValuePair<Keys, ICommand>>();
            this.playerKeys = new List<Keys>
            {
                Keys.W, Keys.Up, Keys.A, Keys.Left, Keys.S, Keys.Down, Keys.D, Keys.Right,
                Keys.Z, Keys.N,
            };
            this.oneUseKeys = new List<Keys>
            {
                Keys.Z, Keys.N,
            };
        }

        /// <inheritdoc/>
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            Keys[] pressed = state.GetPressedKeys();

            if (LoZGame.Instance.GameState is PlayGameState)
            {
                foreach (Keys key in pressed)
                {
                    if (this.playerDict.ContainsKey(key) && this.playerKeys.Contains(key) && this.oldState.IsKeyUp(key))
                    {
                        this.playerCommands.Push(new KeyValuePair<Keys, ICommand>(key, this.playerDict[key]));
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
            }
            else if (LoZGame.Instance.GameState is TitleScreenState)
            {
                if (pressed.Contains(Keys.Enter))
                {
                    LoZGame.Instance.GameState.PlayGame();
                }
            }
            else if (LoZGame.Instance.GameState is OpenInventoryState)
            {
                foreach (Keys key in pressed)
                {
                    if (this.inventoryDict.ContainsKey(key) && this.oldState.IsKeyUp(key))
                    {
                        inventoryDict[key].Execute();
                    }
                }
            }

            if (pressed.Contains(Keys.I) && this.oldState.IsKeyUp(Keys.I))
            {
                this.playerDict[Keys.I].Execute();
            }

            if (pressed.Contains(Keys.P) && this.oldState.IsKeyUp(Keys.P))
            {
                this.playerDict[Keys.P].Execute();
            }

            if (pressed.Contains(Keys.Q))
            {
                this.playerDict[Keys.Q].Execute();
            }

            if (pressed.Contains(Keys.R))
            {
                this.playerDict[Keys.R].Execute();
            }

            this.oldState = state;
        }
    }
}