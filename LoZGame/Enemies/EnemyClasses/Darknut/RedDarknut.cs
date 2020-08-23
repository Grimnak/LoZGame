namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class RedDarknut : EnemyEssentials, IEnemy
    {
        public RedDarknut(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DarknutStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RedDarknutHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DarknutMass;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.RedDarknutDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DarknutSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Darknut;
            DropTable = GameData.Instance.EnemyDropTables.RedDarknutDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplySmallHealthMod();
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
            else if (otherCollider is IProjectile && !Blocked(collisionSide))
            {
                EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateRedDarknutSprite(Physics.CurrentDirection);
        }

        private bool Blocked(CollisionDetection.CollisionSide collisionSide)
        {
            bool blocked = false;

            if (Physics.CurrentDirection == Physics.Direction.North && collisionSide == CollisionDetection.CollisionSide.Top)
            {
                blocked = true;
            }
            else if (Physics.CurrentDirection == Physics.Direction.South && collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                blocked = true;
            }
            else if (Physics.CurrentDirection == Physics.Direction.West && collisionSide == CollisionDetection.CollisionSide.Left)
            {
                blocked = true;
            }
            else if (Physics.CurrentDirection == Physics.Direction.East && collisionSide == CollisionDetection.CollisionSide.Right)
            {
                blocked = true;
            }

            return blocked;
        }
    }
}