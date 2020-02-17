using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class DownMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public DownMovingWallMasterState(WallMaster wallMaster)
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
            wallMaster.CurrentState = new DeadWallMasterState(wallMaster);
        }

        public void attack()
        {
        }

        public void Update()
        {
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X, wallMaster.currentLocation.Y + 3);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
