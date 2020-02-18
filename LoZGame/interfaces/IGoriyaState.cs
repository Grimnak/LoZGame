namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IGoriyaState
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void TakeDamage();

        void Die();

        void Attack();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}