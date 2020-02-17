using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class OldMan : IEnemy
    {
        public Vector2 currentLocation;
        private readonly OldManSprite sprite;

        public OldMan()
        {
            this.currentLocation = new Vector2(650, 200);
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
        }

        public void takeDamage()
        {
            //
        }

        public void die()
        {
            //
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.currentLocation, Color.White);
        }
    }
}