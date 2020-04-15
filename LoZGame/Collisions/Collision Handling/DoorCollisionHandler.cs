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
            System.Console.WriteLine("Deteced player collide with door");
            // Only collide with a door if the player wasn't knocked back into it.
            if (player.Physics.KnockbackVelocity.Length() == 0 && FullIntersect(player, collisionSide))
            {
                System.Console.WriteLine("Letting Player move through door");
                if ((this.door.State is UnlockedDoorState || this.door.State is BombedDoorState) && (!(player.State is GrabbedState)))
                {
                    switch (door.Physics.CurrentDirection) 
                    {
                        case Physics.Direction.North:
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.North);
                            break;
                        case Physics.Direction.South:
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.South);
                            break;
                        case Physics.Direction.East:
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.East);
                            break;
                        case Physics.Direction.West:
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.West);
                            break;

                    }
                }
                else if (this.door.DoorType == Door.DoorTypes.Locked && player.Inventory.HasKey())
                {
                    player.Inventory.UseKey();
                    IDoor cousin = FindCousinDoor();
                    cousin.Open();
                    this.door.Open();
                    SoundFactory.Instance.PlayDoorUnlock();
                }
                else if (this.door.DoorType == Door.DoorTypes.Puzzle && this.door.IsSolved)
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
            switch (this.door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y - 1, X).Doors)
                    {
                        if (cDoor.Physics.CurrentDirection == Physics.Direction.South)
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                case Physics.Direction.South:
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y + 1, X).Doors)
                    {
                        if (cDoor.Physics.CurrentDirection == Physics.Direction.North)
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                case Physics.Direction.East:
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X + 1).Doors)
                    {
                        if (cDoor.Physics.CurrentDirection == Physics.Direction.West)
                        {
                            cousin = cDoor;
                            break;
                        }
                    }
                    break;
                default:
                    foreach (Door cDoor in LoZGame.Instance.Dungeon.GetRoom(Y, X - 1).Doors)
                    {
                        if (cDoor.Physics.CurrentDirection == Physics.Direction.East)
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
            Point DoorWidth = new Point(door.EntryWidth / 2);
            Rectangle entry = new Rectangle(door.Physics.Bounds.Center - DoorWidth, new Point(door.EntryWidth));
            switch (collisionSide)
            {
                case CollisionDetection.CollisionSide.Top:
                    return player.Physics.Bounds.Left >= entry.Left && player.Physics.Bounds.Right <= entry.Right;
                case CollisionDetection.CollisionSide.Bottom:
                    return player.Physics.Bounds.Left >= entry.Left && player.Physics.Bounds.Right <= entry.Right;
                case CollisionDetection.CollisionSide.Left:
                    return player.Physics.Bounds.Top >= entry.Top && player.Physics.Bounds.Bottom <= entry.Bottom;
                case CollisionDetection.CollisionSide.Right:
                    return player.Physics.Bounds.Top >= entry.Top && player.Physics.Bounds.Bottom <= entry.Bottom;
                default:
                    return false;
            }
        }
    }
}