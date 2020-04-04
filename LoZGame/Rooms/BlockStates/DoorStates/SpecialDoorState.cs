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
        private bool isLevel1;

        public SpecialDoorState(Door door)
        {
            this.door = door;
            this.isLevel1 = this.door.GetKind().Equals("special");
            switch (door.GetLoc())
            {
                case "N":
                    {
                        if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown2();
                        }
                        break;
                    }
                case "E":
                    {
                        if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft();
                        } else
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft2();
                        }
                        break;
                    }
                case "S":
                    {
                        if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp2();
                        }
                        break;
                    }
                case "W":
                    {
                        if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight2();
                        }
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