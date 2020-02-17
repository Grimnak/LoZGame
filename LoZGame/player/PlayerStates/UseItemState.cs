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
            this.lockoutTimer = waitTime; // wait period
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            if (this.player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemUp(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemDown(this.player.CurrentColor);
            }
            else if (this.player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemLeft(this.player.CurrentColor);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkUseItemRight(this.player.CurrentColor);
            }
        }

        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new IdleState(this.game, this.player);
            }
        }

        public void MoveUp()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveUpState(this.game, this.player);
            }
        }

        public void MoveDown()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveDownState(this.game, this.player);
            }
        }

        public void MoveLeft()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveLeftState(this.game, this.player);
            }
        }

        public void MoveRight()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveRightState(this.game, this.player);
            }
        }

        public void Attack()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new AttackState(this.game, this.player);
            }
        }

        public void Die()
        {
            this.player.State = new DieState(this.game, this.player);
        }

        public void PickupItem(int itemTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new PickupItemState(this.game, this.player, itemTime);
            }
        }

        public void UseItem(int waitTime)
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