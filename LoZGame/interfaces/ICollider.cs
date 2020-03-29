namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface ICollider
    {
        Physics Physics { get; set; }

        void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide);

        void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide);
    }
}