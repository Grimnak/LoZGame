using System;

namespace LoZCloe
{
    public class UpMovingWallMasterState : IEnemyState
    {
        private WallMasterSprite wallMaster;
        public UpMovingWallMasterState(WallMasterSprite wallMasterSprite)
        {
            this.wallMaster = wallMasterSprite;
            EnemySpriteFactory.Instance.createUpMovingWallMasterSprite();
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
            // Blank b/c already moving up
        }
        public void moveDown()
        {
            wallMaster.state = new DownMovingWallMasterState(wallMaster);
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
            wallMaster.moveUp();
            wallMaster.update();
        }
    }
}
