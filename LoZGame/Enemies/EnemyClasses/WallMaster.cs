namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WallMaster : EnemyEssentials, IEnemy
    {
        public WallMaster(Vector2 location)
        {
            this.Health = new HealthManager(10);
            this.Physics = new Physics(location, new Vector2(0, 0), new Vector2(0, 0));
            this.CurrentState = new LeftMovingWallMasterState(this);
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = 1;
            this.DamageTimer = 0;
            this.MoveSpeed = 1;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }
    }
}