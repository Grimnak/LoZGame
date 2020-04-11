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

        public int Heigth { get; set; }

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
            this.Returning = false;
            this.IsExpired = false;
            this.StunDuration = 0;
            this.Speed = 0;
            this.Acceleration = 0;
            this.Damage = 0;
            this.Width = 0;
            this.Heigth = 0;
            this.Offset = 0;
            this.Source = new Physics(Vector2.Zero);
            this.Physics = new Physics(Vector2.Zero);
            this.Data = new EntityData();
            this.Sprite = ProjectileSpriteFactory.Instance.Bomb();
            this.CollisionHandler = new ProjectileCollisionHandler(this.parent);
        }

        public void InitializeDirection()
        {
            this.Physics = new Physics(Source.Bounds.Center.ToVector2());
            Vector2 unitDirection;
            switch (this.Source.CurrentDirection)
            {
                case Physics.Direction.North:
                    unitDirection = new Vector2(0, -1);
                    this.Physics.BoundsOffset = new Vector2(Width / 2, Heigth / 2);
                    this.Physics.CurrentDirection = Physics.Direction.North;
                    break;
                case Physics.Direction.South:
                    unitDirection = new Vector2(0, 1);
                    this.Data.SpriteEffect = SpriteEffects.FlipVertically;
                    this.Physics.BoundsOffset = new Vector2(Width / 2, Heigth / 2);
                    this.Physics.CurrentDirection = Physics.Direction.South;
                    break;
                case Physics.Direction.East:
                    unitDirection = new Vector2(1, 0);
                    this.Data.Rotation = MathHelper.PiOver2;
                    this.Data.SpriteEffect = SpriteEffects.None;
                    this.Physics.BoundsOffset = new Vector2(Heigth / 2, Width / 2);
                    this.Physics.CurrentDirection = Physics.Direction.East;
                    break;
                case Physics.Direction.West:
                    unitDirection = new Vector2(-1, 0);
                    this.Data.Rotation = MathHelper.PiOver2;
                    this.Data.SpriteEffect = SpriteEffects.FlipVertically;
                    this.Physics.BoundsOffset = new Vector2(Heigth / 2, Width / 2);
                    this.Physics.CurrentDirection = Physics.Direction.West;
                    break;
                default:
                    unitDirection = Vector2.Zero;
                    break;
            }
            this.Physics.Location += unitDirection * Offset;
            this.Physics.MovementVelocity = unitDirection * Speed;
            this.Physics.MovementAcceleration = unitDirection * Acceleration;
            this.Physics.Bounds = new Rectangle((this.Physics.Location - this.Physics.BoundsOffset).ToPoint(), (this.Physics.BoundsOffset * 2).ToPoint());
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
        }

        /// <summary>
        /// temporary method just to correct swordbeam and arrow until i caan find a better solution
        /// TODO: Find a way to remove this method.
        /// </summary>
        public void CorrectProjectile()
        {
            if (this.parent is WoodenSwordProjectile)
            {
                this.Physics.BoundsOffset = new Vector2((this.Physics.BoundsOffset.X * 5) / 8, this.Physics.BoundsOffset.Y + 4);
            }
            else 
            {
                this.Physics.BoundsOffset = new Vector2((this.Physics.BoundsOffset.X * 5) / 8, this.Physics.BoundsOffset.Y * 2);
            }
            this.Physics.SetLocation();
        }

        public virtual void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            if (otherCollider is IPlayer)
            {
                this.CollisionHandler.OnCollisionResponse((IPlayer)otherCollider, collisionSide);
            }
            else if (otherCollider is IEnemy)
            {
                this.CollisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            }
        }

        public virtual void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            this.CollisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public virtual void Update()
        {
            this.Physics.Move();
            this.Sprite.Update();
        }

        public virtual void Draw()
        {
            this.Sprite.Draw(this.Physics.Location, LoZGame.Instance.DefaultTint, this.Data.Rotation, this.Data.SpriteEffect, this.Physics.Depth);
        }
    }
}
