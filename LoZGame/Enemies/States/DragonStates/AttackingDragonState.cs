namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDragonState : IDragonState
    {
        private readonly Dragon dragon;
        private readonly IDragonSprite sprite;
        private const int FireBallScale = 2;

        public AttackingDragonState(Dragon dragon)
        {
            this.dragon = dragon;
            this.sprite = EnemySpriteFactory.Instance.CreateDragonSprite();
            this.dragon.EntityManager.EnemyProjectileManager.AddFireballs(this.dragon, FireBallScale);
        }

        public void MoveLeft()
        {
            this.dragon.CurrentState = new LeftMovingDragonState(this.dragon);
        }

        public void MoveRight()
        {
            this.dragon.CurrentState = new RightMovingDragonState(this.dragon);
        }

        public void Stop()
        {
            this.dragon.CurrentState = new IdleDragonState(this.dragon);
        }

        public void Attack()
        {
            // Blank b/c already attacking
        }

        public void TakeDamage()
        {
            this.dragon.Health--;
            if (this.dragon.Health == 0)
            {
                this.dragon.CurrentState.Die();
            }
        }

        public void Die()
        {
            this.dragon.CurrentState = new DeadDragonState(this.dragon);
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.sprite.Draw(sb, this.dragon.CurrentLocation, Color.White);
        }
    }
}