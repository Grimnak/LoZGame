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
        private BlockManager blockManager;
        private EntityManager entityManager;

        public LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / updatesPerSecond);
        }

        protected override void Initialize()
        {
            this.link = new Link(this);
            this.itemManager = new ItemManager();
            this.blockManager = new BlockManager();
            this.entityManager = new EntityManager();
            this.commandLoader = new CommandLoader(this, this.link, this.itemManager, this.blockManager, this.entityManager);
            this.keyboardController = new KeyboardController(this.commandLoader);
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
            this.keyboardController.Update();
            this.link.Update();
            this.itemManager.currentItem.Update();
            this.blockManager.currentBlock.Update();
            this.entityManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Gray);
            this.spriteBatch.Begin();
            this.link.Draw();
            this.itemManager.currentItem.Draw(this.spriteBatch);
            this.blockManager.currentBlock.Draw(this.spriteBatch, new Vector2(500, 184), Color.White);
            this.entityManager.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}