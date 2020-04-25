namespace LoZClone
{
    using Microsoft.Xna.Framework;

    class HiddenVireState : EnemyStateEssentials, IEnemyState
    {
        public HiddenVireState(IEnemy enemy)
        {
            Enemy = enemy;
            Sprite = null;
            Enemy.CurrentState = this;
            Enemy.IsTransparent = true;
            Enemy.IsKillable = false;
            Enemy.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
        }
    }
}
