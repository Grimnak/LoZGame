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

        private const string WaterTile = "water_tile";
        private const string BasementBrickTile = "basement_brick_tile";
        private const string FireGapTile = "fire_gap_tile";
        private const string TurquoiseStatueLeft = "turquoise_statue_left";
        private const string TurquoiseStatueRight = "turquoise_statue_right";
        private const string BlueStatueLeft = "blue_statue_left";
        private const string BlueStatueRight = "blue_statue_right";
        private const string MovableSquare2 = "movable_square2";
        private const string BlueStatueLeft2 = "blue_statue_left2";
        private const string BlueStatueRight2 = "blue_statue_right2";
        private const string OrangeStatueRight2 = "orange_statue_right2";
        private const string OrangeStatueLeft2 = "orange_statue_left2";
        private const string statueCheck = "statue";

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
            this.Physics.Depth = GameData.Instance.RoomConstants.BlockTileDepth;
            this.SetBounds(name);
        }

        private void SetBounds(string name)
        {
            if (name.Contains(statueCheck))
            {
                this.Physics.Bounds = new Rectangle(this.Physics.Bounds.X, this.Physics.Bounds.Y + GameData.Instance.RoomConstants.BlockTileHeightOffset, this.Physics.Bounds.Width, this.Physics.Bounds.Height - GameData.Instance.RoomConstants.BlockTileHeightOffset);
                this.Physics.BoundsOffset = new Vector2(0, GameData.Instance.RoomConstants.BlockTileHeightOffset);
                this.Physics.SetDepth();
            }
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case WaterTile:
                    return BlockSpriteFactory.Instance.WaterTile();
                case BasementBrickTile:
                    return BlockSpriteFactory.Instance.BasementBrickTile();
                case FireGapTile:
                    return BlockSpriteFactory.Instance.Fire();
                case TurquoiseStatueLeft:
                    return BlockSpriteFactory.Instance.TurquoiseStatueLeft();
                case TurquoiseStatueRight:
                    return BlockSpriteFactory.Instance.TurquoiseStatueRight();
                case BlueStatueLeft:
                    return BlockSpriteFactory.Instance.BlueStatueLeft();
                case BlueStatueRight:
                    return BlockSpriteFactory.Instance.BlueStatueRight();
                case MovableSquare2:
                    return BlockSpriteFactory.Instance.MovableSquare2();
                case BlueStatueRight2:
                    return BlockSpriteFactory.Instance.BlueStatueRight2();
                case BlueStatueLeft2:
                    return BlockSpriteFactory.Instance.BlueStatueLeft2();
                case OrangeStatueRight2:
                    return BlockSpriteFactory.Instance.OrangeStatueRight2();
                case OrangeStatueLeft2:
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