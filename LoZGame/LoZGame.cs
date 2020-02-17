namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static readonly float updatesPerSecond = 50;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private IPlayer link;
        private CommandLoader commandLoader;
        private IController keyboardController;
        private ItemManager itemManager;
        private EntityManager entityManager;
        private BlockManager blockManager;
        private ProjectileManager projectileManager;
        private EnemyManager enemyManager;

        public LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / updatesPerSecond);
        }

        protected override void Initialize()
        {
            link = new Link(this);
            enemyManager = new EnemyManager();
            itemManager = new ItemManager();
            blockManager = new BlockManager();
            entityManager = new EntityManager();
            commandLoader = new CommandLoader(this, link, itemManager, blockManager, entityManager);
            keyboardController = new KeyboardController(commandLoader);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            this.itemManager.loadSprites(384, 184);
            this.blockManager.loadSprites(550, 184);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            link.Update();
            enemyManager.currentEnemy.Update();
            itemManager.currentItem.Update();
            blockManager.currentBlock.Update();
            entityManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw();
            enemyManager.currentEnemy.Draw(spriteBatch);
            itemManager.currentItem.Draw(spriteBatch);
            blockManager.currentBlock.Draw(spriteBatch, new Vector2(500, 184), Color.White);
            entityManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
