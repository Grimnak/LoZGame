namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Sprite interface.
    /// </summary>
    public interface ISprite
    {
        int TotalFrames { get; }

        int CurrentFrame { get; set; }

        int FrameDelay { get; set; }

        /// <summary>
        /// sets frame of sprite to this.
        /// </summary>
        /// <param name="frame">the frame to set</param>
        void SetFrame(int frame);

        /// <summary>
        /// updates to the next frame of the sprite manually.
        /// </summary>
        void NextFrame();

        /// <summary>
        /// Updates the sprite to the next frame based on FrameDelay.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="location">Location to draw the sprite.</param>
        /// <param name="spriteTint">Tint of the sprite.</param>
        /// <param name="depth">Depth to draw the sprite at</param>
        void Draw(Vector2 location, Color spriteTint, float depth);

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="location">Location to draw the sprite.</param>
        /// <param name="tint">Tint of the sprite.</param>
        /// <param name="rotation">rotation of the sprite in radians</param>
        /// <param name="effect">SpriteEffects to apply to the sprite before drawing</param>
        /// <param name="depth">Depth to draw the sprite at</param>
        void Draw(Vector2 location, Color tint, float rotation, SpriteEffects effect, float depth);
    }
}