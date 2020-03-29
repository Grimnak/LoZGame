namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PlayerCollisionHandler
    {
        private IPlayer player;
        private float xDirection;
        private float yDirection;
        private const float Speed = 10;
        private const float Acceleration = -0.5f;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (enemy is WallMaster)
            {
                this.player.State = new GrabbedState(player, (WallMaster)enemy);
            }
            else if (enemy is OldMan || enemy is Merchant)
            {
                // do nothing
            }
            else
            {
                DeterminePushbackValues(enemy.Physics.GetMomentum());
                this.player.TakeDamage(enemy.Damage);
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            if (item.PickUpItemTime >= 0)
            {
                item.Physics.Location = new Vector2(player.Physics.Location.X + 5, player.Physics.Location.Y - 45);
                this.player.State = new PickupItemState(player, item);
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            DeterminePushbackValues(projectile.Physics.GetMomentum());
            this.player.TakeDamage(projectile.Damage);
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IDoor door, CollisionDetection.CollisionSide collisionSide)
        {
            if (door.State is LockedDoorState || door.State is HiddenDoorState)
            {
                PreventDoorEntry(door);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                int side = LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10;
                this.player.Physics.Bounds = new Rectangle(side, this.player.Physics.Bounds.Y, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionX();
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                int side = BlockSpriteFactory.Instance.HorizontalOffset;
                this.player.Physics.Bounds = new Rectangle(side, this.player.Physics.Bounds.Y, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionX();
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                int side = LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight -BlockSpriteFactory.Instance.VerticalOffset;
                this.player.Physics.Bounds = new Rectangle(this.player.Physics.Bounds.X, side, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionY();
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                int side = BlockSpriteFactory.Instance.VerticalOffset;
                this.player.Physics.Bounds = new Rectangle(this.player.Physics.Bounds.X, side, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionY();
            }
            this.player.Physics.SetLocation();
        }

        private void DeterminePushbackValues(Vector2 momentum)
        {
            if (this.player.DamageTimer <= 0)
            {
                Vector2 force = new Vector2(momentum.X / momentum.Length(), momentum.Y / momentum.Length());
                force *= Acceleration;
                this.player.Physics.SetForce(momentum, force);
            }
        }

        private void PreventDoorEntry(IDoor door)
        {
            if (door.Physics.Location == door.LeftScreenLoc)
            {
                player.Physics.Bounds = new Rectangle((int)BlockSpriteFactory.Instance.HorizontalOffset, player.Physics.Bounds.Y, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionX();
            }
            else if (door.Physics.Location == door.RightScreenLoc)
            {
                player.Physics.Bounds = new Rectangle((int)door.RightScreenLoc.X - LinkSpriteFactory.LinkWidth - 7, player.Physics.Bounds.Y, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionX();
            }
            else if (door.Physics.Location == door.DownScreenLoc)
            {
                player.Physics.Bounds = new Rectangle(player.Physics.Bounds.X, (int)door.DownScreenLoc.Y - LinkSpriteFactory.LinkHeight, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionY();
            }
            else if (door.Physics.Location == door.UpScreenLoc)
            {
                player.Physics.Bounds = new Rectangle(player.Physics.Bounds.X, (int)BlockSpriteFactory.Instance.VerticalOffset, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionY();
            }
            this.player.Physics.SetLocation();
        }
    }
}