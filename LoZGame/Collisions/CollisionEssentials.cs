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
            float sourceMomentum = source.GetMomentum();
            if (sourceMomentum < source.Mass)
            {
                sourceMomentum = source.Mass;
            }
            Vector2 knockbackVector = (target.Bounds.Center - source.Bounds.Center).ToVector2();
            knockbackVector.Normalize();
            knockbackVector *= sourceMomentum;
            Console.WriteLine("Attempted knockback with vector " + knockbackVector.ToString());
            target.Knockback(knockbackVector);
        }

        public void DetermineDirectPushback(Physics source, Physics target)
        {
            float sourceMomentum = source.GetMomentum();
            if (sourceMomentum < source.Mass)
            {
                sourceMomentum = source.Mass;
            }
            Console.WriteLine("Attempted direct knockback with magnitude " + sourceMomentum.ToString());
            Vector2 knockbackVector = Vector2.Zero;
            switch (source.CurrentDirection)
            {
                case PhysicsEssentials.Direction.North:
                    knockbackVector = new Vector2(0, -1);
                    break;
                case PhysicsEssentials.Direction.South:
                    knockbackVector = new Vector2(0, 1);
                    break;
                case PhysicsEssentials.Direction.East:
                    knockbackVector = new Vector2(1, 0);
                    break;
                case PhysicsEssentials.Direction.West:
                    knockbackVector = new Vector2(-1, 0);
                    break;
                default:
                    DeterminePushbackValues(source, target);
                    break;
            }
            knockbackVector *= sourceMomentum;
            target.Knockback(knockbackVector);
        }

        public void ReverseKnockback(Physics target, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Top || side == CollisionDetection.CollisionSide.Bottom)
            {
                target.KnockbackVelocity = new Vector2(target.KnockbackVelocity.X, (target.KnockbackVelocity.Y * -1) / 2);
                target.Friction = new Vector2(target.Friction.X, target.Friction.Y * -1);
            } 
            else
            {
                target.KnockbackVelocity = new Vector2((target.KnockbackVelocity.X * -1) / 2, target.KnockbackVelocity.Y);
                target.Friction = new Vector2(target.Friction.X * -1, target.Friction.Y);
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
            int verticalOffset = 0, horizontalOffset = 0;
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                verticalOffset = BlockSpriteFactory.Instance.VerticalOffset;
                horizontalOffset = BlockSpriteFactory.Instance.HorizontalOffset;
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
                    target.Bounds = new Rectangle(horizontalOffset, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                case CollisionDetection.CollisionSide.Right:
                    target.Bounds = new Rectangle(LoZGame.Instance.GraphicsDevice.Viewport.Width - target.Bounds.Width - horizontalOffset + 10, target.Bounds.Y, target.Bounds.Width, target.Bounds.Height);
                    break;
                default:
                    break;
            }
            this.ReverseKnockback(target, collisionSide);
            target.SetLocation();
        }
    }
}
