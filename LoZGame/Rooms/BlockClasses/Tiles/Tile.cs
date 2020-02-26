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
        private Vector2 location;
        private ISprite sprite;
        private Color spriteTint = Color.White;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public Tile(Vector2 location, string name)
        {
            this.location = location;
            this.sprite = this.CreateCorrectSprite(name);
        }

        /// <inheritdoc/>
        public Vector2 Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        /// <inheritdoc/>
        public ISprite CreateCorrectSprite(string name)
        {
            switch (name)
            {
                case "gap_tile":
                    return BlockSpriteFactory.Instance.GapTile(this.location);
                case "ladder_tile":
                    return BlockSpriteFactory.Instance.LadderTile(this.location);
                case "spotted_tile":
                    return BlockSpriteFactory.Instance.SpottedTile(this.location);
                default:
                    return BlockSpriteFactory.Instance.FloorTile(this.location);
            }
        }

        /// <inheritdoc/>
        public void Update()
        {
        }

        /// <inheritdoc/>
        public void Draw()
        {
            this.sprite.Draw(location, spriteTint);
        }
    }
}
