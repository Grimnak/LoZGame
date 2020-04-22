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

        public List<IProjectile> Explosions { get { return explosions; } }

        public int SwordExplosion => (int)ExplosionType.SwordExplode;

        public int Explosion => (int)ExplosionType.BombExplode;

        public ExplosionManager()
        {
            explosionList = new Dictionary<int, IProjectile>();
            explosions = new List<IProjectile>();
            explosionId = 0;
            explosionListSize = 0;
            deletable = new List<int>();
        }

        public void AddExplosion(int explosion, Vector2 loc)
        {
            ExplosionType type = (ExplosionType)explosion;

            explosionId++;
            explosionListSize++;
            switch (type)
            {
                case ExplosionType.SwordExplode:
                    Physics tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.NorthEast
                    };
                    explosionList.Add(explosionId, new SwordBeamExplosion(tempPhysics));
                    explosionId++;
                    explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.NorthWest
                    };
                    explosionList.Add(explosionId, new SwordBeamExplosion(tempPhysics));
                    explosionId++;
                    explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.SouthEast
                    };
                    explosionList.Add(explosionId, new SwordBeamExplosion(tempPhysics));
                    explosionId++;
                    explosionListSize++;
                    tempPhysics = new Physics(loc)
                    {
                        CurrentDirection = Physics.Direction.SouthWest
                    };
                    explosionList.Add(explosionId, new SwordBeamExplosion(tempPhysics));
                    break;

                case ExplosionType.BombExplode:
                    explosionList.Add(explosionId, new BombExplosion(loc));
                    break;
            }
        }

        public void RemoveExplosion(int instance)
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
            foreach (KeyValuePair<int, IProjectile> explosion in explosionList)
            {
                if (explosion.Value.IsExpired)
                {
                    deletable.Add(explosion.Key);
                }
            }

            foreach (int index in deletable)
            {
                RemoveExplosion(index);
            }

            explosions.Clear();
            deletable.Clear();

            foreach (KeyValuePair<int, IProjectile> explosion in explosionList)
            {
                explosions.Add(explosion.Value);
                explosion.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IProjectile> explosion in explosionList)
            {
                explosion.Value.Draw();
            }
        }

        public void Clear()
        {
            explosions.Clear();
        }
    }
}