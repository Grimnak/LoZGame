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
        /// <param name="x">X value of the tiles location vector.</param>
        /// <param name="y">Y value of the tiles location vector.</param>
        /// <param name="name">Name of the tiles sprite.</param>
        public MovableTile(string x, string y, string name)
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
