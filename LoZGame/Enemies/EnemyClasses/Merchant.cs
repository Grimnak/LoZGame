using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class Merchant : IEnemy
    {
        public Vector2 currentLocation;
        private MerchantSprite sprite;

        public Merchant()
        {
            currentLocation = new Vector2(650, 200);
            sprite = EnemySpriteFactory.Instance.createMerchantSprite();
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
            sprite.Update();
        }
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentLocation, Color.White);
        }
    }
}

