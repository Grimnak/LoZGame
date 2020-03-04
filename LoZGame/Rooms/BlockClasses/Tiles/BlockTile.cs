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
    /// Class for a block tile.
    /// </summary>
    public class BlockTile : IBlock
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
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public BlockTile(Vector2 location, string name)
        {
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = this.CreateCorrectSprite(name);
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "water_tile":
                    return BlockSpriteFactory.Instance.WaterTile(this.Physics.Location);
                case "basement_brick_tile":
                    return BlockSpriteFactory.Instance.BasementBrickTile(this.Physics.Location);
                case "fire_gap_tile":
                    return BlockSpriteFactory.Instance.Fire(this.Physics.Location);
                case "turqoise_statue_left":
                    return BlockSpriteFactory.Instance.TurquoiseStatueLeft(this.Physics.Location);
                case "turqoise_statue_right":
                    return BlockSpriteFactory.Instance.TurquoiseStatueRight(this.Physics.Location);
                case "blue_statue_left":
                    return BlockSpriteFactory.Instance.BlueStatueLeft(this.Physics.Location);
                case "blue_statue_right":
                    return BlockSpriteFactory.Instance.BlueStatueRight(this.Physics.Location);
                default:
                    return BlockSpriteFactory.Instance.MovableSquare(this.Physics.Location);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            this.sprite.Update(); 
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
    }
}