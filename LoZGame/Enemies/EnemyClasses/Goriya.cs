namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;

    public class Goriya : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }

        public Goriya(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = GameData.Instance.DefaultEnemyStates.GoriyaStatelist;
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.GoriyaHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.GoriyaMass;
            this.CurrentState = new LeftMovingGoriyaState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.GoriyaDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.GoriyaSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override ISprite CreateCorrectSprite()
        {
            switch (this.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    return EnemySpriteFactory.Instance.CreateUpMovingGoriyaSprite();
                case Physics.Direction.West:
                    return EnemySpriteFactory.Instance.CreateLeftMovingGoriyaSprite();
                case Physics.Direction.South:
                    return EnemySpriteFactory.Instance.CreateDownMovingGoriyaSprite();
                default:
                    return EnemySpriteFactory.Instance.CreateRightMovingGoriyaSprite();
            }
        }
    }
}
