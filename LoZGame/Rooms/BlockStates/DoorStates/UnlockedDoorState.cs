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
                        this.FrameSprite = BlockSpriteFactory.Instance.UnlockedDoorFrameDown();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorDown();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.UnlockedDoorFrameLeft();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorLeft();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.UnlockedDoorFrameUp();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorUp();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.UnlockedDoorFrameRight();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorRight();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.UnlockedDoorFrameDown();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorDown();
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
