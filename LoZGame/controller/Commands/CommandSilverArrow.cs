﻿namespace LoZClone
{
    public class CommandSilverArrow : ICommand
    {
        readonly IPlayer player;
        readonly EntityManager entity;
        private static readonly int PriorityValue = 5;

        public CommandSilverArrow(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }

        public void execute()
        {
            if (!this.player.IsDead)
            {
                this.player.useItem(ProjectileManager.MaxWaitTime);
                this.entity.ProjectileManager.AddItem(this.entity.ProjectileManager.SilverArrow, this.player);
            }
        }

        public int Priority => PriorityValue;
    }
}