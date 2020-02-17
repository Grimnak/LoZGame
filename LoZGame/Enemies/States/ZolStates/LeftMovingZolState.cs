﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LeftMovingZolState : IEnemyState
    {
        private Zol zol;
        private IZolSprite sprite;

        public LeftMovingZolState(Zol zol)
        {
            this.zol = zol;
            sprite = EnemySpriteFactory.Instance.createZolSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            zol.CurrentState = new RightMovingZolState(zol);
        }
        public void moveUp()
        {
            zol.CurrentState = new UpMovingZolState(zol);
        }
        public void moveDown()
        {
            zol.CurrentState = new DownMovingZolState(zol);
        }

        public void takeDamage()
        {
            this.zol.Health--;
            if (this.zol.Health == 0)
            {
                zol.CurrentState.die();
            }
        }
        public void die()
        {
            zol.CurrentState = new DeadZolState(zol);
        }


        public void Update()
        {
            zol.currentLocation = new Vector2(zol.currentLocation.X - 1, zol.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, zol.currentLocation, Color.White);
        }
    }
}