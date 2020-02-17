using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private DeadEnemySprite sprite;

        public DeadWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createDeadEnemySprite();
        }
        public void moveLeft()
        {
        }
        public void moveRight()
        {
        }
        public void moveUp()
        {
        }
        public void moveDown()
        {
        }

        public void takeDamage()
        {
        }
        public void die()
        {
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
