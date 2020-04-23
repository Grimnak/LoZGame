namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Dodongo : EnemyEssentials, IEnemy
    {
        public Dodongo(Vector2 location)
        {
            RandomStateGenerator = new RandomStateGenerator(this);
            States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.EnemyStateWeights.DodongoStateList);
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.DodongoHealth);
            Physics = new Physics(location);
            Physics.Mass = GameData.Instance.EnemyMassConstants.DodongoMass;
            Physics.IsMoveable = false;
            CurrentState = new SpawnEnemyState(this);
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            Expired = false;
            Damage = GameData.Instance.EnemyDamageConstants.DodongoDamage;
            DamageTimer = 0;
            MoveSpeed = GameData.Instance.EnemySpeedConstants.DodongoSpeed;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.Dodongo;
            DropTable = GameData.Instance.EnemyDropTables.DodongoDropTable;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
            ApplyLargeHealthMod();
        }

        public override void Attack()
        {
            CurrentState = new AttackingDodongoState(this);
        }

        public override void Stun(int stunTime)
        {
            CurrentState = new StunnedDodongoState(this);
        }

        public override ISprite CreateCorrectSprite()
        {
            switch (Physics.CurrentDirection)
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