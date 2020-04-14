namespace LoZClone
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Contains the calculations necessary to determine if a collision is occurring between two objects or the wall.
    /// </summary>
    public partial class CollisionDetection
    {
        /// <summary>
        /// This collision enum represents the side of an object that underwent a collision.
        /// </summary>
        public enum CollisionSide
        {
            None,
            Left,
            Right,
            Top,
            Bottom
        }

        private bool CheckCollisions<T>(ICollider sourceCollider, ReadOnlyCollection<T> targetColliders)
        {
            ICollider targetCollider = null;
            CollisionSide biggestSourceSide = CollisionSide.None;
            CollisionSide biggestTargetSide = CollisionSide.None;
            float biggestOverlapArea = 0;
            bool currentlyColliding;

            // Identify largest collision in case of multiple occurring at once.
            foreach (ICollider collider in targetColliders)
            {
                CollisionSide sourceSide = GetCollisionSide(sourceCollider.Physics.Bounds, collider.Physics.Bounds);
                CollisionSide targetSide = GetCollisionSide(collider.Physics.Bounds, sourceCollider.Physics.Bounds);
                Rectangle overlap = Rectangle.Intersect(sourceCollider.Physics.Bounds, collider.Physics.Bounds);
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
                currentlyColliding = true;
            }
            else
            {
                currentlyColliding = false;
            }

            return currentlyColliding;
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
            // Check borders for all rooms except basement
            if (dungeon.CurrentRoomX != 1 || dungeon.CurrentRoomY != 1)
            {
                // is right wall
                if (sourceCollider.Physics.Bounds.Right > LoZGame.Instance.ScreenWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Right);
                }
                // is left wall
                else if (sourceCollider.Physics.Bounds.Left < BlockSpriteFactory.Instance.HorizontalOffset)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Left);
                }
                // is bottom wall
                if (sourceCollider.Physics.Bounds.Bottom > BlockSpriteFactory.Instance.BottomOffset)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Bottom);
                }
                // is top wall
                else if (sourceCollider.Physics.Bounds.Top < BlockSpriteFactory.Instance.TopOffset)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Top);
                }
            }
            // Check borders for basement exception
            else
            {
                if (sourceCollider.Physics.Location.Y < LoZGame.Instance.InventoryOffset)
                {
                    if (sourceCollider is IPlayer)
                    {
                        dungeon.MoveUp();
                    }
                    else
                    {
                        sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Top);
                    }
                }
                else if (sourceCollider.Physics.Location.Y > LoZGame.Instance.ScreenHeight - sourceHeight)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Bottom);
                }
                else if (sourceCollider.Physics.Location.X < 0)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Left);
                }
                else if (sourceCollider.Physics.Location.X > LoZGame.Instance.ScreenWidth - sourceWidth)
                {
                    sourceCollider.OnCollisionResponse(sourceWidth, sourceHeight, CollisionSide.Right);
                }
            }
        }
    }
}