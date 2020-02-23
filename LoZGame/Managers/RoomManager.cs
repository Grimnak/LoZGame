﻿namespace LoZClone
{
    using System.Collections.Generic;
    /// <summary>
    /// Manager for all dungeon rooms.
    /// </summary>
    public class RoomManager
    {
        private List<List<Room>> roomLayout;
        private int currentX;
        private int currentY;
        private int maxX;
        private int maxY;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomManager"/> class.
        /// </summary>
        public RoomManager()
        {
            this.roomLayout = new List<List<Room>>();
            // potentially change x and y starts to match upside down coordinate system
            this.currentX = 2;
            this.currentY = 0;
            this.maxX = 6;
            this.maxY = 6;
        }

        /// <summary>
        /// Moves current displayed room to next one above, if it exists.
        /// </summary>
        public void MoveUp()
        {
            if (this.currentY + 1 < this.maxY && this.roomLayout[this.currentX][this.currentY + 1].Exists)
            {
                this.currentY++;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one below, if it exists.
        /// </summary>
        public void MoveDown()
        {
            if (this.currentY - 1 > 0 && this.roomLayout[this.currentX][this.currentY - 1].Exists)
            {
                this.currentY--;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one left, if it exists.
        /// </summary>
        public void MoveLeft()
        {
            if (this.currentX - 1 > 0 && this.roomLayout[this.currentX - 1][this.currentY].Exists)
            {
                this.currentX--;
            }
        }

        /// <summary>
        /// Moves current displayed room to next one right, if it exists.
        /// </summary>
        public void MoveRight()
        {
            if (this.currentX + 1 < this.maxX && this.roomLayout[this.currentX + 1][this.currentY].Exists)
            {
                this.currentX++;
            }
        }
    }
}