using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    /*
     * The Player must kill all enemies to open these doors.
     */
    public class PuzzleDoorState : IDoorState
    {
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
                case "N":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorDown(door.UpScreenLoc);
                        location = door.UpScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        break;
                    }
                case "E":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorLeft(door.RightScreenLoc);
                        location = door.RightScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        break;
                    }
                case "S":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorUp(door.DownScreenLoc);
                        location = door.DownScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        break;
                    }
                case "W":
                    {
                        this.sprite = BlockSpriteFactory.Instance.SpecialDoorRight(door.LeftScreenLoc);
                        location = door.LeftScreenLoc;
                        door.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
                        break;
                    }
            }
        }

        public void Solve()
        {
            this.solved = true;
        }

        public void Bombed()
        {
            Console.WriteLine("Cannot Bomb Normal Door!");
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
            this.sprite.Draw(location, spriteTint);
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
