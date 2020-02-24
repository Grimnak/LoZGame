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
    /// Interface for a tile.
    /// </summary>
    public interface ITile
    {
        /// <summary>
        /// Gets or sets the tiles location vector.
        /// </summary>
        Vector2 Location { get; set; }

        /// <summary>
        /// Gets or sets the tiles name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Updates the tile.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the tile.
        /// </summary>
        /// <param name="spriteBatch">Spritebatch to do the drawing.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}
