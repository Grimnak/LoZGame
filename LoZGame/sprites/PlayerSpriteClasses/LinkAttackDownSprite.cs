namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LinkAttackDownSprite : ISprite
    {
        private readonly Texture2D linkSprite;
        private readonly int linkSpriteRows;
        private readonly int linkSpriteColumns;
        private readonly int linkSpriteWidth;
        private readonly int linkSpriteHeight;
        private readonly int linkFrame = 2;

        private readonly Texture2D itemSprite;
        private readonly int itemSpriteRows;
        private readonly int itemSpriteColumns;
        private readonly int itemSpriteWidth;
        private readonly int itemSpriteHeight;
        private int itemFrame;
        private Vector2 itemOffset = new Vector2(3, 24);

        private int frameDelay = 0;
        private readonly int frameDelayMax = 5;
        private int counter = 0;

        public LinkAttackDownSprite(Texture2D linkTexture, SpriteSheetData linkData, Texture2D itemTexture, SpriteSheetData itemData)
        {
            this.linkSprite = linkTexture;
            this.linkSpriteRows = linkData.Rows;
            this.linkSpriteColumns = linkData.Columns;
            this.linkSpriteWidth = linkData.Width;
            this.linkSpriteHeight = linkData.Height;

            this.itemSprite = itemTexture;
            this.itemSpriteRows = itemData.Rows;
            this.itemSpriteColumns = itemData.Columns;
            this.itemSpriteWidth = itemData.Width;
            this.itemSpriteHeight = itemData.Height;
        }

        public void Update()
        {
            // link goes into useItem
            // item appears 10 ticks later at full size
            // item goes half size 5 ticks later
            this.frameDelay++;
            if (this.frameDelay == this.frameDelayMax)
            {
                if (this.counter == 1)
                {
                    this.itemFrame = 1;
                }
                else if (this.counter == 2)
                {
                    this.itemFrame = 0;
                }
                else
                {
                    this.counter = 0;
                }

                this.frameDelay = 0;
                this.counter++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int linkWidth = this.linkSprite.Width / this.linkSpriteColumns;
            int linkHeight = this.linkSprite.Height / this.linkSpriteRows;
            int linkRow = (int)((float)this.linkFrame / (float)this.linkSpriteColumns);
            int linkColumn = this.linkFrame % this.linkSpriteColumns;

            int itemWidth = this.itemSprite.Width / this.itemSpriteColumns;
            int itemHeight = this.itemSprite.Height / this.itemSpriteRows;
            int itemRow = (int)((float)this.itemFrame / (float)this.itemSpriteColumns);
            int itemColumn = this.itemFrame % this.itemSpriteColumns;

            Rectangle linkSrcRectangle = new Rectangle(linkWidth * linkColumn, linkHeight * linkRow, linkWidth, linkHeight);
            Rectangle linkDstRectangle = new Rectangle((int)location.X, (int)location.Y, this.linkSpriteWidth, this.linkSpriteHeight);

            Rectangle itemSrcRectangle = new Rectangle(itemWidth * itemColumn, itemHeight * itemRow, itemWidth, itemHeight);
            Rectangle itemDstRectangle = new Rectangle((int)location.X + (int)this.itemOffset.X, (int)location.Y + (int)this.itemOffset.Y, this.itemSpriteWidth, this.itemSpriteHeight);

            spriteBatch.Draw(this.linkSprite, linkDstRectangle, linkSrcRectangle, spriteTint);

            spriteBatch.Draw(this.itemSprite, itemDstRectangle, itemSrcRectangle, spriteTint);
        }
    }
}