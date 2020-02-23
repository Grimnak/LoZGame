namespace LoZClone
{
    public class EnemyCollisionHandler
    {
        private IEnemy enemy;

        public EnemyCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void OnCollisionResponse(IPlayer player)
        {
        }

        public void OnCollisionResponse(IProjectile projectile)
        {
            this.enemy.TakeDamage();
        }
    }
}
