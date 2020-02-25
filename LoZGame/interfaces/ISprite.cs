namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Sprite interface.
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// Updates the sprite.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="location">Location to draw the sprite.</param>
        /// <param name="spriteTint">Tint of the sprite.</param>
        void Draw(Vector2 location, Color spriteTint);
    }
}