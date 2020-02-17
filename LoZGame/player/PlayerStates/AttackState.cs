namespace LoZClone
{
    public class AttackState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        public AttackState(LoZGame game, IPlayer playerInstance)
        {
            this.game = game;
            this.player = playerInstance;
            this.lockoutTimer = 15; // wait period
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            if (this.player.CurrentDirection.Equals("Up"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackUp(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else if (this.player.CurrentDirection.Equals("Down"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackDown(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else if (this.player.CurrentDirection.Equals("Left"))
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackLeft(this.player.CurrentColor, this.player.CurrentWeapon);
            }
            else
            {
                return LinkSpriteFactory.Instance.CreateSpriteLinkAttackRight(this.player.CurrentColor, this.player.CurrentWeapon);
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
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new UseItemState(this.game, this.player, waitTime);
            }
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
