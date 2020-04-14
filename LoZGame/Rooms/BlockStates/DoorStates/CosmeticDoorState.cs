﻿namespace LoZClone
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

                      /*  if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown2();
                        }*/
                        break;
                }
                case East:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();

                       /* if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft2();
                        }*/
                        break;
                }
                case South:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();

                       /* if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp2();
                        }*/
                        break;
                }
                case West:
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();

                      /*  if (this.isLevel1)
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight();
                        }
                        else
                        {
                            this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight2();
                        }*/
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
