using System;

namespace LoZCloe
{
    public class DownMovingWallMasterState : IEnemyState
    {
        private WallMasterSprite wallMaster;
        public DownMovingWallMasterState(WallMasterSprite wallMasterSprite)
        {
            this.wallMaster = wallMasterSprite;
            EnemySpriteFactory.Instance.createDownMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            wallMaster.state = new LeftMovingWallMasterState(wallMaster);
        }
        public void moveRight()
        {
            wallMaster.state = new RightMovingWallMasterState(wallMaster);
        }
        public void moveUp()
        {
            wallMaster.state = new UpMovingWallMasterState(wallMaster);
        }
        public void moveDown()
        {
            // Blank b/c already moving down
        }

        public void takeDamage()
        {
            this.wallMaster.health--;
            if (this.wallMaster.health-- == 0)
            {
                wallMaster.state.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            wallMaster.moveDown();
            wallMaster.update();
        }
    }
}
