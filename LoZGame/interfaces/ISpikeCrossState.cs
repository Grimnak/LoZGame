namespace LoZClone
{
    using Microsoft.Xna.Framework.Graphics;

    public interface ISpikeCrossState
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void Stop();

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}