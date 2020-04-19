namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GoriyaEssentials : EnemyStateEssentials, IEnemyState
    {   
        public override void Attack()
        {
            if (this.Enemy is Goriya)
            {
                this.Enemy.CurrentState = new AttackingGoriyaState(this.Enemy);
            }
            else
            {
                this.Enemy.CurrentState = new AttackingBlueGoriyaState(this.Enemy);
            }
        }

        public override void Update()
        {
            if (this.Lifetime == this.DirectionChange)
            {
                FavorPlayerCardinal(GameData.Instance.EnemyMiscConstants.GoriyaFavorCardinalValue);
            }
            base.Update();
        }
    }
}