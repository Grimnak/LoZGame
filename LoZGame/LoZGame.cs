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
        private ProjectileManager projectileManager;
        private EnemyManager enemyManager;

        public LoZGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            link = new Link(this);
            enemyManager = new EnemyManager();
            itemManager = new ItemManager();
            blockManager = new BlockManager();
            projectileManager = new ProjectileManager();
            commandLoader = new CommandLoader(this, link, itemManager, blockManager, projectileManager);
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
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            enemyManager.loadSprites(400, 240);
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
            enemyManager.currentEnemy.Update();
            itemManager.currentItem.Update();
            blockManager.currentBlock.Update();
            projectileManager.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw();
            enemyManager.currentEnemy.Draw(spriteBatch);
            itemManager.currentItem.Draw(spriteBatch);
            blockManager.currentBlock.Draw(spriteBatch, new Vector2(240, 150), Color.White);
            projectileManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}