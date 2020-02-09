using System;

namespace LoZCloe
{
    public class LeftMovingWallMasterState : IEnemyState
    {
        private WallMasterSprite wallMaster;
        public LeftMovingWallMasterState(WallMasterSprite wallMasterSprite)
        {
            this.wallMaster = wallMasterSprite;
            EnemySpriteFactory.Instance.createLeftMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
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
            wallMaster.moveLeft();
            wallMaster.update();
        }
    }
}
