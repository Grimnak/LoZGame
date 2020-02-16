using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LoZGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        private IPlayer link;
        private CommandLoader commandLoader;
        private IController keyboardController;
        private ItemManager itemManager;
        private BlockManager blockManager;
        private EntityManager entityManager;

        public LoZGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            link = new Link(this);
            itemManager = new ItemManager();
            blockManager = new BlockManager();
            entityManager = new EntityManager();
            commandLoader = new CommandLoader(this, link, itemManager, blockManager, entityManager);
            keyboardController = new KeyboardController(this, commandLoader);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            itemManager.loadSprites(300, 240);
            blockManager.loadSprites(500, 240);
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            link.Update();
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
            itemManager.currentItem.Draw(spriteBatch);
            blockManager.currentBlock.Draw(spriteBatch, new Vector2(500, 240), Color.White);
            entityManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}