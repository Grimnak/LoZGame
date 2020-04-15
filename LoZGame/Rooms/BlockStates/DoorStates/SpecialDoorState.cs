namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /*
     * The player must kill all enemies to open these doors.
     */
    public class SpecialDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public SpecialDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        this.door.Physics.CurrentDirection = Physics.Direction.North;
                        break;
                    }
                case East:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft();
                        this.door.Physics.CurrentDirection = Physics.Direction.East;
                        break;
                    }
                case South:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        this.door.Physics.CurrentDirection = Physics.Direction.South;
                        break;
                    }
                case West:
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight();
                        this.door.Physics.CurrentDirection = Physics.Direction.West;
                        break;
                    }
            }
        }

        public void Bombed()
        {
            this.door.Bombed();
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
            if (LoZGame.Instance.GameObjects.Enemies.EnemyList.Count == 0)
            {
                Open();
            }
        }
    }
}