namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    /// <summary>
    /// Methods that handle the knockback vectors of an entity.
    /// </summary>
    public partial class Physics
    {
        private float currentJump;
        private float maxJump;

        /// <summary>
        /// updates the bounds and knockback velocity of an entity. Sets draw location to the new bounds.
        /// </summary>
        public void HandleJump()
        {
            if (IsJumping)
            {
                boundsLocation += new Vector2(0, currentJump);
                bounds = new Rectangle(boundsLocation.ToPoint(), bounds.Size);
                UpdateJump();
                SetLocation();
            }
        }

        private void UpdateJump()
        {
            if (currentJump < maxJump + Gravity)
            {
                currentJump += Gravity;
            }
            else
            {
                IsJumping = false;
                currentJump = 0;
                maxJump = 0;
            }
        }

        public void Jump(float magnitude)
        {
            maxJump += Math.Abs(magnitude);
            currentJump -= Math.Abs(magnitude);
            IsJumping = true;
        }
    }
}