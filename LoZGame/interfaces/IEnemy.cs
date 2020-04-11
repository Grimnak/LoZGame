namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public interface IEnemy : ICollider
    {
        HealthManager Health { get; set; }

        bool Expired { get; set; }

        int Damage { get; }

        int DamageTimer { get; set; }

        float MoveSpeed { get; set; }

        Color CurrentTint { get; set; }
        
        Dictionary<RandomStateGenerator.StateType, int> States { get; set; }

        IEnemyState CurrentState { get; set; }

        /// <summary>
        /// Creates sprite based on direcion in Physics.
        /// </summary>
        /// <returns>Sprite to return</returns>
        ISprite CreateCorrectSprite();

        /// <summary>
        /// Adds a child associated with the parent enemy
        /// </summary>
        void AddChild();

        /// <summary>
        /// Updates the child(ren) of the parent.
        /// </summary>
        void UpdateChild();

        /// <summary>
        /// Assigns immunity cooldown and deals damage to health.
        /// </summary>
        /// <param name="damageAmount">Damage to be taken</param>

        /// <summary>
        /// Logic to randomly choose a new state.
        /// </summary>
        void UpdateState();
        void TakeDamage(int damageAmount);

        /// <summary>
        /// Sets enemy to be stunned.
        /// </summary>
        /// <param name="stunTime">Duration in ticks to be stunned for</param>
        void Stun(int stunTime);

        void Update();

        void Draw();
    }
}