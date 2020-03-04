namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class DoorCollisionHandler
    {
        private IDoor door;

        public DoorCollisionHandler(IDoor door)
        {
            this.door = door;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(player.State is ImmobileState))
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    LoZGame.Instance.Dungeon.MoveLeft();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    LoZGame.Instance.Dungeon.MoveRight();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    LoZGame.Instance.Dungeon.MoveDown();
                }
                else
                {
                    LoZGame.Instance.Dungeon.MoveUp();
                }
            }
        }
    }
}