namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IKeeseState
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

        void Die();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}