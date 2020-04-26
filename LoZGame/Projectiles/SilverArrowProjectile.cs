namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class SilverArrowProjectile : ProjectileEssentials, IProjectile
    {
        public SilverArrowProjectile(Physics source)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.ArrowWidth;
            Height = ProjectileSpriteFactory.Instance.ArrowHeight;
            Offset = Height / 2;
            Speed = GameData.Instance.ProjectileSpeedConstants.LinkSilverArrowSpeed;
            Damage = GameData.Instance.ProjectileDamageConstants.LinkSilverArrowDamage;
            Source = source;
            InitializeDirection();
            if (Physics.CurrentDirection == Physics.Direction.East || Physics.CurrentDirection == Physics.Direction.West)
            {
                CorrectProjectile();
            }
            Sprite = ProjectileSpriteFactory.Instance.SilverArrow();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.SilverArrowMass;
        }
    }
}