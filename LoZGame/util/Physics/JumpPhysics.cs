namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    /// <summary>
    /// Methods that handle the knockback vectors of an entity.
    /// </summary>
    public partial class Physics
    {
        private const float gravity = 0.1f;
        private float currentJump;
        private float maxJump;

        /// <summary>
        /// updates the bounds and knockback velocity of an entity. Sets draw location to the new bounds.
        /// </summary>
        public void HandleJump()
        {
            if (this.IsJumping)
            {
                this.boundsLocation += new Vector2(0, currentJump);
                this.bounds = new Rectangle(this.boundsLocation.ToPoint(), this.bounds.Size);
                this.UpdateJump();
                this.SetLocation();
            }
        }

        private void UpdateJump()
        {
            if (currentJump < maxJump + gravity)
            {
                currentJump += gravity;
            }
            else
            {
                this.IsJumping = false;
                currentJump = 0;
                maxJump = 0;
            }
        }

        public void Jump(float magnitude)
        {
            maxJump += Math.Abs(magnitude);
            currentJump -= Math.Abs(magnitude);
            this.IsJumping = true;
        }
    }
}