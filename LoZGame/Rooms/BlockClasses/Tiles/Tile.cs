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
        private Color spriteTint = Color.White;
        private Rectangle bounds;

        public Rectangle Bounds
        {
            get { return this.bounds; }
            set { this.bounds = value; }
        }

        public Physics Physics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public Tile(Vector2 location, string name)
        {
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.sprite = this.CreateCorrectSprite(name);
            this.bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, LoZGame.Instance.TileWidth, LoZGame.Instance.TileHeight);
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "gap_tile":
                    return BlockSpriteFactory.Instance.GapTile(this.Physics.Location);
                case "ladder_tile":
                    return BlockSpriteFactory.Instance.LadderTile(this.Physics.Location);
                case "spotted_tile":
                    return BlockSpriteFactory.Instance.SpottedTile(this.Physics.Location);
                case "stairs":
                    return BlockSpriteFactory.Instance.Stairs(this.Physics.Location);
                default:
                    return BlockSpriteFactory.Instance.FloorTile(this.Physics.Location);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, spriteTint);
        }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
        }
    }
}