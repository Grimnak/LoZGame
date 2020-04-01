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
                DeterminePushbackValues(enemy.Physics);
                this.player.TakeDamage(enemy.Damage);
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            if (item.PickUpItemTime >= 0)
            {
                item.Physics.Location = new Vector2(player.Physics.Location.X + 5, player.Physics.Location.Y - 45);
                item.Physics.Bounds = new Rectangle(new Point((int)item.Physics.Location.X, (int)item.Physics.Location.Y), new Point(0,0));
                this.player.State = new PickupItemState(player, item);
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            DetermineDirectPushback(projectile.Physics);
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

        private void DetermineDirectPushback(Physics source)
        {
            if (this.player.DamageTimer <= 0)
            {
                float sourceMomentum = source.GetMomentum().Length();
                switch (source.CurrentDirection)
                {
                    case Physics.Direction.North:
                        this.player.Physics.SetForce(new Vector2(0, -1) * sourceMomentum, new Vector2(0, -1) * Acceleration);
                        break;
                    case Physics.Direction.South:
                        this.player.Physics.SetForce(new Vector2(0, 1) * sourceMomentum, new Vector2(0, -1) * Acceleration);
                        break;
                    case Physics.Direction.East:
                        this.player.Physics.SetForce(new Vector2(1, 0) * sourceMomentum, new Vector2(0, -1) * Acceleration);
                        break;
                    case Physics.Direction.West:
                        this.player.Physics.SetForce(new Vector2(-1, 0) * sourceMomentum, new Vector2(0, -1) * Acceleration);
                        break;
                }
            }
        }

        private void DeterminePushbackValues(Physics source)
        {
            if (this.player.DamageTimer <= 0)
            {
                float sourceMomentum = source.GetMomentum().Length();
                if (sourceMomentum < 1) { sourceMomentum = 1; }
                Vector2 sourceToPlayer = (source.Bounds.Center - this.player.Physics.Bounds.Center).ToVector2();
                sourceToPlayer.Normalize();
                Vector2 friction = new Vector2(sourceToPlayer.X, sourceToPlayer.Y);
                sourceToPlayer *= sourceMomentum;
                friction *= Acceleration;
                this.player.Physics.SetForce(sourceToPlayer, friction);
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