using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DownMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public DownMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createRightWallMasterSprite();
        }
        public void moveLeft()
        {
            wallMaster.currentState = new LeftMovingWallMasterState(wallMaster);
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
            // Blank b/c already moving down
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
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X, wallMaster.currentLocation.Y + 3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
