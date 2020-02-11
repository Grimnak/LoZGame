using System;

namespace LoZCloe
{
    public class DownMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private WallMasterSprite sprite;

        public DownMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createDownMovingWallMasterSprite();
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
            wallMaster.location = new Vector(wallMaster.location.X, wallMaster.location.Y + 3);
            sprite.update();
        }
    }
}
