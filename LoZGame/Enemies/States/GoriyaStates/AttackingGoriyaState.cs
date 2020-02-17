using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class AttackingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private IGoriyaSprite sprite;

        public AttackingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
             switch (goriya.direction)
             {
                case "left":
                    sprite = EnemySpriteFactory.Instance.createLeftMovingGoriyaSprite();
                    break;
                case "right":
                    sprite = EnemySpriteFactory.Instance.createRightMovingGoriyaSprite();
                    break;
                case "up":
                    sprite = EnemySpriteFactory.Instance.createUpMovingGoriyaSprite();
                    break;
                case "down":
                    sprite = EnemySpriteFactory.Instance.createDownMovingGoriyaSprite();
                    break;
                default:
                    break;
             }
           
        }
        public void moveLeft()
        {
            goriya.CurrentState = new LeftMovingGoriyaState(goriya);
        }
        public void moveRight()
        {
            goriya.CurrentState = new RightMovingGoriyaState(goriya);
        }
        public void moveUp()
        {
            goriya.CurrentState = new UpMovingGoriyaState(goriya);
        }
        public void moveDown()
        {
            goriya.CurrentState = new DownMovingGoriyaState(goriya);
        }
        public void attack()
        {
            //Blank b/c already attacking
        }

        public void takeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health-- == 0)
            {
                goriya.CurrentState.die();
            }
        }
        public void die()
        {
            goriya.CurrentState = new DeadGoriyaState(goriya);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, goriya.currentLocation, Color.White);
        }
    }
}
