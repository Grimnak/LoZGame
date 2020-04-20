namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Interface for a player character.
    /// </summary>
    public interface IPlayer : ICollider
    {
        /// <summary>
        /// Gets or sets the current state of the player.
        /// </summary>
        IPlayerState State { get; set; }

        HealthManager Health { get; set; }

        InventoryManager Inventory { get; set; }

        /// <summary>
        /// Gets or sets the current weapon of the player.
        /// </summary>
        Link.LinkWeapon CurrentWeapon { get; set; }

        /// <summary>
        /// Gets or sets the current color of the player.
        /// </summary>
        Link.LinkColor CurrentColor { get; set; }

        /// <summary>
        /// Gets or sets the current tint of the player.
        /// </summary>
        Color CurrentTint { get; set; }

        /// <summary>
        /// Gets or sets the current speed of the player.
        /// </summary>
        float MoveSpeed { get; set; }

        /// <summary>
        /// Gets or sets the damage timer of the player.
        /// </summary>
        int DamageTimer { get; set; }

        /// <summary>
        /// Gets or sets the disarm timer of the player.
        /// </summary>
        int DisarmedTimer { get; set; }

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
        /// /// <param name ="damageAmount">Amount of damage incurred.</param>
        void TakeDamage(int damageAmount);

        /// <summary>
        /// Makes player attack.
        /// </summary>
        void Attack();

        /// <summary>
        /// Makes player pickup an item.
        /// </summary>
        /// <param name ="item">Item that was picked up by the item.</param>
        void PickupItem(IItem item);

        /// <summary>
        /// Makes player use an item.
        /// </summary>
        /// <param name ="waitTime">Time for the player to wait.</param>
        void UseItem(int waitTime);

        /// <summary>
        /// Makes the player become stunned for a period of time.
        /// </summary>
        /// <param name="stunTime">The amount of time the player remains immobile.</param>
        void Stun(int stunTime);

        /// <summary>
        /// Updates the player.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the player's current sprite.
        /// </summary>
        void Draw();
    }
}