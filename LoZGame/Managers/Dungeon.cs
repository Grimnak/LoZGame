namespace LoZClone
{
    using System;
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
        private int dungeonNumber;

        public IPlayer Player
        {
            get { return player; }
            set { this.player = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="dungeonNumber">Number of the dungeon whose file is to be parsed.</param>
        public Dungeon(int dungeonNumber)
        {
            this.dungeonNumber = dungeonNumber;
            this.currentDungeonFile = "../../../../../etc/levels/dungeon" + this.dungeonNumber + ".xml";
            LoZGame.Instance.DungeonTint = Color.White;
            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            if (this.dungeonNumber == 1)
            {
                this.currentX = 2;
                this.currentY = 5; // player spawns at curX/curY
                this.maxX = 6;
                this.maxY = 6;
            }
            else if(this.dungeonNumber == 2)
            {
                this.currentX = 1;
                this.currentY = 7; // player spawns at curX/curY
                this.maxX = 4;
                this.maxY = 8;
            }

            this.LoadNewRoom();
        }

        public int CurrentRoomX
        {
            get { return currentX; }
            set { currentX = value; }
        }

        public int CurrentRoomY
        {
            get { return currentY; }
            set { currentY = value; }
        }

        public Room CurrentRoom
        {
            get { return this.dungeonLayout[this.currentY][this.currentX]; }
        }

        public int DungeonNumber { get { return dungeonNumber; } }

        /// <summary>
        /// Resets dungeon room to default.
        /// </summary>
        public void Reset()
        {
            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            if (this.dungeonNumber == 1)
            {
                this.currentX = 2;
                this.currentY = 5; // player spawns at curX/curY
                this.maxX = 6;
                this.maxY = 6;
            }
            else if (this.dungeonNumber == 2)
            {
                this.currentX = 1;
                this.currentY = 7; // player spawns at curX/curY
                this.maxX = 4;
                this.maxY = 8;
            }

            this.LoadNewRoom();
        }

        /*
         * Given a particular X and Y value, return that room
         */
        public Room GetRoom(int Y, int X)
        {
            return this.dungeonLayout[Y][X];
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
                    this.player.Physics.Bounds = new Rectangle(
                        BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5),
                        BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                        this.player.Physics.Bounds.Width,
                        this.player.Physics.Bounds.Height);
                }
                else
                {
                    this.player.Physics.Bounds = new Rectangle(
                        (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                        this.player.Physics.Bounds.Width,
                        this.player.Physics.Bounds.Height);
                }
                this.player.Physics.SetLocation();
                this.player.Physics.CurrentDirection = Physics.Direction.North;
                this.player.State = new IdleState(this.player);
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
                    this.player.Physics.Bounds = new Rectangle(
                        BlockSpriteFactory.Instance.TileWidth * 4,
                        (BlockSpriteFactory.Instance.TileHeight * 0) + 2,
                        this.player.Physics.Bounds.Width,
                        this.player.Physics.Bounds.Height);
                }
                else
                {
                    this.player.Physics.Bounds = new Rectangle(
                        (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 0) + 2,
                        this.player.Physics.Bounds.Width,
                        this.player.Physics.Bounds.Height);
                }
                this.player.Physics.SetLocation();
                this.player.Physics.CurrentDirection = Physics.Direction.South;
                this.player.State = new IdleState(this.player);
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
                this.player.Physics.Bounds = new Rectangle(
                    BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 11),
                    BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                    this.player.Physics.Bounds.Width,
                    this.player.Physics.Bounds.Height);
                this.player.Physics.SetLocation();
                this.player.Physics.CurrentDirection = Physics.Direction.West;
                this.player.State = new IdleState(this.player);
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
                this.player.Physics.Bounds = new Rectangle(
                    BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 0) + 6,
                    BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                    this.player.Physics.Bounds.Width,
                    this.player.Physics.Bounds.Height);
                this.player.Physics.SetLocation();
                this.player.Physics.CurrentDirection = Physics.Direction.East;
                this.player.State = new IdleState(this.player);
            }
        }

        /// <summary>
        /// Loads new room info into managers.
        /// </summary>
        public void LoadNewRoom()
        {
            LoZGame.Instance.GameObjects.Clear();

            foreach (IEnemy enemy in this.dungeonLayout[this.currentY][this.currentX].Enemies)
            {
                LoZGame.Instance.GameObjects.Enemies.Add(enemy);
            }

            foreach (IBlock block in this.dungeonLayout[this.currentY][this.currentX].Tiles)
            {
                LoZGame.Instance.GameObjects.Blocks.Add(block);
            }

            foreach (IItem item in this.dungeonLayout[this.currentY][this.currentX].Items)
            {
                LoZGame.Instance.GameObjects.Items.Add(item);
            }

            foreach (Door door in this.dungeonLayout[this.currentY][this.currentX].Doors)
            {
                LoZGame.Instance.GameObjects.Doors.Add(door);
            }
        }
    }
}
