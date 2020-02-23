namespace LoZClone
{
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    public static class CollisionDetection
    {
        public static void Update(ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IProjectile> projectiles)
        {
            foreach (IPlayer player in players)
            {
                if (player.State is DieState)
                {
                    continue;
                }
                CheckCollisions<IEnemy>(player, enemies);
                CheckCollisions<IProjectile>(player, projectiles);
                CheckBorders(player, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
            }

            foreach (IEnemy enemy in enemies)
            {
                CheckCollisions<IProjectile>(enemy, projectiles);
                CheckBorders(enemy, CollisionDetection.GetEnemyWidth(enemy), CollisionDetection.GetEnemyHeight(enemy));
            }
        }

        private static void CheckCollisions<T>(ICollider sourceCollider, ReadOnlyCollection<T> targetColliders)
        {
            foreach (ICollider collider in targetColliders)
            {
                if (sourceCollider.Bounds.Intersects(collider.Bounds))
                {
                    sourceCollider.OnCollisionResponse(collider);
                    collider.OnCollisionResponse(sourceCollider);
                }
            }
        }

        private static void CheckBorders(ICollider sourceCollider, int sourceWidth, int sourceHeight)
        {
            if (sourceCollider.CurrentLocation.X + sourceWidth > sourceCollider.Game.GraphicsDevice.Viewport.Width)
            {
                sourceCollider.CurrentLocation = new Vector2(sourceCollider.Game.GraphicsDevice.Viewport.Width - sourceWidth, sourceCollider.CurrentLocation.Y);
            }
            else if (sourceCollider.CurrentLocation.X < 0)
            {
                sourceCollider.CurrentLocation = new Vector2(0, sourceCollider.CurrentLocation.Y);
            }

            if (sourceCollider.CurrentLocation.Y + sourceHeight > sourceCollider.Game.GraphicsDevice.Viewport.Height)
            {
                sourceCollider.CurrentLocation = new Vector2(sourceCollider.CurrentLocation.X, sourceCollider.Game.GraphicsDevice.Viewport.Height - sourceHeight);
            }
            else if (sourceCollider.CurrentLocation.Y < 0)
            {
                sourceCollider.CurrentLocation = new Vector2(sourceCollider.CurrentLocation.X, 0);
            }
        }

        private static int GetEnemyWidth(ICollider collider)
        {
            if (collider is Dodongo)
            {
                return EnemySpriteFactory.DodongoWidthLeftRight;
            }
            else if (collider is Dragon)
            {
                return EnemySpriteFactory.DragonWidth;
            }
            else if (collider is Gel)
            {
                return EnemySpriteFactory.GelWidth;
            }
            else if (collider is Goriya)
            {
                return EnemySpriteFactory.GoriyaWidth;
            }
            else if (collider is Keese)
            {
                return EnemySpriteFactory.KeeseWidth;
            }
            else if (collider is Merchant)
            {
                return EnemySpriteFactory.MerchantWidth;
            }
            else if (collider is OldMan)
            {
                return EnemySpriteFactory.OldManWidth;
            }
            else if (collider is Rope)
            {
                return EnemySpriteFactory.RopeWidth;
            }
            else if (collider is SpikeCross)
            {
                return EnemySpriteFactory.SpikeCrossWidth;
            }
            else if (collider is Stalfos)
            {
                return EnemySpriteFactory.StalfosWidth;
            }
            else if (collider is WallMaster)
            {
                return EnemySpriteFactory.WallMasterWidth;
            }
            else if (collider is Zol)
            {
                return EnemySpriteFactory.ZolWidth;
            }
            else
            {
                return 0;
            }
        }

        public static int GetEnemyHeight (ICollider collider)
        {
            if (collider is Dodongo)
            {
                return EnemySpriteFactory.DodongoHeight;
            }
            else if (collider is Dragon)
            {
                return EnemySpriteFactory.DragonHeight;
            }
            else if (collider is Gel)
            {
                return EnemySpriteFactory.GelHeight;
            }
            else if (collider is Goriya)
            {
                return EnemySpriteFactory.GoriyaHeight;
            }
            else if (collider is Keese)
            {
                return EnemySpriteFactory.KeeseHeight;
            }
            else if (collider is Merchant)
            {
                return EnemySpriteFactory.MerchantHeight;
            }
            else if (collider is OldMan)
            {
                return EnemySpriteFactory.OldManHeight;
            }
            else if (collider is Rope)
            {
                return EnemySpriteFactory.RopeHeight;
            }
            else if (collider is SpikeCross)
            {
                return EnemySpriteFactory.SpikeCrossHeight;
            }
            else if (collider is Stalfos)
            {
                return EnemySpriteFactory.StalfosHeight;
            }
            else if (collider is WallMaster)
            {
                return EnemySpriteFactory.WallMasterHeight;
            }
            else if (collider is Zol)
            {
                return EnemySpriteFactory.ZolHeight;
            }
            else
            {
                return 0;
            }
        }
    }
}
