namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosion : ProjectileEssentials, IProjectile
    {
        private const int FlashDurataion = 10;

        private static readonly int MaxLifeTime = 45;
        private static readonly int DissipateOne = 10;
        private static readonly int DissipateTwo = 5;

        private ISprite sprite;
        private int projectileWidth;
        private int projectileHeight;
        private int lifeTime;
        private ProjectileCollisionHandler collisionHandler;
        private Texture2D flashTexture;
        private Rectangle flashDestination;

        public BombExplosion(Vector2 location)
        {
            this.SetUp(this);
            SoundFactory.Instance.PlayBombExplosion();
            this.Width = ProjectileSpriteFactory.Instance.ExplosionWidth;
            this.Heigth = ProjectileSpriteFactory.Instance.ExplosionHeight;
            this.Physics = new Physics(new Vector2(location.X, location.Y));
            this.collisionHandler = new ProjectileCollisionHandler(this);
            this.lifeTime = MaxLifeTime + 1;
            this.IsExpired = false;
            this.Physics.BoundsOffset = new Vector2(this.Width, this.Heigth) / 2;
            this.Physics.Bounds = new Rectangle((this.Physics.Location - this.Physics.BoundsOffset).ToPoint(), new Point(this.Width, this.Heigth));
            this.Physics.BoundsOffset *= 2;
            this.Physics.SetLocation();
            this.Damage = GameData.Instance.ProjectileDamageData.BombDamage;
            this.Physics.Mass = 5;
            Random numGen = new Random();
            int selectBomb = numGen.Next(0, 5);
            switch (selectBomb)
            {
                case 0:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionOne();
                    break;

                case 1:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionTwo();
                    break;

                case 2:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionThree();
                    break;

                case 3:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionFour();
                    break;

                case 4:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionFive();
                    break;

                default:
                    this.Sprite = ProjectileSpriteFactory.Instance.BombExplosionFive();
                    break;
            }

            // initialize variables for flashing screen
            flashTexture = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            flashTexture.SetData<Color>(new Color[] { LoZGame.Instance.DungeonTint });
            flashDestination = new Rectangle(0, 0, LoZGame.Instance.GraphicsDevice.Viewport.Width, LoZGame.Instance.GraphicsDevice.Viewport.Height);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (otherCollider is IDoor)
            {
                this.collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public override void Update()
        {
            this.lifeTime--;
            if (this.lifeTime < MaxLifeTime)
            {
                this.Physics.Bounds = new Rectangle(this.Physics.Bounds.X, this.Physics.Bounds.Y, 0, 0);
            }
            if (this.lifeTime == DissipateOne || this.lifeTime == DissipateTwo)
            {
                this.Sprite.NextFrame();
            }

            if (this.lifeTime <= 0)
            {
                this.IsExpired = true;
            }
        }

        public override void Draw()
        {
            base.Draw();
            if (this.lifeTime > (MaxLifeTime - FlashDurataion) && this.lifeTime % 2 == 0)
            {
                LoZGame.Instance.SpriteBatch.Draw(flashTexture, flashDestination, new Rectangle(0, 0, 1, 1), LoZGame.Instance.DungeonTint, 0.0f, new Vector2(0, 0), SpriteEffects.None, 1.0f);
            }
        }
    }
}