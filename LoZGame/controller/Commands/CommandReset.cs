﻿using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class CommandReset : ICommand
    {
        IPlayer player;
        ItemManager manager;
        BlockManager block;
        LoZGame game;
        ProjectileManager inventory;
        private static int priority = -1;
        public CommandReset(LoZGame game, IPlayer player, ItemManager manager, BlockManager block, ProjectileManager inventory/*, NPCManager npc*/)
        {
            this.game = game;
            this.player = player;
            this.manager = manager;
            this.block = block;
            this.inventory = inventory;
        }
        public void execute()
        {
            ((Link)player).CurrentLocation = new Vector2(150, 200);
            ((Link)player).CurrentDirection = "Down";
            ((Link)player).State = new NullState(game, player);
            ((Link)player).DamageCounter = 0;
            ((Link)player).DamageTimer = 0;
            ((Link)player).IsDead = false;
            
            manager.CurrentIndex = 1;
            manager.cycleLeft();
            manager.currentItem.location = new Vector2(120, 120);

            inventory.Clear();

            block.CurrentIndex = 1;
            block.cycleLeft();

            //TODO add npc defaults
        }
        public int Priority
        {
            get { return priority; }
        }
    }
}