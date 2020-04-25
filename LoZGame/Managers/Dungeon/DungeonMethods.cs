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
            dungeonLayout = XMLHandler.Parse(currentDungeonFile);

            currentX = startX;
            currentY = startY;
            LoadNewRoom();
        }

        /// <summary>
        /// Moves current displayed room to next one above, if it exists.
        /// </summary>
        public void MoveUp()
        {
            if (currentY - 1 >= 0 && dungeonLayout[currentY - 1][currentX].Exists)
            {
                currentY--;
                LoadNewRoom();

                // Player moved to bottom side of new room (next to door, next to staircase in basement case).
                if (currentX == 1 && currentY == 0)
                {
                    player.Physics.Bounds = new Rectangle(
                        BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 5),
                        BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                        player.Physics.Bounds.Width,
                        player.Physics.Bounds.Height);
                }
                else
                {
                    player.Physics.Bounds = new Rectangle(
                        (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                        BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                        player.Physics.Bounds.Width,
                        player.Physics.Bounds.Height);
                }
                foreach (IEnemy enemy in dungeonLayout[currentY][currentX].Enemies)
                {
                    enemy.Physics.Bounds = new Rectangle(enemy.Physics.Bounds.Location, enemy.Physics.Bounds.Size);
                    if (enemy.AI == EnemyEssentials.EnemyAI.SpikeCross)
                    {
                        enemy.Physics.MovementVelocity = Vector2.Zero;
                        enemy.Physics.Bounds = new Rectangle(enemy.SpawnPoint, enemy.Physics.Bounds.Size);
                    }
                    enemy.Physics.SetLocation();
                    //LoZGame.Instance.GameObjects.Enemies.Add(enemy);
                }
                player.Physics.SetLocation();
                player.Physics.CurrentDirection = Physics.Direction.North;
                player.State = new IdleState(player);
            }
        }

        /// <summary>
        /// Moves current displayed room to next one below, if it exists.
        /// </summary>
        public void MoveDown()
        {
            if (currentY + 1 < maxY && dungeonLayout[currentY + 1][currentX].Exists)
            {
                currentY++;
                LoadNewRoom();

                player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 0) + 2,
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);

                // Player moved to top side of new room (next to door, top of the ladder in the basement case).
                if (LoZGame.Instance.Dungeon.CurrentRoom.IsBasement)
                {
                    player.Physics.Bounds = new Rectangle(
                        (int)BlockSpriteFactory.Instance.TileWidth * 3,
                        (BlockSpriteFactory.Instance.TileHeight * 0) + 10 + LoZGame.Instance.InventoryOffset,
                        player.Physics.Bounds.Width,
                        player.Physics.Bounds.Height);
                }
                player.Physics.SetLocation();
                player.Physics.CurrentDirection = Physics.Direction.South;
                player.State = new IdleState(player);
            }
        }

        /// <summary>
        /// Moves current displayed room to next one left, if it exists.
        /// </summary>
        public void MoveLeft()
        {
            if (currentX - 1 >= 0 && dungeonLayout[currentY][currentX - 1].Exists)
            {
                currentX--;
                LoadNewRoom();

                // Player moved to right side of new room (next to door).
                player.Physics.Bounds = new Rectangle(
                    BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 11),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
                player.Physics.SetLocation();
                player.Physics.CurrentDirection = Physics.Direction.West;
                player.State = new IdleState(player);
            }
        }

        /// <summary>
        /// Moves current displayed room to next one right, if it exists.
        /// </summary>
        public void MoveRight()
        {
            if (currentX + 1 < maxX && dungeonLayout[currentY][currentX + 1].Exists)
            {
                currentX++;
                LoadNewRoom();

                // Player moved to left side of new room (next to door).
                player.Physics.Bounds = new Rectangle(
                    BlockSpriteFactory.Instance.HorizontalOffset + ((int)BlockSpriteFactory.Instance.TileWidth * 0) + 6,
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 3),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
                player.Physics.SetLocation();
                player.Physics.CurrentDirection = Physics.Direction.East;
                player.State = new IdleState(player);
            }
        }

        /// <summary>
        /// Loads new room info into managers and reveals corresponding minimap room.
        /// </summary>
        public void LoadNewRoom()
        {
            if (LoZGame.Instance.Players.Count > 0)
            {
                LoZGame.Instance.Players[0].Inventory.LadderInUse = false;
            }
            miniMap.Explore();
            LoZGame.Instance.GameObjects.LoadNewRoom();
        }

        public void LoadNewRoom(GameObjectManager manager,  Point location, Point offset)
        {
            foreach (IBlock block in dungeonLayout[location.Y][location.X].Tiles)
            {
                block.Physics.Bounds = new Rectangle(block.Physics.Bounds.Location + offset, block.Physics.Bounds.Size);
                block.Physics.SetLocation();
                manager.Blocks.Add(block);
            }

            foreach (Door door in dungeonLayout[location.Y][location.X].Doors)
            {
                door.Physics.Bounds = new Rectangle(door.Physics.Bounds.Location + offset, door.Physics.Bounds.Size);
                door.Physics.SetLocation();
                manager.Doors.Add(door);
            }

            if (LoZGame.Instance.Players.Count > 0)
            {
                LoZGame.Instance.Players[0].Inventory.LadderInUse = false;
            }
        }

        public void SpawnObjects()
        {
            foreach (IEnemy enemy in dungeonLayout[currentY][currentX].Enemies)
            {
                enemy.Physics.Bounds = new Rectangle(enemy.Physics.Bounds.Location, enemy.Physics.Bounds.Size);
                if (enemy.AI == EnemyEssentials.EnemyAI.SpikeCross)
                {
                    enemy.Physics.Bounds = new Rectangle(enemy.SpawnPoint, enemy.Physics.Bounds.Size);
                }
                enemy.Physics.SetLocation();
                LoZGame.Instance.GameObjects.Enemies.Add(enemy);
            }
            foreach (IItem item in dungeonLayout[currentY][currentX].Items)
            {
                item.Physics.Bounds = new Rectangle(item.Physics.Bounds.Location, item.Physics.Bounds.Size);
                item.Physics.SetLocation();
                LoZGame.Instance.GameObjects.Items.Add(item);
            }
        }
    }
}
