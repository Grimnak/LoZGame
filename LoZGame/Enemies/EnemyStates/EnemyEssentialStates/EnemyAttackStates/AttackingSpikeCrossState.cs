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
        private Point stopPoint;
        private bool returning;

        public AttackingSpikeCrossState(IEnemy enemy)
        {
            Enemy = enemy;
            stopPoint = new Point(LoZGame.Instance.ScreenWidth / 2, LoZGame.Instance.InventoryOffset + ((LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset) / 2));
            returning = false;
            Sprite = Enemy.CreateCorrectSprite();
            Enemy.CurrentState = this;
            attackSpeed = GameData.Instance.EnemySpeedConstants.RopeAttackSpeed;
            attackSpeed += LoZGame.Instance.Difficulty > 0 ? LoZGame.Instance.Difficulty * GameData.Instance.DifficultyConstants.LargeMoveMod : 0;
            SetAttackVelocity();
        }

        private void SetAttackVelocity() 
        {
            switch (Enemy.Physics.CurrentDirection)
            {
                case Physics.Direction.North:
                    Enemy.Physics.MovementVelocity = new Vector2(0, -attackSpeed);
                    break;
                case Physics.Direction.South:
                    Enemy.Physics.MovementVelocity = new Vector2(0, attackSpeed);
                    break;
                case Physics.Direction.East:
                    Enemy.Physics.MovementVelocity = new Vector2(attackSpeed, 0);
                    break;
                case Physics.Direction.West:
                    Enemy.Physics.MovementVelocity = new Vector2(-attackSpeed, 0);
                    break;
                default:
                    Enemy.UpdateState();
                    break;
            }
        }

        public override void Update()
        {
            if (!returning)
            {
                switch (Enemy.Physics.CurrentDirection)
                {
                    case Physics.Direction.North:
                        if (Enemy.Physics.Bounds.Top < stopPoint.Y)
                        {
                            returning = true;
                        }
                        break;
                    case Physics.Direction.South:
                        if (Enemy.Physics.Bounds.Bottom > stopPoint.Y)
                        {
                            returning = true;
                        }
                        break;
                    case Physics.Direction.East:
                        if (Enemy.Physics.Bounds.Right > stopPoint.X)
                        {
                            returning = true;
                        }
                        break;
                    case Physics.Direction.West:
                        if (Enemy.Physics.Bounds.Left < stopPoint.X)
                        {
                            returning = true;
                        }
                        break;
                }
                if (returning)
                {
                    Vector2 toStart = (Enemy.SpawnPoint - Enemy.Physics.Bounds.Location).ToVector2();
                    toStart.Normalize();
                    Enemy.Physics.MovementVelocity = toStart * (Enemy.Physics.MovementVelocity.Length() / 2);
                }
            }
            else
            {
                if ((Enemy.Physics.Bounds.Location - Enemy.SpawnPoint).ToVector2().Length() <= Enemy.Physics.MovementVelocity.Length())
                {
                    Enemy.Physics.Bounds = new Rectangle(Enemy.SpawnPoint, Enemy.Physics.Bounds.Size);
                    Enemy.CurrentState.Stop();
                }
            }
        }
    }
}