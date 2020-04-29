namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class SonicBeamProjectile : ProjectileEssentials, IProjectile
    {
        public SonicBeamProjectile(Physics physics)
        {
            SetUp(this);
            Width = ProjectileSpriteFactory.Instance.SonicBeamWidth;
            Height = ProjectileSpriteFactory.Instance.SonicBeamHeight;
            Offset = (Height * 3) / 4;
            Speed = GameData.Instance.ProjectileSpeedConstants.LinkBoomerangSpeed / 2;
            Source = physics;
            Sprite = ProjectileSpriteFactory.Instance.SonicBeam();
            Damage = GameData.Instance.EnemyDamageConstants.FullHeart;
            InitializeDirection();
            Physics.Mass = GameData.Instance.ProjectileMassConstants.BoomerangMass;
        }
    }
}
