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
        private readonly Dictionary<Keys, ICommand> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardCommandLoader"/> class.
        /// </summary>
        /// <param name="player">Player to pass to a command.</param>
        public KeyboardCommandLoader(IPlayer player)
        {
            this.dictionary = new Dictionary<Keys, ICommand>();

            this.commandIdle = new CommandIdle(player);

            this.dictionary.Add(Keys.W, new CommandUp(player));
            this.dictionary.Add(Keys.Up, new CommandUp(player));
            this.dictionary.Add(Keys.A, new CommandLeft(player));
            this.dictionary.Add(Keys.Left, new CommandLeft(player));
            this.dictionary.Add(Keys.S, new CommandDown(player));
            this.dictionary.Add(Keys.Down, new CommandDown(player));
            this.dictionary.Add(Keys.D, new CommandRight(player));
            this.dictionary.Add(Keys.Right, new CommandRight(player));

            this.dictionary.Add(Keys.Z, new CommandAttackA(player));
            this.dictionary.Add(Keys.N, new CommandAttackB(player));
            this.dictionary.Add(Keys.I, new CommandInventory());

            this.dictionary.Add(Keys.D1, new CommandBomb(player));
            this.dictionary.Add(Keys.D2, new CommandArrow(player));
            this.dictionary.Add(Keys.D3, new CommandBoomerang(player));
            this.dictionary.Add(Keys.D4, new CommandBlueCandle(player));
            this.dictionary.Add(Keys.D5, new CommandSilverArrow(player));
            this.dictionary.Add(Keys.D6, new CommandMagicBoomerang(player));
            this.dictionary.Add(Keys.D7, new CommandRedCandle(player));

            this.dictionary.Add(Keys.Q, new CommandQuit());

            this.dictionary.Add(Keys.R, new CommandReset(player));
        }

        /// <summary>
        /// Gets the idle command from the loader.
        /// </summary>
        public ICommand GetIdle => this.commandIdle;

        /// <summary>
        /// Gets the dictionary containing commands from the loader.
        /// </summary>
        public Dictionary<Keys, ICommand> GetDict => this.dictionary;
    }
}