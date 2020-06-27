namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class WallMaster : EnemyEssentials, IEnemy
    {
        public int Timer { get; set; }

        public WallMaster(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.WallMasterStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.WallMasterHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.WallMasterMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.WallMasterDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.WallMasterSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.WallMaster;
            DropTable = GameData.Instance.EnemyDropTables.WallMasterDropTable;
            Timer = 0;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Update()
        {
            base.Update();
            if (CurrentState is AttackingWallMasterState)
            {
                Physics.Depth = 1.0f;
            }
        }

        public override void Attack()
        {
            CurrentState = new AttackingWallMasterState(this);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer && !(((Link)otherCollider).State is PickupItemState || CurrentState is StunnedEnemyState) && ((IPlayer)otherCollider).Inventory.ClockLockout <= 0)
            {
                CurrentState.Attack();
            }
            else if (otherCollider is IBlock && !(CurrentState is AttackingWallMasterState))
            {
                EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile && /*!(CurrentState is AttackingWallMasterState)*/Timer <= 100)
            {
                EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            if (Physics.CurrentDirection == Physics.Direction.North || Physics.CurrentDirection == Physics.Direction.East)
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