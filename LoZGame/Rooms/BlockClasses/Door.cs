using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class Door : IDoor
    {
        private string location; // relative location on screen

        private readonly Vector2 upScreenLoc = new Vector2(
            BlockSpriteFactory.Instance.HorizontalOffset + (5 * BlockSpriteFactory.Instance.TileWidth), BlockSpriteFactory.Instance.DoorOffset);

        private readonly Vector2 rightScreenLoc = new Vector2(
            800 - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight, BlockSpriteFactory.Instance.VerticalOffset + (int)(BlockSpriteFactory.Instance.TileHeight * 2.5));

        private readonly Vector2 downScreenLoc = new Vector2(
            BlockSpriteFactory.Instance.HorizontalOffset + (5 * BlockSpriteFactory.Instance.TileWidth), 480 - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight);

        private readonly Vector2 leftScreenLoc = new Vector2(
            BlockSpriteFactory.Instance.DoorOffset, BlockSpriteFactory.Instance.VerticalOffset + (int)(BlockSpriteFactory.Instance.TileHeight * 2.5));

        private IDoorState state { get; set; } // current state

        private DoorCollisionHandler doorCollisionHandler;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        public Vector2 UpScreenLoc
        {
            get { return upScreenLoc; }
        }

        public Vector2 RightScreenLoc
        {
            get { return rightScreenLoc; }
        }

        public Vector2 DownScreenLoc
        {
            get { return downScreenLoc; }
        }

        public Vector2 LeftScreenLoc
        {
            get { return leftScreenLoc; }
        }

        public Door(string loc, string starting)
        {
            this.location = loc;
            this.doorCollisionHandler = new DoorCollisionHandler(this);
            switch (starting)
            {
                case "locked":
                    this.state = new LockedDoorState(this);
                    break;
                case "special":
                    this.state = new SpecialDoorState(this);
                    break;
                case "bombed":
                    this.state = new HiddenDoorState(this);
                    break;
                default:
                    this.state = new UnlockedDoorState(this);
                    break;
            }
        }

        public void Close()
        {
            this.state = new LockedDoorState(this);
        }

        public void Open()
        {
            this.state = new UnlockedDoorState(this);
        }

        public void Bombed()
        {
            this.state = new BombedDoorState(this);
        }

        public string GetLoc()
        {
            return this.location;
        }

        public void Update()
        {
            this.state.Update();
        }

        public void Draw()
        {
            this.state.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.doorCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }
    }
}