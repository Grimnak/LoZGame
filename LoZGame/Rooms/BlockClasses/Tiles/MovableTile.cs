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
        private bool isTransparent;

        public bool IsTransparent { get { return isTransparent; } set { isTransparent = value; } }

        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return Physics.Bounds; }
            set { Physics.Bounds = value; }
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
            originalLocation = location;
            invalidDirections = new List<InvalidDirection>();
            string[] invalidDirectionStrings = !string.IsNullOrEmpty(direction) ? direction.Split(',') : null;
            blockCollisionHandler = new BlockCollisionHandler(this);
            Physics = new Physics(location);
            sprite = DungeonSpriteFactory.Instance.MoveabeTile(); 
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            Physics.SetDepth();
            moved = false;
            isTransparent = false;
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
            if (Physics.MovementVelocity.X != 0)
            {
                if (Math.Abs(Physics.Location.X - originalLocation.X) <= Physics.Bounds.Width && Physics.Location.Y == originalLocation.Y)
                {
                    Physics.StopMovementY();
                    Physics.Move();
                    Physics.Accelerate();
                }
                else if (!moved)
                {
                    moved = true;
                }
            }
            else if (Physics.MovementVelocity.Y != 0)
            {
                if (Math.Abs(Physics.Location.Y - originalLocation.Y) <= Physics.Bounds.Height && Physics.Location.X == originalLocation.X)
                {
                    Physics.StopMovementX();
                    Physics.Move();
                    Physics.Accelerate();
                }
                else if (!moved)
                {
                    moved = true;
                }
            }
        }

        private void SolveDoors()
        {
            if (Math.Abs(Physics.Location.X - originalLocation.X) >= Physics.Bounds.Width || Math.Abs(Physics.Location.Y - originalLocation.Y) >= Physics.Bounds.Height)
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
                Physics.SetDepth();
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(Physics.Location, LoZGame.Instance.DungeonTint, Physics.Depth);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                blockCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IEnemy)
            {
                blockCollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}