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
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.SwordBeamWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.SwordBeamHeight;
            this.Offset = this.Heigth / 2;
            this.Speed = GameData.Instance.ProjectileSpeedData.SwordBeamSpeed;
            this.Damage = GameData.Instance.ProjectileDamageData.SwordBeamDamage;
            this.Source = source;
            this.InitializeDirection();
            if (this.Physics.CurrentDirection == Physics.Direction.East || this.Physics.CurrentDirection == Physics.Direction.West)
            {
                this.CorrectProjectile();
            }
            this.Sprite = ProjectileSpriteFactory.Instance.SwordBeam();
            this.lifeTime = 0;
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (this.IsExpired)
            {
                this.CreateExplosion();
            }
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
            this.CreateExplosion();
        }

        private void CreateExplosion()
        {
            int explosionType = LoZGame.Instance.GameObjects.Entities.ExplosionManager.SwordExplosion;
            Vector2 explosionLoc = Vector2.Zero;
            if (this.Physics.CurrentDirection == Physics.Direction.North) 
            { 
                explosionLoc = new Vector2(this.Physics.Bounds.Left + (this.Width / 2), this.Physics.Bounds.Top); 
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.South) 
            { 
                explosionLoc = new Vector2(this.Physics.Bounds.Left + (this.Width / 2), this.Physics.Bounds.Bottom); 
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.West) 
            { 
                explosionLoc = new Vector2(this.Physics.Bounds.Left, this.Physics.Bounds.Top + (this.Heigth / 2)); 
            }
            else if (this.Physics.CurrentDirection == Physics.Direction.East) 
            {
                explosionLoc = new Vector2(this.Physics.Bounds.Right, this.Physics.Bounds.Top + (this.Heigth / 2)); 
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