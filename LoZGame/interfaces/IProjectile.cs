namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IProjectile : ICollider
    {
        bool IsExpired { get; }

        bool IsHostile { get; }

        void Update();

        void Draw();
    }
}