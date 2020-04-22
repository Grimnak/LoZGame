namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public partial class Physics
    {
        public void StopVelocity()
        {
            MovementVelocity = Vector2.Zero;
            KnockbackVelocity = Vector2.Zero;
            MasterMovement = Vector2.Zero;
        }

        public void StopAcceleration()
        {
            MovementAcceleration = Vector2.Zero;
            Friction = Vector2.Zero;
        }

        public void StopMovement()
        {
            StopVelocity();
            StopAcceleration();
        }

        public void StopKnockback()
        {
            KnockbackVelocity = Vector2.Zero;
            Friction = Vector2.Zero;
        }

        public void StopMovementY()
        {
            MovementVelocity = new Vector2(MovementVelocity.X, GameData.Instance.PhysicsConstants.ZeroVelocity);
            MovementAcceleration = new Vector2(MovementAcceleration.X, GameData.Instance.PhysicsConstants.ZeroVelocity);
        }

        public void StopMovementX()
        {
            MovementVelocity = new Vector2(0, MovementVelocity.Y);
            MovementAcceleration = new Vector2(0, MovementAcceleration.Y);
        }

        public void StopKnockbackY()
        {
            KnockbackVelocity = new Vector2(KnockbackVelocity.X, GameData.Instance.PhysicsConstants.ZeroVelocity);
            Friction = new Vector2(Friction.X, GameData.Instance.PhysicsConstants.ZeroFriction);
        }

        public void StopKnockbackX()
        {
            KnockbackVelocity = new Vector2(GameData.Instance.PhysicsConstants.ZeroVelocity, KnockbackVelocity.Y);
            Friction = new Vector2(GameData.Instance.PhysicsConstants.ZeroFriction, Friction.Y);
        }

        public void StopMotionY()
        {
            MovementVelocity = new Vector2(MovementVelocity.X, GameData.Instance.PhysicsConstants.ZeroVelocity);
            MovementAcceleration = new Vector2(MovementAcceleration.X, GameData.Instance.PhysicsConstants.ZeroAcceleration);
            KnockbackVelocity = new Vector2(KnockbackVelocity.X, GameData.Instance.PhysicsConstants.ZeroVelocity);
            Friction = new Vector2(Friction.X, 0);
        }

        public void StopMotionX()
        {
            MovementVelocity = new Vector2(GameData.Instance.PhysicsConstants.ZeroVelocity, MovementVelocity.Y);
            MovementAcceleration = new Vector2(GameData.Instance.PhysicsConstants.ZeroAcceleration, MovementAcceleration.Y);
            KnockbackVelocity = new Vector2(GameData.Instance.PhysicsConstants.ZeroVelocity, KnockbackVelocity.Y);
            Friction = new Vector2(GameData.Instance.PhysicsConstants.ZeroFriction, Friction.Y);
        }
    }
}