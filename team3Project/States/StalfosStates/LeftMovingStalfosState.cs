﻿using System;

namespace LoZCloe
{
    public class LeftMovingStalfosState : IEnemyState
    {
        private StalfosSprite stalfos;
        public LeftMovingStalfosState(StalfosSprite stalfosSprite)
        {
            this.stalfos = stalfosSprite;
            EnemySpriteFactory.Instance.createLeftMovingStalfosSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            stalfos.state = new RightMovingStalfosState(stalfos);
        }
        public void moveUp()
        {
            stalfos.state = new UpMovingStalfosState(stalfos);
        }
        public void moveDown()
        {
            stalfos.state = new DownMovingStalfosState(stalfos);
        }

        public void takeDamage()
        {
            this.stalfos.health--;
            if (this.stalfos.health-- == 0)
            {
                stalfos.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            stalfos.moveLeft();
            stalfos.update();
        }
    }
}
