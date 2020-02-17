﻿namespace LoZClone
{
    public class CommandAttackA : ICommand
    {
        IPlayer player;
        EntityManager entity;
        private static int priority = 7;
        public CommandAttackA(IPlayer player, EntityManager entity)
        {
            this.player = player;
            this.entity = entity;
        }
        public void execute()
        {
            if (!player.IsDead)
            {
                player.attack();
                entity.ProjectileManager.addItem(entity.ProjectileManager.Swordbeam, player);
            }
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}