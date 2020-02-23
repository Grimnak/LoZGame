namespace LoZClone
{
    using Microsoft.Xna.Framework;

    public interface ICollider
    {
        LoZGame Game { get; set; }

        Rectangle Bounds { get; set; }

        Vector2 CurrentLocation { get; set; }

        void OnCollisionResponse(ICollider otherCollider);
    }
}
