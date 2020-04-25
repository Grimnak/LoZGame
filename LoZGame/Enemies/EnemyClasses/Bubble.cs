namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Bubble : EnemyEssentials, IEnemy
    {
        public Bubble(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.BubbleStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.BubbleHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.BubbleMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            IsKillable = false;
            IsTransparent = true;
            Damage = GameData.Instance.EnemyDamageConstants.BubbleDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.BubbleSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Bubble;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            ApplySmallSpeedMod();
            ApplySmallWeightModPos();
        }

        public override void Stun(int stunTime)
        {
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
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateBubbleSprite();
        }
    }
}
