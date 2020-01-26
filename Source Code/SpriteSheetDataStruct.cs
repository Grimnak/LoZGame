using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetDataStruct
{
    public struct SpriteSheetData
    {
        private string filePath;
        private int width;
        private int height;

        public string GetFilePath { get { return filePath; } }
        public int GetWidth { get { return width; } }
        public int GetHeight { get { return height; } }
        public SpriteSheetData(string spriteFileName, int spriteWidth, int spriteHeight)
        {
            filePath = spriteFileName;
            width = spriteWidth;
            height = spriteHeight;
        }
    }
}
