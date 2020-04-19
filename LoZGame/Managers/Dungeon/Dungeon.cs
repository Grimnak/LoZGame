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
        private int maxX;
        private int maxY;
        private IPlayer player;
        private string currentDungeonFile;
        private int dungeonNumber;
        private MiniMap miniMap;
        private Point dungeonBossLoc;

        public Point DungeonBossLocation => dungeonBossLoc;

        public List<List<Room>> DungeonLayout { get { return dungeonLayout; } }

        public MiniMap MiniMap => miniMap;

        public Color MapColor => mapColor;

        public IPlayer Player
        {
            get { return player; }
            set { this.player = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="dungeonNumber">Number of the dungeon whose file is to be parsed.</param>
        public Dungeon(int dungeonNumber)
        {
            this.DungeonNumber = dungeonNumber;
            this.currentDungeonFile = "../../../../../etc/levels/dungeon" + this.dungeonNumber + ".xml";
            LoZGame.Instance.GameObjects.LoadedRoomX = -1;
            LoZGame.Instance.GameObjects.LoadedRoomY = -1;

            switch (this.dungeonNumber)
            {
                case 1:
                    LoZGame.Instance.DungeonTint = Color.DarkCyan;
                    this.currentX = 2;
                    this.currentY = 5; // player spawns at curX/curY
                    this.maxX = 6;
                    this.maxY = 6;
                    this.mapColor = Color.CornflowerBlue;
                    this.dungeonBossLoc = new Point(4, 1);
                    break;
                case 2:
                    LoZGame.Instance.DungeonTint = Color.Blue;
                    this.currentX = 1;
                    this.currentY = 7;
                    this.maxX = 4;
                    this.maxY = 8;
                    this.mapColor = Color.DarkBlue;
                    this.dungeonBossLoc = new Point(2, 0);
                    break;
                case 3:
                    LoZGame.Instance.DungeonTint = Color.Green;
                    this.currentX = 3;
                    this.currentY = 5;
                    this.maxX = 5;
                    this.maxY = 6;
                    this.mapColor = Color.Green;
                    break;
                case 4:
                    LoZGame.Instance.DungeonTint = new Color(178, 162, 0);
                    this.currentX = 1;
                    this.currentY = 7;
                    this.maxX = 4;
                    this.maxY = 8;
                    this.mapColor = Color.DarkGoldenrod;
                    break;
                default:
                    break;
            }

            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            this.miniMap = new MiniMap(this);
            this.miniMap.LoadMap(this.dungeonLayout, this.maxX, this.maxY);
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

        public Room CurrentRoom
        {
            get { return this.dungeonLayout[this.currentY][this.currentX]; }
        }

        public int DungeonNumber { get { return dungeonNumber; } set { dungeonNumber = value; } }

        /*
         * Given a particular X and Y value, return that room
         */
        public Room GetRoom(int Y, int X)
        {
            return this.dungeonLayout[Y][X];
        }
    }
}
