namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static readonly float UpdatesPerSecond = 60;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private IPlayer link;
        private KeyboardCommandLoader keyboardCommandLoader;
        private MouseCommandLoader mouseCommandLoader;
        private Dungeon dungeon;
        private Texture2D background;
        private SpriteFont font;

        private ItemManager itemManager;
        private BlockManager blockManager;
        private EntityManager entityManager;
        private EnemyManager enemyManager;
        private DoorManager doorManager;
        private CollisionDetection collisionDetector;
        private Random randomNumberGenerator;

        private List<IController> controllers;
        private List<IPlayer> players;
        private List<IProjectile> projectiles;
        private List<IItem> items;

        private Color dungeonTint;

        public Color DungeonTint { get { return dungeonTint; } set { dungeonTint = value; } }

        public IPlayer Link
        {
            get { return this.link; }
        }

        public Dungeon Dungeon
        {
            get { return this.dungeon; }
        }

        private static readonly LoZGame instance = new LoZGame();

        public static LoZGame Instance { get { return instance; } }

        public ItemManager Items { get { return itemManager; } }

        public BlockManager Blocks { get { return blockManager; } }

        public EntityManager Entities { get { return entityManager; } }

        public EnemyManager Enemies { get { return enemyManager; } }

        public DoorManager Doors { get { return doorManager; } }

        public Random Random { get { return randomNumberGenerator; } }

        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);

            itemManager = new ItemManager();
            blockManager = new BlockManager();
            entityManager = new EntityManager();
            enemyManager = new EnemyManager();
            doorManager = new DoorManager();

        }

        protected override void Initialize()
        {
            this.controllers = new List<IController>();
            this.players = new List<IPlayer>();
            this.projectiles = new List<IProjectile>();
            this.items = new List<IItem>();
            this.projectiles = new List<IProjectile>();
            this.randomNumberGenerator = new Random();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.background = Content.Load<Texture2D>("dungeon");

            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);

            string file = "../../../../../etc/levels/dungeon1.xml";
            this.dungeon = new Dungeon(file);
            collisionDetector = new CollisionDetection(dungeon);
            font = Content.Load<SpriteFont>("Text");

            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            this.link = new Link(new Vector2(
                    (float)(BlockSpriteFactory.Instance.HorizontalOffset + (BlockSpriteFactory.Instance.TileWidth * 5.5)),
                    (float)(BlockSpriteFactory.Instance.VerticalOffset + (BlockSpriteFactory.Instance.TileHeight * 6))));
            this.dungeon.Player = this.link;

            this.keyboardCommandLoader = new KeyboardCommandLoader(this.link, this.dungeon);
            this.mouseCommandLoader = new MouseCommandLoader(this.dungeon);

            this.controllers.Add(new KeyboardController(this.keyboardCommandLoader));
            this.controllers.Add(new MouseController(this.mouseCommandLoader));

            this.players.Add(this.link);

            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.itemManager.LoadSprites(384, 184);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in this.controllers)
            {
                controller.Update();
            }

            this.link.Update();
            this.enemyManager.Update();
            this.itemManager.Update();
            this.blockManager.Update();
            this.doorManager.Update();
            this.entityManager.Update();
            this.collisionDetector.Update(this.players.AsReadOnly(), this.enemyManager.EnemyList.AsReadOnly(), this.blockManager.BlockList.AsReadOnly(), this.doorManager.DoorList.AsReadOnly(), this.projectiles.AsReadOnly());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);
            this.spriteBatch.Begin();
            if (dungeon.CurrentRoomX != 1 || dungeon.CurrentRoomY != 1)
            {
                this.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), new Rectangle(0, 0, 236, 160), dungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            }

            this.blockManager.Draw();
            if (dungeon.CurrentRoomX == 0 && dungeon.CurrentRoomY == 2)
            {
                this.spriteBatch.DrawString(font, this.dungeon.CurrentRoom.RoomText, new Vector2(100, 100), Color.White);
            }
            this.itemManager.Draw();
            this.enemyManager.Draw();
            this.entityManager.Draw();
            this.doorManager.Draw();
            this.link.Draw();
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
