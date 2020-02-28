namespace LoZClone
{
    using System.Collections.Generic;

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
            this.dungeonLayout = XMLHandler.Parse(filePath);

            BlockSpriteFactory.Instance.LoadAllTextures(LoZGame.Instance.Content);

            this.currentX = 2;
            this.currentY = 5; // player spawns at curX/curY
            this.maxX = 6;
            this.maxY = 6;
            this.LoadNewRoom();
        }

        /// <summary>
        /// Resets dungeon room to default.
        /// </summary>
        public void Reset()
        {
            this.currentX = 2;
            this.currentY = 5; // player spawns at curX/curY
            this.maxX = 6;
            this.maxY = 6;
            this.LoadNewRoom();
        }

        /// <summary>
        /// Moves current displayed room to next one above, if it exists.
        /// </summary>
        public void MoveUp()
        {
            if (this.currentY - 1 >= 0 && this.dungeonLayout[this.currentY - 1][this.currentX].Exists)
            {
                this.currentY--;
                this.LoadNewRoom();
            }
        }

        /// <summary>
        /// Moves current displayed room to next one below, if it exists.
        /// </summary>
        public void MoveDown()
        {
            if (this.currentY + 1 < this.maxX && this.dungeonLayout[this.currentY + 1][this.currentX].Exists)
            {
                this.currentY++;
                this.LoadNewRoom(); 
            }
        }

        /// <summary>
        /// Moves current displayed room to next one left, if it exists.
        /// </summary>
        public void MoveLeft()
        {
            if (this.currentX - 1 >= 0 && this.dungeonLayout[this.currentY][this.currentX - 1].Exists)
            {
                this.currentX--;
                this.LoadNewRoom(); 
            }
        }

        /// <summary>
        /// Moves current displayed room to next one right, if it exists.
        /// </summary>
        public void MoveRight()
        {
            if (this.currentX + 1 < this.maxX && this.dungeonLayout[this.currentY][this.currentX + 1].Exists)
            {
                this.currentX++;
                this.LoadNewRoom(); 
            }
        }

        /// <summary>
        /// Loads new room info into managers.
        /// </summary>
        public void LoadNewRoom()
        {
            LoZGame.Instance.Entities.Clear(); // we dont add anything to entity manager after clearing since no projectiles stay when transitioning rooms.
            LoZGame.Instance.Enemies.Clear();
            LoZGame.Instance.Blocks.Clear();
            //LoZGame.Instance.Items.Clear();
            //LoZGame.Instance.Doors.Clear();

            foreach (IEnemy enemy in this.dungeonLayout[this.currentY][this.currentX].Enemies)
            {
                LoZGame.Instance.Enemies.Add(enemy);
            }

            foreach (IBlock block in this.dungeonLayout[this.currentY][this.currentX].Tiles)
            {
                LoZGame.Instance.Blocks.Add(block);
            }

            //TODO change to IItem once separated
            foreach (IItemSprite item in this.dungeonLayout[this.currentY][this.currentX].Items)
            {
                // ItemManager.Instance.Add(item);
            }

            foreach (Door door in this.dungeonLayout[this.currentY][this.currentX].Doors)
            {
                // DoorManager.Instance.Add(door);
            }
        }
    }
}
