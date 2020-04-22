namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class LockedDoorState : DoorEssentials, IDoorState
    {
        public LockedDoorState(IDoor door)
        {
            Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.LockedDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.LockedLeftDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.LockedUpDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.LockedRightDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.LockedDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
            }
        }

        public override void Close()
        {
        }
    }
}
