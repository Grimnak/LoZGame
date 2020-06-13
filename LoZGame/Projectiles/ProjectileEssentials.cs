namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class ProjectileEssentials : IProjectile
    {
        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        public Physics Source { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Offset { get; set; }

        public float Speed { get; set; }

        public float Acceleration { get; set; }

        public int Damage { get; set; }

        public int StunDuration { get; set; }

        public bool Returning { get; set; }

        public bool IsExpired { get; set; }

        public ISprite Sprite { get; set; }

        public ProjectileCollisionHandler CollisionHandler { get; set; }

        private IProjectile parent;

        public void SetUp(IProjectile parent)
        {
            this.parent = parent;
            Returning = false;
            IsExpired = false;
            StunDuration = 0;
            Speed = 0;
            Acceleration = 0;
            Damage = 0;
            Width = 0;
            Height = 0;
            Offset = 0;
            Source = new Physics(Vector2.Zero);
            Physics = new Physics(Vector2.Zero);
            Data = new EntityData();
            Sprite = ProjectileSpriteFactory.Instance.Bomb();
            CollisionHandler = new ProjectileCollisionHandler(this.parent);
        }

        /// <summary>
        /// Determines the direction the projectile moves from the user based on the user's current facing direction.
        /// </summary>
        public void InitializeDirection()
        {
            Physics = new Physics(Source.Bounds.Center.ToVector2());
            Vector2 unitDirection;
            switch (Source.CurrentDirection)
            {
                case Physics.Direction.North:
                    unitDirection = new Vector2(0, -1);
                    Physics.BoundsOffset = new Vector2(Width / 2, Height / 2);
                    Physics.CurrentDirection = Physics.Direction.North;
                    break;
                case Physics.Direction.South:
                    unitDirection = new Vector2(0, 1);
                    Data.SpriteEffect = SpriteEffects.FlipVertically;
                    Physics.BoundsOffset = new Vector2(Width / 2, Height / 2);
                    Physics.CurrentDirection = Physics.Direction.South;
                    break;
                case Physics.Direction.East:
                    unitDirection = new Vector2(1, 0);
                    Data.Rotation = MathHelper.PiOver2;
                    Data.SpriteEffect = SpriteEffects.None;
                    Physics.BoundsOffset = new Vector2(Height / 2, Width / 2);
                    Physics.CurrentDirection = Physics.Direction.East;
                    break;
                case Physics.Direction.West:
                    unitDirection = new Vector2(-1, 0);
                    Data.Rotation = MathHelper.PiOver2;
                    Data.SpriteEffect = SpriteEffects.FlipVertically;
                    Physics.BoundsOffset = new Vector2(Height / 2, Width / 2);
                    Physics.CurrentDirection = Physics.Direction.West;
                    break;
                default:
                    unitDirection = Vector2.Zero;
                    break;
            }
            Physics.Location += unitDirection * Offset;
            Physics.MovementVelocity = unitDirection * Speed;
            Physics.MovementAcceleration = unitDirection * Acceleration;
            Physics.Bounds = new Rectangle((Physics.Location - Physics.BoundsOffset).ToPoint(), (Physics.BoundsOffset * 2).ToPoint());
            Physics.BoundsOffset *= 2;
            Physics.SetLocation();
        }

        /// <summary>
        /// temporary method just to correct swordbeam and arrow until i caan find a better solution
        /// TODO: Find a way to remove this method.
        /// </summary>
        public void CorrectProjectile()
        {
            if (parent is SwordProjectile)
            {
                Physics.BoundsOffset = new Vector2((Physics.BoundsOffset.X * 5) / 8, Physics.BoundsOffset.Y + 4);
            }
            else 
            {
                Physics.BoundsOffset = new Vector2((Physics.BoundsOffset.X * 5) / 8, Physics.BoundsOffset.Y * 2);
            }
            Physics.SetLocation();
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                CollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IEnemy)
            {
                CollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            CollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual void Update()
        {
            Physics.Move();
            Sprite.Update();
        }

        public virtual void Draw()
        {
            Sprite.Draw(Physics.Location, Color.White, Data.Rotation, Data.SpriteEffect, Physics.Depth);
        }
    }
}
