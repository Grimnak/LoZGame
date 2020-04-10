namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class OldMan : EnemyEssentials, IEnemy
    {
        private const float FireballSpeed = 2.5f;
        private readonly ISprite sprite;
        private Vector2 FlameOneLoc;
        private Vector2 FlameTwoLoc;

        public EntityManager EntityManager { get; set; }

        public OldMan(Vector2 location)
        {
            this.Physics = new Physics(location);
            this.FlameOneLoc = new Vector2(location.X - 100, location.Y + 20);
            this.FlameTwoLoc = new Vector2(location.X + 160, location.Y + 20);
            this.sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            this.EnemyCollisionHandler = new EnemyCollisionHandler(this);
            this.EntityManager = LoZGame.Instance.GameObjects.Entities;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, EnemySpriteFactory.GetEnemyWidth(this), EnemySpriteFactory.GetEnemyHeight(this));
            this.Health = new HealthManager(1);
            this.Expired = false;
            this.Damage = GameData.Instance.EnemyDamageData.OldManDamage;
            this.DamageTimer = 0;
            this.MoveSpeed = GameData.Instance.EnemySpeedData.OldManSpeed;
            this.CurrentTint = LoZGame.Instance.DungeonTint;
        }

        private Vector2 UnitVectorToPlayer(Vector2 origin)
        {
            Vector2 unitVector = LoZGame.Instance.Link.Physics.Bounds.Center.ToVector2() - origin;
            unitVector.Normalize();
            return unitVector;
        }

        public void ShootFireballs()
        {
            Vector2 playerVectorOne = this.UnitVectorToPlayer(this.FlameOneLoc);
            Vector2 playerVectorTwo = this.UnitVectorToPlayer(this.FlameTwoLoc);
            Vector2 velocityVectorOne = new Vector2(playerVectorOne.X * FireballSpeed, playerVectorOne.Y * FireballSpeed);
            Vector2 velocityVectorTwo = new Vector2(playerVectorTwo.X * FireballSpeed, playerVectorTwo.Y * FireballSpeed);
            Physics fireballOnePhysics = new Physics(new Vector2(FlameOneLoc.X, FlameOneLoc.Y));
            fireballOnePhysics.MovementVelocity = velocityVectorOne;
            Physics fireballTwoPhysics = new Physics(new Vector2(FlameTwoLoc.X, FlameTwoLoc.Y));
            fireballTwoPhysics.MovementVelocity = velocityVectorTwo;
            EntityManager.EnemyProjectileManager.Add(EntityManager.EnemyProjectileManager.Fireball, fireballOnePhysics);
            EntityManager.EnemyProjectileManager.Add(EntityManager.EnemyProjectileManager.Fireball, fireballTwoPhysics);
        }

        public override void TakeDamage(int damageAmount)
        {
        }

        public override void Update()
        {
            this.Physics.SetDepth();
            this.sprite.Update();
        }

        public override void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
        }

        public ISprite CreateCorrectSprite()
        {
            return EnemySpriteFactory.Instance.CreateOldManSprite();
        }
    }
}