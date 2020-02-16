using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class CommandReset : ICommand
    {
        IPlayer player;
        ItemManager item;
        BlockManager block;
        LoZGame game;
        EntityManager entity;
        private static int priority = -1;
        public CommandReset(LoZGame game, IPlayer player, ItemManager item, BlockManager block, EntityManager entity/*, NPCManager npc*/)
        {
            this.game = game;
            this.player = player;
            this.item = item;
            this.block = block;
            this.entity = entity;
        }
        public void execute()
        {
            ((Link)player).CurrentLocation = new Vector2(218, 184);
            ((Link)player).CurrentDirection = "Down";
            ((Link)player).State = new NullState(game, player);
            ((Link)player).DamageCounter = 0;
            ((Link)player).DamageTimer = 0;
            ((Link)player).IsDead = false;
            ((Link)player).CurrentTint = Color.White;
            
            item.CurrentIndex = 1;
            item.cycleLeft();
            item.currentItem.location = new Vector2(384, 184);

            entity.Clear();

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