namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PuzzleDoorState : DoorEssentials, IDoorState
    {
        private readonly Vector2 location;
        private bool solved;

        public PuzzleDoorState(IDoor door)
        {
            solved = false;
            Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialLeftDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialUpDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialRightDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
            }
        }

        public bool IsSolved
        {
            get { return solved; }
        }

        public void Solve()
        {
            SoundFactory.Instance.PlaySolved();
            SoundFactory.Instance.PlayDoorUnlock();
            Door.IsSolved = true;
        }

        public override void Bombed()
        {
        }

        public override void Update()
        {
            if (Door.IsSolved)
            {
                Open();
            }
        }
    }
}
