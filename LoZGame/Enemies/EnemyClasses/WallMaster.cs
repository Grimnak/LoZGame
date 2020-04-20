namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class WallMaster : EnemyEssentials, IEnemy
    {
        public WallMaster(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.WallMasterStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.WallMasterHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.WallMasterMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.WallMasterDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.WallMasterSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.WallMaster;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplyLargeWeightModPos();
            this.ApplySmallHealthMod();
        }

        public override void Update()
        {
            base.Update();
            if (this.CurrentState is AttackingWallMasterState)
            {
                this.Physics.Depth = 1.0f;
            }
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingWallMasterState(this);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer && !(((Link)otherCollider).State is PickupItemState))
            {
                this.CurrentState.Attack();
                this.Physics.MovementVelocity = new Vector2(-2, 0);
            }
            else if (otherCollider is IBlock && !(this.CurrentState is AttackingWallMasterState))
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile && !(this.CurrentState is AttackingWallMasterState))
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.Physics.CurrentDirection == Physics.Direction.North || this.Physics.CurrentDirection == Physics.Direction.East)
            {
                return EnemySpriteFactory.Instance.CreateRightMovingWallMasterSprite();
            } 
            else
            {
                return EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            }
        }
    }
}