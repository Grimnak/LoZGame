namespace LoZClone
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DebugManager
    {
        private static readonly Color EnemyColor = Color.MediumPurple; 
        private static readonly Color PlayerColor = Color.ForestGreen; 
        private static readonly Color ItemColor = Color.CornflowerBlue; 
        private static readonly Color ProjectileColor = Color.LawnGreen; 
        private static readonly Color EnemyProjectileColor = Color.Purple; 
        private static readonly Color ExplosionColor = Color.DarkOliveGreen;
        private static readonly Color DoorColor = Color.Yellow;
        private static readonly Color BlockColor = Color.Aqua;

        private static readonly float BlockLayer = 0.994f;
        private static readonly float ItemLayer = 0.995f;
        private static readonly float EnemyLayer = 0.996f;
        private static readonly float EnemyProjectileLayer = 0.997f;
        private static readonly float ProjectileLayer = 0.998f;
        private static readonly float ExplosionLayer = 0.999f;
        private static readonly float PlayerLayer = 1.0f;
        private static readonly float DoorLayer = 1.0f;

        private Texture2D DebuggSprite;
        private Rectangle DebuggSourceRectangle;

        private List<IDoor> doors;
        private IPlayer player;
        private List<IProjectile> explosions;
        private List<IProjectile> projectiles;
        private List<IProjectile> enemyProjectiles;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<IBlock> blocks;

        public DebugManager()
        {
        }

        public void Initialize() 
        {
            DebuggSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            DebuggSourceRectangle = new Rectangle(0, 0, 1, 1);
        }
        
        public void Update()
        {
            doors = LoZGame.Instance.GameObjects.Doors.DoorList;
            items = LoZGame.Instance.GameObjects.Items.ItemList;
            explosions = LoZGame.Instance.GameObjects.Entities.ExplosionManager.Explosions;
            projectiles = LoZGame.Instance.GameObjects.Entities.ProjectileManager.Projectiles;
            enemyProjectiles = LoZGame.Instance.GameObjects.Entities.EnemyProjectiles;
            enemies = LoZGame.Instance.GameObjects.Enemies.EnemyList;
            player = LoZGame.Instance.Link;
            blocks = LoZGame.Instance.GameObjects.Blocks.BlockList;
        }

        public void Draw()
        {
            foreach (IDoor door in doors)
            {
                DebuggSprite.SetData<Color>(new Color[] { DoorColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, door.Physics.Bounds, DebuggSourceRectangle, DoorColor, 0.0f, Vector2.Zero, SpriteEffects.None, DoorLayer);
            }
            foreach (IItem item in items)
            {
                DebuggSprite.SetData<Color>(new Color[] { ItemColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, item.Physics.Bounds, DebuggSourceRectangle, ItemColor, 0.0f, Vector2.Zero, SpriteEffects.None, ItemLayer);
            }
            foreach (IProjectile projectile in projectiles)
            {
                DebuggSprite.SetData<Color>(new Color[] { ProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, projectile.Physics.Bounds, DebuggSourceRectangle, ProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, ProjectileLayer);
            }
            foreach (IProjectile projectile in enemyProjectiles)
            {
                DebuggSprite.SetData<Color>(new Color[] { EnemyProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, projectile.Physics.Bounds, DebuggSourceRectangle, EnemyProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyProjectileLayer);
            }
            foreach (IProjectile explosion in explosions)
            {
                DebuggSprite.SetData<Color>(new Color[] { ExplosionColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, explosion.Physics.Bounds, DebuggSourceRectangle, ExplosionColor, 0.0f, Vector2.Zero, SpriteEffects.None, ExplosionLayer);
            }
            foreach (IEnemy enemy in enemies)
            {
                DebuggSprite.SetData<Color>(new Color[] { EnemyColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, enemy.Physics.Bounds, DebuggSourceRectangle, EnemyColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyLayer);
            }
            foreach (IBlock block in blocks)
            {
                if (!(block is Tile))
                {
                    DebuggSprite.SetData<Color>(new Color[] { BlockColor });
                    LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, block.Physics.Bounds, DebuggSourceRectangle, BlockColor, 0.0f, Vector2.Zero, SpriteEffects.None, BlockLayer);
                }
            }
            DebuggSprite.SetData<Color>(new Color[] { PlayerColor });
            LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, player.Physics.Bounds, DebuggSourceRectangle, PlayerColor, 0.0f, Vector2.Zero, SpriteEffects.None, PlayerLayer);
        }

        public void Draw(GameObjectManager manager)
        {
            foreach (IDoor door in manager.Doors.DoorList)
            {
                DebuggSprite.SetData<Color>(new Color[] { DoorColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, door.Physics.Bounds, DebuggSourceRectangle, DoorColor, 0.0f, Vector2.Zero, SpriteEffects.None, DoorLayer);
            }
            foreach (IItem item in manager.Items.ItemList)
            {
                DebuggSprite.SetData<Color>(new Color[] { ItemColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, item.Physics.Bounds, DebuggSourceRectangle, ItemColor, 0.0f, Vector2.Zero, SpriteEffects.None, ItemLayer);
            }
            foreach (IProjectile projectile in manager.Entities.ProjectileManager.Projectiles)
            {
                DebuggSprite.SetData<Color>(new Color[] { ProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, projectile.Physics.Bounds, DebuggSourceRectangle, ProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, ProjectileLayer);
            }
            foreach (IProjectile projectile in manager.Entities.EnemyProjectileManager.Projectiles)
            {
                DebuggSprite.SetData<Color>(new Color[] { EnemyProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, projectile.Physics.Bounds, DebuggSourceRectangle, EnemyProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyProjectileLayer);
            }
            foreach (IProjectile explosion in manager.Entities.ExplosionManager.Explosions)
            {
                DebuggSprite.SetData<Color>(new Color[] { ExplosionColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, explosion.Physics.Bounds, DebuggSourceRectangle, ExplosionColor, 0.0f, Vector2.Zero, SpriteEffects.None, ExplosionLayer);
            }
            foreach (IEnemy enemy in manager.Enemies.EnemyList)
            {
                DebuggSprite.SetData<Color>(new Color[] { EnemyColor });
                LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, enemy.Physics.Bounds, DebuggSourceRectangle, EnemyColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyLayer);
            }
            foreach (IBlock block in manager.Blocks.BlockList)
            {
                if (!(block is Tile))
                {
                    DebuggSprite.SetData<Color>(new Color[] { BlockColor });
                    LoZGame.Instance.SpriteBatch.Draw(DebuggSprite, block.Physics.Bounds, DebuggSourceRectangle, BlockColor, 0.0f, Vector2.Zero, SpriteEffects.None, BlockLayer);
                }
            }
        }
    }
}
