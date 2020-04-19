namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Class for a movable tile.
    /// </summary>
    public class MovableTile : IBlock
    {
        private ISprite sprite;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Vector2 originalLocation;
        private List<InvalidDirection> invalidDirections;
        private bool moved;

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.Physics.Bounds; }
            set { this.Physics.Bounds = value; }
        }

        public enum InvalidDirection
        {
            North,
            South,
            East,
            West
        };

        private BlockCollisionHandler blockCollisionHandler;

        public Physics Physics { get; set; }

        public List<InvalidDirection> InvalidDirections => invalidDirections;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovableTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        /// <param name="direction">Invalid Directions for this.</param>
        public MovableTile(Vector2 location, string name, string direction)
        {
            this.originalLocation = location;
            this.invalidDirections = new List<InvalidDirection>();
            string[] invalidDirectionStrings = !string.IsNullOrEmpty(direction) ? direction.Split(',') : null;
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location);
            this.sprite = this.CreateCorrectSprite(name); 
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            this.Physics.SetDepth();
            this.moved = false;
            if (!(invalidDirectionStrings is null))
            {
                foreach (string invalid in invalidDirectionStrings)
                {
                    switch (invalid)
                    {
                        case "N":
                            InvalidDirections.Add(InvalidDirection.North);
                            break;
                        case "S":
                            InvalidDirections.Add(InvalidDirection.South);
                            break;
                        case "E":
                            InvalidDirections.Add(InvalidDirection.East);
                            break;
                        case "W":
                            InvalidDirections.Add(InvalidDirection.West);
                            break;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "orange_movable_square3":
                    return BlockSpriteFactory.Instance.MovableSquare3();
                default:
                    return BlockSpriteFactory.Instance.MovableSquare();
            }
        }

        private void HandlePush()
        {
            if (this.Physics.MovementVelocity.X != 0)
            {
                if (Math.Abs(this.Physics.Location.X - this.originalLocation.X) <= this.Physics.Bounds.Width && this.Physics.Location.Y == this.originalLocation.Y)
                {
                    this.Physics.StopMovementY();
                    this.Physics.Move();
                    this.Physics.Accelerate();
                }
                else if (!moved)
                {
                    moved = true;
                }
            }
            else if (this.Physics.MovementVelocity.Y != 0)
            {
                if (Math.Abs(this.Physics.Location.Y - this.originalLocation.Y) <= this.Physics.Bounds.Height && this.Physics.Location.X == this.originalLocation.X)
                {
                    this.Physics.StopMovementX();
                    this.Physics.Move();
                    this.Physics.Accelerate();
                }
                else if (!moved)
                {
                    moved = true;
                }
            }
        }

        private void SolveDoors()
        {
            if (Math.Abs(this.Physics.Location.X - this.originalLocation.X) >= this.Physics.Bounds.Width || Math.Abs(this.Physics.Location.Y - this.originalLocation.Y) >= this.Physics.Bounds.Height)
            {
                foreach (Door door in LoZGame.Instance.GameObjects.Doors.DoorList)
                {
                    if (door.State is PuzzleDoorState)
                    {
                        ((PuzzleDoorState)door.State).Solve();
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            HandlePush();
            SolveDoors();
            if (!moved)
            {
                this.Physics.SetDepth();
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, spriteTint, this.Physics.Depth);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.blockCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IEnemy)
            {
                this.blockCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}