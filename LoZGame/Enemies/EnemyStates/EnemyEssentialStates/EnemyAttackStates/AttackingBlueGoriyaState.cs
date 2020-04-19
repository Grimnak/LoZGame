namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class AttackingBlueGoriyaState : EnemyStateEssentials, IEnemyState
    {
        public AttackingBlueGoriyaState(IEnemy enemy)
        {
            this.Enemy = enemy;
            this.DirectionChange = GameData.Instance.EnemyMiscConstants.DirectionChange;
            FacePlayer();
            this.Sprite = this.Enemy.CreateCorrectSprite();
            this.Enemy.Physics.MovementVelocity = Vector2.Zero;
            LoZGame.Instance.GameObjects.Entities.EnemyProjectileManager.Add(new MagicBoomerangProjectile(this.Enemy.Physics));
        }

        private void FacePlayer()
        {
            Point playerLoc = LoZGame.Instance.Players[0].Physics.Bounds.Center - this.Enemy.Physics.Bounds.Center;
            if (Math.Abs(playerLoc.X) > Math.Abs(playerLoc.Y))
            {
                if (playerLoc.X < 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.West;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.East;
                }
            }
            else
            {
                if (playerLoc.Y < 0)
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.North;
                }
                else
                {
                    this.Enemy.Physics.CurrentDirection = Physics.Direction.South;
                }
            }
        }
    }
}