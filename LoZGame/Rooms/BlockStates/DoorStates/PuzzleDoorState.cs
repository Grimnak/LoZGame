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
                        this.FrameSprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        this.FloorSprite = BlockSpriteFactory.Instance.UnlockedDoorFloorRight();
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
