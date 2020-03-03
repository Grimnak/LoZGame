namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class ItemCollisionHandler
    {
        private IItemSprite item;
        private const float Speed = 4;
        private const float Acceleration = -0.1f;
        private int xDirection;
        private int yDirection;

        public ItemCollisionHandler(IItemSprite item)
        {
            this.item = item;
        }

        public void OnCollisionResponse(CollisionDetection.CollisionSide collisionSide)
        {
                DeterminePushbackValues(collisionSide);
        }

        private void DeterminePushbackValues(CollisionDetection.CollisionSide collisionSide)
        {
            DetermineCollisionSide(collisionSide);
            Vector2 oldVelocity = new Vector2(this.item.Physics.Velocity.X, this.item.Physics.Velocity.Y);
            Vector2 oldAccel = new Vector2(this.item.Physics.Acceleration.X, this.item.Physics.Acceleration.Y);
            Vector2 newVelocity = new Vector2(this.xDirection* Speed, yDirection* Speed);
            Vector2 newAccel = new Vector2(this.xDirection * Acceleration, yDirection * Acceleration);
            this.item.Physics.Velocity = new Vector2(oldVelocity.X + newVelocity.X, oldVelocity.Y + newVelocity.Y);
            this.item.Physics.Acceleration = new Vector2(oldAccel.X + newAccel.X, oldAccel.Y + newAccel.Y);
        }

        private void DetermineCollisionSide(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                xDirection = 0;
                yDirection = 1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                xDirection = 0;
                yDirection = -1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                xDirection = 1;
                yDirection = 0;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                xDirection = -1;
                yDirection = 0;
            }
        }
    }
}