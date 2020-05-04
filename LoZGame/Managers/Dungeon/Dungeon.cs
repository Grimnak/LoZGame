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
        private int startX;
        private int startY;
        private int currentX;
        private int currentY;
        private Color mapColor;
        private int maxX;
        private int maxY;
        private IPlayer player;
        private string currentDungeonFile;
        private int dungeonNumber;
        private MiniMap miniMap;
        private Point dungeonBossLoc;
        private bool defeatedBoss;

        public Point DungeonBossLocation => dungeonBossLoc;

        public List<List<Room>> DungeonLayout { get { return dungeonLayout; } }

        public MiniMap MiniMap => miniMap;

        public Color MapColor => mapColor;

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
            currentDungeonFile = "../../../../etc/levels/dungeon" + this.dungeonNumber + ".xml";
            LoZGame.Instance.GameObjects.LoadedRoomX = -1;
            LoZGame.Instance.GameObjects.LoadedRoomY = -1;

            switch (this.dungeonNumber)
            {
                case 1:
                    LoZGame.Instance.DungeonTint = Color.DarkCyan;
                    startX = 2;
                    startY = 5; // player spawns at curX/curY
                    maxX = 6;
                    maxY = 6;
                    mapColor = Color.DarkCyan;
                    dungeonBossLoc = new Point(4, 1);
                    break;
                case 2:
                    LoZGame.Instance.DungeonTint = Color.Blue;
                    startX = 1;
                    startY = 7;
                    maxX = 4;
                    maxY = 8;
                    mapColor = Color.Blue;
                    dungeonBossLoc = new Point(2, 0);
                    break;
                case 3:
                    LoZGame.Instance.DungeonTint = new Color(41, 175, 72);
                    startX = 3;
                    startY = 5;
                    maxX = 5;
                    maxY = 6;
                    mapColor = Color.Green;
                    dungeonBossLoc = new Point(4, 2);
                    break;
                case 4:
                    LoZGame.Instance.DungeonTint = new Color(178, 162, 0);
                    startX = 1;
                    startY = 7;
                    maxX = 4;
                    maxY = 8;
                    mapColor = Color.DarkGoldenrod;
                    dungeonBossLoc = new Point(3, 1);
                    break;
                case 5:
                    LoZGame.Instance.DungeonTint = new Color(41, 175, 72);
                    startX = 2;
                    startY = 7;
                    maxX = 4;
                    maxY = 8;
                    mapColor = Color.Green;
                    dungeonBossLoc = new Point(0, 2);
                    break;
                case 6:
                    LoZGame.Instance.DungeonTint = new Color(178, 162, 0);
                    startX = 1;
                    startY = 7;
                    maxX = 6;
                    maxY = 8;
                    mapColor = Color.DarkGoldenrod;
                    dungeonBossLoc = new Point(4, 1);
                    break;
                case 7:
                    LoZGame.Instance.DungeonTint = new Color(41, 175, 72);
                    startX = 1;
                    startY = 7;
                    maxX = 6;
                    maxY = 8;
                    mapColor = Color.Green;
                    dungeonBossLoc = new Point(2, 2);
                    break;
                case 8:
                    LoZGame.Instance.DungeonTint = Color.LightGray;
                    startX = 3;
                    startY = 7;
                    maxX = 5;
                    maxY = 8;
                    mapColor = Color.Gray;
                    dungeonBossLoc = new Point(1, 3);
                    break;
                default:
                    break;
            }
            currentX = startX;
            currentY = startY;
            defeatedBoss = false;

            dungeonLayout = XMLHandler.Parse(currentDungeonFile);

            miniMap = new MiniMap(this);
            miniMap.LoadMap(dungeonLayout, maxX, maxY);
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
            get { return startX; }
            set { currentX = value; }
        }

        public int StartRoomY
        {
            get { return startY; }
            set { currentY = value; }
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
