namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Contains the various push and knockback interactions that may occur once a collision is detected.
    /// </summary>
    public class CollisionInteractions
    {
        /// <summary>
        /// Pushes the player back based on relative position of the two colliding objects.
        /// </summary>
        /// <param name="source">The object applying the force.</param>
        /// <param name="target">The object receiving the force.</param>
        public void DeterminePushbackValues(Physics source, Physics target)
        {
            float sourceMomentum = source.GetMomentum();
            if (sourceMomentum < source.Mass)
            {
                sourceMomentum = source.Mass;
            }
            Vector2 knockbackVector = (target.Bounds.Center - source.Bounds.Center).ToVector2();
            knockbackVector.Normalize();
            knockbackVector *= sourceMomentum + (float)Math.Sqrt(target.GetMomentum() / 2);
            target.SetKnockback(knockbackVector);
        }

        /// <summary>
        /// Pushes the player back based on the direction the source is traveling.
        /// </summary>
        /// <param name="source">The object applying the force.</param>
        /// <param name="target">The object receiving the force.</param>
        public void DetermineDirectPushback(Physics source, Physics target)
        {
            if (source.MovementVelocity.Length() > 0)
            {
                Vector2 knockbackVector = Vector2.Zero;
                float sourceMomentum = source.GetMomentum();
                if (sourceMomentum < source.Mass)
                {
                    sourceMomentum = source.Mass;
                }
                knockbackVector = new Vector2(source.MovementVelocity.X, source.MovementVelocity.Y);
                knockbackVector.Normalize();
                knockbackVector *= sourceMomentum + (float)Math.Sqrt(target.GetMomentum() / 2);
                target.SetKnockback(knockbackVector);
            }
            else
            {
                DeterminePushbackValues(source, target);
            }
        }

        public void ReverseMovement(Physics target, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Top || side == CollisionDetection.CollisionSide.Bottom)
            {
                target.MovementVelocity = new Vector2(target.MovementVelocity.X, target.MovementVelocity.Y * -1);
            }
            else
            {
                target.MovementVelocity = new Vector2(target.MovementVelocity.X * -1, target.MovementVelocity.Y);
            }
        }

        /// <summary>
        /// Prevents two objects from moving through each other.
        /// </summary>
        /// <param name="source">The stationary object that doesn't move.</param>
        /// <param name="target">The object that gets moved into the stationary object.</param>
        /// <param name="collisionSide">The side of the stationary object that underwent a collision.</param>
        public void SetBounds(Physics source, Physics target, CollisionDetection.CollisionSide collisionSide)
        {
            int side = 0;
            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    side = source.Bounds.Top - target.Bounds.Height;
                    target.Bounds = new Rectangle(target.Bounds.X, side, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackY();
                    break;
                case CollisionDetection.CollisionSide.Bottom:
                    target.StopKnockbackY();
                    side = source.Bounds.Bottom;
                    target.Bounds = new Rectangle(target.Bounds.X, side, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Left:
                    side = source.Bounds.Left - target.Bounds.Width;
                    target.Bounds = new Rectangle(side, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackX();
                    break;
                case CollisionDetection.CollisionSide.Right:
                    side = source.Bounds.Right;
                    target.Bounds = new Rectangle(side, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackX();
                    break;
                default:
                    break;
            }
            target.SetLocation();
        }

        /// <summary>
        /// Prevents an object from moving off the screen.
        /// </summary>
        /// <param name="target">The object that is moving into an area that it shouldn't.</param>
        /// <param name="collisionSide">The side of the moving object that underwent a collision.</param>
        public void SetBounds(Physics target, CollisionDetection.CollisionSide collisionSide)
        {
            int topOffset = LoZGame.Instance.InventoryOffset, bottomOffset = 0, horizontalOffset = 0;
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                topOffset = BlockSpriteFactory.Instance.TopOffset;
                bottomOffset = BlockSpriteFactory.Instance.BottomOffset;
                horizontalOffset = BlockSpriteFactory.Instance.HorizontalOffset;
            }

            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    target.Bounds = new Rectangle(target.Bounds.X, topOffset, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackY();
                    break;
                case CollisionDetection.CollisionSide.Bottom:
                    target.Bounds = new Rectangle(target.Bounds.X, bottomOffset - target.Bounds.Height, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackY();
                    break;
                case CollisionDetection.CollisionSide.Left:
                    target.Bounds = new Rectangle(horizontalOffset, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackX();
                    break;
                case CollisionDetection.CollisionSide.Right:
                    target.Bounds = new Rectangle(LoZGame.Instance.ScreenWidth - horizontalOffset - target.Bounds.Width + GameData.Instance.CollisionConstants.RightBoundCorrection, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    target.StopKnockbackX();
                    break;
                default:
                    break;
            }
            target.SetLocation();
        }
    }
}