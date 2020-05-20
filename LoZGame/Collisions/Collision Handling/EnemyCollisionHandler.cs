namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;

    public class EnemyCollisionHandler : CollisionInteractions
    {
        private IEnemy enemy;

        public EnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnCollisionResponse(IPlayer player, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IBlock block, CollisionDetection.CollisionSide collisionSide)
        {
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            if (enemy is OldMan && (projectile is ArrowProjectile || projectile is SilverArrowProjectile || projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile || projectile is SwordBeamProjectile))
            {
                ((OldMan)enemy).ShootFireballs();
            }
            else if (enemy.IsTransparent)
            {
            }
            else if (enemy is Ganon)
            {
                if (enemy.Health.CurrentHealth > 4 && projectile is SwordProjectile)
                {
                    enemy.TakeDamage(projectile.Damage);
                    enemy.CurrentState = new IdleEnemyState(enemy);
                }
                if (enemy.Health.CurrentHealth <= 4 && projectile is SilverArrowProjectile)
                {
                    enemy.TakeDamage(GameData.Instance.EnemyHealthConstants.GanonHealth);
                }
            }
            else if (enemy is Dodongo)
            {
                if (projectile is BombProjectile)
                {
                    projectile.IsExpired = true;
                    enemy.Stun(0);
                }
                else
                {
                    projectile.IsExpired = true;
                }
            }
            else if (enemy is PolsVoice)
            {
                if (projectile is ArrowProjectile || projectile is SilverArrowProjectile)
                {
                    enemy.TakeDamage(GameData.Instance.EnemyHealthConstants.PolsVoiceHealth);
                }
                else
                {
                    enemy.TakeDamage(projectile.Damage);
                }
            }
            else if (enemy is RedGohma || enemy is BlueGohma)
            {
                if (projectile is ArrowProjectile || projectile is SilverArrowProjectile)
                {
                    enemy.TakeDamage(projectile.Damage);
                }
            }
            else if (enemy is RedMoldormHead || enemy is RedMoldormSegment || enemy is BlueMoldormHead || enemy is BlueMoldormSegment)
            {
                if (!(projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile || projectile is BombProjectile))
                {
                    enemy.TakeDamage(projectile.Damage);
                }
            }
            else if (!(projectile is BombProjectile || projectile is BoomerangProjectile || projectile is MagicBoomerangProjectile))
            {
                if (enemy.DamageTimer <= 0)
                {
                    DetermineDirectPushback(projectile.Physics, enemy.Physics);
                }
                enemy.TakeDamage(projectile.Damage);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            if (enemy is Keese || enemy is VireKeese)
            {
                ReverseMovement(enemy.Physics, collisionSide);
            }
            else
            {
                if (!(enemy is WallMaster && enemy.CurrentState is AttackingWallMasterState))
                {
                    SetBounds(enemy.Physics, collisionSide);
                }
            }
        }
    }
}