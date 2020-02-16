﻿using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private ISpikeCrossSprite sprite;

        public LeftMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createSpikeCrossSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving down
        }
        public void moveRight()
        {
            spikeCross.currentState = new RightMovingSpikeCrossState(spikeCross);
        }
        public void moveUp()
        {
            spikeCross.currentState = new UpMovingSpikeCrossState(spikeCross);
        }
        public void moveDown()
        {
            spikeCross.currentState = new DownMovingSpikeCrossState(spikeCross);
        }
        public void stop()
        {
            spikeCross.currentState = new IdleSpikeCrossState(spikeCross);
        }

        public void takeDamage()
        {
          
        }
        public void die()
        {

        }

        public void update()
        {
            spikeCross.currentLocation = new Vector2(spikeCross.currentLocation.X - 3, spikeCross.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
