namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class Goriya : EnemyEssentials, IEnemy
    {
        public int Cooldown { get; set; }

        public string Direction { get; set; }

        public EntityManager EntityManager { get; set; }


        public Goriya(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyDamageData.GoriyaHealth);
            this.Physics = new Physics(location);
            this.CurrentState = new LeftMovingGoriyaState(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Cooldown = 0;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.GoriyaDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.GoriyaSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        public override void Stun(int stunTime)
        {
            this.CurrentState.Stun(stunTime);
        }

        public void FacePlayer()
        {
            Vector2 playerLoc = UnitVectorToPlayer(this.Physics.Bounds.Center.ToVector2());
            if (Math.Abs(playerLoc.X) > Math.Abs(playerLoc.Y))
            {
                if (playerLoc.X < 0)
                {
                    this.Physics.CurrentDirection = PhysicsEssentials.Direction.West;
                }
                else
                {
                    this.Physics.CurrentDirection = PhysicsEssentials.Direction.East;
                }
            }
            else
            {
                if (playerLoc.Y < 0)
                {
                    this.Physics.CurrentDirection = PhysicsEssentials.Direction.North;
                }
                else 
                {
                    this.Physics.CurrentDirection = PhysicsEssentials.Direction.South;
                }
            }

        }
    }
}