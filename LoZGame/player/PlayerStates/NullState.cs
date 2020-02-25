namespace LoZClone
{
    /// <summary>
    /// Null state for player.
    /// </summary>
    public class NullState : IPlayerState
    {
        private readonly IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullState"/> class.
        /// </summary>
        /// <param name="game">Current game.</param>
        /// <param name="playerInstance">Instance of player.</param>
        public NullState(IPlayer playerInstance)
        {
            this.player = playerInstance;
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
        }

        /// <inheritdoc/>
        public void Draw()
        {
        }
    }
}