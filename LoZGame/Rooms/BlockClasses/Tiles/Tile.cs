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
    /// Class for a basic tile.
    /// </summary>
    public class Tile : IBlock
    {
        private const string GapTile = "gap_tile";
        private const string BlackTile = "black_tile";
        private const string LadderTile = "ladder_tile";
        private const string SpottedTile = "spotted_tile";
        private const string Stairs = "stairs";
        private const string SpottedTile2 = "spotted_tile2";
        private const string BossTile2 = "boss_tile2";
        private const string Lava2 = "lava2";
        private const string Stairs3 = "stairs3";
        private const string SpottedTile3 = "spotted_tile3";
        private const string SpottedTile4 = "spotted_tile4";

        private ISprite sprite;
        private Color spriteTint = LoZGame.Instance.DefaultTint;
        private Rectangle bounds;
        private bool isTransparent;

        public bool IsTransparent { get { return isTransparent; } set { isTransparent = value; } }

        public Rectangle Bounds
        {
            get { return Physics.Bounds; }
            set { Physics.Bounds = value; }
        }

        public Physics Physics { get; set; }

        public string Name { get; }

        public List<MovableBlock.InvalidDirection> InvalidDirections { get { return null; } }

        private BlockCollisionHandler blockCollisionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public Tile(Vector2 location, string name)
        {
            blockCollisionHandler = new BlockCollisionHandler(this);
            Physics = new Physics(location);
            Name = name;
            isTransparent = true;
            spriteTint = Color.Gray;
            sprite = CreateCorrectSprite(name);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, (int)BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
            Physics.Depth = GameData.Instance.RoomConstants.TileDepth;
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case GapTile:
                    return BlockSpriteFactory.Instance.GapTile();
                case BlackTile:
                    return BlockSpriteFactory.Instance.GapTile();
                case LadderTile:
                    return BlockSpriteFactory.Instance.LadderTile();
                case SpottedTile:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.SpottedTile();
                case Stairs:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.Stairs();
                case SpottedTile2:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.SpottedTile();
                case BossTile2:
                    return BlockSpriteFactory.Instance.BossTile2();
                case Lava2:
                    return BlockSpriteFactory.Instance.LavaTile2();
                case Stairs3:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.Stairs();
                case SpottedTile3:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.SpottedTile();
                case SpottedTile4:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.SpottedTile();
                default:
                    spriteTint = LoZGame.Instance.DungeonTint;
                    return DungeonSpriteFactory.Instance.FloorTile();
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
            if (!(LoZGame.Instance.Dungeon is null))
            {
                spriteTint = LoZGame.Instance.Dungeon.CurrentRoom.CurrentRoomTint;
            }
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
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}