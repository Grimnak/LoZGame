﻿using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;
        
        public UpMovingZolState(Zol zol)
        {
            this.zol = zol;
            sprite = EnemySpriteFactory.Instance.createZolSprite();
        }
        public void moveLeft()
        {
            zol.currentState = new LeftMovingZolState(zol);
        }
        public void moveRight()
        {
            zol.currentState = new RightMovingZolState(zol);
        }
        public void moveUp()
        {
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            zol.currentState = new DownMovingZolState(zol);
        }

        public void takeDamage()
        {
            this.zol.Health--;
            if (this.zol.Health-- == 0)
            {
                
                zol.currentState.die();
            }
        }
        public void die()
        {
            zol.currentState = new DeadZolState(zol);
        }

        public void update()
        {
            zol.currentLocation = new Vector2(zol.currentLocation.X, zol.currentLocation.Y-3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, zol.currentLocation, Color.White);
        }
    }
}
