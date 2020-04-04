namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class UnlockedDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;
        private Vector2 location;
        private bool isLevel1;

        public UnlockedDoorState(Door door)
        {
            this.door = door;
            this.isLevel1 = this.door.GetKind().Equals("unlocked");
            switch (door.GetLoc())
            {
                case "N":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown();

                     /*   if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown();

                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown2();
                        }*/
                        location = door.UpScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y - 12, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                }
                case "E":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();

                        /*  if (this.isLevel1)
                          {
                              this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();
                          }
                          else
                          {
                              this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft2();
                          }*/
                        location = door.RightScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 7, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
                        break;
                }
                case "S":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();

                        /*if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp2();
                        }*/
                        location = door.DownScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.VerticalOffset);
                        break;
                }
                case "W":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();
/*
                        if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight2();
                        }*/
                        location = door.LeftScreenLoc;
                        door.Physics.Bounds = new Rectangle((int)door.Physics.Location.X - 20, (int)door.Physics.Location.Y, BlockSpriteFactory.Instance.HorizontalOffset, BlockSpriteFactory.Instance.DoorWidth);
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
            this.sprite.Draw(location, spriteTint, this.door.Physics.Depth);
        }

        public void Open()
        {
        }

        public void Update()
        {
        }
    }
}
