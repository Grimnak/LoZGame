namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class EnemyCollisionHandler
    {
        private IEnemy enemy;
        private float xDirection;
        private float yDirection;
        private const float Speed = 10;
        private const float Acceleration = -0.5f;

        public EnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy is WallMaster)
            {
                this.enemy.CurrentState.Attack();
                this.enemy.Physics.MovementVelocity = new Vector2(-2, 0);
            }
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy is OldMan && (projectile is ArrowProjectile || projectile is SilverArrowProjectile || projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile || projectile is SwordBeamProjectile))
            {
                ((OldMan)this.enemy).ShootFireballs();
            }
            if (!(this.enemy is OldMan || this.enemy is Merchant || this.enemy is SpikeCross))
            {
                if (!(projectile is BoomerangProjectile) && !(projectile is MagicBoomerangProjectile))
                {
                    DeterminePushbackValues(projectile.Physics.GetMomentum());
                }
                else
                {
                    this.enemy.Stun(projectile.StunDuration);
                }
            }
            if (!(projectile is SwordBeamExplosion) && !(projectile is BombProjectile) && !(projectile is MagicBoomerangProjectile) && !(projectile is BoomerangProjectile))
            {
                this.enemy.TakeDamage(projectile.Damage);
            }
        }

        public void ReverseVelocity(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top || collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.enemy.Physics.MovementVelocity = new Vector2(this.enemy.Physics.MovementVelocity.X, this.enemy.Physics.MovementVelocity.Y * -1);
            } else
            {
                this.enemy.Physics.MovementVelocity = new Vector2(this.enemy.Physics.MovementVelocity.X * -1, this.enemy.Physics.MovementVelocity.Y);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy is Keese)
            {
                this.ReverseVelocity(collisionSide);
            }
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Bounds = new Rectangle(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.enemy.Physics.Bounds.Y, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionX();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Bounds = new Rectangle(BlockSpriteFactory.Instance.HorizontalOffset, this.enemy.Physics.Bounds.Y, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionX();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.enemy.Physics.Bounds = new Rectangle(this.enemy.Physics.Bounds.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionY();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Bounds = new Rectangle(this.enemy.Physics.Bounds.X, BlockSpriteFactory.Instance.VerticalOffset, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionY();
                }
            }
            else
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Bounds = new Rectangle(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth, this.enemy.Physics.Bounds.Y, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionX();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Bounds = new Rectangle(0, this.enemy.Physics.Bounds.Y, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionX();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.enemy.Physics.Bounds = new Rectangle(this.enemy.Physics.Bounds.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionY();
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Bounds = new Rectangle(this.enemy.Physics.Bounds.X, 0, this.enemy.Physics.Bounds.Width, this.enemy.Physics.Bounds.Height);
                    this.enemy.Physics.StopMotionY();
                }
            }
            this.enemy.Physics.SetLocation();
            
        }

        private void DeterminePushbackValues(Vector2 momentum)
        {
            if (this.enemy.DamageTimer <= 0)
            {
                Vector2 friction = new Vector2(momentum.X / momentum.Length(), momentum.Y / momentum.Length());
                friction *= Acceleration;
                this.enemy.Physics.SetForce(momentum, friction);
            }
        }
    }
}