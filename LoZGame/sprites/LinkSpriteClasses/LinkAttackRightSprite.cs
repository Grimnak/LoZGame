using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LinkAttackRightSprite : ISprite
    {
        private Texture2D linkSprite;
        private int linkSpriteRows, linkSpriteColumns;
        private int linkSpriteWidth, linkSpriteHeight;
        private int linkFrame = 2;

        private Texture2D itemSprite;
        private int itemSpriteRows, itemSpriteColumns;
        private int itemSpriteWidth, itemSpriteHeight;
        private int itemFrame = 0;
        private Vector2 itemOffset = new Vector2(24, 3);

        private int frameDelay = 0, frameDelayMax = 5, counter = 0;

        public LinkAttackRightSprite(Texture2D linkTexture, SpriteSheetData linkData, Texture2D itemTexture, SpriteSheetData itemData)
        {
            linkSprite = linkTexture;
            linkSpriteRows = linkData.Rows;
            linkSpriteColumns = linkData.Columns;
            linkSpriteWidth = linkData.Width;
            linkSpriteHeight = linkData.Height;

            itemSprite = itemTexture;
            itemSpriteRows = itemData.Rows;
            itemSpriteColumns = itemData.Columns;
            itemSpriteWidth = itemData.Width;
            itemSpriteHeight = itemData.Height;
        }

        public void Update()
        {
            // link goes into useItem
            // item appears 10 ticks later at full size
            // item goes half size 5 ticks later
            frameDelay++;
            if (frameDelay == frameDelayMax)
            {
                if (counter == 1)
                {
                    itemFrame = 1;
                }
                else if (counter == 2)
                {
                    itemFrame = 0;
                }
                else
                {
                    counter = 0;
                }
                frameDelay = 0;
                counter++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color spriteTint)
        {
            int linkWidth = linkSprite.Width / linkSpriteColumns;
            int linkHeight = linkSprite.Height / linkSpriteRows;
            int linkRow = (int)((float)linkFrame / (float)linkSpriteColumns);
            int linkColumn = linkFrame % linkSpriteColumns;

            int itemWidth = itemSprite.Width / itemSpriteColumns;
            int itemHeight = itemSprite.Height / itemSpriteRows;
            int itemRow = (int)((float)itemFrame / (float)itemSpriteColumns);
            int itemColumn = itemFrame % itemSpriteColumns;

            Rectangle linkSrcRectangle = new Rectangle(linkWidth * linkColumn, linkHeight * linkRow, linkWidth, linkHeight);
            Rectangle linkDstRectangle = new Rectangle((int)location.X, (int)location.Y, linkSpriteWidth, linkSpriteHeight);

            Rectangle itemSrcRectangle = new Rectangle(itemWidth * itemColumn, itemHeight * itemRow, itemWidth, itemHeight);
            Rectangle itemDstRectangle = new Rectangle((int)location.X + (int)itemOffset.X, (int)location.Y + (int)itemOffset.Y, itemSpriteWidth, itemSpriteHeight);

            spriteBatch.Draw(linkSprite, linkDstRectangle, linkSrcRectangle, spriteTint);

            spriteBatch.Draw(itemSprite, itemDstRectangle, itemSrcRectangle, spriteTint);
        }
    }
}
