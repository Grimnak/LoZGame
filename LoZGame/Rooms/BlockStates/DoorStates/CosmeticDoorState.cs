namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class CosmeticDoorState : DoorEssentials, IDoorState
    {
        public CosmeticDoorState(IDoor door)
        {
            Door = door;
            switch (door.Physics.CurrentDirection)
            {

                case Physics.Direction.North:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFrame();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFrame();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFrame();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
            }
        }

        public override void Bombed()
        {
        }

        public override void Open()
        {
        }

        public override void Close()
        {
        }
    }
}
