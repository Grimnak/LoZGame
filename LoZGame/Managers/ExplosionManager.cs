namespace LoZClone
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
        private List<IProjectile> explosions;
        private int explosionId;
        private int explosionListSize;

        public List<IProjectile> Explosions { get { return this.explosions; } }
        public int SwordExplosion => (int)ExplosionType.SwordExplode;

        public int Explosion => (int)ExplosionType.BombExplode;

        public ExplosionManager()
        {
            this.explosionList = new Dictionary<int, IProjectile>();
            this.explosionId = 0;
            this.explosionListSize = 0;
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
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(loc, "NorthEast"));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(loc, "NorthWest"));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(loc, "SouthEast"));
                    this.explosionId++;
                    this.explosionListSize++;
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(loc, "SouthWest"));
                    break;

                case ExplosionType.BombExplode:
                    this.explosionList.Add(this.explosionId, new BombExplosion(loc));
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
                    this.deletable.Add(explosion.Key);
                }
            }

            foreach (int index in this.deletable)
            {
                this.RemoveExplosion(index);
            }

            this.explosions.Clear();
            this.deletable.Clear();

            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                this.explosions.Add(explosion.Value);
                explosion.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IProjectile> explosion in this.explosionList)
            {
                explosion.Value.Draw();
            }
        }
    }
}