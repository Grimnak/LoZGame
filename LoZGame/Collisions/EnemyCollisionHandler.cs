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
                this.enemy.Physics.Velocity = new Vector2(-2, 0);
            }
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
            if (block is BlockTile || block is MovableTile)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Location = new Vector2(block.Physics.Location.X - EnemySpriteFactory.GetEnemyWidth(enemy), this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Location = new Vector2(block.Physics.Location.X + BlockSpriteFactory.Instance.TileWidth, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, block.Physics.Location.Y + BlockSpriteFactory.Instance.TileHeight);
                }
                else
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, block.Physics.Location.Y - EnemySpriteFactory.GetEnemyHeight(enemy));
                }
            }
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
                    DeterminePushbackValues(collisionSide);
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

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (LoZGame.Instance.Dungeon.CurrentRoomX != 1 || LoZGame.Instance.Dungeon.CurrentRoomY != 1)
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth - BlockSpriteFactory.Instance.HorizontalOffset + 10, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Location = new Vector2(BlockSpriteFactory.Instance.HorizontalOffset, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight - BlockSpriteFactory.Instance.VerticalOffset);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, BlockSpriteFactory.Instance.VerticalOffset);
                }
            }
            else
            {
                if (collisionSide == CollisionDetection.CollisionSide.Right)
                {
                    this.enemy.Physics.Location = new Vector2(LoZGame.Instance.GraphicsDevice.Viewport.Width - sourceWidth, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Left)
                {
                    this.enemy.Physics.Location = new Vector2(0, this.enemy.Physics.Location.Y);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, LoZGame.Instance.GraphicsDevice.Viewport.Height - sourceHeight);
                }
                else if (collisionSide == CollisionDetection.CollisionSide.Top)
                {
                    this.enemy.Physics.Location = new Vector2(this.enemy.Physics.Location.X, 0);
                }
            }
        }

        private void DeterminePushbackValues(CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy.DamageTimer <= 0)
            {
                DeterminePushbackDirection(collisionSide);
                this.enemy.Physics.Velocity = new Vector2(xDirection * Speed, yDirection * Speed);
                this.enemy.Physics.Acceleration = new Vector2(xDirection * Acceleration, yDirection * Acceleration);
            }
        }

        private void DeterminePushbackDirection(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top)
            {
                xDirection = 0;
                yDirection = 1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                xDirection = 0;
                yDirection = -1;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Left)
            {
                xDirection = 1;
                yDirection = 0;
            }
            else if (collisionSide == CollisionDetection.CollisionSide.Right)
            {
                xDirection = -1;
                yDirection = 0;
            }
        }
    }
}