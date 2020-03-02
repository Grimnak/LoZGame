﻿namespace LoZClone
{
    /// <summary>
    /// Command that makes player take damage.
    /// </summary>
    public class CommandDamage : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandDamage"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandDamage(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.player.TakeDamage(0);
        }
    }
}