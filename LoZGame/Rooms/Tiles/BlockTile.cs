namespace LoZGame
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
    public class BlockTile : ITile
    {
        private Vector2 location;
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockTile"/> class.
        /// </summary>
        /// <param name="x">X value of the tiles location vector.</param>
        /// <param name="y">Y value of the tiles location vector.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public BlockTile(string x, string y, string name)
        {
            this.location = new Vector2(float.Parse(x), float.Parse(y));
            this.name = name;
        }

        /// <inheritdoc/>
        public Vector2 Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        /// <inheritdoc/>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <inheritdoc/>
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
