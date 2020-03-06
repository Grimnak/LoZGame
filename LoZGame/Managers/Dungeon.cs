﻿namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

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
        private IPlayer player;
        private string currentDungeonFile;

        public IPlayer Player
        {
            get { return player; }
            set { this.player = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="filePath">File path of the document to parse.</param>
        /// <param name="player">Player whose location to update.</param>
        public Dungeon(string filePath)
        {
            this.currentDungeonFile = filePath;
            LoZGame.Instance.DungeonTint = Color.White;
            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            this.currentX = 2;
            this.currentY = 5; // player spawns at curX/curY
            this.maxX = 6;
            this.maxY = 6;
            this.LoadNewRoom();
        }

        public int CurrentRoomX
        {
            get { return currentX; }
        }

        public int CurrentRoomY
        {
            get { return currentY; }
        }

        public Room CurrentRoom
        {
            get { return this.dungeonLayout[this.currentY][this.currentX]; }
        }

        /// <summary>
        /// Resets dungeon room to default.
        /// </summary>
        public void Reset()
        {
            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);
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
            if (this.currentY - 1 >= 0 && this.dungeonLayout[this.currentY - 1][this.currentX].Exists && (this.currentX != 1 || this.currentY - 1 != 1))
            {
                this.currentY--;
                this.LoadNewRoom();

                // Player moved to bottom side of new room (next to door, next to staircase in basement case).
                if (this.currentX == 1 && this.currentY == 0)
                {
                    this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                        (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5)),
                        (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3)));
                }
                else
                {
                    this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                        (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6)));
                }

            }
        }

        /// <summary>
        /// Moves current displayed room to next one below, if it exists.
        /// </summary>
        public void MoveDown()
        {
            if (this.currentY + 1 < this.maxX && this.dungeonLayout[this.currentY + 1][this.currentX].Exists && (this.currentX != 1 || this.currentY + 1 != 2))
            {
                this.currentY++;
                this.LoadNewRoom();

                // Player moved to top side of new room (next to door, top of the ladder in the basement case).
                if (currentX == 1 && currentY == 1)
                {
                    this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                        (float)(BlockSpriteFactory.Instance.TileWidth * 4),
                        (float)(BlockSpriteFactory.Instance.TileHeight * 0) + 2);
                }
                else
                {
                    this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                        (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 0)) + 2);
                }
            }
        }

        /// <summary>
        /// Moves current displayed room to next one left, if it exists.
        /// </summary>
        public void MoveLeft()
        {
            if (this.currentX - 1 >= 0 && this.dungeonLayout[this.currentY][this.currentX - 1].Exists && (this.currentX - 1 != 1 || this.currentY != 1))
            {
                this.currentX--;
                this.LoadNewRoom();

                // Player moved to right side of new room (next to door).
                this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 11)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3)));
            }
        }

        /// <summary>
        /// Moves current displayed room to next one right, if it exists.
        /// </summary>
        public void MoveRight()
        {
            if (this.currentX + 1 < this.maxX && this.dungeonLayout[this.currentY][this.currentX + 1].Exists && (this.currentX + 1 != 2 || this.currentY != 1))
            {
                this.currentX++;
                this.LoadNewRoom();

                // Player moved to left side of new room (next to door).
                this.player.Physics.Location = new Microsoft.Xna.Framework.Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 0) + 6),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3)));
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
            LoZGame.Instance.Items.Clear();
            LoZGame.Instance.Doors.Clear();

            foreach (IEnemy enemy in this.dungeonLayout[this.currentY][this.currentX].Enemies)
            {
                LoZGame.Instance.Enemies.Add(enemy);
            }

            foreach (IBlock block in this.dungeonLayout[this.currentY][this.currentX].Tiles)
            {
                LoZGame.Instance.Blocks.Add(block);
            }

            foreach (IItem item in this.dungeonLayout[this.currentY][this.currentX].Items)
            {
                LoZGame.Instance.Items.Add(item);
            }

            foreach (Door door in this.dungeonLayout[this.currentY][this.currentX].Doors)
            {
                LoZGame.Instance.Doors.Add(door);
            }
        }
    }
}
