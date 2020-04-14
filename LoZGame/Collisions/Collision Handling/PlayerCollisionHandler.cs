namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PlayerCollisionHandler : CollisionInteractions
    {
        private IPlayer player;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            if (enemy is WallMaster && !(this.player.State is PickupItemState))
            {
                this.player.State = new GrabbedState(player, (WallMaster)enemy);
            }
            else if (enemy is OldMan || enemy is Merchant || enemy is BlockEnemy)
            {
                // do nothing
            }
            else
            {
                if (!(this.player.State is PickupItemState || this.player.State is AttackState))
                {
                    if (this.player.DamageTimer <= 0)
                    {
                        this.DeterminePushbackValues(enemy.Physics, this.player.Physics);
                    }
                    this.player.TakeDamage(enemy.Damage);
                }
            }
        }

        public void OnCollisionResponse(IItem item, CollisionDetection.CollisionSide collisionSide)
        {
            if (item.PickUpItemTime >= 0)
            {
                item.Physics.Location = new Vector2(player.Physics.Location.X + 5, player.Physics.Location.Y - 45);
                item.Physics.Bounds = new Rectangle(new Point((int)item.Physics.Location.X, (int)item.Physics.Location.Y), new Point(0, 0));
                this.player.State = new PickupItemState(player, item);
            }
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if (!(this.player.State is PickupItemState))
            {
                if (!(projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile) && this.player.DamageTimer <= 0)
                {
                    DetermineDirectPushback(projectile.Physics, this.player.Physics);
                }
                this.player.TakeDamage(projectile.Damage);
            }
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
            this.SetBounds(this.player.Physics, collisionSide);
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
                player.Physics.Bounds = new Rectangle(player.Physics.Bounds.X, (int)BlockSpriteFactory.Instance.TopOffset, this.player.Physics.Bounds.Width, this.player.Physics.Bounds.Height);
                this.player.Physics.StopMotionY();
            }
            this.player.Physics.SetLocation();
        }
    }
}