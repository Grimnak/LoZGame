namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SpikeCross : EnemyEssentials, IEnemy
    {
        private Point InitialPos;

        public SpikeCross(Vector2 location)
        {
            this.Health = new HealthManager(GameData.Instance.EnemyHealthConstants.SpikeCrossHealth);
            this.Physics = new Physics(new Vector2(location.X, location.Y));
            this.Physics.Mass = GameData.Instance.EnemyMassConstants.SpikeCrossMass;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.CurrentState = new IdleEnemyState(this);
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            InitialPos = this.Physics.Bounds.Location;
            this.Expired = false;
            this.IsKillable = false;
            this.Damage = GameData.Instance.EnemyDamageConstants.SpikeCrossDamage;
            this.DamageTimer = 0;
            this.CurrentTint = LoZGame.Instance.DefaultTint;
            this.AI = EnemyAI.SpikeCross;
            this.IsTransparent = true;
            this.ApplyDamageMod();
            this.ApplySmallSpeedMod();
            this.ApplyLargeWeightModPos();
        }

        public new Point SpawnPoint => InitialPos;

        public override void UpdateState()
        {
            this.CurrentState = new IdleEnemyState(this);
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            this.CurrentState = new AttackingSpikeCrossState(this);
        }

        public override void Update()
        {
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || this.IsSpawning || this.IsDead)
            {
                this.CurrentState.Update();
                this.Physics.Move();
            }
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.CurrentState = new IdleEnemyState(this);
            this.Physics.Bounds = new Rectangle(InitialPos, this.Physics.Bounds.Size);
            this.Physics.SetLocation();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }
    }
}