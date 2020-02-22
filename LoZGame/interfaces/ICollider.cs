namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface ICollider
    {
        Rectangle Bounds { get; set; }

        void OnCollisionResponse(ICollider otherCollider);
    }
}
