using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class CommandR : ICommand
    {
        IPlayer player;
        ItemManager manager;
        BlockManager block;
        LoZGame game;
        public CommandR(LoZGame game, IPlayer player, ItemManager manager, BlockManager block/*, NPCManager npc*/)
        {
            this.game = game;
            this.player = player;
            this.manager = manager;
            this.block = block;
        }
        public void execute()
        {
            ((Link)player).CurrentLocation = new Vector2(150, 200);
            ((Link)player).CurrentDirection = "Down";
            ((Link)player).State = new NullState(game, player);
            
            manager.CurrentIndex = 1;
            manager.cycleLeft();
            manager.currentItem.location = new Vector2(120, 120);

            block.CurrentIndex = 1;
            block.cycleLeft();

            //TODO add npc and block defaults
        }
    }
}