namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public class RedGohma : EnemyEssentials, IEnemy
    {
        public RedGohma(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.GohmaStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RedGohmaHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.GohmaMass;
            CurrentState = new CloseEyeState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsSpawning = false;
            Damage = GameData.Instance.EnemyDamageConstants.GohmaDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.GohmaSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Gohma;
            DropTable = GameData.Instance.EnemyDropTables.GohmaDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
            ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            CurrentState = new AttackingGohmaState(this);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile && CurrentState is OpenEyeState)
            {
                EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            if (CurrentState is OpenEyeState)
            {
                Console.WriteLine("Drawing OpenEye Sprite now.");
                return EnemySpriteFactory.Instance.CreateRedGohmaOpenEye();
            }
            else
            {
                Console.WriteLine("Drawing ClosedEye Sprite now.");
                return EnemySpriteFactory.Instance.CreateRedGohmaClosedEye();
            }
        }
    }
}
