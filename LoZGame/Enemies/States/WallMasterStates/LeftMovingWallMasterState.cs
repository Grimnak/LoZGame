using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class LeftMovingWallMasterState : IEnemyState
    {
        private WallMaster wallMaster;
        private IWallMasterSprite sprite;

        public LeftMovingWallMasterState(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            sprite = EnemySpriteFactory.Instance.createLeftMovingWallMasterSprite();
        }
        public void moveLeft()
        {
            // Blank b/c already moving left
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

        public void attack()
        {
        }

        public void Update()
        {
            wallMaster.currentLocation = new Vector2(wallMaster.currentLocation.X - 3, wallMaster.currentLocation.Y);
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, wallMaster.currentLocation, Color.White);
        }
    }
}
