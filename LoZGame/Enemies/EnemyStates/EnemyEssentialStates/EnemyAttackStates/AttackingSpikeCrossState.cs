namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class AttackingSpikeCrossState : EnemyStateEssentials, IEnemyState
    {
        private readonly IEnemy enemy;
        private readonly ISprite sprite;
        private float attackSpeed;
        private Point startPoint;
        private Point stopPoint;
        private bool returning;

        public AttackingSpikeCrossState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.startPoint = this.Enemy.Physics.Bounds.Location;
            this.stopPoint = new Point(LoZGame.Instance.ScreenWidth / 2, LoZGame.Instance.InventoryOffset + ((LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset) / 2));
            this.returning = false;
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.CurrentState = this;
            if (LoZGame.Instance.Difficulty > 0)
            {
                this.attackSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed ;
            }
            else
            {
                this.attackSpeed = GameData.Instance.EnemySpeedConstants.DodongoAttackSpeed;
            }
            SetAttackVelocity();
        }

        private void SetAttackVelocity() 
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

        public override void Update()
        {
            if (!this.returning)
            {
                switch (this.Enemy.Physics.CurrentDirection)
                {
                    case Physics.Direction.North:
                        if (this.Enemy.Physics.Bounds.Top < stopPoint.Y)
                        {
                            this.returning = true;
                        }
                        break;
                    case Physics.Direction.South:
                        if (this.Enemy.Physics.Bounds.Bottom > stopPoint.Y)
                        {
                            this.returning = true;
                        }
                        break;
                    case Physics.Direction.East:
                        if (this.Enemy.Physics.Bounds.Right > stopPoint.X)
                        {
                            this.returning = true;
                        }
                        break;
                    case Physics.Direction.West:
                        if (this.Enemy.Physics.Bounds.Left < stopPoint.X)
                        {
                            this.returning = true;
                        }
                        break;
                }
                if (returning)
                {
                    Vector2 toStart = (this.startPoint - this.Enemy.Physics.Bounds.Location).ToVector2();
                    toStart.Normalize();
                    this.Enemy.Physics.MovementVelocity = toStart * (this.Enemy.Physics.MovementVelocity.Length() / 2);
                }
            }
            else
            {
                if (this.Enemy.Physics.Bounds.Location == startPoint)
                {
                    this.Enemy.CurrentState.Stop();
                }
            }
        }
    }
}