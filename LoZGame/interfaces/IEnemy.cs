namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface IEnemy : ICollider
    {
        HealthManager Health { get; set; }

        bool Expired { get; set; }

        int Damage { get; }

        int DamageTimer { get; set; }

        int MoveSpeed { get; set; }

        Color CurrentTint { get; set; }

        IEnemyState CurrentState { get; set; }

        void TakeDamage(int damageAmount);
        
        void Update();

        void Draw();
    }
}