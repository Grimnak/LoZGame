namespace LoZClone
{
    public class UseItemState : IPlayerState
    {
        private LoZGame game;
        private Link player;
        private ISprite sprite;
        private int lockoutTimer = 0;

        public UseItemState(LoZGame game, IPlayer playerInstance)
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
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemUp(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemDown(player.CurrentColor);
            }
            else if (player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemLeft(player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemRight(player.CurrentColor);
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
            if (lockoutTimer <= 0)
            {
                player.State = new AttackState(game, player);
            }
        }
        public void die()
        {
            player.State = new DieState(game, player);
        }
        public void pickupItem()
        {
            if (lockoutTimer <= 0)
            {
                player.State = new PickupItemState(game, player);
            }
        }
        public void useItem()
        {
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