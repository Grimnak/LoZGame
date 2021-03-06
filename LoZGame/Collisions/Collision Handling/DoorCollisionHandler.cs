﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class DoorCollisionHandler : CollisionInteractions
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
                if ((door.State is UnlockedDoorState || door.State is BombedDoorState) && (!(player.State is GrabbedState)))
                {
                    switch (door.Physics.CurrentDirection) 
                    {
                        case Physics.Direction.North:
                            AlignVertical(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.North);
                            break;
                        case Physics.Direction.South:
                            AlignVertical(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.South);
                            break;
                        case Physics.Direction.East:
                            AlignHorizontal(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.East);
                            break;
                        case Physics.Direction.West:
                            AlignHorizontal(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.West);
                            break;

                    }
                }
                else if (door.DoorType == Door.DoorTypes.Locked && (player.Inventory.HasKey() || player.Inventory.HasMagicKey))
                {
                    player.Inventory.UseKey();
                    IDoor cousin = FindCousinDoor();
                    cousin.Open();
                    door.Open();
                    SoundFactory.Instance.PlayDoorUnlock();

                    // Automatically travel through the door after unlocking.
                    switch (door.Physics.CurrentDirection)
                    {
                        case Physics.Direction.North:
                            AlignVertical(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.North);
                            break;
                        case Physics.Direction.South:
                            AlignVertical(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.South);
                            break;
                        case Physics.Direction.East:
                            AlignHorizontal(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.East);
                            break;
                        case Physics.Direction.West:
                            AlignHorizontal(door.Physics, player.Physics);
                            LoZGame.Instance.GameState.TransitionRoom(Physics.Direction.West);
                            break;

                    }
                }
                else if (door.DoorType == Door.DoorTypes.Puzzle && door.IsSolved)
                {
                    door.Open();
                }
            }
            else
            {
                SetBounds(door.Physics, player.Physics, collisionSide);
            }
        }

        public void OnCollisionResponse(IProjectile projectile)
        {
            if ((door.State is LockedDoorState || door.State is HiddenDoorState) && projectile is BombExplosion)
            {
                IDoor cousin = FindCousinDoor();
                cousin.Bombed();
                door.Bombed();
            }
        }

        private IDoor FindCousinDoor()
        {
            IDoor cousin = new Door(string.Empty, string.Empty);
            int Y = LoZGame.Instance.Dungeon.CurrentRoomY;
            int X = LoZGame.Instance.Dungeon.CurrentRoomX;
            switch (door.Physics.CurrentDirection)
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

        private void AlignVertical(Physics source, Physics target)
        {
            int halfTarget = (target.Bounds.Width / 2) - 2;
            target.Bounds = new Rectangle(new Point(source.Bounds.Center.X - halfTarget, target.Bounds.Y), target.Bounds.Size);
        }

        private void AlignHorizontal(Physics source, Physics target)
        {
            int halfTarget = (target.Bounds.Height / 2) - 2;
            target.Bounds = new Rectangle(new Point(target.Bounds.X, source.Bounds.Center.Y - halfTarget), target.Bounds.Size);
        }
    }
}