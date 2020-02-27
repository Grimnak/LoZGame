namespace LoZClone
{
    using System;

    public class PlayerCollisionHandler
    {
        private IPlayer player;

        public PlayerCollisionHandler(IPlayer player)
        {
            this.player = player;
        }

        public void OnCollisionResponse(IEnemy enemy, CollisionDetection.CollisionSide collisionSide)
        {
            Console.WriteLine("Player colliding with Enemy:  Collision Side = " + collisionSide);
            this.player.TakeDamage();
        }

        public void OnCollisionResponse(IProjectile projectile, CollisionDetection.CollisionSide collisionSide)
        {
            this.player.TakeDamage();
        }
    }
}