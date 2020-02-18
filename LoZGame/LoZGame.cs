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
        private List<IController> controllers;
        private ItemManager itemManager;
        private EntityManager entityManager;
        private BlockManager blockManager;
        private EnemyManager enemyManager;

        public LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
        }

        protected override void Initialize()
        {
            this.link = new Link(this);
            this.entityManager = new EntityManager();
            this.enemyManager = new EnemyManager(this.entityManager);
            this.itemManager = new ItemManager();
            this.blockManager = new BlockManager();
            this.keyboardCommandLoader = new KeyboardCommandLoader(this, this.link, this.itemManager, this.blockManager, this.entityManager, this.enemyManager);
            this.mouseCommandLoader = new MouseCommandLoader();
            this.controllers = new List<IController>();
            this.controllers.Add(new KeyboardController(this.keyboardCommandLoader));
            this.controllers.Add(new MouseController(this.mouseCommandLoader));
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
            this.blockManager.LoadSprites(550, 184);
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
            this.blockManager.CurrentBlock.Update();
            this.entityManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Gray);
            this.spriteBatch.Begin();
            this.link.Draw();
            this.enemyManager.CurrentEnemy.Draw(this.spriteBatch);
            this.itemManager.CurrentItem.Draw(this.spriteBatch);
            this.blockManager.CurrentBlock.Draw(this.spriteBatch);
            this.entityManager.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
