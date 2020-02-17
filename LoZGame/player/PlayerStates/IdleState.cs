namespace LoZClone
{
    public class IdleState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public IdleState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            if (this.player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkIdleUp(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkIdleDown(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkIdleLeft(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkIdleRight(this.player.CurrentColor);
            }
        }

        public void idle()
        {
        }

        public void moveUp()
        {
            this.player.State = new MoveUpState(this.game, this.player);
        }

        public void moveDown()
        {
            this.player.State = new MoveDownState(this.game, this.player);
        }

        public void moveLeft()
        {
            this.player.State = new MoveLeftState(this.game, this.player);
        }

        public void moveRight()
        {
            this.player.State = new MoveRightState(this.game, this.player);
        }

        public void attack()
        {
            this.player.State = new AttackState(this.game, this.player);
        }

        public void die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void pickupItem(int itemTime)
        {
            this.player.State = new PickupItemState(this.game, this.player, itemTime);
        }

        public void useItem(int waitTime)
        {
            this.player.State = new UseItemState(this.game, this.player, waitTime);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}