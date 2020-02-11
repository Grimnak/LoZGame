using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class CommandR : ICommand
    {
        IPlayer player;
        ItemManager manager;
        LoZGame game;
        public CommandR(LoZGame game, IPlayer player, ItemManager manager/*, NPCManager npc*/)
        {
            this.game = game;
            this.player = player;
            this.manager = manager;
        }
        public void execute()
        {
            ((Link)player).CurrentLocation = new Vector2(150, 200);
            ((Link)player).CurrentDirection = "Down";
            ((Link)player).State = new NullState(game, player);
            
            manager.CurrentIndex = 1;
            manager.cycleLeft();

            //TODO add npc and block defaults
        }
    }
}