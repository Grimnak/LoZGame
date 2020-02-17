namespace LoZClone
{
    public class IdleState : IPlayerState
    {
        private LoZGame game;
        private IPlayer player;
        private ISprite sprite;

        public IdleState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            if (player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkIdleUp(player.CurrentColor);
            } else if (player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkIdleDown(player.CurrentColor);
            } else if (player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkIdleLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.createSpriteLinkIdleRight(player.CurrentColor);
            }
        }
        public void idle()
        {
        }
        public void moveUp()
        {
            player.State = new MoveUpState(game, player);
        }
        public void moveDown()
        {
            player.State = new MoveDownState(game, player);
        }
        public void moveLeft()
        {
            player.State = new MoveLeftState(game, player);
        }
        public void moveRight()
        {
            player.State = new MoveRightState(game, player);
        }
        public void attack()
        {
            player.State = new AttackState(game, player);
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem(int itemTime)
        {
            player.State = new PickupItemState(game, player, itemTime);
        }
        public void useItem(int waitTime)
        {
            player.State = new UseItemState(game, player, waitTime);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}