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
            this.boundsLocation += this.KnockbackVelocity;
            this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
            this.UpdateKnockback();
            this.SetLocation();
        }

        //
        private void UpdateKnockback()
        {
            if (KnockbackVelocity.Length() > GameData.Instance.PhysicsConstants.ZeroVelocity)
            {
                this.Friction = new Vector2(KnockbackVelocity.X, KnockbackVelocity.Y) / (GameData.Instance.PhysicsConstants.KnockbackMultiplier * KnockbackVelocity.Length());
                this.Friction *= GameData.Instance.PhysicsConstants.MassMultiplier * (this.Mass / DefaultMass);
                if (KnockbackVelocity.Length() > Friction.Length())
                {
                    this.KnockbackVelocity += this.Friction;
                }
                else
                {
                    this.KnockbackVelocity = Vector2.Zero;
                }
            }
        }

        public void SetKnockback(Vector2 momentum)
        {
            if (IsMoveable)
            {
                this.KnockbackVelocity = GameData.Instance.PhysicsConstants.MomentumMultiplier * momentum / Mass;
            }
        }
    }
}