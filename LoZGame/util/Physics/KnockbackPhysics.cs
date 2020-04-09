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
            if (KnockbackVelocity.Length() > 0)
            {
                this.Friction = new Vector2(KnockbackVelocity.X, KnockbackVelocity.Y) / (10 * KnockbackVelocity.Length());
                this.Friction *= -2 * (this.Mass / DefaultMass);
                Console.WriteLine("Friction: " + Friction + "\t Velocity: " + KnockbackVelocity);
                if (KnockbackVelocity.Length() > Friction.Length())
                {
                    Console.WriteLine("Slowing Down");
                    this.KnockbackVelocity += this.Friction;
                }
                else
                {
                    Console.WriteLine("Stopping");
                    this.KnockbackVelocity = Vector2.Zero;
                }
            }
        }

        public void SetKnockback(Vector2 momentum)
        {
            if (IsMoveable)
            {
                this.KnockbackVelocity = 2 * momentum / Mass;
            }
        }
    }
}