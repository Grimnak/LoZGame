namespace LoZClone
{
    public class PickupItemState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;
        private int lockoutTimer = 0;

        public PickupItemState(LoZGame game, IPlayer playerInstance, int itemTime)
        {
            this.game = game;
            this.player = (Link)playerInstance;
            this.player.CurrentDirection = "Down";
            lockoutTimer = itemTime; //wait period
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.createSpriteLinkPickupItem(player.CurrentColor);
        }
        public void idle()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new IdleState(game, player);
            }
        }
        public void moveUp()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveUpState(game, player);
            }
        }
        public void moveDown()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveDownState(game, player);
            }
        }
        public void moveLeft()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveLeftState(game, player);
            }
        }
        public void moveRight()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new MoveRightState(game, player);
            }
        }
        public void attack()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new AttackState(game, player);
            }
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem(int itemTime)
        {
        }
        public void useItem(int waitTime)
        {
            if (lockoutTimer <= 0)
            {
                player.State = new UseItemState(game, player, waitTime);
            }
        }
        public void Update()
        {
            if (lockoutTimer > 0)
            {
                lockoutTimer--;
            }
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(game.SpriteBatch, player.CurrentLocation, player.CurrentTint);
        }
    }
}