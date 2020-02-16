using System;
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
            spikeCross.CurrentState = new RightMovingSpikeCrossState(spikeCross);
        }
        public void moveUp()
        {
            spikeCross.CurrentState = new UpMovingSpikeCrossState(spikeCross);
        }
        public void moveDown()
        {
            spikeCross.CurrentState = new DownMovingSpikeCrossState(spikeCross);
        }
        public void stop()
        {
            spikeCross.CurrentState = new IdleSpikeCrossState(spikeCross);
        }

        public void takeDamage()
        {
          
        }
        public void die()
        {

        }

        public void Update()
        {
            spikeCross.currentLocation = new Vector2(spikeCross.currentLocation.X - 3, spikeCross.currentLocation.Y);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
