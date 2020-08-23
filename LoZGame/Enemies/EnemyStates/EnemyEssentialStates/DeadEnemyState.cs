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
            if (this.Sprite.CurrentFrame != this.Sprite.TotalFrames - 1)
                Sprite.Update();
            if (deathTimer >= deathTimerMax)
            {
                LoZGame.Instance.Drops.AttemptDrop(Enemy.Physics.Location, LoZGame.Instance.Drops.DropChance, Enemy.DropTable);
                AttemptHealthDrop();
                Enemy.Expired = true;
            }
        }

        private void AttemptHealthDrop()
        {
            float health = 0;
            float maxhealth = 0;
            foreach (IPlayer player in LoZGame.Instance.Players)
            {
                health += player.Health.CurrentHealth;
                maxhealth += player.Health.MaxHealth;
            }

            // use of 100 is not a magic number as it represents a percentage.
            float dropChance = 50 - (50 * health / maxhealth);
            if (dropChance < GameData.Instance.InventoryConstants.MinHealthChance)
            {
                dropChance = GameData.Instance.InventoryConstants.MinHealthChance;
            }
            else if (dropChance > GameData.Instance.InventoryConstants.MaxHealthChance)
            {
                dropChance = GameData.Instance.InventoryConstants.MaxHealthChance;
            }
            if (LoZGame.Instance.Random.Next(100) < dropChance)
            {
                LoZGame.Instance.GameObjects.Items.Add(new DroppedHealth(Enemy.Physics.Bounds.Center.ToVector2()));
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
