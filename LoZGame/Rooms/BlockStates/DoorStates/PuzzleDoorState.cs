namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PuzzleDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private readonly Vector2 location;
        private bool solved;

        public PuzzleDoorState(Door door)
        {
            solved = false;
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        break;
                    }
                case East:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft();
                        break;
                    }
                case South:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        break;
                    }
                case West:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight();
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
            this.solved = true;
        }

        public void Bombed()
        {
        }

        public void Close()
        {
            this.door.Close();
        }

        public void Open()
        {
            this.door.Open();
        }

        public void Draw()
        {
            this.sprite.Draw(this.door.Physics.Location, spriteTint, this.door.Physics.Depth);
        }

        public void Update()
        {
            if (this.solved)
            {
                Open();
            }
        }
    }
}
