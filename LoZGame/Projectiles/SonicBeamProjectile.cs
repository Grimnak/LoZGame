namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SonicBeamProjectile : ProjectileEssentials, IProjectile
    {
        public SonicBeamProjectile(Physics physics)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.StandardWidth;
            Height = ProjectileSpriteFactory.Instance.BoomerangHeight;
            Offset = (Height * 3) / 4;
            Speed = GameData.Instance.ProjectileSpeedConstants.LinkBoomerangSpeed / 2;
            Source = physics;
            InitializeDirection();
            Sprite = ProjectileSpriteFactory.Instance.Boomerang();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.BoomerangMass;
        }
    }
}
