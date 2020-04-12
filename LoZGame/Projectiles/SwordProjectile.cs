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
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.SwordWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.SwordHeight;
            this.Offset = ((this.Heigth * 3) / 4);
            this.Speed = GameData.Instance.ProjectileSpeedData.WoodSwordSpeed;
            this.Source = source.Physics;
            this.InitializeDirection();
            this.sourceOffset = this.Physics.Bounds.Location - this.Source.Bounds.Location;
            this.lifeTime = 0;
            this.CreateCorrectSword(source.CurrentColor, source.CurrentWeapon);
            this.Physics.MovementVelocity = Vector2.Zero;
        }

        public override void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
        }

        private void SetToSource()
        {
            Point currentOffset = this.Physics.Bounds.Location - this.Source.Bounds.Location;
            if (currentOffset != sourceOffset)
            {
                this.Physics.Bounds = new Rectangle(this.Source.Bounds.Location + sourceOffset, new Point(this.Physics.Bounds.Width, this.Physics.Bounds.Height));
                this.Physics.SetLocation();
            }
        }

        public override void Update()
        {
            lifeTime++;
            this.SetToSource();
            if (this.lifeTime == totalLife / 3 || this.lifeTime == (totalLife * 2) / 3)
            {
                this.Sprite.NextFrame();
            }
            if (this.lifeTime >= totalLife)
            {
                this.IsExpired = true;
            }
            this.Physics.SetDepth();
        }

        private void CreateCorrectSword(string color, string sword)
        {
            /*if (color.Equals("Red"))
            {
                if (sword.Equals)
                // this.Sprite = ProjectileSpriteFactory.Instance.RedWoodSword();
            }
            else if (color.Equals("Blue"))
            {
                // this.Sprite = ProjectileSpriteFactory.Instance.BlueWoodSword();
            }
            else
            {
                this.Damage = GameData.Instance.ProjectileDamageData.WoodSwordDamage;
                this.Sprite = ProjectileSpriteFactory.Instance.GreenWoodSword();
                totalLife = 15;
            }*/
            this.Damage = GameData.Instance.ProjectileDamageData.WoodSwordDamage;
            this.Sprite = ProjectileSpriteFactory.Instance.GreenWoodSword();
            this.Physics.Mass = GameData.Instance.ProjectileMassData.WoodSwordMass;
            totalLife = 15;
        }
    }
}