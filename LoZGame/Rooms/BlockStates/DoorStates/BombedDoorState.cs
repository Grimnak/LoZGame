namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BombedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private bool isLevel1;

        public BombedDoorState(Door door)
        {
            this.door = door;
            this.isLevel1 = this.door.GetKind().Equals("hidden");
            switch (door.GetLoc())
            {
                case "N":
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown();

                       /* if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown();
                            
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.BombedOpeningDown2();
                        }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                }
                case "E":
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft();

                       /* if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft();
                        } 
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.BombedOpeningLeft2();
                        }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                }
                case "S":
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp();

                        /* if (this.isLevel1)
                         {
                             this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp();
                         }
                         else
                         {
                             this.sprite = BlockSpriteFactory.Instance.BombedOpeningUp2();

                         }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                }
                case "W":
                {
                        this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight();

                        /* if (this.isLevel1)
                         {
                             this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight();
                         }
                         else
                         {
                             this.sprite = BlockSpriteFactory.Instance.BombedOpeningRight2();
                         }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 20, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                }
            }
        }

        public void Bombed()
        {
        }

        public void Close()
        {
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
