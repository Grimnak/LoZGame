namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DeadEnemyState : EnemyStateEssentials, IEnemyState
    {
        private int deathTimer = 0;
        private int deathTimerMax;

        public DeadEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
            Enemy.IsDead = true;
            Sprite = EnemySpriteFactory.Instance.CreateDeadEnemySprite();
            Enemy.CurrentState = this;
            Enemy.Physics.Bounds = new Rectangle(Enemy.Physics.Bounds.Location, Point.Zero);
            deathTimerMax = GameData.Instance.EnemyMiscConstants.DeathTimerMaximum;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
            deathTimer++;
            Sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                LoZGame.Instance.Drops.AttemptDrop(Enemy.Physics.Location, LoZGame.Instance.Drops.DropChance, Enemy.DropTable);
                Enemy.Expired = true;
            }
        }

        public override void Die()
        {
        }

        public override void Stun(int stunTime)
        {
        }
    }
}
