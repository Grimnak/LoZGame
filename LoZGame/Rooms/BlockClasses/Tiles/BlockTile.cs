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
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.Physics.Bounds; }
            set { this.Physics.Bounds = value; }
        }

        public string[] InvalidDirections { get { return null; } }

        private BlockCollisionHandler blockCollisionHandler;

        public Physics Physics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public BlockTile(Vector2 location, string name)
        {
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location);
            this.sprite = this.CreateCorrectSprite(name);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
            this.Physics.Depth = 0.002f;
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "water_tile":
                    return BlockSpriteFactory.Instance.WaterTile();
                case "basement_brick_tile":
                    return BlockSpriteFactory.Instance.BasementBrickTile();
                case "fire_gap_tile":
                    return BlockSpriteFactory.Instance.Fire();
                case "turqoise_statue_left":
                    return BlockSpriteFactory.Instance.TurquoiseStatueLeft();
                case "turqoise_statue_right":
                    return BlockSpriteFactory.Instance.TurquoiseStatueRight();
                case "blue_statue_left":
                    return BlockSpriteFactory.Instance.BlueStatueLeft();
                case "blue_statue_right":
                    return BlockSpriteFactory.Instance.BlueStatueRight();
                case "movable_square2":
                    return BlockSpriteFactory.Instance.MovableSquare2();
                case "blue_statue_right2":
                    return BlockSpriteFactory.Instance.BlueStatueRight2();
                case "blue_statue_left2":
                    return BlockSpriteFactory.Instance.BlueStatueLeft2();
                case "orange_statue_right2":
                    return BlockSpriteFactory.Instance.OrangeStatueRight2();
                case "orange_statue_left2":
                    return BlockSpriteFactory.Instance.OrangeStatueLeft2();
                default:
                    return BlockSpriteFactory.Instance.MovableSquare();
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