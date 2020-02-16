using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingSpikeCrossState : IEnemyState
    {
        private SpikeCross spikeCross;
        private ISpikeCrossSprite sprite;

        public DownMovingSpikeCrossState(SpikeCross spikeCross)
        {
            this.spikeCross = spikeCross;
            sprite = EnemySpriteFactory.Instance.createDownMovingSpikeCrossSprite();
        }
        public void moveLeft()
        {
            spikeCross.CurrentState = new LeftMovingSpikeCrossState(spikeCross);
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
            // Blank b/c already moving down
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
            spikeCross.currentLocation = new Vector2(spikeCross.currentLocation.X, spikeCross.currentLocation.Y + 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, spikeCross.currentLocation, Color.White);
        }
    }
}
