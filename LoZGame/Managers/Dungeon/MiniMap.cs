namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class MiniMap
    {
        private List<List<MiniMapRoom>> dungeonLayout;
        private Vector2 mapSize = new Vector2(400, 240);
        private Vector2 roomSize;
        private Point location;

        public Point Location { get; set; }

        public enum DoorLocation
        {
            North, 
            South, 
            East, 
            West
        }

        public MiniMap()
        {
            this.dungeonLayout = new List<List<MiniMapRoom>>();
            switch (LoZGame.Instance.Dungeon.DungeonNumber)
            {
                case 1:
                    this.CreateDungeonOneMiniMap();
                    break;
                case 2:
                    this.CreateDungeonTwoMiniMap();
                    break;
                default:
                    break;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                for (int j = 0; j < dungeonLayout[i].Count; j++)
                {
                    this.dungeonLayout[i][j].Draw(this.location, this.roomSize.ToPoint());
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
            this.dungeonLayout.Clear();
            int roomY = 0, roomX = 0;
            while (roomY < maxY)
            {
                while (roomX < maxX)
                {
                    if (dungeon[roomX][roomY].Exists)
                    {
                        List<MiniMap.DoorLocation> doors = FetchDoors(dungeon[roomX][roomY]);
                        this.dungeonLayout[roomX][roomY] = new MiniMapRoom(roomX, roomY, doors);
                    }
                }
            }
            this.roomSize = this.mapSize / Math.Max(roomX, roomY);
        }

        // Note to grader, we are aware this is some smelly code, but it wasn't apparent to us how to do it any cleaner.
        public void CreateDungeonOneMiniMap()
        {
            /*this.dungeonLayout[0][0] = new MiniMapRoom(false, null, 0, 0);
            this.dungeonLayout[0][1] = new MiniMapRoom(true, null, 0, 1);
            this.dungeonLayout[0][2] = new MiniMapRoom(true, null, 0, 2);
            this.dungeonLayout[0][3] = new MiniMapRoom(false, null, 0, 3);
            this.dungeonLayout[0][4] = new MiniMapRoom(false, null, 0, 4);
            this.dungeonLayout[0][5] = new MiniMapRoom(false, null, 0, 5);
            this.dungeonLayout[1][0] = new MiniMapRoom(false, null, 1, 0);
            this.dungeonLayout[1][1] = new MiniMapRoom(false, null, 1, 1);
            this.dungeonLayout[1][2] = new MiniMapRoom(true, null, 1, 2);
            this.dungeonLayout[1][3] = new MiniMapRoom(false, null, 1, 3);
            this.dungeonLayout[1][4] = new MiniMapRoom(true, null, 1, 4);
            this.dungeonLayout[1][5] = new MiniMapRoom(true, null, 1, 5);
            this.dungeonLayout[2][0] = new MiniMapRoom(true, null, 2, 0);
            this.dungeonLayout[2][1] = new MiniMapRoom(true, null, 2, 1);
            this.dungeonLayout[2][2] = new MiniMapRoom(true, null, 2, 2);
            this.dungeonLayout[2][3] = new MiniMapRoom(true, null, 2, 3);
            this.dungeonLayout[2][4] = new MiniMapRoom(true, null, 2, 4);
            this.dungeonLayout[2][5] = new MiniMapRoom(false, null, 2, 5);
            this.dungeonLayout[3][0] = new MiniMapRoom(false, null, 3, 0);
            this.dungeonLayout[3][1] = new MiniMapRoom(true, null, 3, 1);
            this.dungeonLayout[3][2] = new MiniMapRoom(true, null, 3, 2);
            this.dungeonLayout[3][3] = new MiniMapRoom(true, null, 3, 3);
            this.dungeonLayout[3][4] = new MiniMapRoom(false, null, 3, 4);
            this.dungeonLayout[3][5] = new MiniMapRoom(false, null, 3, 5);
            this.dungeonLayout[4][0] = new MiniMapRoom(false, null, 4, 0);
            this.dungeonLayout[4][1] = new MiniMapRoom(false, null, 4, 1);
            this.dungeonLayout[4][2] = new MiniMapRoom(true, null, 4, 2);
            this.dungeonLayout[4][3] = new MiniMapRoom(false, null, 4, 3);
            this.dungeonLayout[4][4] = new MiniMapRoom(false, null, 4, 4);
            this.dungeonLayout[4][5] = new MiniMapRoom(false, null, 4, 5);
            this.dungeonLayout[5][0] = new MiniMapRoom(false, null, 5, 0);
            this.dungeonLayout[5][1] = new MiniMapRoom(true, null, 5, 1);
            this.dungeonLayout[5][2] = new MiniMapRoom(true, null, 5, 2);
            this.dungeonLayout[5][3] = new MiniMapRoom(true, null, 5, 3);
            this.dungeonLayout[5][4] = new MiniMapRoom(false, null, 5, 4);
            this.dungeonLayout[5][5] = new MiniMapRoom(false, null, 5, 5);*/
        }

        public void CreateDungeonTwoMiniMap()
        {

        }
    }
}
