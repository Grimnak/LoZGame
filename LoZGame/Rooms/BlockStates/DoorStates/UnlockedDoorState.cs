namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class UnlockedDoorState : DoorEssentials, IDoorState
    {
        public UnlockedDoorState(IDoor door)
        {
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
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
    }
}
