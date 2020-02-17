using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoZClone
{

    public class ExplosionManager
    {
        private enum ExplosionType { BombExplode, SwordExplode };
        private Dictionary<int, IProjectile> explosionList;
        private List<int> deletable;
        private int scale;
        private int explosionId;
        private int explosionListSize;

        public int SwordExplosion { get { return (int)ExplosionType.SwordExplode; } }
        public int Explosion { get { return (int)ExplosionType.BombExplode; } }

        public ExplosionManager()
        {
            this.explosionList = new Dictionary<int, IProjectile>();
            this.explosionId = 0;
            this.explosionListSize = 0;
            this.scale = (int)ProjectileSpriteFactory.Instance.Scale;
            deletable = new List<int>();
        }

        public void addExplosion(int explosion, Vector2 loc)
        {
            ExplosionType type = (ExplosionType)explosion;

            explosionId++;
            explosionListSize++;
            switch (type)
            {
                case (ExplosionType.SwordExplode):
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthEast", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "NorthWest", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthEast", scale, explosionId));
                    explosionId++;
                    explosionListSize++;
                    this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.SwordExplosion(loc, "SouthWest", scale, explosionId));
                    break;
                case (ExplosionType.BombExplode):
                    Random numGen = new Random();
                    int selectBomb = numGen.Next(0, 5);
                    switch (selectBomb)
                    {
                        case (0):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionOne(loc, scale, explosionId));
                            break;
                        case (1):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionTwo(loc, scale, explosionId));
                            break;
                        case (2):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionThree(loc, scale, explosionId));
                            break;
                        case (3):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionFour(loc, scale, explosionId));
                            break;
                        case (4):
                            this.explosionList.Add(explosionId, ProjectileSpriteFactory.Instance.BombExplosionFive(loc, scale, explosionId));
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        public void removeExplosion(int instance)
        {
            explosionList.Remove(instance);
            explosionListSize--;
            if (explosionListSize == 0)
            {
                explosionId = 0;
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                if (explosion.Value.IsExpired)
                {
                    deletable.Add(explosion.Value.Instance);
                }
            }
            foreach (int index in deletable)
            {
                this.removeExplosion(index);
            }
            deletable.Clear();
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
