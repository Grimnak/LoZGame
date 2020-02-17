namespace LoZClone
{
    public class PickupItemState : IPlayerState
    {
        private readonly LoZGame game;
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        public PickupItemState(LoZGame game, IPlayer playerInstance, int itemTime)
        {
            this.game = game;
            this.player = playerInstance;
            this.player.CurrentDirection = "Down";
            this.lockoutTimer = itemTime; // wait period
            this.sprite = this.createCorrectSprite();
        }

        private ISprite createCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkPickupItem(this.player.CurrentColor);
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