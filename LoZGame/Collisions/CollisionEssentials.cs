namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class CollisionEssentials
    {
        public void DeterminePushbackValues(Physics source, Physics target)
        {
            float sourceMomentum = source.GetMomentum().Length();
            if (sourceMomentum < 1)
            {
                sourceMomentum = source.Mass;
            }
            Vector2 knockbackVector = (target.Bounds.Center - source.Bounds.Center).ToVector2();
            knockbackVector *= sourceMomentum;
            target.Knockback(knockbackVector);
        }

        public void DetermineDirectPushback(Physics source, Physics target)
        {
            float sourceMomentum = source.GetMomentum().Length();
            if (sourceMomentum < source.Mass)
            {
                sourceMomentum = source.Mass;
            }
            switch (source.CurrentDirection)
            {
                case Physics.Direction.North:
                    target.Knockback(new Vector2(0, -1) * sourceMomentum);
                    break;
                case Physics.Direction.South:
                    target.Knockback(new Vector2(0, 1) * sourceMomentum);
                    break;
                case Physics.Direction.East:
                    target.Knockback(new Vector2(1, 0) * sourceMomentum);
                    break;
                case Physics.Direction.West:
                    target.Knockback(new Vector2(-1, 0) * sourceMomentum);
                    break;
            }
        }

        public void ReverseKnockback(Physics target, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Top || side == CollisionDetection.CollisionSide.Bottom)
            {
                target.KnockbackVelocity = new Vector2(target.KnockbackVelocity.X, target.KnockbackVelocity.Y * -1);
            } else
            {
                target.KnockbackVelocity = new Vector2(target.KnockbackVelocity.X * -1, target.KnockbackVelocity.Y);
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

        public void SetBlockBounds(Physics source, Physics target, CollisionDetection.CollisionSide collisionSide)
        {
            int side = 0;
            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    side = source.Bounds.Top - target.Bounds.Height;
                    target.Bounds = new Rectangle(target.Bounds.X, side, target.Bounds.Width, target.Bounds.Height);

                    break;
                case CollisionDetection.CollisionSide.Bottom:
                    side = source.Bounds.Bottom;
                    target.Bounds = new Rectangle(target.Bounds.X, side, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Left:
                    side = source.Bounds.Left - target.Bounds.Width;
                    target.Bounds = new Rectangle(side, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Right:
                    side = source.Bounds.Right;
                    target.Bounds = new Rectangle(side, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                default:
                    break;
            }
            this.ReverseKnockback(target, collisionSide);
            target.SetLocation();
        }

        public void SetRoomBounds(Physics target, CollisionDetection.CollisionSide collisionSide)
        {
            int verticalOffset = 0, rightOffset = 0, leftOffset = 0;
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                verticalOffset = BlockSpriteFactory.Instance.VerticalOffset;
                rightOffset = BlockSpriteFactory.Instance.HorizontalOffset + 10;
                leftOffset = BlockSpriteFactory.Instance.HorizontalOffset;
            }

            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    target.Bounds = new Rectangle(target.Bounds.X, verticalOffset, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Bottom:
                    target.Bounds = new Rectangle(target.Bounds.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - target.Bounds.Height - verticalOffset, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Left:
                    target.Bounds = new Rectangle(leftOffset, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Right:
                    target.Bounds = new Rectangle(LoZGame.Instance.GraphicsDevice.Viewport.Width - target.Bounds.Width - rightOffset, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                default:
                    break;
            }
            this.ReverseKnockback(target, collisionSide);
            target.SetLocation();
        }
    }
}
