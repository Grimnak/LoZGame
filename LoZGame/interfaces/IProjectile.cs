namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IProjectile /*: ICollider*/
    {
        bool IsExpired { get; }

        int Instance { get; }

        bool IsHostile { get; }

        Vector2 Location { get; }

        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}