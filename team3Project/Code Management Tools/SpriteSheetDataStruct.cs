namespace LoZClone
{
    public struct SpriteSheetData
    {
        private string filePath;
        private int width;
        private int height;
        private int rows;
        private int columns;

        public string FilePath { get { return filePath; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int Rows { get { return rows; } }
        public int Columns { get { return columns; } }
        public SpriteSheetData(string spriteFileName, int spriteWidth, int spriteHeight, int spriteSheetRows, int spriteSheetColumns)
        {
            filePath = spriteFileName;
            width = spriteWidth;
            height = spriteHeight;
            rows = spriteSheetRows;
            columns = spriteSheetColumns;
        }
    }
}
