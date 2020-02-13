namespace LoZClone
{
    public class CommandOne : ICommand
    {
        IPlayer player;
        IItemSprite bomb;
        public CommandOne(IPlayer player/*InventoryManager manager*/)
        {
            this.player = player;
        }
        public void execute()
        {

            //player.useItemAnimation2();
            bomb = new Bomb(ItemSpriteFactory.Instance.SpriteSheet, ((Link)player).CurrentLocation, ((Link)player).CurrentDirection, ItemSpriteFactory.Instance.Scale);
        }
    }
}