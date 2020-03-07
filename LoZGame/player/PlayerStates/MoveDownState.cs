namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class MoveDownState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveDownState"/> class.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="playerInstance">Instance of player.</param>
        public MoveDownState(IPlayer playerInstance)
        {
            this.player = playerInstance;
            this.player.CurrentDirection = "Down";
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
        public void PickupItem(IItem item)
        {
            this.player.State = new PickupItemState(this.player, item);
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
            this.player.State = new UseItemState(this.player, waitTime);
        }

        /// <inheritdoc/>
        public void Update()
        {
            this.player.Physics.Location = new Vector2(this.player.Physics.Location.X, this.player.Physics.Location.Y + this.player.MoveSpeed);
            this.sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveDown(this.player.CurrentColor);
        }
    }
}