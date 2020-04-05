namespace LoZClone
{
    /// <summary>
    /// Player state interface.
    /// </summary>
    public interface IPlayerState
    {
        /// <summary>
        /// Transitions state to idle.
        /// </summary>
        void Idle();

        /// <summary>
        /// Transitions state to moving up.
        /// </summary>
        void MoveUp();

        /// <summary>
        /// Transitions state to moving down.
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Transitions state to moving left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Transitions state to moveing right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Transitions state to attack.
        /// </summary>
        void Attack();

        /// <summary>
        /// Transitions state to die.
        /// </summary>
        void Die();

        /// <summary>
        /// Transitions state to picking up an item.
        /// </summary>
        /// <param name="item">Item that player is picking up.</param>
        void PickupItem(IItem item);

        /// <summary>
        /// Transitions state to using an item.
        /// </summary>
        /// <param name="waitTime">Life time of the item.</param>
        void UseItem(int waitTime);

        /// <summary>
        /// Transitions state to becoming stunned for a period of time.
        /// </summary>
        /// <param name="stunTime">The amount of time the player remains immobile.</param>
        void Stun(int stunTime);

        /// <summary>
        /// Updates the state.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the correct state sprite.
        /// </summary>
        void Draw();
    }
}