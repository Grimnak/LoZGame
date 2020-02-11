﻿using System;

namespace LoZCloe
{
    public class LeftMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private KeeseSprite sprite;
        public LeftMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            sprite = EnemySpriteFactory.Instance.createLeftMovingKeeseSprite();
        }

        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            keese.state = new RightMovingKeeseState(keese);
        }
        public void moveUp()
        {
            keese.state = new UpMovingKeeseState(keese);
        }
        public void moveDown()
        {
            keese.state = new DownMovingKeeseState(keese);
        }
        public void moveUpLeft()
        {
            keese.state = new UpLeftMovingKeeseState(keese);
        }
        public void moveUpRight()
        {
            keese.state = new UpRightMovingKeeseState(keese);
        }
        public void moveDownLeft()
        {
            keese.state = new DownLeftMovingKeeseState(keese);
        }
        public void moveDownRight()
        {
            keese.state = new DownRightMovingKeeseState(keese);
        }

        public void takeDamage()
        {
            this.keese.health--;
            if (this.keese.health-- == 0)
            {
                keese.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            keese.location = new Vector(keese.location.X - 3, keese.location.Y);
            sprite.update();
        }
    }
}