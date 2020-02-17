﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingKeeseState : IKeeseState
    {
        private Keese keese;
        private IKeeseSprite sprite;

        public DownMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createKeeseSprite();
        }

        public void moveLeft()
        {
            keese.CurrentState = new LeftMovingKeeseState(keese);
        }
        public void moveRight()
        {
            keese.CurrentState = new RightMovingKeeseState(keese);
        }
        public void moveUp()
        {
            keese.CurrentState = new UpMovingKeeseState(keese);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }
        public void moveUpLeft()
        {
            keese.CurrentState = new UpLeftMovingKeeseState(keese);
        }
        public void moveUpRight()
        {
            keese.CurrentState = new UpRightMovingKeeseState(keese);
        }
        public void moveDownLeft()
        {
            keese.CurrentState = new DownLeftMovingKeeseState(keese);
        }
        public void moveDownRight()
        {
            keese.CurrentState = new DownRightMovingKeeseState(keese);
        }

        public void takeDamage()
        {
            this.keese.Health--;
            if (this.keese.Health-- == 0)
            {
                keese.CurrentState.die();
            }
        }
        public void die()
        {
            keese.CurrentState = new DeadKeeseState(keese);
        }
        
        public void attack() 
        {
        }

        public void Update()
        {
            keese.currentLocation = new Vector2(keese.currentLocation.X, keese.currentLocation.Y + 2);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, keese.currentLocation, Color.White);
        }
    }
}
