namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingGoriyaState : IEnemyState
    {
        private readonly Goriya goriya;
        private readonly ISprite sprite;
        private readonly IProjectile boomerangSprite;
        private int coolDown;
        private EntityManager entity;

        public AttackingGoriyaState(Goriya goriya)
        {
            coolDown = 0;
            this.goriya = goriya;
            this.entity = LoZGame.Instance.Entities;
            switch (goriya.Direction)
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

        public void MoveLeft()
        {
            this.goriya.CurrentState = new LeftMovingGoriyaState(this.goriya);
        }

        public void MoveRight()
        {
            this.goriya.CurrentState = new RightMovingGoriyaState(this.goriya);
        }

        public void MoveUp()
        {
            this.goriya.CurrentState = new UpMovingGoriyaState(this.goriya);
        }

        public void MoveDown()
        {
            this.goriya.CurrentState = new DownMovingGoriyaState(this.goriya);
        }

        public void MoveUpLeft()
        {
        }

        public void MoveUpRight()
        {
        }

        public void MoveDownLeft()
        {
        }

        public void MoveDownRight()
        {
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }

        public void TakeDamage(int damageAmount)
        {
            this.goriya.Health.DamageHealth(damageAmount);
        }

        public void Die()
        {
            this.goriya.CurrentState = new DeadGoriyaState(this.goriya);
        }

        public void Update()
        {
            if (this.coolDown == 0)
            {
                this.coolDown = 240;
                this.entity.EnemyProjectileManager.AddEnemyRang(this.goriya);
            }
            this.sprite.Update();
        }

        public void Draw()
        {
            this.sprite.Draw(this.goriya.Physics.Location, LoZGame.Instance.DungeonTint);
        }
    }
}