namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        public static readonly bool DebugMode = false;
        private static readonly float UpdatesPerSecond = DefaultUpdateSpeed;
        private const int DefaultUpdateSpeed = 60;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private const int InversionTime = 5;
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
        private SoundEffectsFactory music;

        private GameObjectManager gameObjectManager;

        private DropManager dropManager;
        private CollisionDetection collisionDetector;
        private DebugManager debugManager;

        private List<IController> controllers;
        private List<IPlayer> players;

        private Color dungeonTint;

        private static readonly LoZGame instance = new LoZGame();

        public Color DungeonTint { get { return dungeonTint; } set { dungeonTint = value; } }

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
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
            gameObjectManager = new GameObjectManager();
            music = new SoundEffectsFactory();
            dropManager = new DropManager();
            debugManager = new DebugManager();
        }

        protected override void Initialize()
        {
            this.controllers = new List<IController>();
            this.players = new List<IPlayer>();
            this.randomNumberGenerator = new Random();
            this.debugManager.Initialize();

            base.Initialize();
            Console.WriteLine("Initialized");
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

            font = Content.Load<SpriteFont>("Text");
            Thread bgLoad = new Thread(new ThreadStart(BusyWait));
            this.gameState = new TitleScreenState();

            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            Console.WriteLine("Loaded");
<<<<<<< HEAD
=======
        }

        private void BusyWait()
        {
            return;
>>>>>>> TitleScreen2
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
            Console.WriteLine("Updated");
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);

            this.gameState.Draw();

            this.spriteBatch.End();

            if (DebugMode)
            {
                this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
                this.debugManager.Draw();
                this.spriteBatch.End();
            }
            Console.WriteLine("Draw");
            base.Draw(gameTime);
        }
    }
}