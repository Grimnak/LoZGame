﻿namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
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
        /// Gets or sets a value indicating whether or not projectiles move over the block.
        /// </summary>
        bool IsTransparent { get; set; }

        List<MovableBlock.InvalidDirection> InvalidDirections { get; }

        /// <summary>
        /// Creates the correct sprite for the block.
        /// </summary>
        /// <param name="name">The name of the sprite to create.</param>
        /// <returns>The block sprite to be drawn.</returns>
        ISprite CreateCorrectSprite(string name = "");

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
