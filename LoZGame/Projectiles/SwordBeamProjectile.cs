namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordBeamProjectile : ProjectileEssentials, IProjectile
    {
        private static readonly int drawDelay = LoZGame.Instance.UpdateSpeed / 4;
        private int lifeTime;

        public SwordBeamProjectile(Physics source)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.SwordBeamWidth;
            Heigth = ProjectileSpriteFactory.Instance.SwordBeamHeight;
            Offset = Heigth / 2;
            Speed = GameData.Instance.ProjectileSpeedConstants.SwordBeamSpeed;
            Damage = GameData.Instance.ProjectileDamageConstants.SwordBeamDamage;
            Source = source;
            InitializeDirection();
            if (Physics.CurrentDirection == Physics.Direction.East || Physics.CurrentDirection == Physics.Direction.West)
            {
                CorrectProjectile();
            }
            Sprite = ProjectileSpriteFactory.Instance.SwordBeam();
            lifeTime = 0;
            Physics.Mass = GameData.Instance.ProjectileMassConstants.ArrowMass;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (IsExpired)
            {
                CreateExplosion();
            }
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
            CreateExplosion();
        }

        private void CreateExplosion()
        {
            int explosionType = LoZGame.Instance.GameObjects.Entities.ExplosionManager.SwordExplosion;
            Vector2 explosionLoc = Vector2.Zero;
            if (Physics.CurrentDirection == Physics.Direction.North) 
            { 
                explosionLoc = new Vector2(Physics.Bounds.Left + (Width / 2), Physics.Bounds.Top); 
            }
            else if (Physics.CurrentDirection == Physics.Direction.South) 
            { 
                explosionLoc = new Vector2(Physics.Bounds.Left + (Width / 2), Physics.Bounds.Bottom); 
            }
            else if (Physics.CurrentDirection == Physics.Direction.West) 
            { 
                explosionLoc = new Vector2(Physics.Bounds.Left, Physics.Bounds.Top + (Heigth / 2)); 
            }
            else if (Physics.CurrentDirection == Physics.Direction.East) 
            {
                explosionLoc = new Vector2(Physics.Bounds.Right, Physics.Bounds.Top + (Heigth / 2)); 
            }
            LoZGame.Instance.GameObjects.Entities.ExplosionManager.AddExplosion(explosionType, explosionLoc);
        }

        public override void Update()
        {
            lifeTime++;
            if (lifeTime >= drawDelay)
            {
                base.Update();
            }
        }

        public override void Draw()
        {
            if (lifeTime >= drawDelay)
            {
                base.Draw();
            }
        }
    }
}