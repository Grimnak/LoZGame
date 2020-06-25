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
        private ISprite background;
        private bool exists = false;
        private bool basement = false;
        private bool oldman = false;
        private bool dark = false;
        private bool boss = false;
        private int lightTimer;
        private float colorTransitionCounter;
        private string text = null;
        private string purchaseText = null;
        private Color currentRoomTint;
        private Color defaultRoomTint;
        private List<IItem> items = null; // a list for any and all items in a room
        private List<IEnemy> enemies = null; // a list for any and all enemies in a room
        private List<IBlock> blocks = null; // a list for any and all tiles in a room
        private List<Door> doors = null; // a list for any and all doors in a room

        public ISprite Background { get { return background; } set { background = value; } }

        public Color CurrentRoomTint { get { return currentRoomTint; } set { currentRoomTint = value; } }

        public Color DefaultRoomTint { get { return defaultRoomTint; } set { defaultRoomTint = value; } }

        public int LightTimer { get { return lightTimer; } set { lightTimer = value; } }

        public float ColorTransitionCounter { get { return colorTransitionCounter; } set { colorTransitionCounter = value; } }

        /*
         * args:
         * ns => namespace of XML dungeon doc
         * ex => whether the room is null or not
         * bm => whether the room is a basement or not
         * om => whether the room is an oldman room or not
         * dk => whether the room is dark or not
         * bs => whether the room is a boss room or not
         */
        public Room(string ns, bool ex, bool bm = false, bool om = false, bool dk = false, bool bs = false)
        {
            if (ex)
            {
                exists = ex;
                basement = bm;
                oldman = om;
                dark = dk;
                boss = bs;
                doors = new List<Door>();
                blocks = new List<IBlock>();
                enemies = new List<IEnemy>();
                items = new List<IItem>();
                if (oldman)
                {
                    background = DungeonSpriteFactory.Instance.DungeonHole();
                } 
                else
                {
                    background = DungeonSpriteFactory.Instance.Dungeon();
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

        public void SetPurchaseText(string purchasetxt)
        {
            purchaseText = purchasetxt;
        }

        public string RoomText
        {
            get { return text; }
        }

        public string RoomPurchaseText
        {
            get { return purchaseText; }
        }

        public Tuple<IItem, bool> DroppedKey { get; set; }

        public Tuple<IItem, bool> DroppedBoomerang { get; set; }

        public Tuple<IItem, bool> DroppedHeartContainer { get; set; }

        public Tuple<IItem, bool> DroppedMagicBoomerang { get; set; }

        public Tuple<IItem, bool> DroppedBomb { get; set; }

        public Tuple<IItem, bool> DroppedYellowRupee { get; set; }

        public bool IsBasement => basement;

        public bool IsDark { get { return dark; } set { dark = value; } }

        public bool IsBossRoom { get { return boss; } set { boss = value; } }

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
            IEnemy newEnemy = null;
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
                    enemies.Add(new RedMoldormHead(location));
                    break;
                case "BlueSnake":
                    enemies.Add(new BlueMoldormHead(location));
                    break;
                case "FireBlockEnemy":
                    newEnemy = new BlockEnemy(location);
                    CenterObject(newEnemy.Physics);
                    enemies.Add(newEnemy);
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
                case "DigDogger":
                    enemies.Add(new DigDoggerInvincible(location));
                    break;
                case "RedWizzrobe":
                    enemies.Add(new RedWizzrobe(location));
                    break;
                case "BlueWizzrobe":
                    enemies.Add(new BlueWizzrobe(location));
                    break;
                case "Gohma":
                    enemies.Add(new RedGohma(location));
                    break;
                case "BlueGohma":
                    enemies.Add(new BlueGohma(location));
                    break;
                case "Patra":
                    enemies.Add(new Patra(location));
                    break;
                case "Ganon":
                    enemies.Add(new Ganon(location));
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
            IItem newItem = null;
            switch (name)
            {
                case "Bow":
                    newItem = new Bow(location);
                    items.Add(newItem);
                    break;
                case "HeartContainer":
                    newItem = new HeartContainer(location);
                    DroppedHeartContainer = Tuple.Create(newItem, false);
                    break;
                case "Key":
                    newItem = new Key(location);
                    DroppedKey = Tuple.Create(newItem, false);
                    break;
                case "Compass":
                    newItem = new Compass(location);
                    items.Add(newItem);
                    break;
                case "Boomerang":
                    newItem = new Boomerang(location);
                    DroppedBoomerang = Tuple.Create(newItem, false);
                    break;
                case "MagicBoomerang":
                    newItem = new MagicBoomerang(location);
                    DroppedMagicBoomerang = Tuple.Create(newItem, false);
                    break;
                case "TriForce":
                    newItem = new Triforce(location);
                    items.Add(newItem);
                    break;
                case "Map":
                    newItem = new Map(location);
                    items.Add(newItem);
                    break;
                case "WhiteSword":
                    IItem item = new WhiteSword(location);
                    items.Add(item);
                    break;
                case "Flute":
                    newItem = new Flute(location);
                    items.Add(newItem);
                    break;
                case "MagicSword":
                    newItem = new MagicSword(location);
                    items.Add(newItem);
                    break;
                case "Ladder":
                    newItem = new Ladder(location);
                    items.Add(newItem);
                    break;
                case "Bomb":
                    newItem = new Bomb(location);
                    DroppedBomb = Tuple.Create(newItem, false);
                    break;
                case "Arrow":
                    newItem = new Arrow(location);
                    items.Add(newItem);
                    break;
                case "SilverArrow":
                    newItem = new SilverArrow(location);
                    items.Add(newItem);
                    break;
                case "Rupee":
                    newItem = new Rupee(location);
                    items.Add(newItem);
                    break;
                case "YellowRupee":
                    newItem = new YellowRupee(location);
                    DroppedYellowRupee = Tuple.Create(newItem, false);
                    break;
                case "BlueCandle":
                    newItem = new BlueCandle(location);
                    items.Add(newItem);
                    break;
                case "RedCandle":
                    newItem = new RedCandle(location);
                    items.Add(newItem);
                    break;
                case "BlueRing":
                    newItem = new BlueRing(location);
                    items.Add(newItem);
                    break;
                case "RedRing":
                    newItem = new RedRing(location);
                    items.Add(newItem);
                    break;
                case "MagicRod":
                    newItem = new MagicRod(location);
                    items.Add(newItem);
                    break;
                case "MagicShield":
                    newItem = new MagicShield(location);
                    items.Add(newItem);
                    break;
                case "PurchaseRupee":
                    newItem = new PurchaseRupee(location);
                    items.Add(newItem);
                    break;
                case "MagicKey":
                    newItem = new MagicKey(location);
                    items.Add(newItem);
                    break;
                default:
                    break;
            }
            if (!(newItem is null))
            {
                CenterObject(newItem.Physics);
            }
        }

        public void CenterObject(Physics physics)
        {
            Point offset = new Point((int)BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight) - physics.Bounds.Size;
            offset = new Point(offset.X / 2, offset.Y / 2);
            physics.Bounds = new Rectangle(physics.Bounds.Location + offset, physics.Bounds.Size);
            physics.SetLocation();
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
                background.Draw(new Vector2(0 + locationOffset.X, LoZGame.Instance.InventoryOffset + locationOffset.Y), currentRoomTint, 0);    
            }
        }

        /// <summary>
        /// Determines the brightness of the current room.
        /// </summary>
        /// <param name="defaultRoomTint">Represents the default color of the room as determined by the XML file.</param>
        /// <param name="defaultDungeonTint">Represents the default color of the dungeon [non-dark rooms] as determined by the XML file.</param>
        public void HandleRoomBrightness(Color defaultRoomTint, Color defaultDungeonTint)
        {
            if (dark)
            {
                // If a candle was used, gradually brighten the room.
                if (lightTimer > 0)
                {
                    if (colorTransitionCounter < 1 && currentRoomTint != defaultDungeonTint)
                    {
                        colorTransitionCounter += 0.01f;
                        currentRoomTint = Color.Lerp(defaultRoomTint, defaultDungeonTint, colorTransitionCounter);
                        LoZGame.Instance.DefaultTint = Color.Lerp(defaultRoomTint, Color.White, colorTransitionCounter);
                    }
                    else
                    {
                        colorTransitionCounter = 0;
                    }
                    lightTimer--;
                }
                // Once the allotted brightness time expires, gradually fade to black.
                else
                {
                    if (colorTransitionCounter < 1 && currentRoomTint != defaultRoomTint)
                    {
                        colorTransitionCounter += 0.01f;
                        currentRoomTint = Color.Lerp(defaultDungeonTint, defaultRoomTint, colorTransitionCounter);
                        LoZGame.Instance.DefaultTint = Color.Lerp(Color.White, defaultRoomTint, colorTransitionCounter);
                    }
                    else
                    {
                        colorTransitionCounter = 0;
                    }
                }

                // Remove floor crevices if the room is pitch black.
                if (currentRoomTint == defaultRoomTint)
                {
                    background = DungeonSpriteFactory.Instance.DungeonHole();
                }
                else
                {
                    background = DungeonSpriteFactory.Instance.Dungeon();
                }
            }
        }
    }
}
