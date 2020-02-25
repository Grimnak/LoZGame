namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemy : ICollider
    {
        void TakeDamage();

        void Die();

        void Update();

        void Draw();
    }
}