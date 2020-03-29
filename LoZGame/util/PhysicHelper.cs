namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class PhysicsHelper: PhysicsEssentials
    {
        public void StopVelocity()
        {
            this.MovementVelocity = Vector2.Zero;
            this.ForceVelocity = Vector2.Zero;
            this.MasterMovement = Vector2.Zero;
        }

        public void StopAcceleration()
        {
            this.MovementAcceleration = Vector2.Zero;
            this.ForceAcceleration = Vector2.Zero;
        }

        public void StopMovement()
        {
            this.StopVelocity();
            this.StopAcceleration();
        }

        public void StopKnockback()
        {
            this.ForceVelocity = Vector2.Zero;
            this.ForceAcceleration = Vector2.Zero;
        }

        public void StopMovementY()
        {
            this.MovementVelocity = new Vector2(this.MovementVelocity.X, 0);
            this.MovementAcceleration = new Vector2(this.MovementAcceleration.X, 0);
        }

        public void StopMovementX()
        {
            this.MovementVelocity = new Vector2(0, this.MovementVelocity.Y);
            this.MovementAcceleration = new Vector2(0, this.MovementAcceleration.Y);
        }

        public void StopKnockbacakY()
        {
            this.ForceVelocity = new Vector2(this.ForceVelocity.X, 0);
            this.ForceAcceleration = new Vector2(this.ForceAcceleration.X, 0);
        }

        public void StopKnockbackX()
        {
            this.ForceVelocity = new Vector2(0, this.ForceVelocity.Y);
            this.ForceAcceleration = new Vector2(0, this.ForceAcceleration.Y);
        }

        public void StopMotionY()
        {
            this.MovementVelocity = new Vector2(this.MovementVelocity.X, 0);
            this.MovementAcceleration = new Vector2(this.MovementAcceleration.X, 0);
            this.ForceVelocity = new Vector2(this.ForceVelocity.X, 0);
            this.ForceAcceleration = new Vector2(this.ForceAcceleration.X, 0);
        }

        public void StopMotionX()
        {
            this.MovementVelocity = new Vector2(0, this.MovementVelocity.Y);
            this.MovementAcceleration = new Vector2(0, this.MovementAcceleration.Y);
            this.ForceVelocity = new Vector2(0, this.ForceVelocity.Y);
            this.ForceAcceleration = new Vector2(0, this.ForceAcceleration.Y);
        }
    }
}