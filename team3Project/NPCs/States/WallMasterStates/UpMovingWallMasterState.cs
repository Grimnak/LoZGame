using System;

namespace LoZCloe
{
    public class UpMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private WallMasterSprite sprite;
        
        public UpMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createUpMovingWallMasterSprite();
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
                wallMaster.die();
            }
        }
        public void die()
        {

        }

        public void update()
        {
            wallMaster.location = new Vector(wallMaster.location.X, wallMaster.location.Y-3);
            sprite.update();
        }
    }
}
