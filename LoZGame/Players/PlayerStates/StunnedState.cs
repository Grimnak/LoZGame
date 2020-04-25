namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Immobilized state for player when hit by a boomerang.
    /// </summary>
    public class StunnedState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly IPlayerState oldState;
        private Vector2 oldVelocity;
        private int stunDuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="StunnedState"/> class.
        /// </summary>
        /// <param name="playerInstance">Instance of the player.</param>
        /// <param name="oldState">The state the player was in prior to being stunned.</param>
        /// <param name="stunTime">The amount of time the player is stunned.</param>
        public StunnedState(IPlayer playerInstance, IPlayerState oldState, int stunTime)
        {
            player = playerInstance;
            this.oldState = oldState;
            oldVelocity = player.Physics.MovementVelocity;
            player.Physics.MovementVelocity = Vector2.Zero;
            stunDuration = stunTime;
            player.CurrentTint = LoZGame.Instance.DefaultTint;
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
            player.State = new DieState(player);
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
            stunDuration = stunTime;
        }

        /// <inheritdoc/>
        public void Update()
        {
            stunDuration--;
            if (stunDuration <= 0)
            {
                player.Physics.MovementVelocity = oldVelocity;
                player.State = oldState;
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            oldState.Draw();
        }
    }
}