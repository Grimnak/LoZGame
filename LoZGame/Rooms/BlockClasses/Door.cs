﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class Door : IDoor
    {
        private string location;

        private readonly Vector2 upScreenLoc = new Vector2(363, LoZGame.Instance.InventoryOffset + 12);
        private readonly Vector2 downScreenLoc = new Vector2(363, LoZGame.Instance.ScreenHeight - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight);

        private readonly Vector2 rightScreenLoc = new Vector2(
            LoZGame.Instance.ScreenWidth - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight + 11, LoZGame.Instance.InventoryOffset + 195);

        private readonly Vector2 leftScreenLoc = new Vector2(19, LoZGame.Instance.InventoryOffset + 195);

        private IDoorState state;

        private string kind;

        public IDoorState State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        private DoorCollisionHandler doorCollisionHandler;

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
            this.SetPhysics();
            this.kind = starting;
            switch (starting)
            {
                case "locked":
                    this.state = new LockedDoorState(this);
                    break;
                case "locked2":
                    this.state = new LockedDoorState(this);
                    break;
                case "special":
                    this.state = new SpecialDoorState(this);
                    break;
                case "special2":
                    this.state = new SpecialDoorState(this);
                    break;
                case "hidden":
                    this.state = new HiddenDoorState(this);
                    break;
                case "hidden2":
                    this.state = new HiddenDoorState(this);
                    break;
                case "cosmetic":
                    this.state = new CosmeticDoorState(this);
                    break;
                case "cosmetic2":
                    this.state = new CosmeticDoorState(this);
                    break;
                case "puzzle":
                    this.state = new PuzzleDoorState(this);
                    break;
                default:
                    this.state = new UnlockedDoorState(this);
                    break;
            }
        }

        private void SetPhysics()
        {
            switch (this.location)
            {
                case "N":
                    {
                        this.Physics = new Physics(this.upScreenLoc);
                        break;
                    }
                case "E":
                    {
                        this.Physics = new Physics(this.rightScreenLoc);
                        break;
                    }
                case "S":
                    {
                        this.Physics = new Physics(this.downScreenLoc);
                        break;
                    }
                case "W":
                    {
                        this.Physics = new Physics(this.leftScreenLoc);
                        break;
                    }
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
            if (this.state is LockedDoorState || this.state is SpecialDoorState)
            {
                this.state = new UnlockedDoorState(this);
            }
            else
            {
                this.state = new BombedDoorState(this);
            }
        }

        public string GetLoc()
        {
            return this.location;
        }

        public string GetKind()
        {
            return this.kind;
        }

        public void Update()
        {
            this.Physics.SetDepth();
            this.state.Update();
        }

        public void Draw()
        {
            this.state.Draw();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer && !(this.state is CosmeticDoorState || this.state is HiddenDoorState))
            {
                this.doorCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                this.doorCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}