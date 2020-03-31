namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ExplosionManager : IManager
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
            this.explosions = new List<IProjectile>();
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
                    Physics tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.NorthEast
                    };
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(tempPhysics));
                    this.explosionId++;
                    this.explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.NorthWest
                    };
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(tempPhysics));
                    this.explosionId++;
                    this.explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.SouthEast
                    };
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(tempPhysics));
                    this.explosionId++;
                    this.explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.SouthWest
                    };
                    this.explosionList.Add(this.explosionId, new SwordBeamExplosion(tempPhysics));
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

        public void Clear()
        {
            this.explosions.Clear();
        }
    }
}