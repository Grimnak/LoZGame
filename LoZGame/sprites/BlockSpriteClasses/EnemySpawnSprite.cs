namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EnemySpawnSprite : SpriteEssentials, ISprite
    {
        public Vector2 Location { get; set; }

        public EnemySpawnSprite(Texture2D spriteTexture, SpriteData data)
        {
            this.SetUpSprite(spriteTexture, data);
        }
    }
}