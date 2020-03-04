namespace LoZClone
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class BombExplosion : IProjectile
    {
        private static readonly int MaxLifeTime = 90;
        private static readonly int DissipateOne = 20;
        private static readonly int DissipateTwo = 5;

        private ISprite sprite;
        private readonly int scale = ProjectileSpriteFactory.Instance.Scale;
        private int projectileWidth;
        private int projectileHeight;
        private int lifeTime;
        private bool expired;

        public Physics Physics { get; set; }

        public Rectangle Bounds { get; set; }

        private readonly bool hostile;

        public bool IsHostile => this.hostile;

        public BombExplosion(Vector2 location)
        {
            this.projectileWidth = ProjectileSpriteFactory.Instance.ExplosionWidth * this.scale;
            this.projectileHeight = ProjectileSpriteFactory.Instance.ExplosionHeight * this.scale;
            this.Physics = new Physics(new Vector2(location.X, location.Y), new Vector2(0, 0), new Vector2(0, 0));
            this.lifeTime = MaxLifeTime;
            this.hostile = true;
            this.expired = false;
            this.Bounds = new Rectangle((int)this.Physics.Location.X, (int)this.Physics.Location.Y, projectileWidth, projectileHeight);
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
        }

        public bool IsExpired => this.expired;

        public void OnCollisionResponse(ICollider otherCollider, CollisionDetection.CollisionSide collisionSide)
        {
            // do nothing
        }

        public void Update()
        {
            this.lifeTime--;
            if (this.lifeTime == DissipateOne || this.lifeTime == DissipateTwo)
            {
                this.sprite.Update();
            }

            if (this.lifeTime <= 0)
            {
                this.expired = true;
            }
        }

        public void Draw()
        {
            this.sprite.Draw(this.Physics.Location, Color.White);
            if (this.lifeTime % 5 == 0)
            {
                // draw white screen on top layer
            }
        }
    }
}