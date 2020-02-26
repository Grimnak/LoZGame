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
        private IBlockSprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="x">X value of the tiles location vector.</param>
        /// <param name="y">Y value of the tiles location vector.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public Tile(string x, string y, string name)
        {
            float rawX = float.Parse(x);
            float rawY = float.Parse(y);
            this.location = new Vector2((float)(16 + (64 * rawX)), (float)(16 + (64 * rawY)));
            this.sprite = this.CreateCorrectSprite(name);
        }

        /// <inheritdoc/>
        public Vector2 Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        /// <inheritdoc/>
        public IBlockSprite CreateCorrectSprite(string name)
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
        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}
