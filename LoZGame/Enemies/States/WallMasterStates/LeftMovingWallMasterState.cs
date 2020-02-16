using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class LeftMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public LeftMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createLeftMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
        }
        public void moveRight()
        {
            wallMaster.currentState = new RightMovingWallMasterState(wallMaster);
        }
        public void moveUp()
        {
            wallMaster.currentState = new UpMovingWallMasterState(wallMaster);
        }
        public void moveDown()
        {
            wallMaster.currentState = new DownMovingWallMasterState(wallMaster);
        }

        public void takeDamage()
        {
            this.wallMaster.Health--;
            if (this.wallMaster.Health-- == 0)
            {
                wallMaster.currentState.die();
            }
        }
        public void die()
        {
            wallMaster.currentState = new DeadWallMasterState(wallMaster);
        }

        public void update()
        {
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X - 3, wallMaster.currentLocation.Y);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
