namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class RedDarknut : EnemyEssentials, IEnemy
    {
        public RedDarknut(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DarknutStateList);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.RedDarknutHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DarknutMass;
            this.CurrentState = new SpawnEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.RedDarknutDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.DarknutSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.Darknut;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplyLargeWeightModPos();
            this.ApplySmallHealthMod();
        }

        public override void Stun(int stunTime)
        {
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IBlock)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IBlock)otherCollider, collisionSide);
            }
            else if (otherCollider is IProjectile && !Blocked(otherCollider))
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IProjectile)otherCollider, collisionSide);
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateRedDarknutSprite(this.Physics.CurrentDirection);
        }

        private bool Blocked(ICollider otherCollider)
        {
            bool blocked = false;

            if (this.Physics.CurrentDirection == Physics.Direction.North && otherCollider.Physics.CurrentDirection == Physics.Direction.South)
            {
                blocked = true;
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.South && otherCollider.Physics.CurrentDirection == Physics.Direction.North)
            {
                blocked = true;
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.West && otherCollider.Physics.CurrentDirection == Physics.Direction.East)
            {
                blocked = true;
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.East && otherCollider.Physics.CurrentDirection == Physics.Direction.West)
            {
                blocked = true;
            }
            return blocked;
        }
    }
}