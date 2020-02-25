namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Right moving state for player.
    /// </summary>
    public class MoveRightState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveRightState"/> class.
        /// </summary>
        /// <param name="game">Current Game.</param>
        /// <param name="playerInstance">Instance of player.</param>
        public MoveRightState(IPlayer playerInstance)
        {
            this.player = playerInstance;
            this.player.CurrentDirection = "Right";
            this.sprite = this.CreateCorrectSprite();
        }

        /// <inheritdoc/>
        public void Idle()
        {
            this.player.State = new IdleState(this.player);
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
            this.player.CurrentLocation = new Vector2(this.player.CurrentLocation.X + this.player.CurrentSpeed, this.player.CurrentLocation.Y);
            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.CurrentLocation, this.player.CurrentTint);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveRight(this.player.CurrentColor);
        }
    }
}