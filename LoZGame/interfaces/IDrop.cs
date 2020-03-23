namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IDrop
    {
        IProjectile Boomerang { get; set; }

        bool IsGrabbed { get; set; }
    }
}