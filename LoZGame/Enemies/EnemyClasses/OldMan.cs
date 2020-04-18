namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class OldMan : EnemyEssentials, IEnemy
    {
        private const int BreakingPoint = 25;
        private const float FireballSpeed = 2.5f;
        private readonly ISprite sprite;
        private Vector2 FlameOneLoc;
        private Vector2 FlameTwoLoc;
        private int timesShot;

        public EntityManager EntityManager { get; set; }

        public OldMan(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.FlameOneLoc = new Vector2(location.X - 100, location.Y + 20);
            this.FlameTwoLoc = new Vector2(location.X + 160, location.Y + 20);
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.OldManStateList);
            this.CurrentState = new SpawnOldManState(this);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.OldManHealth);
            this.Expired = false;
            this.IsDead = false;
            this.IsSpawning = true;
            this.Damage = GameData.Instance.EnemyDamageConstants.OldManDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.OldManSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.timesShot = 0;
        }

        private Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public void ShootFireballs()
        {
            Console.WriteLine("Called Old Man's ShootFireball().");
            this.timesShot++;
            if (timesShot > BreakingPoint)
            {
                this.CurrentState = new OldManSecretState(this);
                this.timesShot = 0;
            }
            else if (!(this.CurrentState is OldManSecretState))
            {
                this.CurrentState = new OldManAngryState(this);
                Vector2 playerVectorOne = this.UnitVectorToPlayer(this.FlameOneLoc);
                Vector2 playerVectorTwo = this.UnitVectorToPlayer(this.FlameTwoLoc);
                Vector2 velocityVectorOne = new Vector2(playerVectorOne.X * FireballSpeed, playerVectorOne.Y * FireballSpeed);
                Vector2 velocityVectorTwo = new Vector2(playerVectorTwo.X * FireballSpeed, playerVectorTwo.Y * FireballSpeed);
                Physics fireballOnePhysics = new Physics(new Vector2(FlameOneLoc.X, FlameOneLoc.Y));
                fireballOnePhysics.MovementVelocity = velocityVectorOne;
                Physics fireballTwoPhysics = new Physics(new Vector2(FlameTwoLoc.X, FlameTwoLoc.Y));
                fireballTwoPhysics.MovementVelocity = velocityVectorTwo;
                EntityManager.EnemyProjectileManager.Add(new FireballProjectile(fireballOnePhysics));
                EntityManager.EnemyProjectileManager.Add(new FireballProjectile(fireballTwoPhysics));
                Console.WriteLine("Spawned Old Man's fireballs.");
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            this.Physics.SetDepth();
            this.CurrentState.Update();
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.CurrentState is OldManIdleState)
            {
                return EnemySpriteFactory.Instance.CreateOldManSprite();
            }
            return EnemySpriteFactory.Instance.CreateAngryOldManSprite();
        }
    }
}