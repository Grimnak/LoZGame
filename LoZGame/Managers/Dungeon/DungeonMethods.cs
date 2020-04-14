namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public partial class Dungeon
    {
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
                        BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                        this.player.Physics.Bounds.Width,
                        this.player.Physics.Bounds.Height);
                }
                else
                {
                    this.player.Physics.Bounds = new Rectangle(
                        (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
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
            if (this.currentY + 1 < this.maxY && this.dungeonLayout[this.currentY + 1][this.currentX].Exists)
            {
                this.currentY++;
                this.LoadNewRoom();

                this.player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 0) + 2,
                    this.player.Physics.Bounds.Width,
                    this.player.Physics.Bounds.Height);

                // Player moved to top side of new room (next to door, top of the ladder in the basement case).
                if (this.dungeonNumber == 1 && (currentX == 1 && currentY == 1))
                {
                    this.player.Physics.Bounds = new Rectangle(
                        BlockSpriteFactory.Instance.TileWidth * 3,
                        (BlockSpriteFactory.Instance.TileHeight * 0) + 10 + LoZGame.Instance.InventoryOffset,
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
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
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
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
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
            this.miniMap.Explore();
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
