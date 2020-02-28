namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        public readonly int TileWidth = 64;
        public readonly int TileHeight = 64;
        public readonly int VerticalOffset = 16;
        public readonly int HorizontalOffset = 16;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static readonly float UpdatesPerSecond = 60;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private IPlayer link;
        private KeyboardCommandLoader keyboardCommandLoader;
        private MouseCommandLoader mouseCommandLoader;
        private Dungeon dungeon;

        private ItemManager itemManager;
        private OldBlockManager blockManager; //get rid of eventually
        private EntityManager entityManager;
        private EnemyManager enemyManager;

        private List<IController> controllers;
        private List<IPlayer> players;
        private List<IEnemy> enemies;
        private List<IProjectile> projectiles;

        private static readonly LoZGame instance = new LoZGame();

        public static LoZGame Instance { get { return instance; } }

        public ItemManager Items { get { return itemManager; }  }

        public OldBlockManager Blocks { get { return blockManager; } }

        public EntityManager Entities { get { return entityManager; } }

        public EnemyManager Enemies { get { return enemyManager; } }

        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);

            itemManager = new ItemManager();
            blockManager = new OldBlockManager(); //get rid of eventually
            entityManager = new EntityManager();
            enemyManager = new EnemyManager();
        }

        protected override void Initialize()
        {
            string file = "../../../../../etc/levels/dungeon1.xml";
            this.link = new Link();
            this.dungeon = new Dungeon(file);
            this.keyboardCommandLoader = new KeyboardCommandLoader(this.link);
            this.mouseCommandLoader = new MouseCommandLoader(this.dungeon);

            this.controllers = new List<IController>();
            this.controllers.Add(new KeyboardController(this.keyboardCommandLoader));
            this.controllers.Add(new MouseController(this.mouseCommandLoader));

            this.players = new List<IPlayer>();
            this.players.Add(this.link);

            this.projectiles = new List<IProjectile>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            this.enemyManager.LoadSprites();
            this.itemManager.LoadSprites(384, 184);
            this.blockManager.LoadSprites(300, 184); //get rid of eventually
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
            this.enemyManager.CurrentEnemy.Update();
            this.itemManager.CurrentItem.Update();
            //this.blockManager.CurrentBlock.Update();
            this.entityManager.Update();
            CollisionDetection.Update(this.players.AsReadOnly(), this.enemyManager.EnemyList.AsReadOnly(), this.projectiles.AsReadOnly());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Gray);
            this.spriteBatch.Begin();
            this.link.Draw();
            this.enemyManager.CurrentEnemy.Draw();
            this.itemManager.CurrentItem.Draw(this.spriteBatch);
            //this.blockManager.CurrentBlock.Draw();
            this.entityManager.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
