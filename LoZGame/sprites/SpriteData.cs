namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct SpriteData
    {
        private readonly int width;
        private readonly int height;
        private readonly int rows;
        private readonly int columns;

        public int DrawWidth => this.width;

        public int DrawHeight => this.height;

        public int Rows => this.rows;

        public int Columns => this.columns;

        public SpriteData(Vector2 drawSize, Texture2D spriteSheet, int spriteSheetRows, int spriteSheetColumns)
        {
            this.width = (int)drawSize.X;
            this.height = (int)drawSize.Y;
            this.rows = spriteSheetRows;
            this.columns = spriteSheetColumns;
        }
    }
}