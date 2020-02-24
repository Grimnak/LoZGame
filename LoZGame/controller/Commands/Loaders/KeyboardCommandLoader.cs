namespace LoZGame
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
        /// <param name="game">Game to pass to a command.</param>
        /// <param name="player">Player to pass to a command.</param>
        /// <param name="item">Item manager to pass to a command.</param>
        /// <param name="block">Block manager to pass to a command.</param>
        /// <param name="entity">Entity manager to pass to a command.</param>
        /// <param name="enemy">Enemy manager to pass to a command.</param>
        public KeyboardCommandLoader(LoZGame game, IPlayer player, ItemManager item, BlockManager block, EntityManager entity, EnemyManager enemy)
        {
            this.dictionary = new Dictionary<Keys, ICommand>();

            this.commandIdle = new CommandIdle(player);

            this.dictionary.Add(Keys.W, new CommandUp(player));
            this.dictionary.Add(Keys.A, new CommandLeft(player));
            this.dictionary.Add(Keys.S, new CommandDown(player));
            this.dictionary.Add(Keys.D, new CommandRight(player));

            this.dictionary.Add(Keys.Z, new CommandAttackA(player, entity));
            this.dictionary.Add(Keys.N, new CommandAttackB(player, entity));

            this.dictionary.Add(Keys.E, new CommandDamage(player));

            this.dictionary.Add(Keys.D1, new CommandBomb(player, entity));
            this.dictionary.Add(Keys.D2, new CommandArrow(player, entity));
            this.dictionary.Add(Keys.D3, new CommandBoomerang(player, entity));
            this.dictionary.Add(Keys.D4, new CommandBlueCandle(player, entity));
            this.dictionary.Add(Keys.D5, new CommandSilverArrow(player, entity));
            this.dictionary.Add(Keys.D6, new CommandMagicBoomerang(player, entity));
            this.dictionary.Add(Keys.D7, new CommandRedCandle(player, entity));
            this.dictionary.Add(Keys.D8, new CommandTriforce(player, entity));

            this.dictionary.Add(Keys.U, new CommandItemLeft(item));
            this.dictionary.Add(Keys.I, new CommandItemRight(item));

            this.dictionary.Add(Keys.K, new CommandBlockLeft(block));
            this.dictionary.Add(Keys.L, new CommandBlockRight(block));

            this.dictionary.Add(Keys.O, new CommandEnemyLeft(enemy));
            this.dictionary.Add(Keys.P, new CommandEnemyRight(enemy));

            this.dictionary.Add(Keys.Q, new CommandQuit(game));

            this.dictionary.Add(Keys.R, new CommandReset(game, player, item, block, entity, enemy));
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