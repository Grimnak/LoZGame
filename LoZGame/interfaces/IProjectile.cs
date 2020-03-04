namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IProjectile : ICollider
    {
        bool IsExpired { get; }

        void Update();

        void Draw();
    }
}