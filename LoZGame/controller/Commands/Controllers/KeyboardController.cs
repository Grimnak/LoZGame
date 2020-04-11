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

            if (LoZGame.Instance.GameState is PlayGameState)
            {
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
                if (pressed.Contains(Keys.W) && oldState.IsKeyUp(Keys.W))
                {
                    LoZGame.Instance.Players[0].Inventory.MoveSelectionUp();
                }
                else if (pressed.Contains(Keys.A) && oldState.IsKeyUp(Keys.A))
                {
                    LoZGame.Instance.Players[0].Inventory.MoveSelectionLeft();
                }
                else if (pressed.Contains(Keys.S) && oldState.IsKeyUp(Keys.S))
                {
                    LoZGame.Instance.Players[0].Inventory.MoveSelectionDown();
                }
                else if (pressed.Contains(Keys.D) && oldState.IsKeyUp(Keys.D))
                {
                    LoZGame.Instance.Players[0].Inventory.MoveSelectionRight();
                }

                if (pressed.Contains(Keys.Enter))
                {
                    LoZGame.Instance.Players[0].Inventory.SelectItem();
                }
            }

            if (pressed.Contains(Keys.I) && this.oldState.IsKeyUp(Keys.I))
            {
                this.dict[Keys.I].Execute();
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