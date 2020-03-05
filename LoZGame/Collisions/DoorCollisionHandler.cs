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
              if (door.Physics.Location == door.LeftScreenLoc)
              {
                  LoZGame.Instance.Dungeon.MoveLeft();
              }
              else if (door.Physics.Location == door.RightScreenLoc)
              {
                  LoZGame.Instance.Dungeon.MoveRight();
              }
              else if (door.Physics.Location == door.DownScreenLoc)
              {
                  LoZGame.Instance.Dungeon.MoveDown();
              }
              else if (door.Physics.Location == door.UpScreenLoc)
              {
                  LoZGame.Instance.Dungeon.MoveUp();
              }
            }
        }
    }
}
