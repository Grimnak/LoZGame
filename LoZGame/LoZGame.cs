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
        private InventoryManager inventoryManager;

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
            inventoryManager = new InventoryManager();
            commandLoader = new CommandLoader(this, link, itemManager, blockManager, inventoryManager);
            keyboardController = new KeyboardController(this, commandLoader);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            itemManager.loadSprites(120, 120);
            blockManager.loadSprites(240, 240);
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
            inventoryManager.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw();
            itemManager.currentItem.Draw(spriteBatch);
            blockManager.currentBlock.Draw(spriteBatch, new Vector2(240, 150), Color.White);
            inventoryManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}