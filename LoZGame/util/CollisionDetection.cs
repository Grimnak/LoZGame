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
            }

            foreach (IEnemy enemy in enemies)
            {
                CheckCollisions<IPlayer>(enemy, players);
                CheckCollisions<IProjectile>(enemy, projectiles);
            }
        }

        private static void CheckCollisions<T>(ICollider sourceCollider, ReadOnlyCollection<T> targetColliders)
        {
            if (typeof(ICollider).IsAssignableFrom(typeof(T)) || sourceCollider != null || sourceCollider.Bounds != Rectangle.Empty || targetColliders != null)
            {
                foreach (ICollider collider in targetColliders)
                {
                    if (sourceCollider.Bounds.Intersects(collider.Bounds))
                    {
                        sourceCollider.OnCollisionResponse(collider);
                    }
                }
            }
        }
    }
}
