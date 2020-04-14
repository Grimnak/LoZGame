namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class LockedDoorState : IDoorState
    {
        private const string North = "N";
        private const string South = "S";
        private const string East = "E";
        private const string West = "W";

        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private bool isLevel1;

        public LockedDoorState(Door door)
        {
            this.door = door;
            this.isLevel1 = this.door.GetKind().Equals(GameData.Instance.RoomConstants.LockedStr);
            switch (door.GetLoc())
            {
                case North:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorDown();

                       /* if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.LockedDoorDown();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.LockedDoorDown2();

                        }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case East:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft();

                        /*if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.LockedDoorLeft2();
                        }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                    }
                case South:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorUp();

                        /* if (this.isLevel1)
                         {
                             this.sprite = BlockSpriteFactory.Instance.LockedDoorUp();
                         }
                         else
                         {
                             this.sprite = BlockSpriteFactory.Instance.LockedDoorUp2();
                         }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        break;
                    }
                case West:
                    {
                        this.sprite = BlockSpriteFactory.Instance.LockedDoorRight();

                        /* if (this.isLevel1)
                         {
                             this.sprite = BlockSpriteFactory.Instance.LockedDoorRight();
                         }
                         else
                         {
                             this.sprite = BlockSpriteFactory.Instance.LockedDoorRight2();
                         }*/
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
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
        }
    }
}
