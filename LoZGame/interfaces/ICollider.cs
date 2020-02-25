namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface ICollider
    {
        Rectangle Bounds { get; set; }

        Vector2 CurrentLocation { get; set; }

        void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide);
    }
}
