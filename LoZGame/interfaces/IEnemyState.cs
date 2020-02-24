namespace LoZGame
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IEnemyState
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void MoveUpLeft();

        void MoveDownLeft();

        void MoveUpRight();

        void MoveDownRight();

        void TakeDamage();

        void Attack();

        void Stop();

        void Die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}