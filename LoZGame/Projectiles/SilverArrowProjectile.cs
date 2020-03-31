namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : ProjectileEssentials, IProjectile
    {
        public SilverArrowProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.SwordBeamWidth;
            this.Height = ProjectileSpriteFactory.Instance.SwordBeamHeight;
            this.Offset = (this.Height * 3) / 4;
            this.Speed = 10;
            this.Damage = 2;
            this.Source = source;
            this.InitializeDirection();
            this.Sprite = ProjectileSpriteFactory.Instance.SilverArrow();
        }
    }
}