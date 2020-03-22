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
            else if (this.door.State is LockedDoorState)
            {
                if (player.HasKey)
                {
                    player.HasKey = false;
                    Door cousin = new Door(string.Empty, string.Empty);
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
                    cousin.Open();
                    this.door.Open();
                }
                else
                {
                    if (door.Physics.Location == door.LeftScreenLoc && !(player.CurrentDirection == "Right"))
                    {
                        player.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, player.Physics.Location.Y);
                    }
                    else if (door.Physics.Location == door.RightScreenLoc && !(player.CurrentDirection == "Left"))
                    {
                        player.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.X - BlockSpriteFactory.Instance.HorizontalOffset, player.Physics.Location.Y);
                    }
                    else if (door.Physics.Location == door.DownScreenLoc && !(player.CurrentDirection == "Up"))
                    {
                        player.Physics.Location = new Vector2(player.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Y - BlockSpriteFactory.Instance.VerticalOffset);
                    }
                    else if (door.Physics.Location == door.UpScreenLoc && !(player.CurrentDirection == "Down"))
                    {
                        player.Physics.Location = new Vector2(player.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
                    }
                }
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
                Door cousin = new Door(string.Empty, string.Empty);
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
                cousin.Bombed();
                this.door.Bombed();
            }
        }
    }
}
