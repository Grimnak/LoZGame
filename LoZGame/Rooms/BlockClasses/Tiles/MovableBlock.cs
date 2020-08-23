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
    public class MovableBlock : IBlock
    {
        private ISprite sprite;
        private bool movable = false;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Vector2 originalLocation;
        private List<InvalidDirection> invalidDirections;
        private bool isTransparent;
        
        public IMovableBlockState CurrentState { get; set; }

        public Color SpriteTint { get { return spriteTint; } set { spriteTint = value; } }

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

        public Vector2 OriginalLocation { get { return originalLocation; } set { originalLocation = value; } }

        public Physics Physics { get; set; }

        public List<InvalidDirection> InvalidDirections => invalidDirections;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovableBlock"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        /// <param name="direction">Invalid Directions for this.</param>
        public MovableBlock(Vector2 location, string name, string direction)
        {
            originalLocation = location;
            spriteTint = LoZGame.Instance.DungeonTint;
            CurrentState = new UnsolvedState(this);
            invalidDirections = new List<InvalidDirection>();
            string[] invalidDirectionStrings = !string.IsNullOrEmpty(direction) ? direction.Split(',') : null;
            blockCollisionHandler = new BlockCollisionHandler(this);
            Physics = new Physics(location);
            sprite = DungeonSpriteFactory.Instance.MovableTile();
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            Physics.SetDepth();
            isTransparent = false;
            SetInvalidDirections(invalidDirectionStrings);
        }

        public ISprite CreateCorrectSprite(string name)
        {
            return DungeonSpriteFactory.Instance.MovableTile();
        }

        /// <inheritdoc/>
        public void Update()
        {
            CurrentState.Update();

            if (!(LoZGame.Instance.Dungeon is null))
            {
                spriteTint = LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint;
            }
        }

        /// <inheritdoc/>
        public void Draw()
        {
            CurrentState.Draw();
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

        private void SetInvalidDirections(string[] invalidDirectionStrings)
        {
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
    }
}
