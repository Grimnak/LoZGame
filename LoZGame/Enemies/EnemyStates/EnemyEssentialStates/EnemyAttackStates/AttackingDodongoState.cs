﻿namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AttackingDodongoState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private RandomStateGenerator randomStateGenerator;
        private float attackSpeed;

        public AttackingDodongoState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange * 2;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            if (LoZGame.Instance.Difficulty > 0)
            {
                this.attackSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeMoveMod);
            } 
            else
            {
                this.attackSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed + (LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.SmallMoveMod);
            }
            if (this.attackSpeed < 1)
            {
                this.attackSpeed = 1;
            }
            GetMoveSpeed();
        }

        private void GetMoveSpeed()
        {
            switch (this.Enemy.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, -this.attackSpeed);
                    break;
                case Physics.Direction.South:
                    this.Enemy.Physics.MovementVelocity = new Vector2(0, this.attackSpeed);
                    break;
                case Physics.Direction.East:
                    this.Enemy.Physics.MovementVelocity = new Vector2(this.attackSpeed, 0);
                    break;
                case Physics.Direction.West:
                    this.Enemy.Physics.MovementVelocity = new Vector2(-this.attackSpeed, 0);
                    break;
                default:
                    this.Enemy.UpdateState();
                    break;
            }
        }
    }
}