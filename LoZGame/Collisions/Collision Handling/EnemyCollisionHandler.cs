namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class EnemyCollisionHandler : CollisionInteractions
    {
        private IEnemy enemy;

        public EnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy is WallMaster && !(player.State is PickupItemState))
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
            else if (this.enemy is Dodongo)
            {
                if (projectile is BombProjectile)
                {
                    projectile.IsExpired = true;
                    this.enemy.CurrentState.Stun(0);
                }
                else
                {
                    projectile.IsExpired = true;
                }
            }
            else if (!(projectile is BombProjectile))
            {
                if (enemy.DamageTimer <= 0)
                {
                    DetermineDirectPushback(projectile.Physics, enemy.Physics);
                }
                this.enemy.TakeDamage(projectile.Damage);
            }
        }

        public void ReverseVelocity(CollisionDetection.CollisionSide collisionSide)
        {
            if (collisionSide == CollisionDetection.CollisionSide.Top || collisionSide == CollisionDetection.CollisionSide.Bottom)
            {
                this.enemy.Physics.MovementVelocity = new Vector2(this.enemy.Physics.MovementVelocity.X, this.enemy.Physics.MovementVelocity.Y * -1);
            } 
            else
            {
                this.enemy.Physics.MovementVelocity = new Vector2(this.enemy.Physics.MovementVelocity.X * -1, this.enemy.Physics.MovementVelocity.Y);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (this.enemy is Keese)
            {
                this.ReverseMovement(this.enemy.Physics, collisionSide);
            }
            else
            {
                if (!(this.enemy is WallMaster && this.enemy.CurrentState is AttackingWallMasterState))
                {
                    this.SetBounds(this.enemy.Physics, collisionSide);
                }
            }
        }
    }
}