namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IItemSprite
    {
        SpriteSheetData SpriteData { get; }

        void Update();

        void Draw(Vector2 location, Color spritetint, float layer);
    }
}