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
            SetUp(this);
            SoundFactory.Instance.PlayBombExplosion();
            Width = ProjectileSpriteFactory.Instance.ExplosionWidth;
            Height = ProjectileSpriteFactory.Instance.ExplosionHeight;
            Physics = new Physics(new Vector2(location.X, location.Y));
            collisionHandler = new ProjectileCollisionHandler(this);
            lifeTime = MaxLifeTime + 1;
            IsExpired = false;
            Physics.BoundsOffset = new Vector2(Width, Height) / 2;
            Physics.Bounds = new Rectangle((Physics.Location - Physics.BoundsOffset).ToPoint(), new Point(Width, Height));
            Physics.BoundsOffset *= 2;
            Physics.SetLocation();
            Damage = GameData.Instance.ProjectileDamageConstants.BombDamage;
            Physics.Mass = GameData.Instance.ProjectileMassConstants.ExplosionMass;
            Random numGen = new Random();
            int selectBomb = numGen.Next(0, 5);
            switch (selectBomb)
            {
                case 0:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionOne();
                    break;

                case 1:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionTwo();
                    break;

                case 2:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionThree();
                    break;

                case 3:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionFour();
                    break;

                case 4:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionFive();
                    break;

                default:
                    Sprite = ProjectileSpriteFactory.Instance.BombExplosionFive();
                    break;
            }

            // initialize variables for flashing screen
            flashTexture = new Texture2D(LoZGame.Instance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            flashTexture.SetData<Color>(new Color[] { Color.White });
            flashDestination = new Rectangle(0, 0, LoZGame.Instance.ScreenWidth, LoZGame.Instance.GraphicsDevice.Viewport.Height);
        }

        public override void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            base.OnCollisionResponse(otherCollider, collisionSide);
            if (otherCollider is IDoor)
            {
                collisionHandler.OnCollisionResponse((IDoor)otherCollider, collisionSide);
            }
        }

        public override void Update()
        {
            lifeTime--;
            if (lifeTime < MaxLifeTime)
            {
                Physics.Bounds = new Rectangle(Physics.Bounds.X, Physics.Bounds.Y, 0, 0);
            }
            if (lifeTime == DissipateOne || lifeTime == DissipateTwo)
            {
                Sprite.NextFrame();
            }

            if (lifeTime <= 0)
            {
                IsExpired = true;
            }
        }

        public override void Draw()
        {
            base.Draw();
            if (lifeTime > (MaxLifeTime - FlashDurataion) && lifeTime % 2 == 0)
            {
                LoZGame.Instance.SpriteBatch.Draw(flashTexture, flashDestination, new Rectangle(0, 0, 1, 1), Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 1.0f);
            }
        }
    }
}