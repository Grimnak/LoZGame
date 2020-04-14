namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IProjectile : ICollider
    {
        bool IsExpired { get; set; }

        int Damage { get; set; }

        int StunDuration { get; }

        bool Returning { get; set; }

        EntityData Data { get; set; }

        void Update();

        void Draw();
    }
}