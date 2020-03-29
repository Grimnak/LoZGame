using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class CosmeticDoorState : IDoorState
    {
        private readonly Door door;
        private readonly ISprite sprite;
        private readonly Color spriteTint = LoZGame.Instance.DungeonTint;

        public CosmeticDoorState(Door door)
        {
            this.door = door;
            switch (door.GetLoc())
            {
                case "N":
                {
                    this.sprite = BlockSpriteFactory.Instance.UnlockedDoorDown(door.UpScreenLoc);
                    break;
                }
                case "E":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorLeft(door.RightScreenLoc);
                        break;
                }
                case "S":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorUp(door.DownScreenLoc);
                        break;
                }
                case "W":
                {
                        this.sprite = BlockSpriteFactory.Instance.UnlockedDoorRight(door.LeftScreenLoc);
                        break;
                }
            }
        }

        public void Bombed()
        {
            Console.WriteLine("Cannot Bomb Normal Door!");
        }

        public void Close()
        {
            this.door.Close();
        }

        public void Draw()
        {
            this.sprite.Draw(this.door.Physics.Location, spriteTint);
        }

        public void Open()
        {
            Console.WriteLine("Cannot Open Unlocked Door!");
        }

        public void Update()
        {
        }
    }
}
