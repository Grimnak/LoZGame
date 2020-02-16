namespace LoZClone
{
    public class AttackState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;
        private int lockoutTimer = 0;

        public AttackState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = (Link)playerInstance;
            lockoutTimer = 15; //wait period
            sprite = createCorrectSprite();
        }
        private ISprite createCorrectSprite()
        {
            if (player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackUp(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackDown(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.createSpriteLinkAttackRight(player.CurrentColor);
            }
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
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem(int itemTime)
        {
            if (lockoutTimer <= 0)
            {
                player.State = new PickupItemState(game, player, itemTime);
            }
        }
        public void useItem()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new UseItemState(game, player);
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
