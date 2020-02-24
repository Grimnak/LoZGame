﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LoZGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Rectangle leftBounds;
        private Rectangle rightBounds;
        private Rectangle topBounds;
        private Rectangle bottomBounds;
        private static readonly float UpdatesPerSecond = 60;

        public SpriteBatch SpriteBatch => this.spriteBatch;

        private IPlayer link;
        private KeyboardCommandLoader keyboardCommandLoader;
        private MouseCommandLoader mouseCommandLoader;
        private Dungeon dungeon;

        private List<IController> controllers;
        private List<IPlayer> players;
        private List<IEnemy> enemies;
        private List<IProjectile> projectiles;

        private static readonly LoZGame instance = new LoZGame();

        public static LoZGame Instance { get { return instance; } }


        private LoZGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / UpdatesPerSecond);
        }

        protected override void Initialize()
        {
            string file = "../../../../../etc/levels/dungeon1.xml";
            this.link = new Link(this);
            this.dungeon = new Dungeon(file);
            this.keyboardCommandLoader = new KeyboardCommandLoader(this, this.link, ItemManager.Instance, BlockManager.Instance, EntityManager.Instance, EnemyManager.Instance);
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
            EnemyManager.Instance.LoadSprites();
            ItemManager.Instance.LoadSprites(384, 184);
            BlockManager.Instance.LoadSprites(550, 184);
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
            EnemyManager.Instance.CurrentEnemy.Update();
            ItemManager.Instance.CurrentItem.Update();
            BlockManager.Instance.CurrentBlock.Update();
            EntityManager.Instance.Update();
            CollisionDetection.Update(this.players.AsReadOnly(), EnemyManager.Instance.EnemyList.AsReadOnly(), this.projectiles.AsReadOnly());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Gray);
            this.spriteBatch.Begin();
            this.link.Draw();
            EnemyManager.Instance.CurrentEnemy.Draw(this.spriteBatch);
            ItemManager.Instance.CurrentItem.Draw(this.spriteBatch);
            BlockManager.Instance.CurrentBlock.Draw(this.spriteBatch);
            EntityManager.Instance.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
