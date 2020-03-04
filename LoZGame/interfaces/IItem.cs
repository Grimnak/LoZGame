namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IItem : ICollider
    {
        bool Expired { get; set; }

        void Update();

        void Draw(Color spriteTint);
    }
}