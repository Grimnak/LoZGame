namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class LockedDoorState : DoorEssentials, IDoorState
    {
        public LockedDoorState(IDoor door)
        {
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.LockedDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.LockedLeftDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.LockedUpDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.LockedRightDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.LockedDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        break;
                    }
            }
        }

        public override void Close()
        {
        }
    }
}
