namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    /// <summary>
    /// Methods that handle the knockback vectors of an entity.
    /// </summary>
    public partial class Physics
    {
        /// <summary>
        /// updates the bounds and knockback velocity of an entity. Sets draw location to the new bounds.
        /// </summary>
        public void HandleKnockBack()
        {
            boundsLocation += KnockbackVelocity;
            bounds = new Rectangle(boundsLocation.ToPoint(), bounds.Size);
            UpdateKnockback();
            SetLocation();
        }

        private void UpdateKnockback()
        {
            if (KnockbackVelocity.Length() > GameData.Instance.PhysicsConstants.ZeroVelocity)
            {
                Friction = new Vector2(KnockbackVelocity.X, KnockbackVelocity.Y) / (GameData.Instance.PhysicsConstants.KnockbackMultiplier * KnockbackVelocity.Length());
                Friction *= GameData.Instance.PhysicsConstants.MassMultiplier * (Mass / DefaultMass);
                if (KnockbackVelocity.Length() > Friction.Length())
                {
                    KnockbackVelocity += Friction;
                }
                else
                {
                    KnockbackVelocity = Vector2.Zero;
                }
            }
        }

        public void SetKnockback(Vector2 momentum)
        {
            if (IsMovable)
            {
                KnockbackVelocity = GameData.Instance.PhysicsConstants.MomentumMultiplier * momentum / Mass;
            }
        }
    }
}