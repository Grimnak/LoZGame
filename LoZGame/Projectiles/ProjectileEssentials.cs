namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class ProjectileEssentials
    {
        public void InitializeDirection(IProjectile projectile, Rectangle origin, Vector2 dimensions, string direction)
        {
            int projectileWidth = (int)dimensions.X;
            int projectileHeight = (int)dimensions.Y;
            if (direction.Equals("Up"))
            {
                projectile.Physics = new Physics(new Vector2(0, -1));
                projectile.Physics.MovementVelocity = new Vector2(0, -1);
                projectile.Data.Rotation = 0;
                projectile.Data.SpriteEffect = SpriteEffects.None;
                projectile.Physics.BoundsOffset = new Vector2(projectileWidth / 2, projectileHeight / 2);
            }
            else if (direction.Equals("Left"))
            {
                projectile.Physics = new Physics(new Vector2(-1, 0));
                projectile.Physics.MovementVelocity = new Vector2(-1, 0);
                projectile.Data.Rotation = MathHelper.PiOver2;
                projectile.Data.SpriteEffect = SpriteEffects.FlipVertically;
                projectile.Physics.BoundsOffset = new Vector2(projectileHeight / 2, projectileWidth / 2);
            }
            else if (direction.Equals("Right"))
            {
                projectile.Physics = new Physics(new Vector2(1, 0));
                projectile.Physics.MovementVelocity = new Vector2(1, 0);
                projectile.Data.Rotation = MathHelper.PiOver2;
                projectile.Data.SpriteEffect = SpriteEffects.None;
                projectile.Physics.BoundsOffset = new Vector2(projectileHeight / 2, projectileWidth / 2);
            }
            else
            {
                projectile.Physics = new Physics(new Vector2(0, 1));
                projectile.Physics.MovementVelocity = new Vector2(0, 1);
                projectile.Data.Rotation = 0;
                projectile.Data.SpriteEffect = SpriteEffects.FlipVertically;
                projectile.Physics.BoundsOffset = new Vector2(projectileWidth / 2, projectileHeight / 2);
            }
        }
    }
}
