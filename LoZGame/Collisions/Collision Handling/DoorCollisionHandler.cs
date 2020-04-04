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
            if ((this.door.State is UnlockedDoorState || this.door.State is BombedDoorState) && (!(player.State is GrabbedState)))
            {
                if (door.Physics.Location == door.LeftScreenLoc)
                {
                    LoZGame.Instance.GameState.TransitionRoom("Left");
                }
                else if (door.Physics.Location == door.RightScreenLoc)
                {
                    LoZGame.Instance.GameState.TransitionRoom("Right");
                }
                else if (door.Physics.Location == door.DownScreenLoc)
                {
                    LoZGame.Instance.GameState.TransitionRoom("Down");
                }
                else if (door.Physics.Location == door.UpScreenLoc)
                {
                    LoZGame.Instance.GameState.TransitionRoom("Up");
                }
            } 
            else if (this.door.State is LockedDoorState && player.Inventory.HasKey())
            {
                player.Inventory.UseKey();
                IDoor cousin = FindCousinDoor();
                cousin.Open();
                this.door.Open();
                SoundEffectsFactory.Instance.PlayDoorUnlock();
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
    }
}