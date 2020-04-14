namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        public static readonly bool DebugMode = false; // show collision bounding boxes
        public static readonly bool Cheats = true; // infinite life and item uses
        public static readonly bool Music = false; // Title screen and dungeon music (not SFX)
        public static readonly int StartDungeon = 1; // dungeon ID to load into [1 - 3];
        private static readonly float UpdatesPerSecond = DefaultUpdateSpeed;
        private const int DefaultUpdateSpeed = 60;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly int inventoryOffset;

        public int ScreenWidth => this.screenWidth;

        public int ScreenHeight => this.screenHeight;

        public int InventoryOffset => this.inventoryOffset;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //private const int InversionTime = 5;
        private int gameLife;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private Random randomNumberGenerator;

        private IPlayer link;
        private IGameState gameState;
        private KeyboardCommandLoader keyboardCommandLoader;
        private MouseCommandLoader mouseCommandLoader;
        private Dungeon dungeon;
        private Texture2D background;
        private Texture2D backgroundHole;
        private SpriteFont font;
        private SoundFactory music;
        private GameObjectManager gameObjectManager;

        private DropManager dropManager;
        private CollisionDetection collisionDetector;
        private DebugManager debugManager;

        private List<IController> controllers;
        private List<IPlayer> players;

        private Color dungeonTint;

        private static readonly LoZGame instance = new LoZGame();

        public Color DungeonTint { get { return dungeonTint; } set { dungeonTint = value; } }

        public Color DefaultTint { get { return Color.White; } }

        public IPlayer Link
        {
            get { return this.link; }
            set { this.link = value; }
        }

        public Dungeon Dungeon { get { return this.dungeon; } set { this.dungeon = value; } }

        public List<IController> Controllers { get { return controllers; } }

        public List<IPlayer> Players { get { return players; } }

        public static LoZGame Instance { get { return instance; } }

        public GameObjectManager GameObjects { get { return gameObjectManager; } }

        public DropManager Drops { get { return dropManager; } }

        public IGameState GameState { get { return gameState; } set { gameState = value; } }

        public CollisionDetection CollisionDetector { get { return collisionDetector; } set { collisionDetector = value; } }

        public Random Random { get { return randomNumberGenerator; } }

        public int UpdateSpeed { get { return DefaultUpdateSpeed; } }

        public Texture2D Background { get { return background; } }

        public Texture2D BackgroundHole { get { return backgroundHole; } }

        public SpriteFont Font { get { return font; } }

        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 654;
            this.graphics.GraphicsProfile = GraphicsProfile.HiDef;
            this.graphics.ApplyChanges();

            this.screenWidth = 800;
            this.screenHeight = 654;
            this.inventoryOffset = 174;

            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
            this.gameObjectManager = new GameObjectManager();
            this.dropManager = new DropManager();
            this.debugManager = new DebugManager();
        }

        protected override void Initialize()
        {
            this.controllers = new List<IController>();
            this.players = new List<IPlayer>();
            this.randomNumberGenerator = new Random();
            this.debugManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.background = Content.Load<Texture2D>("dungeon");
            this.backgroundHole = Content.Load<Texture2D>("dungeonHole");

            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            ScreenSpriteFactory.Instance.LoadAllTextures(this.Content);
            InventorySpriteFactory.Instance.LoadAllTextures(this.Content);

            this.font = Content.Load<SpriteFont>("Text");
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.GameObjects.Enemies.Add(new FireSnakeHead(new Vector2(200, 400)));
            this.StartGame();
        }

        private void StartGame()
        {
            this.gameState = new TitleScreenState();
            this.gameState.TitleScreen();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < controllers.Count; i++)
            {
                controllers[i].Update();
            }

            this.gameState.Update();

            if (DebugMode)
            {
                this.debugManager.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.gameState.Draw();

            if (DebugMode)
            {
                this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                this.debugManager.Draw();
                this.spriteBatch.End();
            }

            if (Cheats)
            {
                this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                this.spriteBatch.DrawString(font, "CHEATS ON", new Vector2(0,LoZGame.Instance.InventoryOffset), Color.Black);
                this.spriteBatch.DrawString(font, "CHEATS ON", new Vector2(3, LoZGame.Instance.InventoryOffset+3), Color.DarkRed);
                this.spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}