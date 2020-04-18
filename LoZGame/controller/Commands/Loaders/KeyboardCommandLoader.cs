namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Loads/creates all commands into a dict with their corresponding keyboard key.
    /// </summary>
    public class KeyboardCommandLoader
    {
        private readonly CommandIdle commandIdle;
        private readonly Dictionary<Keys, ICommand> playerDictionary;
        private readonly Dictionary<Keys, ICommand> inventoryDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardCommandLoader"/> class.
        /// </summary>
        /// <param name="player">Player to pass to a command.</param>
        public KeyboardCommandLoader(IPlayer player)
        {
            this.playerDictionary = new Dictionary<Keys, ICommand>();
            this.inventoryDictionary = new Dictionary<Keys, ICommand>();

            this.commandIdle = new CommandIdle(player);

            this.playerDictionary.Add(Keys.W, new CommandUp(player));
            this.playerDictionary.Add(Keys.Up, new CommandUp(player));
            this.playerDictionary.Add(Keys.A, new CommandLeft(player));
            this.playerDictionary.Add(Keys.Left, new CommandLeft(player));
            this.playerDictionary.Add(Keys.S, new CommandDown(player));
            this.playerDictionary.Add(Keys.Down, new CommandDown(player));
            this.playerDictionary.Add(Keys.D, new CommandRight(player));
            this.playerDictionary.Add(Keys.Right, new CommandRight(player));

            this.playerDictionary.Add(Keys.Z, new CommandAttackA(player));
            this.playerDictionary.Add(Keys.N, new CommandAttackB(player));
            this.playerDictionary.Add(Keys.I, new CommandInventory());
            this.playerDictionary.Add(Keys.P, new CommandPause());

            this.playerDictionary.Add(Keys.Q, new CommandQuit());

            this.playerDictionary.Add(Keys.R, new CommandReset(player));

            this.inventoryDictionary.Add(Keys.Enter, new CommandItemSelect(player));
            this.inventoryDictionary.Add(Keys.W, new CommandSelectionUp(player));
            this.inventoryDictionary.Add(Keys.Up, new CommandSelectionUp(player));
            this.inventoryDictionary.Add(Keys.A, new CommandSelectionLeft(player));
            this.inventoryDictionary.Add(Keys.Left, new CommandSelectionLeft(player));
            this.inventoryDictionary.Add(Keys.S, new CommandSelectionDown(player));
            this.inventoryDictionary.Add(Keys.Down, new CommandSelectionDown(player));
            this.inventoryDictionary.Add(Keys.D, new CommandSelectionRight(player));
            this.inventoryDictionary.Add(Keys.Right, new CommandSelectionRight(player));
        }

        /// <summary>
        /// Gets the idle command from the loader.
        /// </summary>
        public ICommand GetIdle => this.commandIdle;

        /// <summary>
        /// Gets the dictionary containing player commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetPlayerDict => this.playerDictionary;

        /// <summary>
        /// Gets the dictionary containing inventory commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetInventoryDict => this.inventoryDictionary;
    }
}