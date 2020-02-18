namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemyState
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void TakeDamage();

        void Die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}