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
            if ((this.door.State is UnlockedDoorState || this.door.State is BombedDoorState) && !(player.State is ImmobileState) && !(player.State is IdleState))
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

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            Console.WriteLine("Projectile Type: " + projectile.GetType());
            if (this.door.State is HiddenDoorState && projectile is BombExplosion)
            {
                this.door.Bombed();
            }
        }
    }
}
