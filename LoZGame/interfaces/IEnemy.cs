namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemy : ICollider
    {
        HealthManager Health { get; set; }

        int Damage { get; }

        IEnemyState CurrentState { get; set; }

        void TakeDamage(int damageAmount);
        
        void Update();

        void Draw();
    }
}