using System;
using Microsoft.Xna.Framework;

namespace LoZClone
{
    public class DeadWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public DeadWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createDeadWallMasterSprite();
        }
        public void moveLeft()
        {
            wallMaster.CurrentState = new LeftMovingWallMasterState(wallMaster);
        }
        public void moveRight()
        {
            wallMaster.CurrentState = new RightMovingWallMasterState(wallMaster);
        }
        public void moveUp()
        {
            wallMaster.CurrentState = new UpMovingWallMasterState(wallMaster);
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
                wallMaster.CurrentState.die();
            }
        }
        public void die()
        {

        }

        public void Update()
        {
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X, wallMaster.currentLocation.Y + 3);
            sprite.Update();
        }

        public void draw(SpriteBatch sb)
        {
            sprite.draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
