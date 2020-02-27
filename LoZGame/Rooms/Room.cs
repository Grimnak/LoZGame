namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    /*
     * A Room object represents a single dungeon room in-game.
     * All instance fields are private so that the dungeon rooms cannot
     * be adjusted prior to the level being loaded.
     */
    public partial class Room
    {
        private bool exists = false;
        private string border = null;
        private string text = null;
        private List<IItemSprite> items = null; // a list for any and all items in a room
        private List<IEnemy> enemies = null; // a list for any and all enemies in a room
        private List<ITile> tiles = null; // a list for any and all tiles in a room
        private List<Door> doors = null; // a list for any and all doors in a room

        /*
         * args:
         * ns => namespace of XML dungeon doc
         * ex => whether the room is null or not
         */
        public Room(string ns, bool ex)
        {
            if (ex)
            {
                this.exists = ex;
                this.border = ns; // ns = LEVEL-1 || LEVEL-2
                this.doors = new List<Door>();
                this.tiles = new List<ITile>();
                this.enemies = new List<IEnemy>();
                this.items = new List<IItemSprite>();
            }
        }

        /// <summary>
        /// Gets the enemies list.
        /// </summary>
        public List<IEnemy> Enemies
        {
            get { return this.enemies; }
        }

        /// <summary>
        /// Gets the items list.
        /// </summary>
        public List<IItemSprite> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Gets the tiles list.
        /// </summary>
        public List<ITile> Tiles
        {
            get { return this.tiles; }
        }

        /// <summary>
        /// Gets the doors list.
        /// </summary>
        public List<Door> Doors
        {
            get { return this.doors; }
        }

        /// <summary>
        /// Gets a value indicating whether the room contains anything.
        /// </summary>
        public bool Exists
        {
            get { return this.exists; }
        }

        /*
         * this method exists in case we want to change the text during runtime
         * for any reason and also since most rooms will not normally have text
         * args:
         * txt => a particular string to be displayed in a room
         */
        public void SetText(string txt)
        {
            this.text = txt;
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type/kind of enemy at X/Y
         */
        public void AddEnemy(int x, int y, string type)
        {
            switch (type)
            {
                // commented lines require entity manager to be passed currently
                case "Dodongo":
                    this.enemies.Add(new Dodongo(new Vector2(650, 200)));
                    break;
                case "Dragon":
                    // needs entity manager
                    this.enemies.Add(new Dragon(new Vector2(650,200)));
                    break;
                case "Gel":
                    this.enemies.Add(new Gel(new Vector2(650, 200)));
                    break;
                case "Goriya":
                    // needs entity manager
                    this.enemies.Add(new Goriya(new Vector2(650, 200)));
                    break;
                case "Keese":
                    this.enemies.Add(new Keese(new Vector2(650, 200)));
                    break;
                case "Merchant":
                    this.enemies.Add(new Merchant(new Vector2(650, 200)));
                    break;
                case "OldMan":
                    this.enemies.Add(new OldMan(new Vector2(650, 200)));
                    break;
                case "Rope":
                    this.enemies.Add(new Rope(new Vector2(650, 200)));
                    break;
                case "SpikeCross":
                    this.enemies.Add(new SpikeCross(new Vector2(650, 200)));
                    break;
                case "Stalfos":
                    this.enemies.Add(new Stalfos(new Vector2(650, 200)));
                    break;
                case "WallMaster":
                    this.enemies.Add(new WallMaster(new Vector2(650, 200)));
                    break;
                case "Zol":
                    this.enemies.Add(new Zol(new Vector2(650, 200)));
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * name => the item's name
         */
        public void AddItem(int x, int y, string name)
        {
            // commented things will remain commented until items are separated from their sprites
            switch (name)
            {
                case "Bow":
                    // this.items.Add(new Bow());
                    break;
                case "HeartContainer":
                    // this.items.Add(new HeartContainer());
                    break;
                case "Key":
                    // this.items.Add(new Key());
                    break;
                case "Compass":
                    // this.items.Add(new Compass());
                    break;
                case "Boomerang":
                    // this.items.Add(new Boomerang());
                    break;
                case "TriForce":
                    // this.items.Add(new TriForce());
                    break;
                case "Map":
                    // this.items.Add(new Map());
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type of tile
         * name => name of tile sprite
         */
        public void AddTile(string x, string y, string type, string name)
        {
            switch (type)
            {
                case "movable":
                    this.tiles.Add(new MovableTile(x, y, name));
                    break;
                case "walkable":
                    this.tiles.Add(new Tile(x, y, name));
                    break;
                case "block":
                    this.tiles.Add(new BlockTile(x, y, name));
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * location => N/E/S/W
         * kind => which kind of door sprite
         */
        public void AddDoor(string location, string kind)
        {
            Door newDoor = new Door(location, kind);
            this.doors.Add(newDoor); // appending a new Door (Door.cs) to a room object's list of doors
        }
    }
}
