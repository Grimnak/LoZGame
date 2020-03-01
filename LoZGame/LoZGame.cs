﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        public readonly int TileWidth = 50;
        public readonly int TileHeight = 50;
        public readonly int VerticalOffset = 64;
        public readonly int HorizontalOffset = 96;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private static readonly float UpdatesPerSecond = 60;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private IPlayer link;
        private KeyboardCommandLoader keyboardCommandLoader;
        private MouseCommandLoader mouseCommandLoader;
        private Dungeon dungeon;

        private ItemManager itemManager;
        private BlockManager blockManager;
        private EntityManager entityManager;
        private EnemyManager enemyManager;
        private CollisionDetection collisionDetector;

        private List<IController> controllers;
        private List<IPlayer> players;
        private List<IEnemy> enemies;
        private List<IProjectile> projectiles;

        public IPlayer Link
        {
            get { return this.link; }
        }

        private static readonly LoZGame instance = new LoZGame();

        public static LoZGame Instance { get { return instance; } }

        public ItemManager Items { get { return itemManager; } }

        public BlockManager Blocks { get { return blockManager; } }

        public EntityManager Entities { get { return entityManager; } }

        public EnemyManager Enemies { get { return enemyManager; } }

        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);

            itemManager = new ItemManager();
            blockManager = new BlockManager();
            entityManager = new EntityManager();
            enemyManager = new EnemyManager();
            collisionDetector = new CollisionDetection();
        }

        protected override void Initialize()
        {
            this.controllers = new List<IController>();
            this.players = new List<IPlayer>();
            this.projectiles = new List<IProjectile>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            this.link = new Link();

            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);

            string file = "../../../../../etc/levels/dungeon1.xml";
            this.dungeon = new Dungeon(file, this.link);


            this.keyboardCommandLoader = new KeyboardCommandLoader(this.link, this.dungeon);
            this.mouseCommandLoader = new MouseCommandLoader(this.dungeon);


            this.controllers.Add(new KeyboardController(this.keyboardCommandLoader));
            this.controllers.Add(new MouseController(this.mouseCommandLoader));


            this.players.Add(this.link);


            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);


            this.itemManager.LoadSprites(384, 184);
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
            this.enemyManager.Update();
            this.itemManager.CurrentItem.Update();
            this.blockManager.Update();
            this.entityManager.Update();
            this.collisionDetector.Update(this.players.AsReadOnly(), this.enemyManager.EnemyList.AsReadOnly(), this.projectiles.AsReadOnly());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Gray);
            this.spriteBatch.Begin();
            this.blockManager.Draw();
            this.itemManager.CurrentItem.Draw(this.spriteBatch);
            this.link.Draw();
            this.enemyManager.Draw();
            this.entityManager.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
