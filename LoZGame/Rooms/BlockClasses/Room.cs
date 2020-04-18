namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /*
     * A Room object represents a single dungeon room in-game.
     * All instance fields are private so that the dungeon rooms cannot
     * be adjusted prior to the level being loaded.
     */
    public class Room
    {
        private bool exists = false;
        private bool basement = false;
        private bool oldman = false;
        private Boomerang droppedBoomerang = null;
        private HeartContainer droppedHeartContainer = null;
        private MagicBoomerang droppedMagicBoomerang = null;
        private string text = null;
        private List<IItem> items = null; // a list for any and all items in a room
        private List<IEnemy> enemies = null; // a list for any and all enemies in a room
        private List<IBlock> blocks = null; // a list for any and all tiles in a room
        private List<Door> doors = null; // a list for any and all doors in a room
        private ISprite border = null;

        /*
         * args:
         * ns => namespace of XML dungeon doc
         * ex => whether the room is null or not
         * bm => whether the room is a basement or not
         * om => whether the room is an oldman room or not
         */
        public Room(string ns, bool ex, bool bm = false, bool om = false)
        {
            if (ex)
            {
                this.exists = ex;
                this.basement = bm;
                this.oldman = om;
                // this.border = ns; // ns = LEVEL-1 || LEVEL-2 || LEVEL-3
                this.doors = new List<Door>();
                this.blocks = new List<IBlock>();
                this.enemies = new List<IEnemy>();
                this.items = new List<IItem>();
            }
        }

        /// <summary>
        /// Gets or sets the enemies list.
        /// </summary>
        public List<IEnemy> Enemies
        {
            get { return this.enemies; } set { this.enemies = value; }
        }

        /// <summary>
        /// Gets or sets the items list.
        /// </summary>
        public List<IItem> Items
        {
            get { return this.items; } set { this.items = value; }
        }

        /// <summary>
        /// Gets or sets the blocks list.
        /// </summary>
        public List<IBlock> Tiles
        {
            get { return this.blocks; } set { this.blocks = value; }
        }

        /// <summary>
        /// Gets or sets the doors list.
        /// </summary>
        public List<Door> Doors
        {
            get { return this.doors; } set { this.doors = value; }
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

        public string RoomText
        {
            get { return this.text; }
        }

        public Tuple<Key, bool> DroppedKey { get; set; }

        public Boomerang DroppedBoomerang => this.droppedBoomerang;

        public HeartContainer DroppedHeartContainer => this.droppedHeartContainer;

        public MagicBoomerang DroppedMagicBoomerang => this.droppedMagicBoomerang;

        public bool IsBasement => this.basement;

        /// <summary>
        /// Converts grid position in the room to a screen vector.
        /// </summary>
        /// <param name="gridX">X value of the grid coord.</param>
        /// <param name="gridY">Y value of the grid coord.</param>
        /// <returns>Vector for screen drawing.</returns>
        public Vector2 GridToScreenVector(float gridX, float gridY)
        {
            return new Vector2(
                (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * gridX)),
                (float)(BlockSpriteFactory.Instance.TopOffset + (BlockSpriteFactory.Instance.TileHeight * gridY)));
        }

        /// <summary>
        /// Converts grid position in the room to a screen vector, without offsets of dungeon border in basement special case.
        /// </summary>
        /// <param name="gridX">X value of the grid coord.</param>
        /// <param name="gridY">Y value of the grid coord.</param>
        /// <returns>Vector for screen drawing.</returns>
        public Vector2 GridToScreenSpecialVector(float gridX, float gridY)
        {
            return new Vector2(
                (float)(BlockSpriteFactory.Instance.TileWidth * gridX),
                (float)(LoZGame.Instance.InventoryOffset + (BlockSpriteFactory.Instance.TileHeight * gridY)));
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type/kind of enemy at X/Y
         */
        public void AddEnemy(float x, float y, string type)
        {
            Vector2 location = this.GridToScreenVector(x, y);
            switch (type)
            {
                case "Dodongo":
                    this.enemies.Add(new Dodongo(location));
                    break;
                case "Dragon":
                    this.enemies.Add(new Dragon(location));
                    break;
                case "TealGel":
                    this.enemies.Add(new Gel(location));
                    break;
                case "Goriya":
                    this.enemies.Add(new Goriya(location));
                    break;
                case "BlueGoriya":
                    this.enemies.Add(new BlueGoriya(location));
                    break;
                case "Keese":
                    this.enemies.Add(new Keese(location));
                    break;
                case "Merchant":
                    this.enemies.Add(new Merchant(location));
                    break;
                case "OldMan":
                    this.enemies.Add(new OldMan(location));
                    break;
                case "Rope":
                    this.enemies.Add(new Rope(location));
                    break;
                case "SpikeCross":
                    this.enemies.Add(new SpikeCross(location));
                    break;
                case "Stalfos":
                    this.enemies.Add(new Stalfos(location));
                    break;
                case "WallMaster":
                    this.enemies.Add(new WallMaster(location));
                    break;
                case "Zol":
                    this.enemies.Add(new Zol(location));
                    break;
                case "FireSnake":
                    this.enemies.Add(new FireSnakeHead(location));
                    break;
                case "FireBlockEnemy":
                    this.enemies.Add(new BlockEnemy(location));
                    break;
                case "Darknut":
                    this.enemies.Add(new Darknut(location));
                    break;
                case "Vire":
                    this.enemies.Add(new Vire(location));
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
        public void AddItem(float x, float y, string name)
        {
            Vector2 location = this.GridToScreenVector(x, y);
            switch (name)
            {
                case "Bow":
                    location = this.GridToScreenSpecialVector(x, y);
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.items.Add(new Bow(location));
                    break;
                case "HeartContainer":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 4);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.droppedHeartContainer = new HeartContainer(location);
                    break;
                case "Key":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.DroppedKey = Tuple.Create(new Key(location), false);
                    break; 
                case "Compass":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 4);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.items.Add(new Compass(location));
                    break;
                case "Boomerang":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.droppedBoomerang = new Boomerang(location);
                    break;
                case "MagicBoomerang":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.droppedMagicBoomerang = new MagicBoomerang(location);
                    break;
                case "TriForce":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 5);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 2);
                    this.items.Add(new Triforce(location));
                    break;
                case "Map":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    this.items.Add(new Map(location));
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
         * dirs => directions for movable tile [Optional]
         */
        public void AddBlock(string x, string y, string type, string name, [Optional] string dirs)
        {
            Vector2 location = this.GridToScreenVector(float.Parse(x), float.Parse(y));
            switch (type)
            {
                case "movable":
                    this.blocks.Add(new MovableTile(location, name, dirs));
                    break;
                case "walkable":
                    if (name.Equals("ladder_tile"))
                    {
                        location = this.GridToScreenSpecialVector(float.Parse(x), float.Parse(y));
                    }

                    this.blocks.Add(new Tile(location, name));
                    break;
                case "block":
                    if (name.Equals("basement_brick_tile"))
                    {
                        location = this.GridToScreenSpecialVector(float.Parse(x), float.Parse(y));
                    }
                    this.blocks.Add(new BlockTile(location, name));
                    break;
                default:
                    break;
            }
        }

        private void SetBounds(IBlock block, string name)
        {
            if (name.Contains("statue"))
            {
                block.Physics.Bounds = new Rectangle(block.Physics.Bounds.X, block.Physics.Bounds.Y + GameData.Instance.RoomConstants.BlockTileHeightOffset, block.Physics.Bounds.Width, block.Physics.Bounds.Height - GameData.Instance.RoomConstants.BlockTileHeightOffset);
                block.Physics.BoundsOffset = new Vector2(0, GameData.Instance.RoomConstants.BlockTileHeightOffset);
                block.Physics.SetDepth();
                block.Physics.SetLocation();
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

        /// <summary>
        /// Draws the correct border for a room.
        /// </summary>
        /// <param name="locationOffset">the offset from the standard location to draw at. Leave as Vector2.Zero for normal border.</param>
        public void Draw(Point locationOffset)
        {
            if (this.basement)
            {
                // dont draw a border
            }
            else if (this.oldman)
            {
                LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.BackgroundHole, new Rectangle(0 + locationOffset.X, LoZGame.Instance.InventoryOffset + locationOffset.Y, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
            }
            else
            {
                LoZGame.Instance.SpriteBatch.Draw(LoZGame.Instance.Background, new Rectangle(0 + locationOffset.X, LoZGame.Instance.InventoryOffset + locationOffset.Y, LoZGame.Instance.ScreenWidth, LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset), new Rectangle(0, 0, 236, 160), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0f);
            }
        }
    }
}
