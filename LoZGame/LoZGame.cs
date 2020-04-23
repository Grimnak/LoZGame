namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        public static bool DebugMode = false; // show collision bounding boxes
        public static bool Cheats = true; // infinite life and item uses
        public static bool Music = false; // Title screen and dungeon music (not SFX)
        public static readonly int StartDungeon = 1; // dungeon ID to load into [1 - 5];
        public int Difficulty = 0; // 0 is normal, can scale infinitely up but you'll get really dumb bugs and probably crash
        private static readonly float UpdatesPerSecond = DefaultUpdateSpeed;
        private const int DefaultUpdateSpeed = 60;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly int inventoryOffset;

        public int ScreenWidth => screenWidth;

        public int ScreenHeight => screenHeight;

        public int InventoryOffset => inventoryOffset;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private int gameLife;

        public SpriteBatch SpriteBatch => spriteBatch;

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
        private Effect betterTinting;

        private DropManager dropManager;
        private CollisionDetection collisionDetector;
        private DebugManager debugManager;

        private List<IController> controllers;
        private List<IPlayer> players;

        private Color dungeonTint;

        private static readonly LoZGame instance = new LoZGame();

        public Effect BetterTinting => betterTinting;

        public Color DungeonTint { get { return dungeonTint; } set { dungeonTint = value; } }

        public Color DefaultTint { get { return Color.White; } }

        public IPlayer Link
        {
            get { return link; }
            set { link = value; }
        }

        public Dungeon Dungeon { get { return dungeon; } set { dungeon = value; } }

        public List<IController> Controllers { get { return controllers; } }

        public List<IPlayer> Players { get { return players; } }

        public static LoZGame Instance { get { return instance; } }

        public GameObjectManager GameObjects { get { return gameObjectManager; } set { gameObjectManager = value; } }

        public DebugManager Debugger => debugManager;

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
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 654;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();

            screenWidth = 800;
            screenHeight = 654;
            inventoryOffset = 174;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
            gameObjectManager = new GameObjectManager();
            dropManager = new DropManager();
            debugManager = new DebugManager();
            Window.Title = "The Legend of Zelda: Reimagined";
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            controllers = new List<IController>();
            players = new List<IPlayer>();
            randomNumberGenerator = new Random();
            debugManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("dungeon");
            backgroundHole = Content.Load<Texture2D>("dungeonHole");
            Effect effect = Content.Load<Effect>("BetterTint");
            betterTinting = effect;
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ScreenSpriteFactory.Instance.LoadAllTextures(Content);
            InventorySpriteFactory.Instance.LoadAllTextures(Content);
            DungeonSpriteFactory.Instance.LoadAllTextures(Content);

            font = Content.Load<SpriteFont>("Text");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StartGame();
        }

        private void StartGame()
        {
            gameState = new TitleScreenState();
            gameState.TitleScreen();
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

            gameState.Update();

            if (DebugMode)
            {
                debugManager.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            gameState.Draw();

            if (DebugMode)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                debugManager.Draw();
                spriteBatch.End();
            }

            if (Cheats)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                spriteBatch.DrawString(font, "CHEATS ON", new Vector2(0, LoZGame.Instance.InventoryOffset), Color.Black);
                spriteBatch.DrawString(font, "CHEATS ON", new Vector2(3, LoZGame.Instance.InventoryOffset + 3), Color.DarkRed);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public void ToggleDebug()
        {
            if (DebugMode)
            {
                DebugMode = false;
            }
            else
            {
                DebugMode = true;
            }
        }

        public void ToggleCheats()
        {
            if (DebugMode)
            {
                Cheats = false;
            }
            else
            {
                Cheats = true;
            }
        }

        public void ToggleMusic()
        {
            if (DebugMode)
            {
                Music = false;
            }
            else
            {
                Music = true;
            }
        }
    }
}