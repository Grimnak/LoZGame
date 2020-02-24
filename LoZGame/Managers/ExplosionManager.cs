namespace LoZGame
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ExplosionManager
    {
        private enum ExplosionType
        {
            BombExplode,
            SwordExplode,
        }

        private readonly Dictionary<int, IProjectile> explosionList;
        private readonly List<int> deletable;
        private readonly int scale;
        private int explosionId;
        private int explosionListSize;

        public int SwordExplosion => (int)ExplosionType.SwordExplode;

        public int Explosion => (int)ExplosionType.BombExplode;

        public ExplosionManager()
        {
            this.explosionList = new Dictionary<int, IProjectile>();
            this.explosionId = 0;
            this.explosionListSize = 0;
            this.scale = (int)ProjectileSpriteFactory.Instance.Scale;
            this.deletable = new List<int>();
        }

        public void AddExplosion(int explosion, Vector2 loc)
        {
            ExplosionType type = (ExplosionType)explosion;

            this.explosionId++;
            this.explosionListSize++;
            switch (type)
            {
                case ExplosionType.SwordExplode:
                    this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthEast", this.scale, this.explosionId));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthWest", this.scale, this.explosionId));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthEast", this.scale, this.explosionId));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthWest", this.scale, this.explosionId));
                    break;

                case ExplosionType.BombExplode:
                    Random numGen = new Random();
                    int selectBomb = numGen.Next(0, 5);
                    switch (selectBomb)
                    {
                        case 0:
                            this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.BombExplosionOne(loc, this.scale, this.explosionId));
                            break;

                        case 1:
                            this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.BombExplosionTwo(loc, this.scale, this.explosionId));
                            break;

                        case 2:
                            this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.BombExplosionThree(loc, this.scale, this.explosionId));
                            break;

                        case 3:
                            this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.BombExplosionFour(loc, this.scale, this.explosionId));
                            break;

                        case 4:
                            this.explosionList.Add(this.explosionId, ProjectileSpriteFactory.Instance.BombExplosionFive(loc, this.scale, this.explosionId));
                            break;

                        default:
                            break;
                    }

                    break;
            }
        }

        public void RemoveExplosion(int instance)
        {
            this.explosionList.Remove(instance);
            this.explosionListSize--;
            if (this.explosionListSize == 0)
            {
                this.explosionId = 0;
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                if (explosion.Value.IsExpired)
                {
                    this.deletable.Add(explosion.Value.Instance);
                }
            }

            foreach (int index in this.deletable)
            {
                this.RemoveExplosion(index);
            }

            this.deletable.Clear();
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                explosion.Value.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                explosion.Value.Draw(spritebatch);
            }
        }
    }
}