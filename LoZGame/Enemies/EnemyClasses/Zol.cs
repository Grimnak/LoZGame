namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Zol : EnemyEssentials, IEnemy
    {
        public bool ShouldMove { get; set; }

        public Zol(Vector2 location)
        {
            this.Health = new HealthManager(4);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.CurrentState = new LeftMovingZolState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.ShouldMove = true;
            this.Expired = false;
            this.Damage = 2;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
    }
}