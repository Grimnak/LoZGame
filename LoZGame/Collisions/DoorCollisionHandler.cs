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
            if ((this.door.State is UnlockedDoorState || this.door.State is BombedDoorState) && (!(player.State is GrabbedState) && !(player.State is IdleState)))
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
            else if (this.door.State is LockedDoorState && player.HasKey)
            {
                player.HasKey = false;
                this.door.Open();
            }
            else if (this.door.State is PuzzleDoorState && ((PuzzleDoorState)this.door.State).IsSolved)
            {
                this.door.Open();
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if ((this.door.State is LockedDoorState || this.door.State is HiddenDoorState) && projectile is BombExplosion)
            {
                this.door.Bombed();
            }
        }
    }
}
