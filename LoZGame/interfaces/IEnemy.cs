namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemy : ICollider
    {
        int Health { get; set; }

        void TakeDamage();

        void Die();

        void Update();

        void Draw();
    }
}