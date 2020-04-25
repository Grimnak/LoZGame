namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Death state for player.
    /// </summary>
    public class DieState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="DieState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        public DieState(IPlayer playerInstance)
        {
            player = playerInstance;
            sprite = CreateCorrectSprite();
            player.Physics.MovementVelocity = Vector2.Zero;
        }

        /// <inheritdoc/>
        public void Idle()
        {
        }

        /// <inheritdoc/>
        public void MoveUp()
        {
        }

        /// <inheritdoc/>
        public void MoveDown()
        {
        }

        /// <inheritdoc/>
        public void MoveLeft()
        {
        }

        /// <inheritdoc/>
        public void MoveRight()
        {
        }

        /// <inheritdoc/>
        public void Attack()
        {
        }

        /// <inheritdoc/>
        public void Die()
        {
        }

        /// <inheritdoc/>
        public void PickupItem(IItem item)
        {
        }

        /// <inheritdoc/>
        public void UseItem(int waitTime)
        {
        }

        /// <inheritdoc/>
        public void Stun(int stunTime)
        {
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (sprite.CurrentFrame < sprite.TotalFrames - 1)
            {
                sprite.Update();
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(player.Physics.Location, player.CurrentTint, player.Physics.Depth);
        }

        private ISprite CreateCorrectSprite()
        {
            return LinkSpriteFactory.Instance.CreateSpriteLinkDie(player.CurrentColor);
        }
    }
}