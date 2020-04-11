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
        private Vector2 location;

        public enum DoorLocation
        {
            North, 
            South, 
            East,   
            West
        }

        public MiniMap()
        {
            this.mapSize = new Vector2(365, 195);
        }

        public void Draw(Vector2 location)
        {
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                Console.WriteLine("Tried drawing box");
                Console.WriteLine(dungeonLayout[i]);
                Console.WriteLine(this.location);
                this.dungeonLayout[i].Draw(location.ToPoint(), this.roomSize.ToPoint());
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
            Console.WriteLine("Started Loading Map with Room Count (" + maxX + ", " + maxY + ")");
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
                        Console.WriteLine("Loaded Room: (" + roomX + ",  " + roomY + ")");
                    }
                    else
                    {
                        Console.WriteLine("Room (" + roomX + ", " + roomY + ") Did not Exist");
                    }
                    roomX++;
                }
                roomY++;
            }
            this.roomSize = this.mapSize / Math.Max(maxX, maxY);
        }
    }
}
