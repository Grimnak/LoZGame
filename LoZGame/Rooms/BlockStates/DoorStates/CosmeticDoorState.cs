namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class CosmeticDoorState : DoorEssentials, IDoorState
    {
        public CosmeticDoorState(IDoor door)
        {
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {

                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFrame();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
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
