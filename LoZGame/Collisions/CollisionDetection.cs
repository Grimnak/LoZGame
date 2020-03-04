namespace LoZClone
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    public partial class CollisionDetection
    {
        Dungeon dungeon;

        public CollisionDetection(Dungeon dungeon)
        {
            this.dungeon = dungeon;
        }

        public void Update(ReadOnlyCollection<IPlayer> players, ReadOnlyCollection<IEnemy> enemies, ReadOnlyCollection<IBlock> blocks, ReadOnlyCollection<IDoor> doors, ReadOnlyCollection<IItem> items, ReadOnlyCollection<IProjectile> projectiles)
        {
            foreach (IPlayer player in players)
            {
                if (!(player.State is DieState) && !(player.State is ImmobileState))
                {
                    CheckCollisions<IEnemy>(player, enemies);
                    CheckCollisions<IProjectile>(player, projectiles);
                    CheckCollisions<IDoor>(player, doors);
                    CheckCollisions<IItem>(player, items);
                    CheckBorders(player, LinkSpriteFactory.LinkWidth, LinkSpriteFactory.LinkHeight);
                }
            }

            foreach (IEnemy enemy in enemies)
            {
                if (!(enemy is WallMaster))
                {
                    CheckBorders(enemy, EnemySpriteFactory.GetEnemyWidth(enemy), EnemySpriteFactory.GetEnemyHeight(enemy));
                }
                CheckCollisions<IProjectile>(enemy, projectiles);
            }

            foreach (IBlock block in blocks)
            {
                if (block is BlockTile || block is MovableTile)
                {
                    CheckCollisions<IPlayer>(block, players);
                    CheckCollisions<IEnemy>(block, enemies);
                    CheckBorders(block, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
                }
            }

            foreach (IItem item in items)
            {
                if (item is Fairy)
                {
                    CheckBorders(item, ItemSpriteFactory.FairyWidth * ItemSpriteFactory.Instance.Scale, ItemSpriteFactory.FairyHeight * ItemSpriteFactory.Instance.Scale);
                }
            }
        }

        private void CheckCollisions<T>(ICollider sourceCollider, ReadOnlyCollection<T> targetColliders)
        {
            ICollider targetCollider = null;
            CollisionSide biggestSourceSide = CollisionSide.None;
            CollisionSide biggestTargetSide = CollisionSide.None;
            float biggestOverlapArea = 0;

            // Identify largest collision in case of multiple occurring at once.
            foreach (ICollider collider in targetColliders)
            {
                CollisionSide sourceSide = GetCollisionSide(sourceCollider.Bounds, collider.Bounds);
                CollisionSide targetSide = GetCollisionSide(collider.Bounds, sourceCollider.Bounds);
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

        private CollisionSide GetCollisionSide(Rectangle sourceRectangle, Rectangle targetRectangle)
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

        private void CheckBorders(ICollider sourceCollider, int sourceWidth, int sourceHeight)
        {
            if (dungeon.CurrentRoomX != 1 || dungeon.CurrentRoomY != 1)
            {
                // is right wall
                if (sourceCollider.Physics.Location.X + sourceWidth > LoZGame.Instance.GraphicsDevice.Viewport.Width - BlockSpriteFactory.Instance.HorizontalOffset + 10)
                {
                    sourceCollider.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, sourceCollider.Physics.Location.Y);
                }
                // is left wall
                else if (sourceCollider.Physics.Location.X < BlockSpriteFactory.Instance.HorizontalOffset)
                {
                    sourceCollider.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, sourceCollider.Physics.Location.Y);
                }

                // is bottom wall
                if (sourceCollider.Physics.Location.Y + sourceHeight > LoZGame.Instance.GraphicsDevice.Viewport.Height - BlockSpriteFactory.Instance.VerticalOffset)
                {
                    sourceCollider.Physics.Location = new Vector2(sourceCollider.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
                }
                // is top wall
                else if (sourceCollider.Physics.Location.Y < BlockSpriteFactory.Instance.VerticalOffset)
                {
                    sourceCollider.Physics.Location = new Vector2(sourceCollider.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
                }
            }
            else
            {
                if (sourceCollider.Physics.Location.Y < 0)
                {
                    dungeon.MoveUp();
                }
            }

        }
    }
}