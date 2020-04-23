namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SpikeCross : EnemyEssentials, IEnemy
    {
        private Point InitialPos;

        public SpikeCross(Vector2 location)
        {
            Health = new HealthManager(GameData.Instance.EnemyHealthConstants.SpikeCrossHealth);
            Physics = new Physics(new Vector2(location.X, location.Y));
            Physics.Mass = GameData.Instance.EnemyMassConstants.SpikeCrossMass;
            Physics.Bounds = new Rectangle((int)Physics.Location.X, (int)Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            CurrentState = new IdleEnemyState(this);
            EnemyCollisionHandler = new EnemyCollisionHandler(this);
            InitialPos = Physics.Bounds.Location;
            Expired = false;
            IsKillable = false;
            Damage = GameData.Instance.EnemyDamageConstants.SpikeCrossDamage;
            DamageTimer = 0;
            CurrentTint = LoZGame.Instance.DefaultTint;
            AI = EnemyAI.SpikeCross;
            DropTable = GameData.Instance.EnemyDropTables.EmptyDropTable;
            IsTransparent = true;
            ApplyDamageMod();
            ApplySmallSpeedMod();
            ApplyLargeWeightModPos();
        }

        public new Point SpawnPoint => InitialPos;

        public override void UpdateState()
        {
            CurrentState = new IdleEnemyState(this);
        }

        public override void Stun(int stunTime)
        {
        }

        public override void Attack()
        {
            CurrentState = new AttackingSpikeCrossState(this);
        }

        public override void Update()
        {
            if (!LoZGame.Instance.Players[0].Inventory.HasClock || IsSpawning || IsDead)
            {
                CurrentState.Update();
                Physics.Move();
            }
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                EnemyCollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            CurrentState = new IdleEnemyState(this);
            Physics.Bounds = new Rectangle(InitialPos, Physics.Bounds.Size);
            Physics.SetLocation();
        }

        public override ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateSpikeCrossSprite();
        }
    }
}