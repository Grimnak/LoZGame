namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /*
     * The player must kill all enemies to open these doors.
     */
    public class SpecialDoorState : DoorEssentials, IDoorState
    {
        public SpecialDoorState(IDoor door)
        {
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorDown();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorLeft();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorLeft();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorUp();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorRight();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorRight();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorDown();
                        break;
                    }
            }
        }

        public override void Update()
        {
            if (LoZGame.Instance.GameObjects.Enemies.EnemyList.Count == 0)
            {
                Open();
            }
        }
    }
}