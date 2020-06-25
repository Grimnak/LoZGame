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
        private Point flameOffset;
        private int timesShot;

        public OldMan(Vector2 location)
        {
            Physics = new Physics(location);
            flameOffset = new Point(130, 0);
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.OldManStateList);
            CurrentState = new IdleEnemyState(this);
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.OldManHealth);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.OldManDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.OldManSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            timesShot = 0;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            IsKillable = false;
        }

        private Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            CurrentState = new NPCSecretState(this);
        }

        public void ShootFireballs()
        {
            timesShot++;
            if (timesShot > BreakingPoint)
            {
                CurrentState = new NPCSecretState(this);
                timesShot = 0;
            }
            else if (!(CurrentState is NPCSecretState))
            {
                CurrentState = new NPCAngryState(this);
                Vector2 playerVectorOne = UnitVectorToPlayer((Physics.Bounds.Center - flameOffset).ToVector2());
                Vector2 playerVectorTwo = UnitVectorToPlayer((Physics.Bounds.Center + flameOffset).ToVector2());
                Vector2 velocityVectorOne = new Vector2(playerVectorOne.X * FireballSpeed, playerVectorOne.Y * FireballSpeed);
                Vector2 velocityVectorTwo = new Vector2(playerVectorTwo.X * FireballSpeed, playerVectorTwo.Y * FireballSpeed);
                Physics fireballOnePhysics = new Physics((Physics.Bounds.Center - flameOffset).ToVector2());
                fireballOnePhysics.MovementVelocity = velocityVectorOne;
                Physics fireballTwoPhysics = new Physics((Physics.Bounds.Center + flameOffset).ToVector2());
                fireballTwoPhysics.MovementVelocity = velocityVectorTwo;
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballOnePhysics));
                LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new FireballProjectile(fireballTwoPhysics));
            }
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            Physics.SetDepth();
            CurrentState.Update();
        }

        public override ISprite CreateCorrectSprite()
        {
            if (CurrentState is IdleEnemyState)
            {
                return EnemySpriteFactory.Instance.CreateOldManSprite();
            }
            return EnemySpriteFactory.Instance.CreateAngryOldManSprite();
        }
    }
}