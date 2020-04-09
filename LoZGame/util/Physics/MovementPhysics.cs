namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    /// <summary>
    /// Physics Methods involving and updating the movement vector and acceleration of a target.
    /// </summary>
    public partial class Physics
    {
        /// <summary>
        /// Updates the bounds of the entity based on movement velocity, then sets the draw location to the new bounds.
        /// </summary>
        public void Move()
        {
            if (KnockbackVelocity.Length() > 0)
            {
                DampenedMovement();
            }
            else
            {
                this.boundsLocation += this.MovementVelocity;
                this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
            }
            this.SetLocation();
        }
        /// <summary>
        /// Lowers movement velocity in directions that knockback has been applied
        /// </summary>
        private void DampenedMovement()
        {
            float dampenedMovement = 0;
            if (MovementVelocity.Length() > 0)
            {
                dampenedMovement = (MovementVelocity.Length() - KnockbackVelocity.Length()) / MovementVelocity.Length();
            }
            this.boundsLocation += this.MovementVelocity * dampenedMovement;
            this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
        }

        /// <summary>
        /// updates the movement velocity of an entity by the movement accleration of the entity.
        /// </summary>
        public void Accelerate()
        {
            this.MovementVelocity += this.MovementAcceleration;
        }

        /// <summary>
        /// fetches the momentum of the entity based on current movement velocity and mass.
        /// </summary>
        /// <returns>momentum of the entity.</returns>
        public float GetMomentum()
        {
            float momentum = 2 * MovementVelocity.Length() * Mass;
            return momentum;
        }
    }
}