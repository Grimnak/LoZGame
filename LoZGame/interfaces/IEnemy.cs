namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public interface IEnemy : ICollider
    {
        HealthManager Health { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an enemy has completed its death sequence.
        /// </summary>
        bool Expired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an enemy has been killed but has not necessarily completed its death sequence.
        /// </summary>
        bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an enemy is still in its spawn sequence or not.
        /// </summary>
        bool IsSpawning { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not an enemy can be killed.
        /// </summary>
        bool IsKillable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not an enemy interacts with projectiles.
        /// </summary>
        // bool IsTransparent { get; set; }

        bool HasChild { get; set; }

        int Damage { get; }

        int DamageTimer { get; set; }

        float MoveSpeed { get; set; }

        Color CurrentTint { get; set; }

        Point MinMaxWander { get; set; }

        EnemyEssentials.EnemyAI AI { get; set; }
        
        Dictionary<RandomStateGenerator.StateType, int> States { get; set; }

        IEnemyState CurrentState { get; set; }

        /// <summary>
        /// Creates sprite based on direcion in Physics.
        /// </summary>
        /// <returns>Sprite to return.</returns>
        ISprite CreateCorrectSprite();

        /// <summary>
        /// Adds a child associated with the parent enemy.
        /// </summary>
        void AddChild();

        /// <summary>
        /// Updates the child(ren) of the parent.
        /// </summary>
        void UpdateChild();

        /// <summary>
        /// Assigns immunity cooldown and deals damage to health.
        /// </summary>
        /// <param name="damageAmount">Damage to be taken.</param>

        /// <summary>
        /// Logic to randomly choose a new state.
        /// </summary>
        void UpdateState();

        void TakeDamage(int damageAmount);

        /// <summary>
        /// Sets enemy to be stunned.
        /// </summary>
        /// <param name="stunTime">Duration in ticks to be stunned for.</param>
        void Stun(int stunTime);

        /// <summary>
        /// Handles special logic for an enemy to attck
        /// </summary>
        void Attack();

        void Update();

        void Draw();
    }
}