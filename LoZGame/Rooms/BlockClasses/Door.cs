namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public partial class Door : IDoor
    {
        /// <summary>
        /// Defines the location relative to the door to draw the overhang of the hallway.
        /// </summary>
        private Vector2 overhangOffset;

        public Door(string loc, string starting)
        {
            doorCollisionHandler = new DoorCollisionHandler(this);
            SetPhysics(loc);
            solved = false;
            doorWidth = GameData.Instance.PhysicsConstants.DoorWidth;
            switch (starting)
            {
                case "locked":
                    state = new LockedDoorState(this);
                    DoorType = DoorTypes.Locked;
                    break;
                case "special":
                    state = new SpecialDoorState(this);
                    DoorType = DoorTypes.Special;
                    break;
                case "hidden":
                    state = new HiddenDoorState(this);
                    DoorType = DoorTypes.Hidden;
                    break;
                case "cosmetic":
                    state = new CosmeticDoorState(this);
                    DoorType = DoorTypes.Cosmetic;
                    break;
                case "puzzle":
                    state = new PuzzleDoorState(this);
                    DoorType = DoorTypes.Puzzle;
                    break;
                default:
                    state = new UnlockedDoorState(this);
                    DoorType = DoorTypes.Unlocked;
                    break;
            }
        }

        private void SetPhysics(string loc)
        {
            switch (loc)
            {
                case North:
                    {
                        Physics = new Physics(upScreenLoc);
                        Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        Physics.CurrentDirection = Physics.Direction.North;
                        overhangOffset = new Vector2(0, -(BlockSpriteFactory.Instance.VerticalOffset - Physics.Bounds.Height));
                        break;
                    }
                case East:
                    {
                        Physics = new Physics(rightScreenLoc);
                        Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        Physics.CurrentDirection = Physics.Direction.East;
                        overhangOffset = new Vector2(Physics.Bounds.Width + 2, 0);
                        break;
                    }
                case South:
                    {
                        Physics = new Physics(downScreenLoc);
                        Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                        Physics.CurrentDirection = Physics.Direction.South;
                        overhangOffset = new Vector2(0, Physics.Bounds.Height);
                        break;
                    }
                case West:
                    {
                        Physics = new Physics(leftScreenLoc);
                        Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.DoorHeight, BlockSpriteFactory.Instance.DoorWidth);
                        Physics.CurrentDirection = Physics.Direction.West;
                        overhangOffset = new Vector2(-(BlockSpriteFactory.Instance.HorizontalOffset - Physics.Bounds.Width + 2), 0);
                        break;
                    }
                default:
                    Physics = new Physics(upScreenLoc);
                    Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, BlockSpriteFactory.Instance.DoorWidth, BlockSpriteFactory.Instance.DoorHeight);
                    Physics.CurrentDirection = Physics.Direction.North;
                    overhangOffset = new Vector2(0, -(BlockSpriteFactory.Instance.VerticalOffset - Physics.Bounds.Height));
                    break;
            }
            Physics.SetDepth();
        }

        public Vector2 OverhangOffset
        {
            get { return overhangOffset; }
            set { overhangOffset = value; }
        }

        public void Bombed()
        {
            state.Bombed();
        }

        public void Open()
        {
            state.Open();
        }

        public void Close()
        {
            state.Close();
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw()
        {
            state.DrawFrame();
            state.DrawFloor();
        }

        public void DrawFrame()
        {
            state.DrawFrame();
        }

        public void DrawFloor()
        {
            state.DrawFloor();
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer && !(state is CosmeticDoorState || state is HiddenDoorState))
            {
                doorCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile)
            {
                doorCollisionHandler.OnCollisionResponse((IProjectile)otherCollider);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}