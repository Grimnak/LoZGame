namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MiniMap
    {
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
            this.mapSize = new Vector2(365, 195);
            this.miniMapSize = new Vector2(208, 104);
            this.dungeon = dungeon;
        }

        public void Draw(Vector2 InventoryMapLoc, Vector2 MiniMapLoc)
        {
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                this.dungeonLayout[i].DrawInventory(InventoryMapLoc.ToPoint() + roomDrawOffset.ToPoint(), this.inventoryRoomSize.ToPoint(), Color.Black);
                this.dungeonLayout[i].DrawMiniMap(MiniMapLoc.ToPoint() + miniMapDrawOffset.ToPoint(), this.miniMapRoomSize.ToPoint(), dungeon.MapColor);
                if (this.dungeonLayout[i].Location == new Point(this.dungeon.CurrentRoomX, this.dungeon.CurrentRoomY))
                {
                    this.dungeonLayout[i].DrawDot(InventoryMapLoc.ToPoint() + roomDrawOffset.ToPoint(), this.inventoryRoomSize.ToPoint(), Color.Yellow);
                    this.dungeonLayout[i].DrawDot(MiniMapLoc.ToPoint() + miniMapDrawOffset.ToPoint(), this.miniMapRoomSize.ToPoint(), Color.LightYellow);
                }
            }
        }

        private List<DoorLocation> FetchDoors(Room room)
        {
            List<MiniMap.DoorLocation> doors = new List<MiniMap.DoorLocation>();
            foreach (Door door in room.Doors)
            {
                if (!(door.State is HiddenDoorState))
                {
                    switch (door.GetLoc())
                    {
                        case "N":
                            doors.Add(MiniMap.DoorLocation.North);
                            break;
                        case "S":
                            doors.Add(MiniMap.DoorLocation.South);
                            break;
                        case "E":
                            doors.Add(MiniMap.DoorLocation.East);
                            break;
                        case "W":
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
            this.dungeonLayout = new List<MiniMapRoom>();
            int roomY = 0, roomX = 0;
            while (roomY < maxY)
            {
                roomX = 0;
                while (roomX < maxX)
                {
                    if (dungeon[roomY][roomX].Exists)
                    {
                        List<MiniMap.DoorLocation> doors = FetchDoors(dungeon[roomY][roomX]);
                        this.dungeonLayout.Add(new MiniMapRoom(roomX, roomY, doors));
                    }
                    roomX++;
                }
                roomY++;
            }
            this.inventoryRoomSize = this.mapSize / Math.Max(maxX, maxY);
            this.miniMapRoomSize = this.miniMapSize / Math.Max(maxX, maxY);
            DetermineDrawOffset(maxX, maxY);
        }

        public void Explore()
        {
            foreach (MiniMapRoom room in this.dungeonLayout)
            {
                if (this.dungeon.CurrentRoomX == room.Location.X && this.dungeon.CurrentRoomY == room.Location.Y)
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
            this.roomDrawOffset = new Vector2(this.inventoryRoomSize.X * offset.X, this.inventoryRoomSize.Y * offset.Y);
            this.miniMapDrawOffset = new Vector2(this.miniMapRoomSize.X * offset.X, this.miniMapRoomSize.Y * offset.Y);
        }
    }
}
