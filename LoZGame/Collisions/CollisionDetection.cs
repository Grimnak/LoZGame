namespace LoZClone
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    public static class CollisionDetection
    {
        public enum CollisionSide
        {
            None,
            Left,
            Right,
            Top,
            Bottom
        }

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
            ICollider targetCollider = null;
            CollisionSide biggestSourceSide = CollisionSide.None;
            CollisionSide biggestTargetSide = CollisionSide.None;
            float biggestOverlapArea = 0;

            // Identify largest collision in case of multiple occurring at once.
            foreach (ICollider collider in targetColliders)
            {
                CollisionSide sourceSide = GetCollisionSide(sourceCollider.Bounds, collider.Bounds);
                CollisionSide targetSide = GetCollisionSide(sourceCollider.Bounds, collider.Bounds);
                Rectangle overlap = Rectangle.Intersect(sourceCollider.Bounds, collider.Bounds);
                float overlapArea = overlap.Width * overlap.Height;
                if (overlapArea > biggestOverlapArea)
                {
                    biggestOverlapArea = overlapArea;
                    targetCollider = collider;
                    biggestSourceSide = sourceSide;
                    biggestTargetSide = targetSide;
                }
            }

            // Handle each collision appropriately.
            if (targetCollider != null && biggestSourceSide != CollisionSide.None && biggestTargetSide != CollisionSide.None)
            {
                sourceCollider.OnCollisionResponse(targetCollider, biggestSourceSide);
                targetCollider.OnCollisionResponse(sourceCollider, biggestTargetSide);
            }
        }

        private static CollisionSide GetCollisionSide(Rectangle sourceRectangle, Rectangle targetRectangle)
        {
            CollisionSide sourceCollisionSide;

            float avgWidth = 0.5f * (sourceRectangle.Width + targetRectangle.Width);
            float avgHeight = 0.5f * (sourceRectangle.Height + targetRectangle.Height);
            float xDistance = sourceRectangle.Center.X - targetRectangle.Center.X;
            float yDistance = sourceRectangle.Center.Y - targetRectangle.Center.Y;

            if (targetRectangle.IsEmpty || sourceRectangle.IsEmpty || Math.Abs(xDistance) > avgWidth || Math.Abs(yDistance) > avgHeight)
            {
                sourceCollisionSide = CollisionSide.None;
            }
            else
            {
                float yWidth = avgWidth * yDistance;
                float xHeight = avgHeight * xDistance;

                if (yWidth > xHeight)
                    sourceCollisionSide = (yWidth > -xHeight) ? CollisionSide.Top : CollisionSide.Right;
                else
                    sourceCollisionSide = (yWidth > -xHeight) ? CollisionSide.Left : CollisionSide.Bottom;
            }

            return sourceCollisionSide;
        }

        private static void CheckBorders(ICollider sourceCollider, int sourceWidth, int sourceHeight)
        {
            if (sourceCollider.CurrentLocation.X + sourceWidth > LoZGame.Instance.GraphicsDevice.Viewport.Width)
            {
                sourceCollider.CurrentLocation = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth, sourceCollider.CurrentLocation.Y);
            }
            else if (sourceCollider.CurrentLocation.X < 0)
            {
                sourceCollider.CurrentLocation = new Vector2(0, sourceCollider.CurrentLocation.Y);
            }

            if (sourceCollider.CurrentLocation.Y + sourceHeight > LoZGame.Instance.GraphicsDevice.Viewport.Height)
            {
                sourceCollider.CurrentLocation = new Vector2(sourceCollider.CurrentLocation.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight);
            }
            else if (sourceCollider.CurrentLocation.Y < 0)
            {
                sourceCollider.CurrentLocation = new Vector2(sourceCollider.CurrentLocation.X, 0);
            }
        }
    }
}