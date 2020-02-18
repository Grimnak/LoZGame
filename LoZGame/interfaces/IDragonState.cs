namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IDragonState
    {
        void MoveLeft();

        void MoveRight();

        void Attack();

        void Stop();

        void TakeDamage();

        void Die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}