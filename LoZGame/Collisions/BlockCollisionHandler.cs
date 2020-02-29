namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class BlockCollisionHandler
    {
        private IBlock block;
        private float xDirection;
        private float yDirection;

        public BlockCollisionHandler(IBlock block)
        {
            this.block = block;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (block is MovableTile)
            {
                DeterminePushVelocity(player, collisionSide);
            }
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
        }

        private void DeterminePushVelocity(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            DetermineCollisionSide(collisionSide);
            this.block.Physics.Velocity = new Vector2(xDirection * player.MoveSpeed, yDirection * player.MoveSpeed);
            Console.WriteLine("Got to DeterminePushVelocity call.");
            Console.WriteLine("Determined block collision side: " + collisionSide);
            Console.WriteLine("Current MovableTile Velocity: " + this.block.Physics.Velocity);
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
