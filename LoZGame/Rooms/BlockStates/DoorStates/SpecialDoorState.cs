namespace LoZClone
{
    using Microsoft.Xna.Framework;

    /*
     * The player must kill all enemies to open these doors.
     */
    public class SpecialDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public SpecialDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft();
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight();
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