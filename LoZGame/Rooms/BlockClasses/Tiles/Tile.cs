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
        private ISprite sprite;
        private Color spriteTint = LoZGame.Instance.DungeonTint;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.Physics.Bounds; }
            set { this.Physics.Bounds = value; }
        }

        public Physics Physics { get; set; }

        public string Name { get; }

        public string[] InvalidDirections { get { return null; } }

        private BlockCollisionHandler blockCollisionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public Tile(Vector2 location, string name)
        {
            this.blockCollisionHandler = new BlockCollisionHandler(this);
            this.Physics = new Physics(location);
            this.Name = name;
            this.sprite = this.CreateCorrectSprite(name);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, BlockSpriteFactory.Instance.TileWidth, BlockSpriteFactory.Instance.TileHeight);
            this.Physics.Depth = 0.001f;
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "gap_tile":
                    return BlockSpriteFactory.Instance.GapTile();
                case "black_tile":
                    return BlockSpriteFactory.Instance.GapTile();
                case "ladder_tile":
                    return BlockSpriteFactory.Instance.LadderTile();
                case "spotted_tile":
                    return BlockSpriteFactory.Instance.SpottedTile();
                case "stairs":
                    return BlockSpriteFactory.Instance.Stairs();
                default:
                    return BlockSpriteFactory.Instance.FloorTile();
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
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
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}