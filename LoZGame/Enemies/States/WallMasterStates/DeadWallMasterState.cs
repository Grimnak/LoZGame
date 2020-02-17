using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DeadWallMasterState : IEnemyState
    {
        private readonly WallMaster wallMaster;
        private readonly DeadEnemySprite sprite;

        public DeadWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
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
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.wallMaster.currentLocation, Color.White);
        }
    }
}
