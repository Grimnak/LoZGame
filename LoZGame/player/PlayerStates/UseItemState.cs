namespace LoZClone
{
    public class UseItemState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        public UseItemState(LoZGame game, IPlayer playerInstance, int waitTime)
        {
            this.game = game;
            this.player = playerInstance;
            this.lockoutTimer = waitTime; //wait period
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            if (this.player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemUp(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemDown(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemLeft(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.createSpriteLinkUseItemRight(this.player.CurrentColor);
            }
        }

        public void idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new IdleState(this.game, this.player);
            }
        }

        public void moveUp()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveUpState(this.game, this.player);
            }
        }

        public void moveDown()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveDownState(this.game, this.player);
            }
        }

        public void moveLeft()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveLeftState(this.game, this.player);
            }
        }

        public void moveRight()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveRightState(this.game, this.player);
            }
        }

        public void attack()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new AttackState(this.game, this.player);
            }
        }

        public void die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void pickupItem(int itemTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new PickupItemState(this.game, this.player, itemTime);
            }
        }

        public void useItem(int waitTime)
        {
        }

        public void Update()
        {
            if (this.lockoutTimer > 0)
            {
                this.lockoutTimer--;
            }

            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.game.SpriteBatch, this.player.CurrentLocation, this.player.CurrentTint);
        }
    }
}