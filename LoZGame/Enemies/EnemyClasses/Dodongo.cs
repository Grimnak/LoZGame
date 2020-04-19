namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        public Dodongo(Vector2 location)
        {
            this.RandomStateGenerator = new RandomStateGenerator(this);
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DodongoStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DodongoHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.DodongoMass;
            this.Physics.IsMoveable = false;
            this.CurrentState = new SpawnEnemyState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.DodongoDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedConstants.DodongoSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.EnemyName = EnemyNames.Dodongo;
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingDodongoState(this);
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState = new StunnedDodongoState(this);
        }

        public override ISprite CreateCorrectSprite()
        {
            switch (this.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    return EnemySpriteFactory.Instance.CreateUpMovingDodongoSprite();
                case Physics.Direction.West:
                    return EnemySpriteFactory.Instance.CreateLeftMovingDodongoSprite();
                case Physics.Direction.South:
                    return EnemySpriteFactory.Instance.CreateDownMovingDodongoSprite();
                default:
                    return EnemySpriteFactory.Instance.CreateRightMovingDodongoSprite();
            }
        }
    }
}