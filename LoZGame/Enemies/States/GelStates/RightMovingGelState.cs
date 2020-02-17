﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class RightMovingGelState : IEnemyState
    {
        private Gel gel;
        private IGelSprite sprite;

        public RightMovingGelState(Gel gel)
        {
            this.gel = gel;
            sprite = EnemySpriteFactory.Instance.createGelSprite();
        }
        public void moveLeft()
        {
            gel.CurrentState = new LeftMovingGelState(gel);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            gel.CurrentState = new UpMovingGelState(gel);
        }
        public void moveDown()
        {
            gel.CurrentState = new DownMovingGelState(gel);
        }

        public void takeDamage()
        {
            this.gel.Health--;
            if (this.gel.Health == 0)
            {
                gel.CurrentState.die();
            }
        }

        public void die()
        {
            gel.CurrentState = new DeadGelState(gel);
        }

        public void Update()
        {
            gel.currentLocation = new Vector2(gel.currentLocation.X + 1, gel.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, gel.currentLocation, Color.White);
        }
    }
}