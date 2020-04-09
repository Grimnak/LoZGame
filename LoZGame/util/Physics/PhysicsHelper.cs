namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class Physics
    {
        public void StopVelocity()
        {
            this.MovementVelocity = Vector2.Zero;
            this.KnockbackVelocity = Vector2.Zero;
            this.MasterMovement = Vector2.Zero;
        }

        public void StopAcceleration()
        {
            this.MovementAcceleration = Vector2.Zero;
            this.Friction = Vector2.Zero;
        }

        public void StopMovement()
        {
            this.StopVelocity();
            this.StopAcceleration();
        }

        public void StopKnockback()
        {
            this.KnockbackVelocity = Vector2.Zero;
            this.Friction = Vector2.Zero;
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

        public void StopKnockbackY()
        {
            this.KnockbackVelocity = new Vector2(this.KnockbackVelocity.X, 0);
            this.Friction = new Vector2(this.Friction.X, 0);
        }

        public void StopKnockbackX()
        {
            this.KnockbackVelocity = new Vector2(0, this.KnockbackVelocity.Y);
            this.Friction = new Vector2(0, this.Friction.Y);
        }

        public void StopMotionY()
        {
            this.MovementVelocity = new Vector2(this.MovementVelocity.X, 0);
            this.MovementAcceleration = new Vector2(this.MovementAcceleration.X, 0);
            this.KnockbackVelocity = new Vector2(this.KnockbackVelocity.X, 0);
            this.Friction = new Vector2(this.Friction.X, 0);
        }

        public void StopMotionX()
        {
            this.MovementVelocity = new Vector2(0, this.MovementVelocity.Y);
            this.MovementAcceleration = new Vector2(0, this.MovementAcceleration.Y);
            this.KnockbackVelocity = new Vector2(0, this.KnockbackVelocity.Y);
            this.Friction = new Vector2(0, this.Friction.Y);
        }
    }
}