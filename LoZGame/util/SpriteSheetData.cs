namespace LoZClone
{
    public struct SpriteSheetData
    {
        private readonly string filePath;
        private readonly int width;
        private readonly int height;
        private readonly int rows;
        private readonly int columns;

        public string FilePath => this.filePath;

        public int Width => this.width;

        public int Height => this.height;

        public int Rows => this.rows;

        public int Columns => this.columns;

        public SpriteSheetData(string spriteFileName, int spriteWidth, int spriteHeight, int spriteSheetRows, int spriteSheetColumns)
        {
            this.filePath = spriteFileName;
            this.width = spriteWidth;
            this.height = spriteHeight;
            this.rows = spriteSheetRows;
            this.columns = spriteSheetColumns;
        }
    }
}
