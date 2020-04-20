namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Rope : EnemyEssentials, IEnemy
    {
        public Rope(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.RopeStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RopeHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.RopeMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.RopeDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.RopeSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.Rope;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplySmallWeightModNeg();
            this.ApplySmallHealthMod();
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingRopeState(this);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            this.UpdateState();
            base.OnCollisionResponse(otherCollider, collisionSide);
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.UpdateState();
            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.Physics.CurrentDirection.Equals(Physics.Direction.North) || this.Physics.CurrentDirection.Equals(Physics.Direction.East))
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