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
        private ISprite Background;
        private bool exists = false;
        private bool basement = false;
        private bool oldman = false;
        private string text = null;
        private List<IItem> items = null; // a list for any and all items in a room
        private List<IEnemy> enemies = null; // a list for any and all enemies in a room
        private List<IBlock> blocks = null; // a list for any and all tiles in a room
        private List<Door> doors = null; // a list for any and all doors in a room

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
                exists = ex;
                basement = bm;
                oldman = om;
                doors = new List<Door>();
                blocks = new List<IBlock>();
                enemies = new List<IEnemy>();
                items = new List<IItem>();
                if (oldman)
                {
                    Background = DungeonSpriteFactory.Instance.DungeonHole();
                } 
                else
                {
                    Background = DungeonSpriteFactory.Instance.Dungeon();
                }
            }
        }

        /// <summary>
        /// Gets or sets the enemies list.
        /// </summary>
        public List<IEnemy> Enemies
        {
            get { return enemies; } set { enemies = value; }
        }

        /// <summary>
        /// Gets or sets the items list.
        /// </summary>
        public List<IItem> Items
        {
            get { return items; } set { items = value; }
        }

        /// <summary>
        /// Gets or sets the blocks list.
        /// </summary>
        public List<IBlock> Tiles
        {
            get { return blocks; } set { blocks = value; }
        }

        /// <summary>
        /// Gets or sets the doors list.
        /// </summary>
        public List<Door> Doors
        {
            get { return doors; } set { doors = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the room contains anything.
        /// </summary>
        public bool Exists
        {
            get { return exists; }
        }

        /*
         * this method exists in case we want to change the text during runtime
         * for any reason and also since most rooms will not normally have text
         * args:
         * txt => a particular string to be displayed in a room
         */
        public void SetText(string txt)
        {
            text = txt;
        }

        public string RoomText
        {
            get { return text; }
        }

        public Tuple<Key, bool> DroppedKey { get; set; }

        public Tuple<Boomerang, bool> DroppedBoomerang { get; set; }

        public Tuple<HeartContainer, bool> DroppedHeartContainer { get; set; }

        public Tuple<MagicBoomerang, bool> DroppedMagicBoomerang { get; set; }

        public Tuple<Bomb, bool> DroppedBomb { get; set; }

        public Tuple<YellowRupee, bool> DroppedYellowRupee { get; set; }

        public bool IsBasement => basement;

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
            Vector2 location = GridToScreenVector(x, y);
            switch (type)
            {
                case "Dodongo":
                    enemies.Add(new Dodongo(location));
                    break;
                case "Dragon":
                    enemies.Add(new Dragon(location));
                    break;
                case "TealGel":
                    enemies.Add(new Gel(location));
                    break;
                case "Goriya":
                    enemies.Add(new RedGoriya(location));
                    break;
                case "BlueGoriya":
                    enemies.Add(new BlueGoriya(location));
                    break;
                case "Keese":
                    enemies.Add(new Keese(location));
                    break;
                case "Merchant":
                    enemies.Add(new Merchant(location));
                    break;
                case "OldMan":
                    enemies.Add(new OldMan(location));
                    break;
                case "Rope":
                    enemies.Add(new Rope(location));
                    break;
                case "SpikeCross":
                    enemies.Add(new SpikeCross(location));
                    break;
                case "Stalfos":
                    enemies.Add(new Stalfos(location));
                    break;
                case "Gibdo":
                    enemies.Add(new Gibdo(location));
                    break;
                case "WallMaster":
                    enemies.Add(new WallMaster(location));
                    break;
                case "Zol":
                    enemies.Add(new Zol(location));
                    break;
                case "FireSnake":
                    enemies.Add(new MoldormHead(location));
                    break;
                case "FireBlockEnemy":
                    enemies.Add(new BlockEnemy(location));
                    break;
                case "Darknut":
                    enemies.Add(new RedDarknut(location));
                    break;
                case "BlueDarknut":
                    enemies.Add(new BlueDarknut(location));
                    break;
                case "Vire":
                    enemies.Add(new Vire(location));
                    break;
                case "Bubble":
                    enemies.Add(new Bubble(location));
                    break;
                case "Manhandla":
                    Console.WriteLine(x + " | " + y);
                    Console.WriteLine(location);
                    enemies.Add(new ManhandlaBody(location));
                    break;
                case "Gleeok":
                    enemies.Add(new GleeokBody(location));
                    break;
                case "LikeLike":
                    enemies.Add(new Likelike(location));
                    break;
                case "PolsVoice":
                    enemies.Add(new PolsVoice(location));
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
            Vector2 location = GridToScreenVector(x, y);
            switch (name)
            {
                case "Bow":
                    location = GridToScreenSpecialVector(x, y);
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    items.Add(new Bow(location));
                    break;
                case "HeartContainer":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 4);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    DroppedHeartContainer = Tuple.Create(new HeartContainer(location), false);
                    break;
                case "Key":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    DroppedKey = Tuple.Create(new Key(location), false);
                    break; 
                case "Compass":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 4);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    items.Add(new Compass(location));
                    break;
                case "Boomerang":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    DroppedBoomerang = Tuple.Create(new Boomerang(location), false);
                    break;
                case "MagicBoomerang":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    DroppedMagicBoomerang = Tuple.Create(new MagicBoomerang(location), false);
                    break;
                case "TriForce":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 5);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 2);
                    items.Add(new Triforce(location));
                    break;
                case "Map":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 3);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 6);
                    items.Add(new Map(location));
                    break;
                case "WhiteSword":
                    location.X = location.X + (BlockSpriteFactory.Instance.TileWidth / 5);
                    location.Y = location.Y + (BlockSpriteFactory.Instance.TileHeight / 2);
                    items.Add(new WhiteSword(location));
                    break;
                case "MagicSword":
                    items.Add(new MagicSword(location));
                    break;
                case "Ladder":
                    items.Add(new Ladder(location));
                    break;
                case "Bomb":
                    DroppedBomb = Tuple.Create(new Bomb(location), false);
                    break;
                case "Arrow":
                    items.Add(new Arrow(location));
                    break;
                case "SilverArrow":
                    items.Add(new SilverArrow(location));
                    break;
                case "Rupee":
                    items.Add(new Rupee(location));
                    break;
                case "YellowRupee":
                    DroppedYellowRupee = Tuple.Create(new YellowRupee(location), false);
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
            Vector2 location = GridToScreenVector(float.Parse(x), float.Parse(y));
            switch (type)
            {
                case "movable":
                    blocks.Add(new MovableBlock(location, name, dirs));
                    break;
                case "walkable":
                    if (name.Equals("ladder_tile"))
                    {
                        location = GridToScreenSpecialVector(float.Parse(x), float.Parse(y));
                    }

                    blocks.Add(new Tile(location, name));
                    break;
                case "block":
                    if (name.Equals("basement_brick_tile"))
                    {
                        location = GridToScreenSpecialVector(float.Parse(x), float.Parse(y));
                    }
                    blocks.Add(new BlockTile(location, name));
                    break;
                case "crossable":
                    blocks.Add(new CrossableTile(location, name));
                    break;
                default:
                    break;
            }
        }

        public void AddStairs(string x, string y, Point room, Point spawn, bool hidden)
        {
            Vector2 location = GridToScreenVector(float.Parse(x), float.Parse(y));
            blocks.Add(new Stairs(location, room, spawn, hidden));
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
            doors.Add(newDoor); // appending a new Door (Door.cs) to a room object's list of doors
        }

        /// <summary>
        /// Draws the correct border for a room.
        /// </summary>
        /// <param name="locationOffset">the offset from the standard location to draw at. Leave as Vector2.Zero for normal border.</param>
        public void Draw(Point locationOffset)
        {
            if (!basement)
            {
                Background.Draw(new Vector2(0 + locationOffset.X, LoZGame.Instance.InventoryOffset + locationOffset.Y), LoZGame.Instance.DungeonTint, 0);    
            }
        }
    }
}
