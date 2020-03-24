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
        private Color spriteTint = LoZGame.Instance.DungeonTint;
        private Vector2 originalLocation;
        private string[] invalidDirections;

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        private BlockCollisionHandler blockCollisionHandler;

        public Physics Physics { get; set; }

        public string[] InvalidDirections
        {
            get { return this.invalidDirections; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovableTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        /// <param name="direction">Invalid Directions for this.</param>
        public MovableTile(Vector2 location, string name, string direction)
        {
            this.originalLocation = location;
            this.invalidDirections = !string.IsNullOrEmpty(direction) ? direction.Split(',') : null;
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = this.CreateCorrectSprite(name);
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            return BlockSpriteFactory.Instance.MovableSquare(this.Physics.Location);
        }

        private void HandlePush()
        {
            if (this.Physics.Velocity.X != 0)
            {
                if (Math.Abs(this.Physics.Location.X - this.originalLocation.X) < this.Bounds.Width && this.Physics.Location.Y == this.originalLocation.Y)
                {
                    this.Physics.StopMovementY();
                    this.Physics.Move();
                    this.Physics.Accelerate();
                }
            }
            else if (this.Physics.Velocity.Y != 0)
            {
                if (Math.Abs(this.Physics.Location.Y - this.originalLocation.Y) < this.Bounds.Height && this.Physics.Location.X == this.originalLocation.X)
                {
                    this.Physics.StopMovementX();
                    this.Physics.Move();
                    this.Physics.Accelerate();
                }
            }
        }

        private void SolveDoors()
        {
            if (Math.Abs(this.Physics.Location.X - this.originalLocation.X) == this.Bounds.Width - 1 || Math.Abs(this.Physics.Location.Y - this.originalLocation.Y) == this.Bounds.Height)
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
            this.bounds.X = (int)this.Physics.Location.X;
            this.bounds.Y = (int)this.Physics.Location.Y;
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, spriteTint);
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