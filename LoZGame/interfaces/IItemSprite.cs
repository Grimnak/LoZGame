namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IItemSprite : ICollider
    {
        void Update();

        void Draw();
    }
}