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

        public int DrawWidth => width;

        public int DrawHeight => height;

        public int Rows => rows;

        public int Columns => columns;

        public SpriteData(Vector2 drawSize, Texture2D spriteSheet, int spriteSheetRows, int spriteSheetColumns)
        {
            width = (int)drawSize.X;
            height = (int)drawSize.Y;
            rows = spriteSheetRows;
            columns = spriteSheetColumns;
        }
    }
}