namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class CosmeticDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public CosmeticDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case North:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown();
                        break;
                }
                case East:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();
                        break;
                }
                case South:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();
                        break;
                }
                case West:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();
                        break;
                }
            }
        }

        public void Bombed()
        {
        }

        public void Close()
        {
            this.door.Close();
        }

        public void Draw()
        {
            this.sprite.Draw(this.door.Physics.Location, spriteTint, this.door.Physics.Depth);
        }

        public void Open()
        {
        }

        public void Update()
        {
        }
    }
}
