namespace LoZClone
{
    /// <summary>
    /// Item pickup state for player.
    /// </summary>
    public class PickupItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int lockoutTimer = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupItemState"/> class.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="playerInstance">Instance of player.</param>
        /// <param name="itemTime">Lifetime of item.</param>
        public PickupItemState(IPlayer playerInstance, int itemTime)
        {
            this.player = playerInstance;
            this.player.CurrentDirection = "Down";
            this.lockoutTimer = itemTime; // wait period
            this.sprite = this.CreateCorrectSprite();
        }

        /// <inheritdoc/>
        public void Idle()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new IdleState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveUpState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveDownState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveLeftState(this.player);
            }
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new MoveRightState(this.player);
            }
        }

        /// <inheritdoc/>
        public void Attack()
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new AttackState(this.player);
            }
        }

        /// <inheritdoc/>
        public void Die()
        {
            this.player.State = new DieState(this.player);
        }

        /// <inheritdoc/>
        public void PickupItem(int itemTime)
        {
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            if (this.lockoutTimer <= 0)
            {
                this.player.State = new UseItemState(this.player, waitTime);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (this.lockoutTimer > 0)
            {
                this.lockoutTimer--;
            }

            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.CurrentLocation, this.player.CurrentTint);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkPickupItem(this.player.CurrentColor);
        }
    }
}