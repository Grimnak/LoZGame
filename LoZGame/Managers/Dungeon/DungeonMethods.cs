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
                        BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 5),
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
                if (LoZGame.Instance.Dungeon.CurrentRoom.IsBasement)
                {
                    this.player.Physics.Bounds = new Rectangle(
                        (int)BlockSpriteFactory.Instance.TileWidth * 3,
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
                    BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 11),
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
                    BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 0) + 6,
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                    this.player.Physics.Bounds.Width,
                    this.player.Physics.Bounds.Height);
                this.player.Physics.SetLocation();
                this.player.Physics.CurrentDirection = Physics.Direction.East;
                this.player.State = new IdleState(this.player);
            }
        }

        /// <summary>
        /// Loads new room info into managers and reveals corresponding minimap room.
        /// </summary>
        public void LoadNewRoom()
        {
            this.miniMap.Explore();
            LoZGame.Instance.GameObjects.LoadNewRoom();
        }

        public void LoadNewRoom(GameObjectManager manager,  Point location, Point offset)
        {
            foreach (IBlock block in this.dungeonLayout[location.Y][location.X].Tiles)
            {
                block.Physics.Bounds = new Rectangle(block.Physics.Bounds.Location + offset, block.Physics.Bounds.Size);
                block.Physics.SetLocation();
                manager.Blocks.Add(block);
            }

            foreach (Door door in this.dungeonLayout[location.Y][location.X].Doors)
            {
                door.Physics.Bounds = new Rectangle(door.Physics.Bounds.Location + offset, door.Physics.Bounds.Size);
                door.Physics.SetLocation();
                manager.Doors.Add(door);
            }
        }

        public void SpawnObjects()
        {
            foreach (IEnemy enemy in this.dungeonLayout[this.currentY][this.currentX].Enemies)
            {
                enemy.Physics.Bounds = new Rectangle(enemy.Physics.Bounds.Location, enemy.Physics.Bounds.Size);
                if (enemy.AI == EnemyEssentials.EnemyAI.SpikeCross)
                {
                    enemy.Physics.Bounds = new Rectangle(enemy.SpawnPoint, enemy.Physics.Bounds.Size);
                }
                enemy.Physics.SetLocation();
                LoZGame.Instance.GameObjects.Enemies.Add(enemy);
            }
            foreach (IItem item in this.dungeonLayout[this.currentY][this.currentX].Items)
            {
                item.Physics.Bounds = new Rectangle(item.Physics.Bounds.Location, item.Physics.Bounds.Size);
                item.Physics.SetLocation();
                LoZGame.Instance.GameObjects.Items.Add(item);
            }
        }
    }
}
