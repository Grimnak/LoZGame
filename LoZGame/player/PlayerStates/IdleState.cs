namespace LoZClone
{
    /// <summary>
    /// Idle state for player.
    /// </summary>
    public class IdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdleState"/> class.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="playerInstance">Instance of player.</param>
        public IdleState(IPlayer playerInstance)
        {
            this.player = playerInstance;
            this.sprite = this.CreateCorrectSprite();
        }

        /// <inheritdoc/>
        public void Idle()
        {
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
            this.player.State = new MoveUpState(this.player);
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
            this.player.State = new MoveDownState(this.player);
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
            this.player.State = new MoveLeftState(this.player);
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
            this.player.State = new MoveRightState(this.player);
        }

        /// <inheritdoc/>
        public void Attack()
        {
            this.player.State = new AttackState(this.player);
        }

        /// <inheritdoc/>
        public void Die()
        {
            this.player.State = new DieState(this.player);
        }

        /// <inheritdoc/>
        public void PickupItem(int itemTime)
        {
            this.player.State = new PickupItemState(this.player, itemTime);
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            this.player.State = new UseItemState(this.player, waitTime);
        }

        /// <inheritdoc/>
        public void Update()
        {
            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint);
        }

        private ISprite CreateCorrectSprite()
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
    }
}