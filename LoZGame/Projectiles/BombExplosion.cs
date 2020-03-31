namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosion : IProjectile
    {
        private const int FlashDurataion = 10;

        private static readonly int MaxLifeTime = 45;
        private static readonly int DissipateOne = 10;
        private static readonly int DissipateTwo = 5;

        private ISprite sprite;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private int projectileWidth;
        private int projectileHeight;
        private int lifeTime;
        private bool expired;
        private ProjectileCollisionHandler collisionHandler;
        private int damage;
        private Texture2D flashTexture;
        private Rectangle flashDestination;

        public int StunDuration { get { return 0; } set {/*do nothing*/} }

        public bool Returning { get { return false; } set {/*do nothing*/} }

        public int Damage { get { return damage; } set { damage = value; } }

        public Physics Physics { get; set; }

        public EntityData Data { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public BombExplosion(Vector2 location)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ExplosionWidth * this.scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.ExplosionHeight * this.scale;
            this.Data = new EntityData();
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.Physics = new Physics(new Vector2(location.X, location.Y));
            this.lifeTime = MaxLifeTime;
            this.hostile = true;
            this.expired = false;
            this.Physics.Bounds = new Rectangle((int)this.Physics.Location.X - (projectileWidth / 2), (int)this.Physics.Location.Y - (projectileHeight / 2), projectileWidth, projectileHeight);
            this.damage = 8;
            Random numGen = new Random();
            int selectBomb = numGen.Next(0, 5);
            switch (selectBomb)
            {
                case 0:
                    this.sprite = ProjectileSpriteFactory.Instance.BombExplosionOne();
                    break;

                case 1:
                    this.sprite = ProjectileSpriteFactory.Instance.BombExplosionTwo();
                    break;

                case 2:
                    this.sprite = ProjectileSpriteFactory.Instance.BombExplosionThree();
                    break;

                case 3:
                    this.sprite = ProjectileSpriteFactory.Instance.BombExplosionFour();
                    break;

                case 4:
                    this.sprite = ProjectileSpriteFactory.Instance.BombExplosionFive();
                    break;

                default:
                    break;
            }
            // initialize variables for flashing screen
            flashTexture = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            flashTexture.SetData<Color>(new Color[] { LoZGame.Instance.DungeonTint });
            flashDestination = new Rectangle(0, 0, LoZGame.Instance.GraphicsDevice.Viewport.Width, LoZGame.Instance.GraphicsDevice.Viewport.Height);
        }

        public bool IsExpired { get { return this.expired; } set { this.expired = value; } }

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            Console.WriteLine("BombExplosion.cs: " + otherCollider.GetType().ToString());
            if (otherCollider is IEnemy)
            {
                this.collisionHandler.OnCollisionResponse((IEnemy)otherCollider, collisionSide);
            } else if (otherCollider is IDoor)
            {
                Console.WriteLine("Door Bomba boi");
                this.collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public void OnCollisionResponse(int sourceWidth, int sourceHeight, CollisionDetection.CollisionSide collisionSide)
        {
            collisionHandler.OnCollisionResponse(sourceWidth, sourceHeight, collisionSide);
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == DissipateOne || this.lifeTime == DissipateTwo)
            {
                this.sprite.Update();
                this.Physics.Bounds = new Rectangle(this.Physics.Bounds.X, this.Physics.Bounds.Y, 0, 0);
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, LoZGame.Instance.DungeonTint, this.Physics.Depth);
            if (this.lifeTime > (MaxLifeTime - FlashDurataion) && this.lifeTime % 2 == 0)
            {
                LoZGame.Instance.SpriteBatch.Draw(flashTexture, flashDestination, new Rectangle(0, 0, 1, 1), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 1.0f);
            }
        }
    }
}