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
    public class MovableTile : IBlock
    {
        private Vector2 location;
        private ISprite sprite;
        private Color spriteTint = Color.White;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovableTile"/> class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public MovableTile(Vector2 location, string name)
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
                case "turqoise_statue_left":
                    return BlockSpriteFactory.Instance.TurquoiseStatueLeft(this.location);
                case "turqoise_statue_right":
                    return BlockSpriteFactory.Instance.TurquoiseStatueRight(this.location);
                case "blue_statue_left":
                    return BlockSpriteFactory.Instance.BlueStatueLeft(this.location);
                case "blue_statue_right":
                    return BlockSpriteFactory.Instance.BlueStatueRight(this.location);
                default:
                    return BlockSpriteFactory.Instance.OrangeMovableSquare(this.location);
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
