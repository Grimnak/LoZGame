namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public partial class Door : IDoor
    {
        public Door(string loc, string starting)
        {
            this.doorCollisionHandler = new DoorCollisionHandler(this);
            this.SetPhysics(loc);
            this.solved = false;
            this.doorWidth = GameData.Instance.PhysicsConstants.DoorWidth;
            switch (starting)
            {
                case "locked":
                    this.state = new LockedDoorState(this);
                    this.DoorType = DoorTypes.Locked;
                    break;
                case "special":
                    this.state = new SpecialDoorState(this);
                    this.DoorType = DoorTypes.Special;
                    break;
                case "hidden":
                    this.state = new HiddenDoorState(this);
                    this.DoorType = DoorTypes.Hidden;
                    break;
                case "cosmetic":
                    this.state = new CosmeticDoorState(this);
                    this.DoorType = DoorTypes.Cosmetic;
                    break;
                case "puzzle":
                    this.state = new PuzzleDoorState(this);
                    this.DoorType = DoorTypes.Puzzle;
                    break;
                default:
                    this.state = new UnlockedDoorState(this);
                    this.DoorType = DoorTypes.Unlocked;
                    break;
            }
        }

        private void SetPhysics(string loc)
        {
            switch (loc)
            {
                case North:
                    {
                        this.Physics = new Physics(this.upScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.Physics.CurrentDirection = Physics.Direction.North;
                        break;
                    }
                case East:
                    {
                        this.Physics = new Physics(this.rightScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.Physics.CurrentDirection = Physics.Direction.East;
                        break;
                    }
                case South:
                    {
                        this.Physics = new Physics(this.downScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.Physics.CurrentDirection = Physics.Direction.South;
                        break;
                    }
                case West:
                    {
                        this.Physics = new Physics(this.leftScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.Physics.CurrentDirection = Physics.Direction.West;
                        break;
                    }
                default:
                    this.Physics = new Physics(this.upScreenLoc);
                    this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                    this.Physics.CurrentDirection = Physics.Direction.North;
                    break;
            }
            this.Physics.SetDepth();
        }

        public void Bombed()
        {
            this.state.Bombed();
        }

        public void Open()
        {
            this.state.Open();
        }

        public void Close()
        {
            this.state.Close();
        }

        public void Update()
        {
            this.state.Update();
        }

        public void Draw()
        {
            this.state.DrawFrame();
            this.state.DrawFloor();
        }

        public void DrawFrame()
        {
            this.state.DrawFrame();
        }

        public void DrawFloor()
        {
            this.state.DrawFloor();
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