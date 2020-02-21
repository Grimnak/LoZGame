namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public class LinkCollisionHandler
    {
        private IPlayer player;
        private IPlayerState state;

        public LinkCollisionHandler(IPlayer player, IPlayerState state)
        {
            this.player = player;
            this.state = state;
        }

        public void OnCollisionResponse(IEnemy enemy)
        {
            // check to see if player is dead in CollisionDetection.cs, not here
            this.player.TakeDamage();
        }

        public void OnCollisionResponse(IProjectile projectile)
        {
            this.player.TakeDamage();
        }
    }
}
