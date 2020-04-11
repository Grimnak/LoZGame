namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MiniMap
    {
        private List<MiniMapRoom> dungeonLayout;
        private Vector2 mapSize;
        private Vector2 roomSize;
        private Vector2 roomDrawOffset;
        private Dungeon dungeon;

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
            this.dungeon = dungeon;
        }

        public void Draw(Vector2 location)
        {
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                this.dungeonLayout[i].Draw(location.ToPoint() + roomDrawOffset.ToPoint(), this.roomSize.ToPoint());
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
            this.roomSize = this.mapSize / Math.Max(maxX, maxY);
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
            this.roomDrawOffset = new Vector2(this.roomSize.X * offset.X, this.roomSize.Y * offset.Y);
        }
    }
}
