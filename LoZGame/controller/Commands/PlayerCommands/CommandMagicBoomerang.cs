﻿namespace LoZClone
{
    /// <summary>
    /// Command that makes player throw a magic boomerang.
    /// </summary>
    public class CommandMagicBoomerang : ICommand
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMagicBoomerang"/> class.
        /// </summary>
        /// <param name="player">Player to execute a command on.</param>
        public CommandMagicBoomerang(IPlayer player)
        {
            this.player = player;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (!LoZGame.Instance.Entities.ProjectileManager.BoomerangOut && !(this.player.State is DieState || this.player.State is PickupItemState))
            {
                this.player.UseItem(ProjectileManager.MaxWaitTime);
                LoZGame.Instance.Entities.ProjectileManager.AddItem(LoZGame.Instance.Entities.ProjectileManager.MagicBoomerang, this.player);
            }
        }
    }
}