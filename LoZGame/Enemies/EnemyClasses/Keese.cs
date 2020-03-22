namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Keese : EnemyEssentials, IEnemy
    {
        public Keese(Vector2 location)
        {
            this.Health = new HealthManager(1);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.CurrentState = new LeftMovingKeeseState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 1;
            this.DamageTimer = 0;
            this.MoveSpeed = 0;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }
    }
}