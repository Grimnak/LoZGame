namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Moving up state for player.
    /// </summary>
    public class MoveUpState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveUpState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of player.</param>
        public MoveUpState(IPlayer playerInstance)
        {
            this.player = playerInstance;
            this.player.Physics.CurrentDirection = Physics.Direction.North;
            this.sprite = this.CreateCorrectSprite();
            this.player.Physics.MovementVelocity = new Vector2(0, -1 * this.player.MoveSpeed);
        }

        /// <inheritdoc/>
        public void Idle()
        {
            this.player.State = new IdleState(this.player);
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
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
            this.sprite.Update();
            if (this.sprite.CurrentFrame >= GameData.Instance.PlayerData.MaxFrames)
            {
                this.sprite.SetFrame(0);
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.player.Physics.Location, this.player.CurrentTint, this.player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkMoveUp(this.player.CurrentColor);
        }
    }
}