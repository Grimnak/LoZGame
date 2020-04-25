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
        private readonly Dictionary<Keys, ICommand> optionsDict;
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
            oldState = Keyboard.GetState();
            playerDict = allCommands.GetPlayerDict;
            inventoryDict = allCommands.GetInventoryDict;
            optionsDict = allCommands.GetOptionsDict;
            playerCommands = new Stack<KeyValuePair<Keys, ICommand>>();
            playerKeys = new List<Keys>
            {
                Keys.W, Keys.Up, Keys.A, Keys.Left, Keys.S, Keys.Down, Keys.D, Keys.Right,
                Keys.Z, Keys.N,
            };
            oneUseKeys = new List<Keys>
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
                    if (playerDict.ContainsKey(key) && playerKeys.Contains(key) && oldState.IsKeyUp(key))
                    {
                        playerCommands.Push(new KeyValuePair<Keys, ICommand>(key, playerDict[key]));
                    }
                }

                if (playerCommands.Count > 0)
                {
                    currentCommand = playerCommands.Peek().Value;
                    currentCommand.Execute();

                    List<ICommand> removable = new List<ICommand>();
                    foreach (KeyValuePair<Keys, ICommand> command in playerCommands)
                    {
                        if (state.IsKeyUp(command.Key) || oneUseKeys.Contains(command.Key))
                        {
                            removable.Add(command.Value);
                        }
                    }

                    for (int i = 0; i < removable.Count; i++)
                    {
                        if (removable[i].Equals(playerCommands.Peek().Value))
                        {
                            playerCommands.Pop();
                        }
                    }
                    removable.Clear();
                }
                else
                {
                    allCommands.GetIdle.Execute();
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
                    if (inventoryDict.ContainsKey(key) && oldState.IsKeyUp(key))
                    {
                        inventoryDict[key].Execute();
                    }
                }
            }
            else if (LoZGame.Instance.GameState is OptionsState)
            {
                foreach (Keys key in pressed)
                {
                    if (optionsDict.ContainsKey(key) && oldState.IsKeyUp(key))
                    {
                        optionsDict[key].Execute();
                    }
                }
            }
            else if (LoZGame.Instance.GameState is DeathState)
            {
                if (pressed.Contains(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
                {
                    allCommands.GetContine.Execute();
                }
            }

            if (pressed.Contains(Keys.O) && oldState.IsKeyUp(Keys.O))
            {
                playerDict[Keys.O].Execute();
            }

            if (pressed.Contains(Keys.I) && oldState.IsKeyUp(Keys.I))
            {
                playerDict[Keys.I].Execute();
            }

            if (pressed.Contains(Keys.P) && oldState.IsKeyUp(Keys.P))
            {
                playerDict[Keys.P].Execute();
            }

            if (pressed.Contains(Keys.Q))
            {
                playerDict[Keys.Q].Execute();
            }

            if (pressed.Contains(Keys.R))
            {
                playerDict[Keys.R].Execute();
            }

            oldState = state;
        }
    }
}