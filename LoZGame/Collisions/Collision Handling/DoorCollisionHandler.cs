namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class DoorCollisionHandler : CollisionInteractions
    {
        private IDoor door;

        public DoorCollisionHandler(IDoor door)
        {
            this.door = door;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            // Only collide with a door if the player wasn't knocked back into it.
            if (player.Physics.KnockbackVelocity.Length() == 0 && FullIntersect(player, collisionSide))
            {
                if ((this.door.State is UnlockedDoorState || this.door.State is BombedDoorState) && (!(player.State is GrabbedState)))
                {
                    if (door.Physics.Location == door.LeftScreenLoc)
                    {
                        LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.West);
                    }
                    else if (door.Physics.Location == door.RightScreenLoc)
                    {
                        LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.East);
                    }
                    else if (door.Physics.Location == door.DownScreenLoc)
                    {
                        LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.South);
                    }
                    else if (door.Physics.Location == door.UpScreenLoc)
                    {
                        LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.North);
                    }
                }
                else if (this.door.State is LockedDoorState && player.Inventory.HasKey())
                {
                    player.Inventory.UseKey();
                    IDoor cousin = FindCousinDoor();
                    cousin.Open();
                    this.door.Open();
                    SoundFactory.Instance.PlayDoorUnlock();
                }
                else if (this.door.State is PuzzleDoorState && ((PuzzleDoorState)this.door.State).IsSolved)
                {
                    this.door.Open();
                }
            }
            else
            {
                SetBounds(this.door.Physics, player.Physics, collisionSide);
            }
        }

        public void OnCollisionResponse(IProjectile projectile)
        {
            if ((this.door.State is LockedDoorState || this.door.State is HiddenDoorState) && projectile is BombExplosion)
            {
                IDoor cousin = FindCousinDoor();
                cousin.Bombed();
                this.door.Bombed();
            }
        }

        private IDoor FindCousinDoor()
        {
            IDoor cousin = new Door(string.Empty, string.Empty);
            int Y = LoZGame.Instance.Dungeon.CurrentRoomY;
            int X = LoZGame.Instance.Dungeon.CurrentRoomX;
            switch (((Door)door).GetLoc())
            {
                case "N":
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y - 1, X).Doors)
                    {
                        if (cDoor.GetLoc().Equals("S"))
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                case "S":
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y + 1, X).Doors)
                    {
                        if (cDoor.GetLoc().Equals("N"))
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                case "E":
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X + 1).Doors)
                    {
                        if (cDoor.GetLoc().Equals("W"))
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                default:
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X - 1).Doors)
                    {
                        if (cDoor.GetLoc().Equals("E"))
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
            }
            return cousin;
        }

        private bool FullIntersect(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    return player.Physics.Bounds.Left >= door.Physics.Bounds.Left && player.Physics.Bounds.Right <= door.Physics.Bounds.Right;
                case CollisionDetection.CollisionSide.Bottom:
                    return player.Physics.Bounds.Left >= door.Physics.Bounds.Left && player.Physics.Bounds.Right <= door.Physics.Bounds.Right;
                case CollisionDetection.CollisionSide.Left:
                    return player.Physics.Bounds.Top >= door.Physics.Bounds.Top && player.Physics.Bounds.Bottom <= door.Physics.Bounds.Bottom;
                case CollisionDetection.CollisionSide.Right:
                    return player.Physics.Bounds.Top >= door.Physics.Bounds.Top && player.Physics.Bounds.Bottom <= door.Physics.Bounds.Bottom;
                default:
                    return false;
            }
        }
    }
}