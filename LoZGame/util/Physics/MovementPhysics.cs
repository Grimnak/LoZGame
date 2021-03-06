﻿namespace LoZClone
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
            if (KnockbackVelocity.Length() == GameData.Instance.PhysicsConstants.ZeroLength)
            {
                boundsLocation += MovementVelocity;
                bounds = new Rectangle(boundsLocation.ToPoint(), bounds.Size);
            }
            SetLocation();
        }

        /// <summary>
        /// Updates the bounds of the entity based on Master movement velocity, then sets the draw location to the new bounds.
        /// </summary>
        public void MoveMaster()
        {
            boundsLocation += MasterMovement;
            bounds = new Rectangle(boundsLocation.ToPoint(), bounds.Size);
            SetLocation();
        }

        /// <summary>
        /// updates the movement velocity of an entity by the movement accleration of the entity.
        /// </summary>
        public void Accelerate()
        {
            MovementVelocity += MovementAcceleration;
        }

        /// <summary>
        /// fetches the momentum of the entity based on current movement velocity and mass.
        /// </summary>
        /// <returns>momentum of the entity.</returns>
        public float GetMomentum()
        {
            float momentum = GameData.Instance.PhysicsConstants.MomentumMultiplier * MovementVelocity.Length() * Mass;
            return momentum;
        }

        public void Jump()
        {
            // get this to work for vires
        }
    }
}