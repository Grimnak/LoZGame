namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : ProjectileEssentials, IProjectile
    {

        public SilverArrowProjectile(Physics source)
        {
            this.SetUp(this);
            this.Width = ProjectileSpriteFactory.Instance.ArrowWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.ArrowHeight;
            this.Offset = this.Heigth / 2;
            this.Speed = GameData.Instance.ProjectileSpeedData.LinkSilverArrowSpeed;
            this.Damage = GameData.Instance.ProjectileDamageData.LinkSilverArrowDamage;
            this.Source = source;
            this.InitializeDirection();
            if (this.Physics.CurrentDirection == Physics.Direction.East || this.Physics.CurrentDirection == Physics.Direction.West)
            {
                this.CorrectProjectile();
            }
            this.Sprite = ProjectileSpriteFactory.Instance.SilverArrow();
            this.Physics.Mass = GameData.Instance.ProjectileMassData.SilverArrowMass;
        }
    }
}