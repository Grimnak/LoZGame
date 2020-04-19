namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class GelEssentials : EnemyStateEssentials, IEnemyState
    {
        bool isMoving = true;

        public override void Stun(int stunTime)
        {
            this.Enemy.TakeDamage(this.Enemy.Health.MaxHealth);
        }

        public override void Update()
        {
            base.Update();
            if (this.Lifetime == this.DirectionChange)
            {
                this.Lifetime = 0;
                if (!this.isMoving)
                {
                    FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GelFavorCardinalValue);
                    this.isMoving = true;
                    this.Enemy.UpdateState();
                }
                else
                {
                    this.isMoving = false;
                    this.Enemy.CurrentState = new IdleEnemyState(this.Enemy);
                }
            }
        }
    }
}