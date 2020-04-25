namespace LoZClone
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public partial class EnemyProjectileManager : IManager
    {
        private const int Scale = 2;
        private readonly Dictionary<int, IProjectile> projectileList;
        private readonly List<int> deletable;
        private List<IProjectile> projectiles;
        private int projectileId;
        private int listSize;

        public List<IProjectile> Projectiles { get { return projectiles; } }

        public EnemyProjectileManager()
        {
            projectileList = new Dictionary<int, IProjectile>();
            projectiles = new List<IProjectile>();
            deletable = new List<int>();
            projectileId = 0;
            listSize = 0;
        }

        public void Add(IProjectile projectile)
        {
            projectileId++;
            listSize++;
            projectileList.Add(projectileId, projectile);
    }

        public void Remove(int instance)
        {
            projectileList.Remove(instance);
            listSize--;
            if (listSize == 0)
            {
                projectileId = 0;
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<int, IProjectile> item in projectileList)
            {
                if (item.Value.IsExpired)
                {
                    deletable.Add(item.Key);
                }
            }
            foreach (int index in deletable)
            {
                Remove(index);
            }

            projectiles.Clear();
            deletable.Clear();

            foreach (KeyValuePair<int, IProjectile> item in projectileList)
            {
                projectiles.Add(item.Value);
                item.Value.Update();
            }
        }

        public void Draw()
        {
            foreach (KeyValuePair<int, IProjectile> projectile in projectileList)
            {
                projectile.Value.Draw();
            }

        }

        public void Clear()
        {
            projectileList.Clear();
        }
    }
}