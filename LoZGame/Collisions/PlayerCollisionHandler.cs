namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class PlayerCollisionHandler
    {
        private IPlayer player;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy)
        {
            this.player.TakeDamage();
        }

        public void OnCollisionResponse(IProjectile projectile)
        {
            this.player.TakeDamage();
        }
    }
}
