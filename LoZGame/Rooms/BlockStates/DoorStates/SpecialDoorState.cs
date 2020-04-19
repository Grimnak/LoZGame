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
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialLeftDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialUpDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialRightDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
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