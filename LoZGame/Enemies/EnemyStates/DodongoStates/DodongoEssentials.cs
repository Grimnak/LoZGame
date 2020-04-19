namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public partial class DodongoEssentials : EnemyStateEssentials, IEnemyState
    {
        public override void Attack()
        {
            this.Enemy.CurrentState = new AttackingDodongoState(this.Enemy);
        }

        public override void Stun(int stunTime)
        {
            if (!this.Enemy.IsSpawning)
            {
                this.Enemy.CurrentState = new StunnedDodongoState(this.Enemy);
            }
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.DodongoFavorCardinalValue);
            }
            if (!(this.Enemy.CurrentState is AttackingDodongoState))
            {
                this.CheckForLink();
            }
            if (this.Sprite.CurrentFrame >= 2)
            {
                this.Sprite.SetFrame(0);
            }
            base.Update();
        }
    }
}