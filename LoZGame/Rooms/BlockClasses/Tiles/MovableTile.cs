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
        private Color spriteTint = Color.White;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        BlockCollisionHandler blockCollisionHandler;

        public Physics Physics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovableTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public MovableTile(Vector2 location, string name)
        {
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
            if (Math.Abs((int)this.Physics.Velocity.X) != 0 || Math.Abs((int)this.Physics.Velocity.Y) != 0)
            {
                this.Physics.Move();
                this.Physics.Accelerate();
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            HandlePush();
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
            else if (otherCollider is IBlock)
            {
                this.blockCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
        }
    }
}