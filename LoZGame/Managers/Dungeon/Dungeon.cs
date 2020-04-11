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
        private int maxX;
        private int maxY;
        private IPlayer player;
        private string currentDungeonFile;
        private int dungeonNumber;
        private MiniMap miniMap;

        public MiniMap MiniMap => miniMap;

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
            this.dungeonNumber = dungeonNumber;
            this.currentDungeonFile = "../../../../../etc/levels/dungeon" + this.dungeonNumber + ".xml";


            switch (this.dungeonNumber)
            {
                case 1:
                    LoZGame.Instance.DungeonTint = Color.White;
                    this.currentX = 2;
                    this.currentY = 5; // player spawns at curX/curY
                    this.maxX = 6;
                    this.maxY = 6;
                    break;
                case 2:
                    LoZGame.Instance.DungeonTint = new Color(190, 130, 255);
                    this.currentX = 1;
                    this.currentY = 7; // player spawns at curX/curY
                    this.maxX = 4;
                    this.maxY = 8;
                    break;
                // more cases here for more dungeons
                default:
                    break;
            }

            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            this.miniMap = new MiniMap();
            this.miniMap.LoadMap(this.dungeonLayout, this.maxX, this.maxY);
            this.LoadNewRoom();
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

        public int DungeonNumber { get { return dungeonNumber; } }

        /*
         * Given a particular X and Y value, return that room
         */
        public Room GetRoom(int Y, int X)
        {
            return this.dungeonLayout[Y][X];
        }
    }
}
