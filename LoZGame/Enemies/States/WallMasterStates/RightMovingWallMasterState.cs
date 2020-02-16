using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class RightMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public RightMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createRightMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            wallMaster.CurrentState = new LeftMovingWallMasterState(wallMaster);
        }
        public void moveRight()
        {
            // Blank b/c already moving right
        }
        public void moveUp()
        {
            wallMaster.CurrentState = new UpMovingWallMasterState(wallMaster);
        }
        public void moveDown()
        {
            wallMaster.CurrentState = new DownMovingWallMasterState(wallMaster);
        }

        public void takeDamage()
        {
            this.wallMaster.Health--;
            if (this.wallMaster.Health-- == 0)
            {
                wallMaster.CurrentState.die();
            }
        }
        public void die()
        {
            wallMaster.CurrentState = new DeadWallMasterState(wallMaster);
        }

        public void Update()
        {
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X + 3, wallMaster.currentLocation.Y);
            sprite.update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
