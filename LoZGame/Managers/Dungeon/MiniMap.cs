namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MiniMap
    {
        private const int BlinkRate = 30;
        private int lifetime;

        private List<MiniMapRoom> dungeonLayout;
        private Dungeon dungeon;

        private Vector2 mapSize;
        private Vector2 inventoryRoomSize;
        private Vector2 roomDrawOffset;

        private Vector2 miniMapSize;
        private Vector2 miniMapRoomSize;
        private Vector2 miniMapDrawOffset;

        public enum DoorLocation
        {
            North, 
            South, 
            East,   
            West
        }

        public MiniMap(Dungeon dungeon)
        {
            mapSize = new Vector2(365, 195);
            miniMapSize = new Vector2(208, 104);
            this.dungeon = dungeon;
            lifetime = 0;
        }

        public void Draw(Vector2 InventoryMapLoc, Vector2 MiniMapLoc)
        {
            lifetime++;
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                dungeonLayout[i].DrawInventory(InventoryMapLoc.ToPoint() + roomDrawOffset.ToPoint(), inventoryRoomSize.ToPoint(), Color.Black);
                dungeonLayout[i].DrawMiniMap(MiniMapLoc.ToPoint() + miniMapDrawOffset.ToPoint(), miniMapRoomSize.ToPoint(), dungeon.MapColor);
                if (lifetime > BlinkRate)
                {
                    if (dungeonLayout[i].Location == dungeon.DungeonBossLocation && dungeon.Player.Inventory.HasCompass)
                    {
                        dungeonLayout[i].DrawDot(InventoryMapLoc.ToPoint() + roomDrawOffset.ToPoint(), inventoryRoomSize.ToPoint(), Color.Red);
                        dungeonLayout[i].DrawDot(MiniMapLoc.ToPoint() + miniMapDrawOffset.ToPoint(), miniMapRoomSize.ToPoint(), Color.Red);
                    }
                    if (dungeonLayout[i].Location == new Point(dungeon.CurrentRoomX, dungeon.CurrentRoomY))
                    {
                        dungeonLayout[i].DrawDot(InventoryMapLoc.ToPoint() + roomDrawOffset.ToPoint(), inventoryRoomSize.ToPoint(), Color.Yellow);
                        dungeonLayout[i].DrawDot(MiniMapLoc.ToPoint() + miniMapDrawOffset.ToPoint(), miniMapRoomSize.ToPoint(), Color.LightYellow);
                    }
                }
            }
            if (lifetime > BlinkRate * 2)
            {
                lifetime = 0;
            }
        }

        private List<DoorLocation> FetchDoors(Room room)
        {
            List<MiniMap.DoorLocation> doors = new List<MiniMap.DoorLocation>();
            foreach (Door door in room.Doors)
            {
                if (!(door.State is HiddenDoorState))
                {
                    switch (door.Physics.CurrentDirection)
                    {
                        case Physics.Direction.North:
                            doors.Add(MiniMap.DoorLocation.North);
                            break;
                        case Physics.Direction.South:
                            doors.Add(MiniMap.DoorLocation.South);
                            break;
                        case Physics.Direction.East:
                            doors.Add(MiniMap.DoorLocation.East);
                            break;
                        case Physics.Direction.West:
                            doors.Add(MiniMap.DoorLocation.West);
                            break;
                        default:
                            break;
                    }
                }
            }
            return doors;
        }

        public void LoadMap(List<List<Room>> dungeon, int maxX, int maxY)
        {
            dungeonLayout = new List<MiniMapRoom>();
            int roomY = 0, roomX = 0;
            while (roomY < maxY)
            {
                roomX = 0;
                while (roomX < maxX)
                {
                    if (dungeon[roomY][roomX].Exists)
                    {
                        List<MiniMap.DoorLocation> doors = FetchDoors(dungeon[roomY][roomX]);
                        dungeonLayout.Add(new MiniMapRoom(roomX, roomY, doors));
                    }
                    roomX++;
                }
                roomY++;
            }
            inventoryRoomSize = mapSize / Math.Max(maxX, maxY);
            miniMapRoomSize = miniMapSize / Math.Max(maxX, maxY);
            DetermineDrawOffset(maxX, maxY);
        }

        public void Explore()
        {
            foreach (MiniMapRoom room in dungeonLayout)
            {
                if (dungeon.CurrentRoomX == room.Location.X && dungeon.CurrentRoomY == room.Location.Y)
                {
                    room.Explore();
                }
            }
        }

        private void DetermineDrawOffset(int x, int y)
        {
            Vector2 offset;
            if (x > y)
            {
                offset = new Vector2(0, (x - y) / 2);
            }
            else
            {
                offset = new Vector2((y - x) / 2, 0);
            }
            roomDrawOffset = new Vector2(inventoryRoomSize.X * offset.X, inventoryRoomSize.Y * offset.Y);
            miniMapDrawOffset = new Vector2(miniMapRoomSize.X * offset.X, miniMapRoomSize.Y * offset.Y);
        }
    }
}
