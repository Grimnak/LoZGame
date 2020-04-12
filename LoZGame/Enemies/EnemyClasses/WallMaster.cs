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
            this.States = new Dictionary<RandomStateGenerator.StateType, int>(GameData.Instance.DefaultEnemyStates.WallMasterStatelist);
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.WallMasterHealth);
            this.Physics = new Physics(location);
            this.Physics.Mass = GameData.Instance.EnemyMassData.WallMasterMass;
            this.CurrentState = new LeftMovingWallMasterState(this);
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.WallMasterDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.WallMasterSpeed;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public override void Update()
        {
            base.Update();
            if (this.CurrentState is AttackingWallMasterState)
            {
                this.Physics.Depth = 1.0f;
            }
        }

        public override ISprite CreateCorrectSprite()
        {
            if (this.Physics.CurrentDirection == Physics.Direction.North || this.Physics.CurrentDirection == Physics.Direction.East)
            {
                return EnemySpriteFactory.Instance.CreateRightMovingWallMasterSprite();
            } else
            {
                return EnemySpriteFactory.Instance.CreateLeftMovingWallMasterSprite();
            }
        }
    }
}