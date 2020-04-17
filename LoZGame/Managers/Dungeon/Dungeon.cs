﻿namespace LoZClone
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

            switch (this.dungeonNumber)
            {
                case 1:
                    LoZGame.Instance.DungeonTint = Color.White;
                    this.currentX = 2;
                    this.currentY = 5; // player spawns at curX/curY
                    this.maxX = 6;
                    this.maxY = 6;
                    this.mapColor = Color.CornflowerBlue;
                    this.dungeonBossLoc = new Point(4, 1);
                    break;
                case 2:
                    LoZGame.Instance.DungeonTint = new Color(190, 130, 255);
                    this.currentX = 1;
                    this.currentY = 7;
                    this.maxX = 4;
                    this.maxY = 8;
                    this.mapColor = Color.DarkBlue;
                    this.dungeonBossLoc = new Point(2, 0);
                    break;
                case 3:
                    LoZGame.Instance.DungeonTint = Color.Yellow;
                    this.currentX = 3;
                    this.currentY = 5;
                    this.maxX = 5;
                    this.maxY = 6;
                    this.mapColor = Color.Green;
                    break;
                case 4:
                    LoZGame.Instance.DungeonTint = Color.Tan;
                    this.currentX = 1;
                    this.currentY = 7;
                    this.maxX = 4;
                    this.maxY = 8;
                    this.mapColor = Color.Yellow;
                    break;
                default:
                    break;
            }

            this.dungeonLayout = XMLHandler.Parse(this.currentDungeonFile);

            this.miniMap = new MiniMap(this);
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
