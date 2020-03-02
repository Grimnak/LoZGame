namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IItem : ICollider
    {
        void Update();

        void Draw();
    }
}