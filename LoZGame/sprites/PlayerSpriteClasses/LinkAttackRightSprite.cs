namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LinkAttackRightSprite : SpriteEssentials, ISprite
    {
        private readonly Texture2D linkSprite;
        private readonly int linkSpriteRows;
        private readonly int linkSpriteColumns;
        private readonly int linkSpriteWidth;
        private readonly int linkSpriteHeight;
        private readonly int linkFrame = 2;
        private Vector2 itemOffset = new Vector2(3, 29);

        private int frameDelay = 0;
        private readonly int frameDelayMax = 5;
        private int counter = 0;

        public LinkAttackRightSprite(Texture2D linkTexture, SpriteData linkData)
        {
            this.linkSprite = linkTexture;
            this.linkSpriteRows = linkData.Rows;
            this.linkSpriteColumns = linkData.Columns;
            this.linkSpriteWidth = linkData.Width;
            this.linkSpriteHeight = linkData.Height;
        }

        public void Update()
        {
        }

        public void Draw(Vector2 location, Color spriteTint)
        {
            int linkWidth = this.linkSprite.Width / this.linkSpriteColumns;
            int linkHeight = this.linkSprite.Height / this.linkSpriteRows;
            int linkRow = (int)((float)this.linkFrame / (float)this.linkSpriteColumns);
            int linkColumn = this.linkFrame % this.linkSpriteColumns;

            Rectangle linkSrcRectangle = new Rectangle(linkWidth * linkColumn, linkHeight * linkRow, linkWidth, linkHeight);
            Rectangle linkDstRectangle = new Rectangle((int)location.X, (int)location.Y, this.linkSpriteWidth, this.linkSpriteHeight);
            float layer = 1 - (1 / (location.Y + this.linkSpriteHeight));

            LoZGame.Instance.SpriteBatch.Draw(this.linkSprite, linkDstRectangle, linkSrcRectangle, spriteTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, layer);
        }
    }
}