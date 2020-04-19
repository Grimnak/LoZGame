namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public partial class Door : IDoor
    {
        /// <summary>
        /// Defines the location relative to the door to draw thee overhang of the hallway.
        /// </summary>
        private Vector2 overhangOffset;

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
                        this.overhangOffset = new Vector2(0, -(BlockSpriteFactory.Instance.VerticalOffset - this.Physics.Bounds.Height));
                        break;
                    }
                case East:
                    {
                        this.Physics = new Physics(this.rightScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.Physics.CurrentDirection = Physics.Direction.East;
                        this.overhangOffset = new Vector2(this.Physics.Bounds.Width, 0);
                        break;
                    }
                case South:
                    {
                        this.Physics = new Physics(this.downScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        this.Physics.CurrentDirection = Physics.Direction.South;
                        this.overhangOffset = new Vector2(0, this.Physics.Bounds.Height);
                        break;
                    }
                case West:
                    {
                        this.Physics = new Physics(this.leftScreenLoc);
                        this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        this.Physics.CurrentDirection = Physics.Direction.West;
                        this.overhangOffset = new Vector2(-(BlockSpriteFactory.Instance.HorizontalOffset - this.Physics.Bounds.Width), 0);
                        break;
                    }
                default:
                    this.Physics = new Physics(this.upScreenLoc);
                    this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                    this.Physics.CurrentDirection = Physics.Direction.North;
                    this.overhangOffset = new Vector2(0, -(BlockSpriteFactory.Instance.VerticalOffset - this.Physics.Bounds.Height));
                    break;
            }
            this.Physics.SetDepth();
        }

        public Vector2 OverhangOffset
        {
            get { return overhangOffset; }
            set { overhangOffset = value; }
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