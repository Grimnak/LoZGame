using System;

namespace LoZCloe
{
    public class RightMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private WallMasterSprite sprite;

        public RightMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createRightMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            wallMaster.state = new LeftMovingWallMasterState(wallMaster);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
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
            wallMaster.location = new Vector(wallMaster.location.X + 3, wallMaster.location.Y);
            sprite.update();
        }
    }
}
