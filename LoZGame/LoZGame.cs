namespace LoZClone
{
    using System;
    using System.Collections.Generic;
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
        private SpriteFont font;

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
        }

        public Dungeon Dungeon { get { return this.dungeon; } }

        public List<IController> Controllers { get { return controllers; } }

        public List<IPlayer> Players { get { return players; } }

        public static LoZGame Instance { get { return instance; } }

        public GameObjectManager GameObjects { get { return gameObjectManager; } }

        public DropManager Drops { get { return dropManager; } }

        public IGameState GameState { get { return gameState; } set { gameState = value; } }

        public CollisionDetection CollisionDetector { get { return collisionDetector; } }

        public Random Random { get { return randomNumberGenerator; } }

        public int UpdateSpeed { get { return DefaultUpdateSpeed; } }

        public Texture2D Background { get { return background; } }

        public SpriteFont Font { get { return font; } }

        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
            gameObjectManager = new GameObjectManager();
            dropManager = new DropManager();
            debugManager = new DebugManager();
        }

        protected override void Initialize()
        {
            this.controllers = new List<IController>();
            this.players = new List<IPlayer>();
            this.randomNumberGenerator = new Random();
            this.debugManager.Initialize();

            this.gameState = new PlayGameState();

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
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
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

            this.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);

            this.gameState.Draw();

            if (DebugMode)
            {
                this.debugManager.Draw();
            }
            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            foreach (IPlayer player in this.players)
            {
                ICommand reset = new CommandReset(player, this.dungeon);
                reset.Execute();
            }
        }
    }
}