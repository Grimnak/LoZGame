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
                CheckBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
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
    }
}
