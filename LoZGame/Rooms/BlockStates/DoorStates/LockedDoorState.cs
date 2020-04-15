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
                        this.FrameSprite = BlockSpriteFactory.Instance.LockedDoorDown();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorDown();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.LockedDoorLeft();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorLeft();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.LockedDoorUp();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorUp();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.LockedDoorRight();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorRight();
                        break;
                    }
            }
        }

        public override void Close()
        {
        }
    }
}
