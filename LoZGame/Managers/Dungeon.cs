namespace LoZGame
{
    using System.Collections.Generic;
    using global::LoZGame.util;

    /// <summary>
    /// Manager for all dungeon rooms.
    /// </summary>
    public class Dungeon
    {
        private List<List<Room>> dungeonLayout;
        private int currentX;
        private int currentY;
        private int maxX;
        private int maxY;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="filePath">File path of the document to parse.</param>
        public Dungeon(string filePath)
        {
            this.dungeonLayout = XMLParser.Parse(filePath);

            // potentially change x and y starts to match upside down coordinate system
            this.currentX = 2;
            this.currentY = 5; // player spawns at curX/curY
            this.maxX = 6;
            this.maxY = 6;
        }

        /// <summary>
        /// Moves current displayed room to next one above, if it exists.
        /// </summary>
        public void MoveUp()
        {
            if (this.currentY + 1 < this.maxY && this.dungeonLayout[this.currentX][this.currentY + 1].Exists)
            {
                this.currentY++;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one below, if it exists.
        /// </summary>
        public void MoveDown()
        {
            if (this.currentY - 1 > 0 && this.dungeonLayout[this.currentX][this.currentY - 1].Exists)
            {
                this.currentY--;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one left, if it exists.
        /// </summary>
        public void MoveLeft()
        {
            if (this.currentX - 1 > 0 && this.dungeonLayout[this.currentX - 1][this.currentY].Exists)
            {
                this.currentX--;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one right, if it exists.
        /// </summary>
        public void MoveRight()
        {
            if (this.currentX + 1 < this.maxX && this.dungeonLayout[this.currentX + 1][this.currentY].Exists)
            {
                this.currentX++;
            }
        }
    }
}
