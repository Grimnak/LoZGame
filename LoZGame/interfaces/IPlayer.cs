namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Interface for a player character.
    /// </summary>
    public interface IPlayer : ICollider
    {
        /// <summary>
        /// Sets the players state.
        /// </summary>
        IPlayerState State { set; }

        /// <summary>
        /// Gets or sets the current weapon of the player.
        /// </summary>
        string CurrentWeapon { get; set; }

        /// <summary>
        /// Gets or sets the current color of the player.
        /// </summary>
        string CurrentColor { get; set; }

        /// <summary>
        /// Gets or sets the current direction of the player.
        /// </summary>
        string CurrentDirection { get; set; }

        /// <summary>
        /// Gets or sets the current location of the player.
        /// </summary>
        Vector2 CurrentLocation { get; set; }

        /// <summary>
        /// Gets or sets the current tint of the player.
        /// </summary>
        Color CurrentTint { get; set; }

        /// <summary>
        /// Gets or sets the current speed of the player.
        /// </summary>
        int CurrentSpeed { get; set; }

        /// <summary>
        /// Gets or sets the damage counter of the player.
        /// </summary>
        int DamageCounter { get; set; }

        /// <summary>
        /// Gets or sets the damage timer of the player.
        /// </summary>
        int DamageTimer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is or isn't dead.
        /// </summary>
        bool IsDead { get; set; }

        /// <summary>
        /// Makes player idle.
        /// </summary>
        void Idle();

        /// <summary>
        /// Moves player up.
        /// </summary>
        void MoveUp();

        /// <summary>
        /// Moves player down.
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Moves player left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Moves player right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Makes player take damage.
        /// </summary>
        void TakeDamage();

        /// <summary>
        /// Makes player attack.
        /// </summary>
        void Attack();

        /// <summary>
        /// Makes player pickup an item.
        /// </summary>
        /// <param name ="itemTime">Time for the item to expire.</param>
        void PickupItem(int itemTime);

        /// <summary>
        /// Makes player use an item.
        /// </summary>
        /// <param name ="waitTime">Time for the player to wait.</param>
        void UseItem(int waitTime);

        /// <summary>
        /// Updates the player.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the players current sprite.
        /// </summary>
        void Draw();
    }
}