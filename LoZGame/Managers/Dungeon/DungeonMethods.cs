namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class Dungeon
    {
        /// <summary>
        /// Resets dungeon room to default.
        /// </summary>
        public void Reset()
        {
            dungeonLayout = XMLHandler.ParseLayout(currentDungeonFile);

            currentX = startLocation.X;
            currentY = startLocation.Y;
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

                // Player moved to bottom side of new room.
                player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 6),
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);
                foreach (IEnemy enemy in dungeonLayout[currentY][currentX].Enemies)
                {
                    enemy.Physics.Bounds = new Rectangle(enemy.Physics.Bounds.Location, enemy.Physics.Bounds.Size);
                    if (enemy.AI == EnemyEssentials.EnemyAI.SpikeCross)
                    {
                        enemy.Physics.MovementVelocity = Vector2.Zero;
                        enemy.Physics.Bounds = new Rectangle(enemy.SpawnPoint, enemy.Physics.Bounds.Size);
                    }
                    enemy.Physics.SetLocation();
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
            if (currentY + 1 < maxDimensions.Y && dungeonLayout[currentY + 1][currentX].Exists)
            {
                currentY++;
                LoadNewRoom();

                player.Physics.Bounds = new Rectangle(
                    (int)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * 0) + 2,
                    player.Physics.Bounds.Width,
                    player.Physics.Bounds.Height);

                // Player moved to top side of new room (next to door, top of the ladder in the basement case).
                if (CurrentRoom.IsBasement)
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
            if (currentX + 1 < maxDimensions.X && dungeonLayout[currentY][currentX + 1].Exists)
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

        public void LoadNewRoom(GameObjectManager manager, Point location, Point offset)
        {
            foreach (IBlock block in dungeonLayout[location.Y][location.X].Tiles)
            {
                block.Physics.Bounds = new Rectangle(block.Physics.Bounds.Location + offset, block.Physics.Bounds.Size);
                block.Physics.SetLocation();
                manager.Blocks.Add(block);
            }

            foreach (IDoor door in dungeonLayout[location.Y][location.X].Doors)
            {
                door.Physics.Bounds = new Rectangle(door.Physics.Bounds.Location + offset, door.Physics.Bounds.Size);
                door.Physics.SetLocation();
                manager.Doors.Add((Door)door);
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

        /// <summary>
        /// Draws the correct dungeon background text if applicable.
        /// </summary>
        public void DrawText()
        {
            switch (dungeonNumber)
            {
                case 1:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon1TxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon1TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon1TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 2:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon2TxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon2TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon2TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 3:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon3TxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon3TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon3TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 4:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon4TxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon4TxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon4TxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 5:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5FluteTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5FluteTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon5FluteTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5PurchaseBombTxtX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5PurchaseBombTxtY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.PurchaseBombTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomPurchaseText, GameData.Instance.InventoryConstants.PurchasePriceTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon5ArrowTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon5ArrowTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon5ArrowTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 6:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon6BossHintTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon6BossHintTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon6BossHintTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon6MagicRodTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 7:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon7FreeBombsTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon7FreeBombsTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon7FreeBombsTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon7SwordTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon7SwordTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon7SwordTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon7SecretTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon7SecretTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon7SecretTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 8:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon8KeyTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon8KeyTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon8KeyTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon8SecretTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon8SecretTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon8SecretTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                case 9:
                    if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon9ArrowTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon9ArrowTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon9ArrowTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon9NextRoomTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon9NextRoomTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon9NextRoomTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon9MapTxtRoomX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon9MapTxtRoomY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.Dungeon9MapTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    else if (CurrentRoomX == GameData.Instance.InventoryConstants.Dungeon9PurchaseBombTxtX && CurrentRoomY == GameData.Instance.InventoryConstants.Dungeon9PurchaseBombTxtY)
                    {
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomText, GameData.Instance.InventoryConstants.PurchaseBombTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                        LoZGame.Instance.SpriteBatch.DrawString(LoZGame.Instance.Font, CurrentRoom.RoomPurchaseText, GameData.Instance.InventoryConstants.PurchasePriceTxtDrawLoc, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1f);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
