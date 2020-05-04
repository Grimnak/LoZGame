namespace LoZClone
{
    using System.Collections.Generic;
    using LoZClone;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Loads/creates all commands into a dict with their corresponding keyboard key.
    /// </summary>
    public class KeyboardCommandLoader
    {
        private readonly CommandIdle commandIdle;
        private readonly CommandContinue commandContinue;
        private readonly Dictionary<Keys, ICommand> playerDictionary;
        private readonly Dictionary<Keys, ICommand> inventoryDictionary;
        private readonly Dictionary<Keys, ICommand> optionsDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardCommandLoader"/> class.
        /// </summary>
        /// <param name="player">Player to pass to a command.</param>
        public KeyboardCommandLoader(IPlayer player)
        {
            playerDictionary = new Dictionary<Keys, ICommand>();
            inventoryDictionary = new Dictionary<Keys, ICommand>();
            optionsDictionary = new Dictionary<Keys, ICommand>();

            commandIdle = new CommandIdle(player);
            commandContinue = new CommandContinue(player);

            playerDictionary.Add(Keys.W, new CommandUp(player)); 
            playerDictionary.Add(Keys.Up, new CommandUp(player));
            playerDictionary.Add(Keys.A, new CommandLeft(player));
            playerDictionary.Add(Keys.Left, new CommandLeft(player));
            playerDictionary.Add(Keys.S, new CommandDown(player));
            playerDictionary.Add(Keys.Down, new CommandDown(player));
            playerDictionary.Add(Keys.D, new CommandRight(player));
            playerDictionary.Add(Keys.Right, new CommandRight(player));

            playerDictionary.Add(Keys.Z, new CommandAttackA(player));
            playerDictionary.Add(Keys.N, new CommandAttackB(player));
            playerDictionary.Add(Keys.I, new CommandInventory());
            playerDictionary.Add(Keys.P, new CommandPause());
            playerDictionary.Add(Keys.O, new CommandOptions());

            playerDictionary.Add(Keys.Q, new CommandQuit());

            playerDictionary.Add(Keys.R, new CommandReset(player));

            inventoryDictionary.Add(Keys.W, new CommandSelectionUp(player));
            inventoryDictionary.Add(Keys.Up, new CommandSelectionUp(player));
            inventoryDictionary.Add(Keys.A, new CommandSelectionLeft(player));
            inventoryDictionary.Add(Keys.Left, new CommandSelectionLeft(player));
            inventoryDictionary.Add(Keys.S, new CommandSelectionDown(player));
            inventoryDictionary.Add(Keys.Down, new CommandSelectionDown(player));
            inventoryDictionary.Add(Keys.D, new CommandSelectionRight(player));
            inventoryDictionary.Add(Keys.Right, new CommandSelectionRight(player));

            optionsDictionary.Add(Keys.W, new CommandMoveOptionUp());
            optionsDictionary.Add(Keys.Up, new CommandMoveOptionUp());
            optionsDictionary.Add(Keys.S, new CommandMoveOptionDown());
            optionsDictionary.Add(Keys.Down, new CommandMoveOptionDown());
            optionsDictionary.Add(Keys.Enter, new CommandToggleOption());

        }

        /// <summary>
        /// Gets the idle command from the loader.
        /// </summary>
        public ICommand GetIdle => commandIdle;

        /// <summary>
        /// Gets the continue command from the loader.
        /// </summary>
        public ICommand GetContinue => commandContinue;

        /// <summary>
        /// Gets the dictionary containing player commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetPlayerDict => playerDictionary;

        /// <summary>
        /// Gets the dictionary containing inventory commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetInventoryDict => inventoryDictionary;

        /// <summary>
        /// Gets the dictionary containing options commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetOptionsDict => optionsDictionary;
    }
}