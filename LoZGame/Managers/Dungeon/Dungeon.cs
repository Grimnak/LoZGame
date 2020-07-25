namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Manager for all dungeon rooms.
    /// </summary>
    public partial class Dungeon
    {
        private List<List<Room>> dungeonLayout;
        private int currentX;
        private int currentY;
        private Color mapColor;
        private Point maxDimensions;
        private Point startLocation;
        private IPlayer player;
        private string currentDungeonFile;
        private int dungeonNumber;
        private MiniMap miniMap;
        private Point dungeonBossLoc;
        private bool defeatedBoss;
        private string dungeonName;

        public List<List<Room>> DungeonLayout { get { return dungeonLayout; } }

        public MiniMap MiniMap => miniMap;

        public bool DefeatedBoss { get { return defeatedBoss; } set { defeatedBoss = value; } }

        public IPlayer Player
        {
            get { return player; }
            set { player = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="dungeonNumber">Number of the dungeon whose file is to be parsed.</param>
        public Dungeon(int dungeonNumber)
        {
            DungeonNumber = dungeonNumber;
            currentDungeonFile = "Content/dungeon" + this.dungeonNumber + ".xml";
            LoZGame.Instance.GameObjects.LoadedRoomX = -1;
            LoZGame.Instance.GameObjects.LoadedRoomY = -1;

            LoZGame.Instance.DungeonTint = XMLHandler.ParseColor(currentDungeonFile);
            dungeonName = XMLHandler.ParseName(currentDungeonFile);
            mapColor = XMLHandler.ParseMapColor(currentDungeonFile);
            dungeonBossLoc = XMLHandler.ParseBossLocation(currentDungeonFile);
            startLocation = XMLHandler.ParseStartLocation(currentDungeonFile);
            maxDimensions = XMLHandler.ParseMaxSize(currentDungeonFile);
            dungeonLayout = XMLHandler.ParseLayout(currentDungeonFile);

            // Parse each individual room's color based on if it's a dark room or not.
            foreach (List<Room> roomList in dungeonLayout)
            {
                foreach (Room room in roomList)
                {
                    room.CurrentRoomTint = LoZGame.Instance.DungeonTint;

                    if (room.IsDark)
                    {
                        room.DefaultRoomTint = Color.Black;
                    }
                    else
                    {
                        room.DefaultRoomTint = LoZGame.Instance.DungeonTint;
                    }
                }
            }

            currentX = startLocation.X;
            currentY = startLocation.Y;
            defeatedBoss = false;
            miniMap = new MiniMap(this);
            miniMap.LoadMap(dungeonLayout, maxDimensions.X, maxDimensions.Y);
        }

        public Point DungeonBossLocation
        {
            get { return dungeonBossLoc; }
            set { dungeonBossLoc = value; }
        }

        public string DungeonName
        {
            get { return dungeonName; }
            set { dungeonName = value; }
        }

        public Color MapColor
        {
            get { return mapColor; }
            set { mapColor = value; }
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

        public int StartRoomX
        {
            get { return startLocation.X; }
            set { startLocation.X = value; }
        }

        public int StartRoomY
        {
            get { return startLocation.Y; }
            set { startLocation.Y = value; }
        }

        public Room CurrentRoom
        {
            get { return dungeonLayout[currentY][currentX]; }
        }

        public int DungeonNumber { get { return dungeonNumber; } set { dungeonNumber = value; } }

        /*
         * Given a particular X and Y value, return that room
         */
        public Room GetRoom(int Y, int X)
        {
            return dungeonLayout[Y][X];
        }
    }
}
