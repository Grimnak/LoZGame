using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class CommandR : ICommand
    {
        IPlayer player;
        ItemManager manager;
        BlockManager block;
        LoZGame game;
        ProjectileManager inventory;
        public CommandR(LoZGame game, IPlayer player, ItemManager manager, BlockManager block, ProjectileManager inventory/*, NPCManager npc*/)
        {
            this.game = game;
            this.player = player;
            this.manager = manager;
            this.block = block;
            this.inventory = inventory;
        }
        public void execute()
        {
            ((Link)player).CurrentLocation = new Vector2(400, 240);
            ((Link)player).CurrentDirection = "Down";
            ((Link)player).State = new NullState(game, player);
            ((Link)player).DamageCounter = 0;
            ((Link)player).DamageTimer = 0;
            
            manager.CurrentIndex = 1;
            manager.cycleLeft();
            manager.currentItem.location = new Vector2(300, 240);

            inventory.Clear();

            block.CurrentIndex = 1;
            block.cycleLeft();

            //TODO add npc and block defaults
        }
    }
}