namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SwordProjectile : ProjectileEssentials, IProjectile
    {
        private int lifeTime;
        private int totalLife;
        private Point sourceOffset;

        public SwordProjectile(IPlayer source)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.SwordWidth;
            Height = ProjectileSpriteFactory.Instance.SwordHeight;
            Offset = (Height * 3) / 4;
            Speed = GameData.Instance.ProjectileSpeedConstants.WoodSwordSpeed;
            Source = source.Physics;
            InitializeDirection();
            sourceOffset = Physics.Bounds.Location - Source.Bounds.Location;
            lifeTime = 0;
            Sprite = ProjectileSpriteFactory.Instance.Sword(source.CurrentColor, source.CurrentWeapon);
            CreateCorrectSword(source.CurrentWeapon);
            Physics.MovementVelocity = Vector2.Zero;
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        private void SetToSource()
        {
            Point currentOffset = Physics.Bounds.Location - Source.Bounds.Location;
            if (currentOffset != sourceOffset)
            {
                Physics.Bounds = new Rectangle(Source.Bounds.Location + sourceOffset, new Point(Physics.Bounds.Width, Physics.Bounds.Height));
                Physics.SetLocation();
            }
        }

        public override void Update()
        {
            lifeTime++;
            SetToSource();
            if (lifeTime == totalLife / 3 || lifeTime == (totalLife * 2) / 3)
            {
                Sprite.NextFrame();
            }
            if (lifeTime >= totalLife)
            {
                IsExpired = true;
            }
            Physics.SetDepth();
        }

        private void CreateCorrectSword(Link.LinkWeapon sword)
        {
            if (sword is Link.LinkWeapon.Wood)
            {
                Damage = GameData.Instance.ProjectileDamageConstants.WoodSwordDamage;
                Physics.Mass = GameData.Instance.ProjectileMassConstants.WoodSwordMass;
            }
            else if (sword is Link.LinkWeapon.White)
            {
                Damage = GameData.Instance.ProjectileDamageConstants.WhiteSwordDamage;
                Physics.Mass = GameData.Instance.ProjectileMassConstants.WhiteSwordMass;
            }
            else if (sword is Link.LinkWeapon.Magic)
            {
                Damage = GameData.Instance.ProjectileDamageConstants.MagicSwordDamage;
                Physics.Mass = GameData.Instance.ProjectileMassConstants.MagicSwordMass;
            }
            totalLife = 15;
        }
    }
}