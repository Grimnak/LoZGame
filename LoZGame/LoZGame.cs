using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LoZClone
{
    public class LoZGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static float UpdatesPerSecond = 50;
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        private IPlayer link;
        private CommandLoader commandLoader;
        private IController keyboardController;
        private ItemManager itemManager;
        private BlockManager blockManager;
        private ProjectileManager projectileManager;
        private EnemyManager enemyManager;

        public LoZGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            itemManager.loadSprites(384, 184);
            blockManager.loadSprites(550, 184);
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
