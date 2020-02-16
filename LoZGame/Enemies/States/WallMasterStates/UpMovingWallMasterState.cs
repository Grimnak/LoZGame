using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class UpMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;
        
        public UpMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.creatLeftWallMasterSprite();
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
            // Blank b/c already moving up
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
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X, wallMaster.currentLocation.Y-3);
            sprite.update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
