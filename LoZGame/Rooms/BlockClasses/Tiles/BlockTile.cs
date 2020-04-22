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
        private const string BasementBrickTile = "basement_brick_tile";
        private const string FireGapTile = "fire_gap_tile";
        private const string TurquoiseStatueLeft = "turquoise_statue_left";
        private const string TurquoiseStatueRight = "turquoise_statue_right";
        private const string BlueStatueLeft = "blue_statue_left";
        private const string BlueStatueRight = "blue_statue_right";
        private const string MovableSquare2 = "movable_square2";
        private const string MovableSquare3 = "movable_square3";
        private const string BlueStatueLeft2 = "blue_statue_left2";
        private const string BlueStatueRight2 = "blue_statue_right2";
        private const string OrangeStatueRight2 = "orange_statue_right2";
        private const string OrangeStatueLeft2 = "orange_statue_left2";
        private const string RedStatueLeft3 = "red_statue_left3";
        private const string RedStatueRight3 = "red_statue_right3";
        private const string GreenStatueRight3 = "green_statue_right";
        private const string GreenStatueLeft3 = "green_statue_left";
        private const string statueCheck = "statue";
        private const string BlueStatueLeft4 = "blue_statue_left4";
        private const string BlueStatueRight4 = "blue_statue_right4";
        private const string BrownStatueRight4 = "brown_statue_right4";
        private const string BrownStatueLeft4 = "brown_statue_left4";
        private const string MovableTile4 = "movable_tile4";

        private ISprite sprite;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Rectangle bounds;
        private bool isTransparent;

        public bool IsTransparent { get { return isTransparent; } set { isTransparent = value; } }

        public Rectangle Bounds { get { return Physics.Bounds; } set { Physics.Bounds = value; } }

        public List<MovableTile.InvalidDirection> InvalidDirections { get { return null; } }

        private BlockCollisionHandler blockCollisionHandler;

        public Physics Physics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public BlockTile(Vector2 location, string name)
        {
            blockCollisionHandler = new BlockCollisionHandler(this);
            Physics = new Physics(location);
            spriteTint = Color.Gray;
            isTransparent = DetermineTransparency(name);
            sprite = CreateCorrectSprite(name);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, (int)BlockSpriteFactory.Instance.TileHeight);
            Physics.Depth = GameData.Instance.RoomConstants.BlockTileDepth;
            SetBounds(name);
        }

        private void SetBounds(string name)
        {
            if (name.Contains(statueCheck))
            {
                Physics.Bounds = new Rectangle(Physics.Bounds.X, Physics.Bounds.Y + GameData.Instance.RoomConstants.BlockTileHeightOffset, Physics.Bounds.Width, Physics.Bounds.Height - GameData.Instance.RoomConstants.BlockTileHeightOffset);
                Physics.BoundsOffset = new Vector2(0, -GameData.Instance.RoomConstants.BlockTileHeightOffset);
                Physics.SetDepth();
                Physics.SetLocation();
            }
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
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
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.MoveabeTile();
                case BlueStatueRight2:
                    return BlockSpriteFactory.Instance.BlueStatueRight2();
                case BlueStatueLeft2:
                    return BlockSpriteFactory.Instance.BlueStatueLeft2();
                case OrangeStatueRight2:
                    return BlockSpriteFactory.Instance.OrangeStatueRight2();
                case OrangeStatueLeft2:
                    return BlockSpriteFactory.Instance.OrangeStatueLeft2();
                case RedStatueRight3:
                    return BlockSpriteFactory.Instance.RedStatueRight3();
                case RedStatueLeft3:
                    return BlockSpriteFactory.Instance.RedStatueLeft3();
                case GreenStatueRight3:
                    return BlockSpriteFactory.Instance.GreenStatueRight3();
                case GreenStatueLeft3:
                    return BlockSpriteFactory.Instance.GreenStatueLeft3();
                case MovableSquare3:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.MoveabeTile();
                case BlueStatueRight4:
                    return BlockSpriteFactory.Instance.BlueStatueRight4();
                case BlueStatueLeft4:
                    return BlockSpriteFactory.Instance.BlueStatueLeft4();
                case BrownStatueRight4:
                    return BlockSpriteFactory.Instance.BrownStatueRight4();
                case BrownStatueLeft4:
                    return BlockSpriteFactory.Instance.BrownStatueLeft4();
                case MovableTile4:
                    return BlockSpriteFactory.Instance.MovableTile4();
                default:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.MoveabeTile();
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            sprite.Update();
        }

        /// <inheritdoc/>
        public void Draw()
        {
            sprite.Draw(Physics.Location, spriteTint, Physics.Depth);
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

        /// <summary>
        /// Determines if a block is transparent or not, which affects the ability of some projectile (e.g. fireballs) to travel over them.
        /// </summary>
        /// <param name="name">The name of the block tile.</param>
        /// <returns></returns>
        private bool DetermineTransparency(string name)
        {
            if (name.Equals(BasementBrickTile) || name.Equals(FireGapTile) || name.Equals(BlueStatueLeft2) || name.Equals(BlueStatueRight2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}