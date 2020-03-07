
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

        private static readonly float EnemyLayer = 0.996f;
        private static readonly float PlayerLayer = 1.0f;
        private static readonly float ItemLayer = 0.995f;
        private static readonly float ProjectileLayer = 0.998f;
        private static readonly float EnemyProjectileLayer = 0.997f;
        private static readonly float ExplosionLayer = 0.999f;
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

        public DebugManager()
        {
        }

        public void Initialize() 
        {
            this.DebuggSprite = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.DebuggSourceRectangle = new Rectangle(0, 0, 1, 1);
        }
        
        public void Update()
        {
            this.doors = LoZGame.Instance.Doors.DoorList;
            this.items = LoZGame.Instance.Items.ItemList;
            this.explosions = LoZGame.Instance.Entities.ExplosionManager.Explosions;
            this.projectiles = LoZGame.Instance.Entities.ProjectileManager.Projectiles;
            this.enemyProjectiles = LoZGame.Instance.Entities.EnemyProjectiles;
            this.enemies = LoZGame.Instance.Enemies.EnemyList;
            this.player = LoZGame.Instance.Link;
        }

        public void Draw()
        {
            foreach (IDoor door in this.doors) {
                this.DebuggSprite.SetData<Color>(new Color[] { DoorColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, door.Bounds, this.DebuggSourceRectangle, DoorColor, 0.0f, Vector2.Zero, SpriteEffects.None, DoorLayer);
            }
            foreach (IItem item in this.items) {
                this.DebuggSprite.SetData<Color>(new Color[] {ItemColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, item.Bounds, this.DebuggSourceRectangle, ItemColor, 0.0f, Vector2.Zero, SpriteEffects.None, ItemLayer);
            }
            foreach (IProjectile projectile in this.projectiles) {
                this.DebuggSprite.SetData<Color>(new Color[] { ProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, projectile.Bounds, this.DebuggSourceRectangle, ProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, ProjectileLayer);
            }
            foreach (IProjectile projectile in this.enemyProjectiles) {
                this.DebuggSprite.SetData<Color>(new Color[] { EnemyProjectileColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, projectile.Bounds, this.DebuggSourceRectangle, EnemyProjectileColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyProjectileLayer);
            }
            foreach (IProjectile explosion in this.explosions) {
                this.DebuggSprite.SetData<Color>(new Color[] { ExplosionColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, explosion.Bounds, this.DebuggSourceRectangle, ExplosionColor, 0.0f, Vector2.Zero, SpriteEffects.None, ExplosionLayer);
            }
            foreach (IEnemy enemy in this.enemies) {
                this.DebuggSprite.SetData<Color>(new Color[] { EnemyColor });
                LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, enemy.Bounds, this.DebuggSourceRectangle, EnemyColor, 0.0f, Vector2.Zero, SpriteEffects.None, EnemyLayer);
            }
            this.DebuggSprite.SetData<Color>(new Color[] { PlayerColor });
            LoZGame.Instance.SpriteBatch.Draw(this.DebuggSprite, player.Bounds, this.DebuggSourceRectangle, PlayerColor, 0.0f, Vector2.Zero, SpriteEffects.None, PlayerLayer);
        }
    }
}
