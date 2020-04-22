namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Rope : EnemyEssentials, IEnemy
    {
        public Rope(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.RopeStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RopeHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.RopeMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.RopeDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.RopeSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Rope;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModNeg();
            ApplySmallHealthMod();
        }

        public override void Attack()
        {
            CurrentState = new AttackingRopeState(this);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            UpdateState();
            base.OnCollisionResponse(otherCollider, collisionSide);
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            UpdateState();
            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public override ISprite CreateCorrectSprite()
        {
            if (Physics.CurrentDirection.Equals(Physics.Direction.North) || Physics.CurrentDirection.Equals(Physics.Direction.East))
            {
                return EnemySpriteFactory.Instance.CreateRightMovingRopeSprite();
            }
            else
            {
                return EnemySpriteFactory.Instance.CreateLeftMovingRopeSprite();
            }
        }
    }
}