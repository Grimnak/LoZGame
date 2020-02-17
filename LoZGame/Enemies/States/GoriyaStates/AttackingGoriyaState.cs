using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{
    public class AttackingGoriyaState : IGoriyaState
    {
        private readonly Goriya goriya;
        private readonly IGoriyaSprite sprite;
        private IProjectile boomerangSprite;
        public AttackingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            switch (goriya.direction)
             {
                case "Left":
                    this.sprite = EnemySpriteFactory.Instance.CreateLeftMovingGoriyaSprite();
                    break;
                case "Right":
                    this.sprite = EnemySpriteFactory.Instance.CreateRightMovingGoriyaSprite();
                    break;
                case "Up":
                    this.sprite = EnemySpriteFactory.Instance.CreateUpMovingGoriyaSprite();
                    break;
                case "Down":
                    this.sprite = EnemySpriteFactory.Instance.CreateDownMovingGoriyaSprite();
                    break;
                default:
                    break;
             }
        }

        public void moveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void moveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void moveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void moveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void attack()
        {
            // Blank b/c already attacking
        }

        public void takeDamage()
        {
            this.goriya.Health--;
            if (this.goriya.Health == 0)
            {
                this.goriya.CurrentState.die();
            }
        }

        public void die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.goriya.currentLocation, Color.White);
        }
    }
}
