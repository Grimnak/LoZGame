namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PuzzleDoorState : DoorEssentials, IDoorState
    {
        private readonly Vector2 location;
        private bool solved;

        public PuzzleDoorState(IDoor door)
        {
            this.solved = false;
            this.Door = door;
            switch (door.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.East:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialLeftDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedLeftDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                case Physics.Direction.South:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialUpDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedUpDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
                case Physics.Direction.West:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialRightDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedRightDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.HorizontalOverhang();
                        break;
                    }
                default:
                    {
                        this.FrameSprite = DungeonSpriteFactory.Instance.SpecialDownDoor();
                        this.FloorSprite = DungeonSpriteFactory.Instance.UnlockedDownDoorFloor();
                        this.OverhangSprite = DungeonSpriteFactory.Instance.VerticalOverhang();
                        break;
                    }
            }
        }

        public bool IsSolved
        {
            get { return this.solved; }
        }

        public void Solve()
        {
            SoundFactory.Instance.PlaySolved();
            SoundFactory.Instance.PlayDoorUnlock();
            this.Door.IsSolved = true;
        }

        public override void Bombed()
        {
        }

        public override void Update()
        {
            if (this.Door.IsSolved)
            {
                Open();
            }
        }
    }
}
