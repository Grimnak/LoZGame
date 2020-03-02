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
    /// Interface for a tile.
    /// </summary>
    public interface IBlock : ICollider
    {
        /// <summary>
        /// Creates the correct sprite for the block.
        /// </summary>
        /// <param name="name">The name of the sprite to create.</param>
        /// <returns>The block sprite to be drawn.</returns>
        ISprite CreateCorrectSprite(string name);

        /// <summary>
        /// Updates the tile.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the tile.
        /// </summary>
        void Draw();
    }
}
